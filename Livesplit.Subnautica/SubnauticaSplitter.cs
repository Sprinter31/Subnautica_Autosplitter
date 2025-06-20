using LiveSplit.ComponentUtil;
using LiveSplit.Model;
using LiveSplit.UI.Components.AutoSplit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Livesplit.Subnautica.SubnauticaSplitSettings;

namespace Livesplit.Subnautica
{
    public class SubnauticaSplitter : IAutoSplitter
    {
        private Process game;
        private System.Threading.Timer debugWriteTimer;
        private GameVersion gameVersion;
        private readonly Dictionary<SplitName, Func<bool>> splitConditions;

        #region MemoryWatchers
        private MemoryWatcher<bool>  isIntroCinematicActive = new MemoryWatcher<bool>(IntPtr.Zero);
        private MemoryWatcher<bool>  isLoadingScreen        = new MemoryWatcher<bool>(IntPtr.Zero);
        private MemoryWatcher<bool>  isAnimationPlaying     = new MemoryWatcher<bool>(IntPtr.Zero);
        private MemoryWatcher<bool>  isPortalLoading        = new MemoryWatcher<bool>(IntPtr.Zero);
        private MemoryWatcher<bool>  isEggsHatching         = new MemoryWatcher<bool>(IntPtr.Zero);
        private MemoryWatcher<bool>  isNotInWater           = new MemoryWatcher<bool>(IntPtr.Zero);
        private MemoryWatcher<bool>  isDying                = new MemoryWatcher<bool>(IntPtr.Zero);
        private MemoryWatcher<int>   isFabiOpen             = new MemoryWatcher<int>(IntPtr.Zero); // 2 means that the esc menu is open
        private MemoryWatcher<int>   isPDAOpen              = new MemoryWatcher<int>(IntPtr.Zero); // true = 1051931443, false = 1056964608
        private MemoryWatcher<int>   isRocketLaunching      = new MemoryWatcher<int>(IntPtr.Zero);
        private MemoryWatcher<int>   knownTechSize          = new MemoryWatcher<int>(IntPtr.Zero);
        private MemoryWatcher<int>   inventorySize          = new MemoryWatcher<int>(IntPtr.Zero);
        private MemoryWatcher<int>   oxygen                 = new MemoryWatcher<int>(IntPtr.Zero);
        private MemoryWatcher<float> timeCured              = new MemoryWatcher<float>(IntPtr.Zero);
        private MemoryWatcher<float> walkDir                = new MemoryWatcher<float>(IntPtr.Zero);
        private MemoryWatcher<float> strafeDir              = new MemoryWatcher<float>(IntPtr.Zero);
        private MemoryWatcher<float> posX                   = new MemoryWatcher<float>(IntPtr.Zero);
        private MemoryWatcher<float> posY                   = new MemoryWatcher<float>(IntPtr.Zero);
        private MemoryWatcher<float> posZ                   = new MemoryWatcher<float>(IntPtr.Zero);

        // pointer to the beginning of the string
        private MemoryWatcher<IntPtr> playerBiomePtr        = new MemoryWatcher<IntPtr>(IntPtr.Zero);
        private string biomeString;
        private string biomeStringOld;

        private MemoryWatcher<IntPtr> inventoryDictionaryPtr = new MemoryWatcher<IntPtr>(IntPtr.Zero);
        private Dictionary<TechType, int> playerInventory;
        private Dictionary<TechType, int> playerInventoryOld;

        private MemoryWatcher<IntPtr> knownTechPtr          = new MemoryWatcher<IntPtr>(IntPtr.Zero);
        private List<TechType> knownTech;
        private List<TechType> knownTechOld;
        #endregion

        private bool pointersInitialized;

        private SubnauticaSettings settings;
        internal SubnauticaSplitter(SubnauticaSettings _settings)
        {
            this.settings = _settings;
            splitConditions = new Dictionary<SplitName, Func<bool>>
            {
                { SplitName.RocketSplit, () => isRocketLaunching.Current != isRocketLaunching.Old && (isRocketLaunching.Current == 1 || isRocketLaunching.Current == 256) },
                //{ SplitName.PCFTabletSplit, () => playerIsCuredWatcher.Current },
                //{ SplitName.PortalSplit, () => gunIsDeactivatedWatcher.Current },
        
            };
        }       

        public void Update()
        {
            Debug.WriteLineIf(game == null, $"[Subnautica Autosplitter] game null");
            Debug.WriteLineIf(!pointersInitialized, $"[Subnautica Autosplitter] pointers not intialized");
            
            if (game != null && pointersInitialized)
            {
                isIntroCinematicActive.Update(game);
                isRocketLaunching.Update(game);
            }
        }

        #region Memory & Such
        private void GetGameProcess()
        {
            if (game == null)
            {
                WriteDebug("Getting game");
                game = Process.GetProcessesByName("Subnautica").FirstOrDefault(p => !p.HasExited);
                if (game != null)
                {
                    WriteDebug("Game found");
                    GetGameVersion();
                    InitPointers();
                    game.Exited += (object o, EventArgs e) => { game = null; };
                }
            }
        }
           
        private void GetGameVersion()
        {            
            ProcessModule firstModule = game.Modules.Cast<ProcessModule>().FirstOrDefault();
            int moduleLen = firstModule.ModuleMemorySize;
            switch (moduleLen)
            {
                case 23801856:
                    gameVersion = GameVersion.Sept2018;
                    WriteDebug("Game version Sept 2018");
                    break;

                case 675840:
                    gameVersion = GameVersion.Mar2023;
                    WriteDebug("Game version March 2023");
                    break;

                default:
                    gameVersion = GameVersion.Mar2023;
                    MessageBox.Show($"Module length {moduleLen} does not match a version, defaulting to most recent (March 2023)", 
                                    "Subnautica Autosplitter",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    break;
            }
        }

        
        private void InitPointers()
        {
            DeepPointer introPtr;
            DeepPointer rocketPtr;
            
            switch (gameVersion)
            {
                case GameVersion.Sept2018:
                    introPtr =  new DeepPointer("mono.dll", 0x262a68, 0x40, 0xd88, 0x218, 0x10, 0x28, 0x18, 0x1e8, 0x28, 0x86);
                    rocketPtr = new DeepPointer("mono.dll", 0x27EAD8, 0x40, 0x70, 0x50, 0x90, 0x30, 0x8, 0x80);
                    break;                

                default/* GameVersion.Mar2023*/:
                    introPtr =  new DeepPointer("mono-2.0-bdwgc.dll", 0x499c78, 0x9d0, 0x130, 0x48, 0x250, 0x220, 0x28, 0x87);
                    rocketPtr = new DeepPointer("UnityPlayer.dll",    0x17FC238, 0x10, 0x3C);
                    break;
            }
            isIntroCinematicActive = new MemoryWatcher<bool>(introPtr);
            isRocketLaunching = new MemoryWatcher<int>(rocketPtr);
            WriteDebug("Pointers initialized");

            pointersInitialized = true;
        }

        #region Mem utils

        private string IntPtrToString(IntPtr ptr, int maxLen)
        {
            StringBuilder strBuilder = new StringBuilder();
            if (game != null)
            {
                byte[] bytes;
                //WriteDebug($"Converting {ptr.ToString("X")} to string");
                if (!game.ReadBytes(ptr, maxLen * 2, out bytes))
                {
                    return strBuilder.ToString();
                }

                for (int i = 0; i < maxLen; i += 2)
                {
                    if (bytes[i] != 0 || bytes[i + 1] != 0)
                    {
                        char ch = BitConverter.ToChar(bytes, i);
                        //WriteDebug($"{bytes[i]}{bytes[i+1]} is {ch}");
                        strBuilder.Append(ch);
                    }
                    else
                    {
                        //WriteDebug("String ended");
                        break;
                    }
                }
            }

            return strBuilder.ToString();
        }

        #endregion

        #endregion

        #region Logic
        public bool ShouldStart(LiveSplitState state)
        {
            if (game == null)
            {
                GetGameProcess();
                return false;
            }
            else if (settings.introStart)
            {
                if (isIntroCinematicActive.Current == false && isIntroCinematicActive.Old == true)
                    return true;
            }
            return false;
        }

        public bool ShouldSplit(LiveSplitState state)
        {
            if (game == null) return false;

            foreach (var split in settings.Splits)
            {
                if (splitConditions.TryGetValue(split, out var condition) && condition())
                {
                    WriteDebug($"{split} triggered");
                    return true;
                }
            }

            return false;
        }

        public bool ShouldReset(LiveSplitState state) { return false; }
        public void OnReset(TimerPhase t) { }
        public bool IsGameTimePaused(LiveSplitState state) { return false; }
        public TimeSpan? GetGameTime(LiveSplitState state) { return null; }

        #endregion Logic

        private void WriteDebug(string message)
        {
            #if DEBUG
            Debug.WriteLine($"[Subnautica Autosplitter] {message}");
            #endif
        }

        #region World/Player Checks

        bool isWithinBounds(float[] bounds)
        {
            int x = 0;
            int y = 0;
            int z = 0;
            if (x >= Math.Min(bounds[0], bounds[1]) && x <= Math.Max(bounds[0], bounds[1]) &&
                y >= Math.Min(bounds[2], bounds[3]) && y <= Math.Max(bounds[2], bounds[3]) &&
                z >= Math.Min(bounds[4], bounds[5]) && z <= Math.Max(bounds[4], bounds[5]))
            {
                return true;
            }
            else return false;
        }

        /*private void GetInventory(object o)
        {
            Dictionary<TechType, int> inv = new Dictionary<TechType, int>();
            if (game != null)
            {
                inventoryDictionaryPtr.Update(game);
                IntPtr startAddr = inventoryDictionaryPtr.Current;

#if EXTRADBG
                DateTime start = DateTime.Now;
                WriteDebug("Getting inv from " + startAddr.ToString("X"));
#endif

                int size = game.ReadValue<int>(startAddr + 0x18);
                //for Dec2021 & Mar2023 patches, the items start at 0x30 after the ptr
                //                               and each take up 0x18.
                //for Sept2018 patch, the items start at 0x20 after the ptr
                // 					 and each take up 0x8.
                int startOffset = gameVersion == GameVersion.Sept2018 ? 0x20 : 0x30;
                int itemOffset = gameVersion == GameVersion.Sept2018 ? 0x8 : 0x18;

                for (int i = 0; i < size; i++)
                {
                    IntPtr itemGroup = game.ReadPointer(startAddr + startOffset + (itemOffset * i));

                    if (itemGroup != IntPtr.Zero)
                    {
                        TechType itemType = (TechType)game.ReadValue<int>(itemGroup + 0x18);
                        WriteDebug((itemGroup + 0x18).ToString("X"));

                        IntPtr list = game.ReadPointer(itemGroup + 0x10);
                        int itemCount = game.ReadValue<int>(list + 0x18);
                        inv.Add(itemType, itemCount);

#if EXTRADBG
                        WriteDebug($"Inv contains: {itemCount} {itemType}");
#endif
                    }
                }
#if EXTRADBG
                DateTime end = DateTime.Now;
                TimeSpan time = end - start;
                WriteDebug($"inv read took {time.Ticks / 1000000d}ms");
                WriteDebug("end inv");
#endif
            }
            else
            {
                WriteDebug("Game null in GetInventory");
            }
            Thread.Sleep(10);
            playerInventoryOld = playerInventory;
            playerInventory = inv;
        }

        private void GetBlueprints(object o)
        {
            List<TechType> blueprints = new List<TechType>();
            if (game != null)
            {
                knownTechPtr.Update(game);
                IntPtr startAddr = knownTechPtr.Current;
#if EXTRADBG
                DateTime start = DateTime.Now;
                WriteDebug("Getting bps from " + startAddr.ToString("X"));
#endif

                int slotsOffset = gameVersion == GameVersion.Sept2018 ? 0x20 : 0x18;
                IntPtr slots = game.ReadPointer(startAddr + slotsOffset);
                int countOffset = gameVersion == GameVersion.Sept2018 ? 0x40 : 0x30;
                int count = game.ReadValue<int>(startAddr + countOffset);

                int slotBeginningOffset = gameVersion == GameVersion.Sept2018 ? 0x0 : 0x20;
                int slotSize = gameVersion == GameVersion.Sept2018 ? 0x4 : 0xC;
                for (int i = 0; i < count; i++)
                {
                    int tech = game.ReadValue<int>(slots + slotBeginningOffset + slotSize * i);
                    if (tech > 0 && tech < 10005)
                    {
                        TechType type = (TechType)tech;
                        blueprints.Add(type);
#if EXTRADBG
                        WriteDebug($"knows: {type}");
#endif
                    }
                }
#if EXTRADBG
                DateTime end = DateTime.Now;
                TimeSpan time = end - start;
                WriteDebug($"bp read took {time.Ticks / 1000000d}ms");
                WriteDebug("end BPs");
#endif
            }
            else
            {
                WriteDebug("Game null in GetBlueprints");
            }
            knownTechOld = knownTech;
            knownTech = blueprints;
        }*/
        #endregion

        #region Bounds
        private readonly float[] teethBounds = { -212f, 27f, -100f, 100f, 159f, 177f };
        private readonly float[] auroraExitBounds = { 545f, 550f, -10f, 10f, -265f, 256f };
        private readonly float[] eyestalkBounds = { -200f, 130f, -100f, 50f, 477f, 479f };
        private readonly float[] mountainBounds = { 475f, 534f, -510f, -191f, 745f, 810f };
        private readonly float[] PCFEntrBounds = { 216f, 224f, -1453f, -1445f, -276f, -267f };
        private readonly float[] portalBounds = { 240f, 250f, -1590f, -1580f, -2000f, 2000f };
        private readonly float[] gunBounds = { 359f, 365f, -75f, -66f, 1079f, 1085f };
        private readonly float[] upperTabletBounds = { 380f, 386f, 10f, 30f, 1084f, 1090f };
        private readonly float[] SGLBaseBounds = { 20f, 80f, -45f, -17f, 290f, 360f };
        private readonly float[] deathClipABounds = { 33f, 65f, -20f, -8f, 118f, 96f };
        private readonly float[] deathClipCBounds = { -155f, -133f, -20f, -10f, 73f, 96f };
        private readonly float[] enterClipABounds = { 48f, 55f, -20f, -5f, 106f, 111f };
        private readonly float[] enterClipCBounds = { -142f, -132f, -20f, -5f, 82f, 90f };
        #endregion

        private enum GameVersion
        {
            Sept2018,
            Mar2023
        }
    }
}
