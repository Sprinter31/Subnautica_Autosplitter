using LiveSplit.ComponentUtil;
using LiveSplit.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Voxif.AutoSplitter;
using Voxif.Helpers.Unity;
using Voxif.IO;
using Voxif.Memory;

namespace LiveSplit.Subnautica
{
    public class SubnauticaMemory : Memory
    {
        protected override string[] ProcessNames => new string[] { "Subnautica" };

        public SubnauticaSplit CurrentSplitToCheck { get; set; }

        private IMonoHelper mono;

        public bool startedTimerBefore = false;
        public bool isInMainMenu = false;
        private readonly Stopwatch _duringLoad = new Stopwatch();
        private readonly Stopwatch _afterLoad = new Stopwatch();
        private int prePortalDelayMs = 0;
        private int postPortalDelayMs = 0;
        private const int maxInventoryTimeWithoutChangingMs = 1000;
        public bool pointersInitialized;
        public GameVersion gameVersion;
        //string[] EncyMappingMarch2023;

        public readonly Dictionary<SplitName, Func<bool>> splitConditions;
        public readonly Dictionary<SplitName, Func<bool>> subConditions;

        private readonly SubnauticaSettings settings;

        readonly Dictionary<TechType, InvChangeInfo> curPickUpCounts = new Dictionary<TechType, InvChangeInfo>();
        readonly Dictionary<TechType, InvChangeInfo> curDropCounts = new Dictionary<TechType, InvChangeInfo>();
        private Dictionary<TechType, int> currentInventoryChanges = new Dictionary<TechType, int>();
        private readonly Stopwatch flareThrowArmedTime = new Stopwatch();
        private bool flareThrowArmed;
        private const int maxFlareThrowAnimWindowMs = 1500;

        #region Pointer stuff
        public Pointer<bool> IsIntroCinematicActive; // true in main menu sometimes
        public Pointer<bool> IsAnimationPlaying;
        public Pointer<bool> IsLoadingScreenShowing;
        public Pointer<bool> DamageEffectsShowing;
        public Pointer<bool> RocketLaunching;
        public Pointer<bool> RadiationFixed;        
        public Pointer<bool> IsPlayerJumping;   
        public Pointer<bool> IsDying;

        public Pointer<float> TimeCured;
        public Pointer<float> Health;
        public Pointer<float> TimeToStartCountdown;
        public Pointer<float> TimeToStartWarning;
        public Pointer<float> TimeOfLastToolUseAnim;

        public Pointer<IntPtr> MainMenu;
        public Pointer<IntPtr> CraftingMenu;
        private Pointer<IntPtr> knowntechPtr;
        private Pointer<IntPtr> pdaMappingPtr;
        private Pointer<IntPtr> goalsPtr;

        public Pointer<int> PDATab;
        public Pointer<int> GameMode;
        public Pointer<int> CraftedNode;
        public Pointer<int> PlayerMode;

        public StringPointer BiomeString;
        public StringPointer ActiveToolName;

        public Dictionary<TechType, int> PlayerInventory = new Dictionary<TechType, int>();
        public Dictionary<TechType, int> PlayerInventoryOld = new Dictionary<TechType, int>();
        public List<TechType> PlayerEquipment = new List<TechType>();
        public List<TechType> PlayerEquipmentOld = new List<TechType>();
        public List<TechType> KnownTech = new List<TechType>();
        public List<TechType> KnownTechOld = new List<TechType>();
        public List<EncyEntry> Encyclopedia = new List<EncyEntry>();
        public List<EncyEntry> EncyclopediaOld = new List<EncyEntry>();

        IntPtr invKlass;
        IntPtr equipmentKlass;
        IntPtr icKlass;
        int off_container;
        int off_equipment;
        int off_equippedCount;
        int off_itemsDict;
        IntPtr itemGroupKlass;
        int off_itemGroup_items;
        int off_list_size;
        int dict_off_entries;
        int arr_off_len;
        int arr_data_base;
        int off_itemGroup_id;
        int dict_off_version;


        IntPtr invStaticKlass;
        int invStaticOffset;

        struct LegacyDictOffsets
        {
            public int off_table;
            public int off_linkSlots;
            public int off_keySlots;
            public int off_valSlots;
            public int off_touched;
        }
        bool useLegacyDict = false;
        LegacyDictOffsets legacy_off;

        public MemoryWatcher<bool> isPortalLoading = new MemoryWatcher<bool>(IntPtr.Zero);
        public MemoryWatcher<bool> isEggsHatching = new MemoryWatcher<bool>(IntPtr.Zero);
        public MemoryWatcher<bool> isNotInWater = new MemoryWatcher<bool>(IntPtr.Zero);
        public MemoryWatcher<float> walkDir = new MemoryWatcher<float>(IntPtr.Zero);
        public MemoryWatcher<float> strafeDir = new MemoryWatcher<float>(IntPtr.Zero);
        public MemoryWatcher<float> posX = new MemoryWatcher<float>(IntPtr.Zero);
        public MemoryWatcher<float> posY = new MemoryWatcher<float>(IntPtr.Zero);
        public MemoryWatcher<float> posZ = new MemoryWatcher<float>(IntPtr.Zero);
        #endregion

        private UnityHelperTask unityTask;

        public SubnauticaMemory(LiveSplitState state, SubnauticaComponent component, Logger logger, SubnauticaSettings settings) : base(logger)
        {            
            //EncyMappingMarch2023 = Assembly.GetExecutingAssembly().ReadAllLinesFromResource("Livesplit.Subnautica.Resources.EncyMappingMarch2023.txt");

            OnHook += () =>
            {
                GetGameVersion();
                prePortalDelayMs = gameVersion == GameVersion.Sept2018 ? 500 : 550;
                postPortalDelayMs = gameVersion == GameVersion.Sept2018 ? 350 : 350;
                unityTask = new UnityHelperTask(game, logger);
                unityTask.Run(InitPointers);               
            };

            OnExit += () => {
                if (unityTask != null)
                {
                    pointersInitialized = false;
                    unityTask.Dispose();
                    unityTask = null;
                }
            };

            this.settings = settings;

            subConditions = new Dictionary<SplitName, Func<bool>>
            {
                { SplitName.Inventory,            () => !((ItemSplit)CurrentSplitToCheck).IsCount && HasPlayerItem(((ItemSplit)CurrentSplitToCheck).Item.ConvertTo<TechType>()) || ((ItemSplit)CurrentSplitToCheck).IsCount && GetPlayerItemCount(((ItemSplit)CurrentSplitToCheck).Item.ConvertTo<TechType>()) == ((ItemSplit)CurrentSplitToCheck).Count },
                { SplitName.Blueprint,            () => KnownTech.Contains(((BlueprintSplit)CurrentSplitToCheck).Blueprint.ConvertTo<TechType>()) },
                { SplitName.Encyclopedia,         () => Encyclopedia.Contains(((EncySplit)CurrentSplitToCheck).Entry) },
                { SplitName.Biome,                () => string.Equals(BiomeString.New, ((BiomeSplit)CurrentSplitToCheck).Biomes.Biome1.ToString(), StringComparison.OrdinalIgnoreCase) || ((BiomeSplit)CurrentSplitToCheck).Biomes.Biome1 == Biome.Any },
            };

            splitConditions = new Dictionary<SplitName, Func<bool>>
            {
                { SplitName.Inventory,            () => { 
                                                        var inv = (ItemSplit)CurrentSplitToCheck;
                                                        var techType = inv.Item.ConvertTo<TechType>();

                                                        int currentPickUpChange = curPickUpCounts.TryGetValue(techType, out InvChangeInfo infP) ? infP.Count : 0;
                                                        int currentDropChange = curDropCounts.TryGetValue(techType, out InvChangeInfo infD) ? infD.Count : 0;

                                                        int change = inv.PickUp ? currentPickUpChange : -currentDropChange;
                                                        bool changedInRightDirection = change > 0;
                                                        int curCount = GetPlayerItemCount(techType);
                                                        int oldCount = GetPlayerItemCountOld(techType);

                                                        if (!inv.IsCount)
                                                        {
                                                            int currentChange = currentInventoryChanges.TryGetValue(techType, out int delta) ? delta : 0;
                                                            return inv.PickUp ? currentChange > 0 : currentChange < 0;
                                                        }

                                                        if (inv.AlreadySplitInvChanging)
                                                            return false;

                                                        bool split = change >= inv.Count && changedInRightDirection;
                                                        inv.AlreadySplitInvChanging = split;
                                                        return split;
                                                        } },
                { SplitName.Blueprint,            () => KnownTech.Contains(((BlueprintSplit)CurrentSplitToCheck).Blueprint.ConvertTo<TechType>()) && !KnownTechOld.Contains(((BlueprintSplit)CurrentSplitToCheck).Blueprint.ConvertTo<TechType>()) },
                { SplitName.Encyclopedia,         () => Encyclopedia.Contains(((EncySplit)CurrentSplitToCheck).Entry) && !EncyclopediaOld.Contains(((EncySplit)CurrentSplitToCheck).Entry) },
                { SplitName.Biome,                () => (((BiomeSplit)CurrentSplitToCheck).Biomes.Biome1 == Biome.Any && ((BiomeSplit)CurrentSplitToCheck).Biomes.Biome2 == Biome.Any && BiomeString.Changed) ||
                                                        (((BiomeSplit)CurrentSplitToCheck).Biomes.Biome1 == Biome.Any && string.Equals(BiomeString.New, ((BiomeSplit)CurrentSplitToCheck).Biomes.Biome2.ToString(), StringComparison.OrdinalIgnoreCase) && BiomeString.Changed) ||
                                                        (((BiomeSplit)CurrentSplitToCheck).Biomes.Biome2 == Biome.Any && string.Equals(BiomeString.Old, ((BiomeSplit)CurrentSplitToCheck).Biomes.Biome1.ToString(), StringComparison.OrdinalIgnoreCase) && BiomeString.Changed) ||
                                                        (string.Equals(BiomeString.New, ((BiomeSplit)CurrentSplitToCheck).Biomes.Biome2.ToString(), StringComparison.OrdinalIgnoreCase) && string.Equals(BiomeString.Old, ((BiomeSplit)CurrentSplitToCheck).Biomes.Biome1.ToString(), StringComparison.OrdinalIgnoreCase)) },
                { SplitName.Craft,                () =>  string.Equals(((CraftSplit)CurrentSplitToCheck).Craftable.ToString(), ((TechType)CraftedNode.New).ToString(), StringComparison.OrdinalIgnoreCase) && CraftedNode.Changed },
                { SplitName.RocketSplit,          () => RocketLaunching.New && !RocketLaunching.Old },
                { SplitName.PCFTabletSplit,       () => IsAnimationPlaying.New && !IsAnimationPlaying.Old && IsWithinBounds(PCFEntrBounds) },
                { SplitName.PortalSplit,          () => isPortalLoading.Current && !isPortalLoading.Old && IsWithinBounds(portalBounds) },
                { SplitName.HatchSplit,           () => isEggsHatching.Current && !isEggsHatching.Old },
                { SplitName.CureSplit,            () => TimeCured.New > TimeCured.Old },
                { SplitName.NeptuneLaunchPlatform,() => (TechType)CraftedNode.New == TechType.RocketBase && CraftedNode.Changed },
                { SplitName.GantrySplit,          () => KnownTech.Contains(TechType.RocketStage1) && !KnownTechOld.Contains(TechType.RocketStage1) },
                { SplitName.BoostersSplit,        () => KnownTech.Contains(TechType.RocketStage2) && !KnownTechOld.Contains(TechType.RocketStage2) },
                { SplitName.FuelReservesSplit,    () => KnownTech.Contains(TechType.RocketStage3) && !KnownTechOld.Contains(TechType.RocketStage3) },
                { SplitName.GunDeactivationSplit, () => IsAnimationPlaying.New && !IsAnimationPlaying.Old && IsWithinBounds(gunBounds) },
                { SplitName.BaseDeathSplit,       () => Health.New <= 0 && Health.Old > 0 && (IsWithinBounds(deathClipABounds) || IsWithinBounds(deathClipCBounds)) },
                { SplitName.LeaveKelpForestSplit, () => IsWithinBounds(teethBounds) && !IsWithinBounds(teethBounds, old: true) && PlayerInventory.ContainsKey(TechType.CreepvinePiece) },
                { SplitName.FourToothSplit,       () => PlayerInventory.GetCount(TechType.StalkerTooth) == 4 && PlayerInventoryOld.GetCount(TechType.StalkerTooth) != 4 },
                { SplitName.AuroraDeathSplit,     () => !component.alreadySplit.Select(s => s.SplitName).Contains(SplitName.AuroraBiomeSplit) && Health.New <= 0 && Health.Old > 0 && new[] { "crashedShip", "generatorRoom" }.Contains(BiomeString.New)},
                { SplitName.RocketUnlockSplit,    () => KnownTech.Contains(TechType.RocketBase) && !KnownTechOld.Contains(TechType.RocketBase) },
                { SplitName.MountainDescendSplit, () => IsWithinBounds(mountainBounds) && !IsWithinBounds(mountainBounds, old: true) },
                { SplitName.IonDeathSplit,        () => Health.New <= 0 && Health.Old > 0 && new[] { "Precursor_LavaCastleBase", "PrecursorThermalRoom" }.Contains(BiomeString.New) },
                { SplitName.GunDeathSplit,        () => Health.New <= 0 && Health.Old > 0 && BiomeString.New == "Precursor_Gun_ControlRoom" },
                { SplitName.SparseDeathSplit,     () => Health.New <= 0 && Health.Old > 0 && new[] { "sparseReef", "seaTreaderPath", "seaTreaderPath_wreck" }.Contains(BiomeString.New) },
                { SplitName.SGLBaseSplit,         () => isNotInWater.Current && !isNotInWater.Old && IsWithinBounds(SGLBaseBounds) },
                { SplitName.SGLShallowsSplit,     () => !isNotInWater.Current && IsAnimationPlaying.New && IsWithinBounds(SGLBaseBounds) && PlayerInventory.ContainsKey(TechType.DoubleTank) },
                { SplitName.UpperTabletSplit,     () => PlayerInventory.GetCount(TechType.PrecursorKey_Purple) > PlayerInventoryOld.GetCount(TechType.PrecursorKey_Purple) && IsWithinBounds(upperTabletBounds) },
                { SplitName.IonUnstuckSplit,      () => IsAnimationPlaying.New && !IsAnimationPlaying.Old && BiomeString.New == "PrecursorThermalRoom" },
                { SplitName.PCFPoolSplit,         () => BiomeString.New == "Prison_Aquarium_Upper" && BiomeString.Old == "Prison_Moonpool" },
                { SplitName.SparseBiomeSplit,     () => !component.alreadySplit.Select(s => s.SplitName).Contains(SplitName.SparseDeathSplit) && new[] { "sparseReef", "seaTreaderPath", "seaTreaderPath_wreck" }.Contains(BiomeString.Old) && new[] { "safeShallows", "kelpForest", "Lifepod" }.Contains(BiomeString.New) },
                { SplitName.AuroraBiomeSplit,     () => !component.alreadySplit.Select(s => s.SplitName).Contains(SplitName.AuroraDeathSplit) && new[] { "crashedShip", "generatorRoom" }.Contains(BiomeString.Old) && new[] { "safeShallows", "kelpForest", "Lifepod" }.Contains(BiomeString.New) },
                { SplitName.IonUnlockSplit,       () => KnownTech.Contains(TechType.PrecursorIonBattery) && !KnownTechOld.Contains(TechType.PrecursorIonBattery) },
                { SplitName.AuroraExitSplit,      () => IsWithinBounds(auroraExitBounds) && !IsWithinBounds(auroraExitBounds, old: true) && KnownTech.Contains(TechType.RocketBase) },
                { SplitName.HCGSparseSplit,       () => IsAnimationPlaying.New && !IsAnimationPlaying.Old && (IsWithinBounds(enterClipABounds) || IsWithinBounds(enterClipCBounds)) && PlayerInventory.ContainsKey(TechType.AluminumOxide) },
                { SplitName.DeathSplit,           () => Health.New <= 0 && Health.Old > 0 || IsDying.New && !IsDying.Old },
                { SplitName.ReactorCoreRepairSplit, () => RadiationFixed.New && !RadiationFixed.Old },
                { SplitName.FullInventorySplit,   () => PlayerInventory.Select(kvp => kvp.Value * TechTypeItemSlots.GetSlotCount(kvp.Key)).Sum() == 48 && PlayerInventoryOld.Select(kvp => kvp.Value * TechTypeItemSlots.GetSlotCount(kvp.Key)).Sum() != 48 },
                //{ SplitName.ChairSplit,           () => (PlayerMode)PlayerMode.New == LiveSplit.Subnautica.PlayerMode.Sitting && PlayerMode.Changed },
                { SplitName.ThrowFlareSplit,      () => IsFlareThrowDrop() },
                { SplitName.RepairSecondarySystemsSplit,     () => string.Equals(BiomeString.New, "Lifepod", StringComparison.OrdinalIgnoreCase) && ( string.Equals(ActiveToolName.New, "welder", StringComparison.OrdinalIgnoreCase) || string.Equals(ActiveToolName.Old, "welder", StringComparison.OrdinalIgnoreCase)) && DamageEffectsShowing.Old && !DamageEffectsShowing.New },
            };
        }

        public override bool Update()
        {
            if (!base.Update())
                return false;

            if (!pointersInitialized || game == null)
                return false;

            UpdateMemoryWatchers();

            isInMainMenu = IsInMainMenu();
            if (isInMainMenu)
                startedTimerBefore = false;

            return true;
        }

        #region Memory stuff
        private void GetGameVersion()
        {
            System.Diagnostics.ProcessModule firstModule = game.Process.Modules.Cast<System.Diagnostics.ProcessModule>().FirstOrDefault();
            if (firstModule == null) return;
            int moduleLen = firstModule.ModuleMemorySize;
            switch (moduleLen)
            {
                case 23801856:
                    gameVersion = GameVersion.Sept2018;
                    logger.Log("Game version Sept 2018");
                    break;

                case 675840:
                    gameVersion = GameVersion.Mar2023;
                    logger.Log("Game version March 2023");
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

        private void InitPointers(IMonoHelper mono)
        {
            this.mono = mono;
            var ptrFactory = new MonoNestedPointerFactory(game, mono);


            #region Intro Cinematic
            Pointer<IntPtr> introCinematicPtr = ptrFactory.Make<IntPtr>("EscapePod", "main", "introCinematic");
            IntPtr pccKlass = mono.FindClass("PlayerCinematicController");
            int off_cinematicModeActive = mono.GetFieldOffset(pccKlass, "cinematicModeActive");
            IsIntroCinematicActive = ptrFactory.Make<bool>(introCinematicPtr, off_cinematicModeActive);
            #endregion Intro Cinematic
            #region Is Animation Playing
            IsAnimationPlaying = ptrFactory.Make<bool>("Player", "main", "_cinematicModeActive");
            #endregion Is Animation Playing
            #region IsLoadingScreenShowing
            Pointer<IntPtr> uGUI_SceneLoadingPtr = ptrFactory.Make<IntPtr>("uGUI", "_main", "loading");
            int off_isLoading = mono.GetFieldOffset(mono.FindClass("uGUI_SceneLoading"), "isLoading");
            IsLoadingScreenShowing = ptrFactory.Make<bool>(uGUI_SceneLoadingPtr, off_isLoading);
            #endregion IsLoadingScreenShowing
            #region Time Cured
            TimeCured = ptrFactory.Make<float>("Player", "main", "timePlayerInfectionCured");
            #endregion
            #region Health
            Pointer<IntPtr> liveMixingPtr = ptrFactory.Make<IntPtr>("Player", "main", "liveMixin");
            IntPtr lmKlass = mono.FindClass("LiveMixin");
            int off_health = mono.GetFieldOffset(lmKlass, "health");
            Health = ptrFactory.Make<float>(liveMixingPtr, off_health);
            #endregion
            #region Inventory
            invKlass = mono.FindClass("Inventory", mono.MainImage);
            equipmentKlass = mono.FindClass("Equipment", mono.MainImage);
            icKlass = mono.FindClass("ItemsContainer", mono.MainImage);

            invStaticOffset = mono.GetFieldOffset(invKlass, "main");
            invStaticKlass = invKlass;

            off_container = ((UnityHelperTask.UnityHelperBase)mono)
                .ResolveFieldOffsetByNameOrPredicate(invKlass, new[] { "_container" },
                    fname => UnityHelperTask.UnityNameUtil.NameHas(fname, "container"));

            off_equipment = ((UnityHelperTask.UnityHelperBase)mono)
                .ResolveFieldOffsetByNameOrPredicate(invKlass, new[] { "_equipment" },
                    fname => UnityHelperTask.UnityNameUtil.NameHas(fname, "equipment"));

            off_equippedCount = ((UnityHelperTask.UnityHelperBase)mono)
                .ResolveFieldOffsetByNameOrPredicate(equipmentKlass, new[] { "equippedCount" },
                    fname => UnityHelperTask.UnityNameUtil.NameHas(fname, "equippedCount"));

            off_itemsDict = ((UnityHelperTask.UnityHelperBase)mono)
                .ResolveFieldOffsetByNameOrPredicate(icKlass, new[] { "_items" },
                    fname => UnityHelperTask.UnityNameUtil.NameHas(fname, "items"));

            itemGroupKlass = mono.FindClass("ItemGroup", mono.MainImage);

            off_itemGroup_items = (itemGroupKlass != IntPtr.Zero)
                ? mono.GetFieldOffset(itemGroupKlass, "items") : 0;
            if (off_itemGroup_items == 0 && itemGroupKlass != IntPtr.Zero)
                off_itemGroup_items = ((UnityHelperTask.UnityHelperBase)mono)
                    .ResolveFieldOffsetByNameOrPredicate(itemGroupKlass, new[] { "items" },
                        fname => UnityHelperTask.UnityNameUtil.NameHas(fname, "items"));

            off_itemGroup_id = (itemGroupKlass != IntPtr.Zero)
                ? mono.GetFieldOffset(itemGroupKlass, "id") : 0;
            if (off_itemGroup_id == 0 && itemGroupKlass != IntPtr.Zero)
                off_itemGroup_id = ((UnityHelperTask.UnityHelperBase)mono)
                    .ResolveFieldOffsetByNameOrPredicate(itemGroupKlass, new[] { "id", "techType" },
                        fname => {
                            var f = fname.ToLowerInvariant();
                            return f == "id" || f.Contains("techtype") || f.EndsWith("techtype");
                        });


            // List<T>._size
            IntPtr core = ((UnityHelperTask.UnityHelperBase)mono).TryFindImageOnce(
                "mscorlib", "mscorlib.dll", "System.Private.CoreLib", "System.Private.CoreLib.dll", "netstandard", "netstandard.dll");
            IntPtr listKlass = core != IntPtr.Zero ? ((UnityHelperTask.UnityHelperBase)mono).TryFindClassOnce("List`1", core) : IntPtr.Zero;
            off_list_size = 0x18;
            if (listKlass != IntPtr.Zero)
            {
                int cand = mono.GetFieldOffset(listKlass, "_size");
                if (cand != 0) off_list_size = cand;
            }


            // Dictionary<>.entries, Array header
            dict_off_entries = 0x18;
            arr_off_len = 0x18;
            arr_data_base = 0x20;

            if (core != IntPtr.Zero)
            {
                IntPtr dictKlass = ((UnityHelperTask.UnityHelperBase)mono).TryFindClassOnce("Dictionary`2", core);
                if (dictKlass != IntPtr.Zero)
                {
                    var unity = (UnityHelperTask.UnityHelperBase)mono;

                    //  force legacy on 2018
                    if (gameVersion == GameVersion.Sept2018)
                    {
                        int off_table = unity.ResolveFieldOffsetByNameOrPredicate(dictKlass, new[] { "table" }, s => s.IndexOf("table", StringComparison.OrdinalIgnoreCase) >= 0);
                        int off_linkSlots = unity.ResolveFieldOffsetByNameOrPredicate(dictKlass, new[] { "linkSlots" }, s => s.IndexOf("link", StringComparison.OrdinalIgnoreCase) >= 0);
                        int off_keySlots = unity.ResolveFieldOffsetByNameOrPredicate(dictKlass, new[] { "keySlots" }, s => s.IndexOf("key", StringComparison.OrdinalIgnoreCase) >= 0);
                        int off_valSlots = unity.ResolveFieldOffsetByNameOrPredicate(dictKlass, new[] { "valueSlots" }, s => s.IndexOf("value", StringComparison.OrdinalIgnoreCase) >= 0);
                        int off_touched = unity.ResolveFieldOffsetByNameOrPredicate(dictKlass, new[] { "touchedSlots", "count" }, s =>
                        {
                            var f = s.ToLowerInvariant();
                            return f.Contains("touched") || f.Equals("count") || f.EndsWith("count");
                        });

                        legacy_off = new LegacyDictOffsets
                        {
                            off_table = off_table,
                            off_linkSlots = off_linkSlots,
                            off_keySlots = off_keySlots,
                            off_valSlots = off_valSlots,
                            off_touched = off_touched
                        };
                        useLegacyDict = true;
                        logger.Log("[Unity] Forced legacy Dictionary<> layout for Sept 2018 (keySlots/valueSlots).");
                    }
                    else
                    {
                        // modern path only for 2023
                        int oe = mono.GetFieldOffset(dictKlass, "entries");
                        if (oe == 0) oe = mono.GetFieldOffset(dictKlass, "_entries");
                        if (oe != 0) dict_off_entries = oe;
                        useLegacyDict = false;
                    }
                }
            }
            #endregion Inventory
            #region Known Tech
            knowntechPtr = ptrFactory.Make<IntPtr>("KnownTech", "knownTech");
            #endregion Known Tech
            #region PDA Mapping
            pdaMappingPtr = ptrFactory.Make<IntPtr>("PDAEncyclopedia", "entries");
            //off_entry_unlocked = gameVersion == GameVersion.Sept2018 ? 0x49 : 0x4C;
            #endregion PDA Mapping
            #region Main Menu
            MainMenu = ptrFactory.Make<IntPtr>("uGUI_MainMenu", "main");
            #endregion
            #region Biome
            BiomeString = ptrFactory.MakeString("Player", "main", "biomeString", 0x14);
            #endregion
            #region PDATab
            PDATab = ptrFactory.Make<int>("uGUI_PDA", "<main>k__BackingField", "tabOpen");
            #endregion PDATab
            #region Damage Effects Showing
            DamageEffectsShowing = ptrFactory.Make<bool>("EscapePod", "main", "damageEffectsShowing");
            #endregion Damage Effects Showing
            #region Game Mode
            GameMode = ptrFactory.Make<int>("GameModeUtils", "currentGameMode");
            #endregion Game Mode
            #region Goals
            goalsPtr = ptrFactory.Make<IntPtr>("Story.StoryGoalManager", "<main>k__BackingField", "completedGoals");
            #endregion Goals
            #region Rocket Launching
            RocketLaunching = ptrFactory.Make<bool>("LaunchRocket", "launchStarted");
            #endregion Rocket Launching
            #region RadiationFixed
            RadiationFixed = ptrFactory.Make<bool>("LeakingRadiation", "main", "radiationFixed");
            #endregion RadiationFixed
            #region Explosion Time
            TimeToStartCountdown = ptrFactory.Make<float>("CrashedShipExploder", "main", "timeToStartCountdown");
            TimeToStartWarning = ptrFactory.Make<float>("CrashedShipExploder", "main", "timeToStartWarning");
            #endregion Explosion Time
            #region Crafted Menu/Node
            Pointer<IntPtr> uGUI_CraftingMenuPtr = ptrFactory.Make<IntPtr>("uGUI", "_main", "craftingMenu");
            int off_craftedNode = mono.GetFieldOffset(mono.FindClass("uGUI_CraftingMenu"), "craftedNode");
            Pointer<IntPtr> craftedNodePtr = ptrFactory.Make<IntPtr>(uGUI_CraftingMenuPtr, off_craftedNode);

            if (gameVersion == GameVersion.Sept2018)
                CraftedNode = ptrFactory.Make<int>(craftedNodePtr, mono.GetFieldOffset("uGUI_CraftNode", "techType0"));
            else
                CraftedNode = ptrFactory.Make<int>(craftedNodePtr, 0x34);

            CraftingMenu = ptrFactory.Make<IntPtr>(uGUI_CraftingMenuPtr, mono.GetFieldOffset(mono.FindClass("uGUI_CraftingMenu"), "_client"));
            #endregion Crafted Menu/Node
            #region Player Mode
            PlayerMode = ptrFactory.Make<int>("Player", "main", "mode");
            #endregion Player Mode
            #region IsPlayerJumping
            Pointer<IntPtr> groundMotorPtr = ptrFactory.Make<IntPtr>("Player", "main", "groundMotor");
            int off_jumping = mono.GetFieldOffset(mono.FindClass("GroundMotor"), "jumping");
            Pointer<IntPtr> jumpingPtr = ptrFactory.Make<IntPtr>(groundMotorPtr, off_jumping);
            IsPlayerJumping = ptrFactory.Make<bool>(jumpingPtr, 0x24);
            #endregion IsPlayerJumping
            #region IsDying
            IsDying = ptrFactory.Make<bool>("uGUI_PlayerDeath", "main", "active");
            #endregion IsDying
            #region ThrowFlare
            Pointer<IntPtr> quickSlotsPtr = ptrFactory.Make<IntPtr>("Inventory", "main", "<quickSlots>k__BackingField");

            int off_activeToolName = mono.GetFieldOffset(mono.FindClass("QuickSlots"), "activeToolName");
            ActiveToolName = ptrFactory.MakeString(quickSlotsPtr, off_activeToolName, 0x14);

            Pointer<IntPtr> armsControllerPtr = ptrFactory.Make<IntPtr>("Player", "main", "armsController");
            int off_armsControllerGuiHand = mono.GetFieldOffset(mono.FindClass("ArmsController"), "guiHand");
            Pointer<IntPtr> guiHandPtr = ptrFactory.Make<IntPtr>(armsControllerPtr, off_armsControllerGuiHand);
            int off_timeOfLastToolUseAnim = mono.GetFieldOffset(mono.FindClass("GUIHand"), "timeOfLastToolUseAnim");
            TimeOfLastToolUseAnim = ptrFactory.Make<float>(guiHandPtr, off_timeOfLastToolUseAnim);
            #endregion ThrowFlare

            #region Memory Watchers
            DeepPointer portalLoadingPtr;
            DeepPointer hatchPtr;
            DeepPointer notInWaterPtr;
            DeepPointer walkDirPtr;
            DeepPointer strafePtr;
            DeepPointer posXPtr;
            DeepPointer posYPtr;
            DeepPointer posZPtr;

            switch (gameVersion)
            {
                case GameVersion.Sept2018:
                    portalLoadingPtr = new DeepPointer("Subnautica.exe", 0x142B740, 0x8, 0x10, 0x30, 0x1F8, 0x28, 0x28);
                    hatchPtr = new DeepPointer("fmodstudio.dll", 0x304A30, 0x88, 0x18, 0x158, 0x498, 0x108);
                    notInWaterPtr = new DeepPointer("Subnautica.exe", 0x14BC6A0, 0x7C);
                    walkDirPtr = new DeepPointer("Subnautica.exe", 0x142B8C8, 0x158, 0x40, 0xA0);
                    strafePtr = new DeepPointer("Subnautica.exe", 0x142B8C8, 0x158, 0x40, 0x160);
                    posXPtr = new DeepPointer("Subnautica.exe", 0x142B8C8, 0x180, 0x40, 0xA8, 0x7C0);
                    posYPtr = new DeepPointer("Subnautica.exe", 0x142B8C8, 0x180, 0x40, 0xA8, 0x7C4);
                    posZPtr = new DeepPointer("Subnautica.exe", 0x142B8C8, 0x180, 0x40, 0xA8, 0x7C8);                   
                    break;

                default: // GameVersion.Mar2023
                    portalLoadingPtr = new DeepPointer("UnityPlayer.dll", 0x17FBE70, 0x10, 0x10, 0x30, 0x1F8, 0x28, 0x28);
                    hatchPtr = new DeepPointer("fmodstudio.dll", 0x2CED70, 0x78, 0x18, 0x190, 0x4D8, 0xB0, 0x20, 0x28);
                    notInWaterPtr = new DeepPointer("UnityPlayer.dll", 0x18AB130, 0x48, 0x0, 0x68);
                    walkDirPtr = new DeepPointer("UnityPlayer.dll", 0x17FBC28, 0x30, 0x98);
                    strafePtr = new DeepPointer("UnityPlayer.dll", 0x17FBC28, 0x30, 0x150);
                    posXPtr = new DeepPointer("UnityPlayer.dll", 0x1839CE0, 0x28, 0x10, 0x150, 0xA58);
                    posYPtr = new DeepPointer("UnityPlayer.dll", 0x1839CE0, 0x28, 0x10, 0x150, 0xA5C);
                    posZPtr = new DeepPointer("UnityPlayer.dll", 0x1839CE0, 0x28, 0x10, 0x150, 0xA60);
                    break;
            }

            isPortalLoading = new MemoryWatcher<bool>(portalLoadingPtr);
            isEggsHatching = new MemoryWatcher<bool>(hatchPtr);
            isNotInWater = new MemoryWatcher<bool>(notInWaterPtr);
            walkDir = new MemoryWatcher<float>(walkDirPtr);
            strafeDir = new MemoryWatcher<float>(strafePtr);
            posX = new MemoryWatcher<float>(posXPtr);
            posY = new MemoryWatcher<float>(posYPtr);
            posZ = new MemoryWatcher<float>(posZPtr);
            #endregion Memory Watchers 

            logger.Log("Pointers initialized");
            pointersInitialized = true;
        }

        private void UpdateMemoryWatchers()
        {
            if (settings.CreativeStart)
            {
                walkDir.Update(game.Process);
                strafeDir.Update(game.Process);
            }

            isPortalLoading.Update(game.Process);

            if (Needs(SplitName.HatchSplit))
                isEggsHatching.Update(game.Process);

            if (Needs(SplitName.SGLBaseSplit, SplitName.SGLShallowsSplit))
                isNotInWater.Update(game.Process);

            if (Needs(SplitName.ThrowFlareSplit))
                UpdateFlareThrowState();

            if (Needs(SplitName.PCFTabletSplit,
                      SplitName.GunDeactivationSplit,
                      SplitName.BaseDeathSplit,
                      SplitName.LeaveKelpForestSplit,
                      SplitName.MountainDescendSplit,
                      SplitName.SGLBaseSplit,
                      SplitName.SGLShallowsSplit,
                      SplitName.UpperTabletSplit,
                      SplitName.AuroraExitSplit,
                      SplitName.HCGSparseSplit) ||
                      settings.Reset)
                UpdatePosition();

            if (Needs(SplitName.Inventory,
                      SplitName.FullInventorySplit,
                      SplitName.ThrowFlareSplit,
                      SplitName.LeaveKelpForestSplit,
                      SplitName.FourToothSplit,
                      SplitName.HCGSparseSplit,
                      SplitName.SGLShallowsSplit,
                      SplitName.UpperTabletSplit))
                UpdateInventory();

            if (Needs(SplitName.Blueprint, 
                      SplitName.BoostersSplit,
                      SplitName.FuelReservesSplit,
                      SplitName.RocketUnlockSplit,
                      SplitName.AuroraExitSplit,
                      SplitName.IonUnlockSplit))
                UpdateBlueprints();

            if(Needs(SplitName.Encyclopedia))
                UpdateEncyclopedia();
        }
        private void UpdatePosition() { posX.Update(game.Process); posY.Update(game.Process); posZ.Update(game.Process); }
        private bool Needs(params SplitName[] required)
        {
            if (settings?.Splits == null || settings.Splits.Count == 0)
                return false;

            var usedSplitNames = new HashSet<SplitName>();

            foreach (var split in settings.Splits)
            {
                usedSplitNames.Add(split.SplitName);

                foreach (var conditionSplit in SubnauticaComponent.GetAllConditions(split))
                    usedSplitNames.Add(conditionSplit.SplitName);
            }
            return required.Any(usedSplitNames.Contains);
        }
        #endregion Memory stuff
        #region World/Player Checks
        public bool IsInMainMenu() => posX.Current == 0 && posZ.Current == 0 && posY.Current == 1.75f;

        private void UpdateBlueprints()
        {
            List<TechType> blueprints = new List<TechType>();
            IntPtr startAddr = knowntechPtr.New;

            int slotsOffset = gameVersion == GameVersion.Sept2018 ? 0x20 : 0x18;
            IntPtr slots = game.Process.ReadPointer(startAddr + slotsOffset);
            int countOffset = gameVersion == GameVersion.Sept2018 ? 0x40 : 0x30;
            int count = game.Process.ReadValue<int>(startAddr + countOffset);

            int slotBeginningOffset = 0x20;
            int slotSize = gameVersion == GameVersion.Sept2018 ? 0x4 : 0xC;
            for (int i = 0; i < count; i++)
            {
                int tech = game.Process.ReadValue<int>(slots + slotBeginningOffset + slotSize * i);
                if (tech > 0 && tech < 10005)
                {
                    TechType type = (TechType)tech;
                    blueprints.Add(type);
                }
            }

            KnownTechOld = KnownTech;
            KnownTech = blueprints;
        }
        
        private void UpdateInventory()
        {
            PlayerInventoryOld = PlayerInventory;
            PlayerInventory = ReadInventoryCounts();
            PlayerEquipmentOld = PlayerEquipment;
            PlayerEquipment = ReadEquipmentTypes();

            Dictionary<TechType, int> changedItems =
                PlayerInventory.Keys
                    .Union(PlayerInventoryOld.Keys)
                    .Union(PlayerEquipment)
                    .Union(PlayerEquipmentOld)
                    .Select(key =>
                    {
                        int newCount = GetPlayerItemCount(key);
                        int oldCount = GetPlayerItemCountOld(key);

                        return new
                        {
                            Key = key,
                            Delta = newCount - oldCount
                        };
                    })
                    .Where(x => x.Delta != 0)
                    .ToDictionary(x => x.Key, x => x.Delta);

            currentInventoryChanges = changedItems;

            TechType pickedUpItem = changedItems.FirstOrDefault(kvp => kvp.Value > 0).Key;
            TechType droppedItem = changedItems.FirstOrDefault(kvp => kvp.Value < 0).Key;

            foreach (var key in curPickUpCounts.Keys.ToList())
                if (curPickUpCounts[key].ElapsedTime.ElapsedMilliseconds > maxInventoryTimeWithoutChangingMs)
                {
                    var correspongingSplit = settings.Splits
                        .OfType<ItemSplit>()
                        .FirstOrDefault(s => s.Item.ConvertTo<TechType>() == key);

                    if (correspongingSplit != null)
                        correspongingSplit.AlreadySplitInvChanging = false;

                    curPickUpCounts.Remove(key);
                }


            foreach (var key in curDropCounts.Keys.ToList())
                if (curDropCounts[key].ElapsedTime.ElapsedMilliseconds > maxInventoryTimeWithoutChangingMs)
                {
                    var correspongingSplit = settings.Splits
                        .OfType<ItemSplit>()
                        .FirstOrDefault(s => s.Item.ConvertTo<TechType>() == key);

                    if (correspongingSplit != null)
                        correspongingSplit.AlreadySplitInvChanging = false;

                    curDropCounts.Remove(key);
                }

            foreach (var changedItem in changedItems)
            {
                if (changedItem.Value > 0)
                    HandleChange(curPickUpCounts, changedItem.Key, changedItem.Value);
                else
                    HandleChange(curDropCounts, changedItem.Key, changedItem.Value);
            }
            

            void HandleChange(Dictionary<TechType, InvChangeInfo> dict,
                      TechType key,
                      int amount)
            {
                if (dict.TryGetValue(key, out var info))
                {
                    info.Count += amount;
                    info.ElapsedTime.Restart();
                }
                else
                {
                    dict[key] = new InvChangeInfo(amount, Stopwatch.StartNew());
                }
            }
        }

        private bool HasPlayerItem(TechType techType) => PlayerInventory.ContainsKey(techType) || PlayerEquipment.Contains(techType);

        private int GetPlayerItemCount(TechType techType) => PlayerInventory.GetCount(techType) + PlayerEquipment.Count(item => item == techType);

        private int GetPlayerItemCountOld(TechType techType) => PlayerInventoryOld.GetCount(techType) + PlayerEquipmentOld.Count(item => item == techType);

        private void UpdateFlareThrowState()
        {
            bool isFlareTool = string.Equals(ActiveToolName.New, "flare", StringComparison.OrdinalIgnoreCase)
                || string.Equals(ActiveToolName.Old, "flare", StringComparison.OrdinalIgnoreCase);

            if (isFlareTool && TimeOfLastToolUseAnim.New != TimeOfLastToolUseAnim.Old)
            {
                flareThrowArmed = true;
                flareThrowArmedTime.Restart();
            }

            if (flareThrowArmed && flareThrowArmedTime.ElapsedMilliseconds > maxFlareThrowAnimWindowMs)
            {
                flareThrowArmed = false;
                flareThrowArmedTime.Reset();
            }
        }

        private bool IsFlareThrowDrop()
        {
            bool flareDropped = currentInventoryChanges.TryGetValue(TechType.Flare, out int delta) && delta < 0;
            if (!flareDropped)
            {
                return false;
            }

            bool split = flareThrowArmed && flareThrowArmedTime.ElapsedMilliseconds <= maxFlareThrowAnimWindowMs;
            flareThrowArmed = false;
            flareThrowArmedTime.Reset();
            return split;
        }

        private void UpdateEncyclopedia()
        {
            EncyclopediaOld = Encyclopedia;
            Encyclopedia = ReadPDAEncyMapping();
        }

        private bool IsWithinBounds(float[] bounds, bool old = false)
        {
            float x = old ? posX.Old : posX.Current;
            float y = old ? posY.Old : posY.Current;
            float z = old ? posZ.Old : posZ.Current;
            if (x >= Math.Min(bounds[0], bounds[1]) && x <= Math.Max(bounds[0], bounds[1]) &&
                y >= Math.Min(bounds[2], bounds[3]) && y <= Math.Max(bounds[2], bounds[3]) &&
                z >= Math.Min(bounds[4], bounds[5]) && z <= Math.Max(bounds[4], bounds[5]))
                return true;
            else
                return false;
        }

        public bool ShouldPause()
        {
            if (isInMainMenu)
            {
                _duringLoad.Reset();
                _afterLoad.Reset();
                return false;
            }

            if (!settings.SRCLoadtimes)
                return isPortalLoading.Current;

            if (isPortalLoading.Current && !isPortalLoading.Old)
            {
                _afterLoad.Reset();
                _duringLoad.Restart();
            }

            if (!isPortalLoading.Current && isPortalLoading.Old)
            {
                _duringLoad.Reset();
                _afterLoad.Restart();
            }

            if (isPortalLoading.Current)
            {
                if (!_duringLoad.IsRunning) _duringLoad.Restart();

                return _duringLoad.ElapsedMilliseconds >= prePortalDelayMs;
            }
            else
            {
                if (_afterLoad.IsRunning)
                {
                    if (_afterLoad.ElapsedMilliseconds < postPortalDelayMs)
                        return true;

                    _afterLoad.Reset();
                    return false;
                }

                return false;
            }
        }

        List<TechType> ReadEquipmentTypes()
        {
            var result = new List<TechType>();

            IntPtr invMain = game.Read<IntPtr>(mono.GetStaticAddress(invStaticKlass) + invStaticOffset);
            if (invMain == IntPtr.Zero) return result;

            IntPtr equipment = game.Read<IntPtr>(invMain + off_equipment);
            if (equipment == IntPtr.Zero) return result;

            IntPtr dict = game.Read<IntPtr>(equipment + off_equippedCount);
            if (dict == IntPtr.Zero) return result;

            // modern layout for Dictionary<TechType, int>
            if (!useLegacyDict)
            {
                for (int attempt = 0; attempt < 3; attempt++)
                {
                    int verBefore = (dict_off_version != 0) ? game.Read<int>(dict + dict_off_version) : 0;

                    IntPtr entriesArr = game.Read<IntPtr>(dict + dict_off_entries);
                    if (entriesArr == IntPtr.Zero) break;

                    int len = game.Read<int>(entriesArr + arr_off_len);
                    if (len <= 0 || len > 200000) break;

                    IntPtr basePtr = entriesArr + arr_data_base;

                    const int stride = 16;

                    // [0x00]=hashCode(int), [0x04]=next(int), [0x08]=key(int), [0x0C]=value(int)
                    for (int i = 0; i < len; i++)
                    {
                        IntPtr entry = basePtr + i * stride;

                        int hashCode = game.Read<int>(entry + 0x00);
                        if (hashCode < 0) continue;

                        int keyInt = game.Read<int>(entry + 0x08);
                        int count = game.Read<int>(entry + 0x0C);

                        if (keyInt > 0 && count > 0)
                        {
                            for (int item = 0; item < count; item++)
                                result.Add((TechType)keyInt);
                        }
                    }

                    int verAfter = (dict_off_version != 0) ? game.Read<int>(dict + dict_off_version) : verBefore;
                    if (verAfter == verBefore)
                    {
                        return result;
                    }

                    result.Clear();
                }
            }

            IntPtr keyArr = legacy_off.off_keySlots != 0 ? game.Read<IntPtr>(dict + legacy_off.off_keySlots) : IntPtr.Zero;
            IntPtr valArr = legacy_off.off_valSlots != 0 ? game.Read<IntPtr>(dict + legacy_off.off_valSlots) : IntPtr.Zero;
            if (keyArr == IntPtr.Zero || valArr == IntPtr.Zero) return result;

            IntPtr linkArr = IntPtr.Zero;
            if (legacy_off.off_linkSlots != 0)
                linkArr = game.Read<IntPtr>(dict + legacy_off.off_linkSlots);

            int touched = 0;
            if (legacy_off.off_touched != 0)
                touched = game.Read<int>(dict + legacy_off.off_touched);

            int keyLen = game.Read<int>(keyArr + arr_off_len);
            int valLen = game.Read<int>(valArr + arr_off_len);
            int upper = Math.Min(keyLen, valLen);

            if (touched > 0 && touched <= upper) upper = touched;
            if (upper <= 0 || upper > 200000) return result;

            IntPtr keyBase = keyArr + arr_data_base;
            IntPtr valBase = valArr + arr_data_base;
            IntPtr linkBase = linkArr != IntPtr.Zero ? linkArr + arr_data_base : IntPtr.Zero;

            const int linkStride = 8;

            for (int i = 0; i < upper; i++)
            {
                if (linkBase != IntPtr.Zero)
                {
                    int h = game.Read<int>(linkBase + i * linkStride);
                    if (h == 0) continue;
                }

                int keyInt = game.Read<int>(keyBase + i * 4);
                int count = game.Read<int>(valBase + i * 4);

                if (keyInt > 0 && count > 0)
                {
                    for (int item = 0; item < count; item++)
                        result.Add((TechType)keyInt);
                }
            }

            return result;
        }

        Dictionary<TechType, int> ReadInventoryCounts()
        {
            var result = new Dictionary<TechType, int>();

            IntPtr invMain = game.Read<IntPtr>(mono.GetStaticAddress(invStaticKlass) + invStaticOffset);
            if (invMain == IntPtr.Zero) return result;

            IntPtr container = game.Read<IntPtr>(invMain + off_container);
            if (container == IntPtr.Zero) return result;

            IntPtr dict = game.Read<IntPtr>(container + off_itemsDict);
            if (dict == IntPtr.Zero) return result;

            // modern layout (entries/_entries)
            if (!useLegacyDict)
            {
                // up to 3 tries to get a consistent snapshot
                for (int attempt = 0; attempt < 3; attempt++)
                {
                    int verBefore = (dict_off_version != 0) ? game.Read<int>(dict + dict_off_version) : 0;

                    IntPtr entriesArr = game.Read<IntPtr>(dict + dict_off_entries);
                    if (entriesArr == IntPtr.Zero) break;

                    int len = game.Read<int>(entriesArr + arr_off_len);
                    if (len <= 0 || len > 200000) break;

                    IntPtr basePtr = entriesArr + arr_data_base;

                    const int stride = 24;


                    // [0x00]=hashCode(int), [0x04]=next(int), [0x08]=key(int), [0x10]=value(ref)
                    for (int i = 0; i < len; i++)
                    {
                        IntPtr entry = basePtr + i * stride;

                        int hashCode = game.Read<int>(entry + 0x00);
                        if (hashCode < 0) continue;

                        int keyInt = game.Read<int>(entry + 0x08);
                        IntPtr pGroup = game.Read<IntPtr>(entry + 0x10);
                        if (pGroup == IntPtr.Zero) continue;

                        int id = (off_itemGroup_id != 0) ? game.Read<int>(pGroup + off_itemGroup_id) : keyInt;
                        if (id != keyInt) continue;

                        IntPtr pList = game.Read<IntPtr>(pGroup + off_itemGroup_items);
                        if (pList == IntPtr.Zero) continue;

                        int count = game.Read<int>(pList + off_list_size);
                        if ((uint)count > 100000) continue;

                        result[(TechType)keyInt] = count;
                    }

                    int verAfter = (dict_off_version != 0) ? game.Read<int>(dict + dict_off_version) : verBefore;
                    if (verAfter == verBefore)
                    {
                        return result;
                    }

                    result.Clear();
                }
            }

            // legacy layout (Unity 2018 mscorlib: keySlots/valueSlots[/linkSlots])
            if (!useLegacyDict)
            {
                //logger.Log("[Unity] Falling back to legacy Dictionary<> read (entries array missing).");
            }

            IntPtr keyArr = legacy_off.off_keySlots != 0 ? game.Read<IntPtr>(dict + legacy_off.off_keySlots) : IntPtr.Zero;
            IntPtr valArr = legacy_off.off_valSlots != 0 ? game.Read<IntPtr>(dict + legacy_off.off_valSlots) : IntPtr.Zero;
            if (valArr == IntPtr.Zero) return result;

            IntPtr linkArr = IntPtr.Zero;
            if (legacy_off.off_linkSlots != 0)
                linkArr = game.Read<IntPtr>(dict + legacy_off.off_linkSlots);

            // bounds
            int touched = 0;
            if (legacy_off.off_touched != 0)
                touched = game.Read<int>(dict + legacy_off.off_touched);

            int keyLen = keyArr != IntPtr.Zero ? game.Read<int>(keyArr + arr_off_len) : 0;
            int valLen = game.Read<int>(valArr + arr_off_len);
            int upper = valLen;

            if (touched > 0 && touched <= valLen) upper = touched;
            if (upper <= 0 || upper > 200000) return result;

            IntPtr keyBase = keyArr != IntPtr.Zero ? keyArr + arr_data_base : IntPtr.Zero;
            IntPtr valBase = valArr + arr_data_base;
            IntPtr linkBase = linkArr != IntPtr.Zero ? linkArr + arr_data_base : IntPtr.Zero;

            int ptrSize = IntPtr.Size;
            const int linkStride = 8;

            for (int i = 0; i < upper; i++)
            {
                if (linkBase != IntPtr.Zero)
                {
                    int h = game.Read<int>(linkBase + i * linkStride);
                    if (h == 0) continue;
                }

                IntPtr pGroup = game.Read<IntPtr>(valBase + i * ptrSize);
                if (pGroup == IntPtr.Zero) continue;

                int id = (off_itemGroup_id != 0) ? game.Read<int>(pGroup + off_itemGroup_id) : 0;

                int keyInt = id;
                if (keyBase != IntPtr.Zero)
                {
                    int k = game.Read<int>(keyBase + i * 4);
                    if (k == id) keyInt = k;
                }

                IntPtr pList = game.Read<IntPtr>(pGroup + off_itemGroup_items);
                if (pList == IntPtr.Zero) continue;

                int count = game.Read<int>(pList + off_list_size);
                if ((uint)count > 100000) continue;

                if (keyInt != 0)
                    result[(TechType)keyInt] = count;
            }
            return result;
        }
        public List<EncyEntry> ReadPDAEncyMapping()
        {
            var result = new List<EncyEntry>();

            IntPtr dict = pdaMappingPtr.New;
            if (dict == IntPtr.Zero)
                return result;

            int strHeader = game.PointerSize * 2 + 0x4;
            int ptrSize = game.PointerSize;

            // modern layout (entries/_entries)
            if (!useLegacyDict)
            {
                // up to 3 tries to get a consistent snapshot
                for (int attempt = 0; attempt < 3; attempt++)
                {
                    int verBefore = (dict_off_version != 0) ? game.Read<int>(dict + dict_off_version) : 0;

                    IntPtr entriesArr = game.Read<IntPtr>(dict + dict_off_entries);
                    if (entriesArr == IntPtr.Zero)
                        break;

                    int len = game.Read<int>(entriesArr + arr_off_len);
                    if (len <= 0 || len > 200000)
                        break;

                    IntPtr basePtr = entriesArr + arr_data_base;
                    const int stride = 24;

                    // [0x00]=hashCode(int), [0x04]=next(int), [0x08]=key(int), [0x10]=value(ref)
                    for (int i = 0; i < len; i++)
                    {
                        IntPtr entry = basePtr + i * stride;

                        int hashCode = game.Read<int>(entry + 0x00);
                        if (hashCode < 0)
                            continue;

                        IntPtr pKey = game.Read<IntPtr>(entry + 0x08);
                        IntPtr pVal = game.Read<IntPtr>(entry + 0x10); // PDAEncyclopedia.EntryData*
                        if (pKey == IntPtr.Zero || pVal == IntPtr.Zero)
                            continue;

                        string key = game.ReadString(pKey + strHeader, EStringType.UTF16Sized);
                        if (!string.IsNullOrEmpty(key))
                            if (Enum.TryParse(key, out EncyEntry encyEntry)) 
                                result.Add(encyEntry);
                    }

                    int verAfter = (dict_off_version != 0) ? game.Read<int>(dict + dict_off_version) : verBefore;
                    if (verAfter == verBefore)
                        return result;

                    result.Clear();
                }
            }

            // legacy layout (Unity 2018 mscorlib: keySlots/valueSlots[/linkSlots])
            {
                IntPtr keyArr = legacy_off.off_keySlots != 0 ? game.Read<IntPtr>(dict + legacy_off.off_keySlots) : IntPtr.Zero;
                IntPtr valArr = legacy_off.off_valSlots != 0 ? game.Read<IntPtr>(dict + legacy_off.off_valSlots) : IntPtr.Zero;
                if (valArr == IntPtr.Zero)
                    return result;

                IntPtr linkArr = IntPtr.Zero;
                if (legacy_off.off_linkSlots != 0)
                    linkArr = game.Read<IntPtr>(dict + legacy_off.off_linkSlots);

                int touched = 0;
                if (legacy_off.off_touched != 0)
                    touched = game.Read<int>(dict + legacy_off.off_touched);

                int keyLen = keyArr != IntPtr.Zero ? game.Read<int>(keyArr + arr_off_len) : 0;
                int valLen = game.Read<int>(valArr + arr_off_len);
                int upper = valLen;

                if (touched > 0 && touched <= valLen) upper = touched;
                if (upper <= 0 || upper > 200000) return result;

                IntPtr keyBase = keyArr != IntPtr.Zero ? keyArr + arr_data_base : IntPtr.Zero;
                IntPtr valBase = valArr + arr_data_base;
                IntPtr linkBase = linkArr != IntPtr.Zero ? linkArr + arr_data_base : IntPtr.Zero;

                const int linkStride = 8;

                for (int i = 0; i < upper; i++)
                {
                    if (linkBase != IntPtr.Zero)
                    {
                        int h = game.Read<int>(linkBase + i * linkStride);
                        if (h == 0) continue;
                    }

                    IntPtr pVal = game.Read<IntPtr>(valBase + i * ptrSize);
                    if (pVal == IntPtr.Zero) continue;

                    if (keyBase != IntPtr.Zero)
                    {
                        IntPtr pKey = game.Read<IntPtr>(keyBase + i * ptrSize);
                        if (pKey == IntPtr.Zero) continue;

                        string key = game.ReadString(pKey + strHeader, EStringType.UTF16Sized);
                        if (!string.IsNullOrEmpty(key))
                            if (Enum.TryParse(key, out EncyEntry encyEntry))
                                result.Add(encyEntry);
                    }
                }
            }

            return result;
        }
        #endregion
        #region Bounds
        // xmin, xmax, ymin, ymax, zmin, zmax
        private readonly float[] teethBounds = { -212f, 27f, -100f, 100f, 159f, 177f };
        private readonly float[] auroraExitBounds = { 545f, 550f, -10f, 10f, -265f, 256f };
        private readonly float[] mountainBounds = { 475f, 534f, -510f, -191f, 745f, 810f };
        private readonly float[] PCFEntrBounds = { 216f, 224f, -1453f, -1445f, -276f, -267f };
        private readonly float[] portalBounds = { 240f, 250f, -1590f, -1580f, -2000f, 2000f };
        private readonly float[] gunBounds = { 359f, 365f, -75f, -66f, 1079f, 1085f };
        private readonly float[] upperTabletBounds = { 380f, 386f, 10f, 30f, 1084f, 1090f };
        private readonly float[] SGLBaseBounds = { 20f, 80f, -45f, -17f, 290f, 360f };
        private readonly float[] deathClipABounds = { 33f, 65f, -20f, -8f, 118f, 96f };
        private readonly float[] deathClipCBounds = { -155f, -133f, -20f, -10f, 73f, 96f };
        private readonly float[] enterClipABounds = { 48f, 55f, -20f, -5f, 106f, 111f };
        private readonly float[] enterClipCBounds = { -144f, -132f, -20f, -5f, 78f, 90f };
        #endregion
    }

    public class InvChangeInfo
    {
        public int Count { get; set; }
        public Stopwatch ElapsedTime { get; }

        public InvChangeInfo(int count, Stopwatch elapsedTime)
        {
            Count = count;
            ElapsedTime = elapsedTime ?? throw new ArgumentNullException(nameof(elapsedTime));
        }
    }
}
