state("Subnautica", "September 2018")
{
    //int GameMode:                        0x149E490, 0x28, 0x0, 0x10, 0xA0, 0x350, 0x20; //0-3, in menu it's 0 and also randomly changes to 0 when loading
    bool introCinematicActive:             0x142B908, 0x188, 0x150, 0xD0, 0x18, 0x1E8, 0x28, 0x86;
    bool NotMainMenu:          "mono.dll", 0x262A68, 0x80, 0xED8;
    bool IsLoadingScreen:      "mono.dll", 0x266180, 0x50, 0x2C0, 0x0, 0x30, 0x8, 0x18, 0x20, 0x10, 0x44;
    bool IsAnimationPlaying:               0x142B740, 0x8, 0x8, 0x10, 0x30, 0xD8, 0x28, 0x6C;
    bool IsPortalLoading:                  0x142B740, 0x8, 0x10, 0x30, 0x1F8, 0x28, 0x28;
    bool IsEggsHatching: "fmodstudio.dll", 0x304A30, 0x88, 0x18, 0x158, 0x498, 0x108;
    bool IsNotInWater:                     0x14BC6A0, 0x7C;
    int IsFabiMenu:            "mono.dll", 0x296BC8, 0x20, 0xA58, 0x20; // 2 means that the esc menu is open
    int IsPDAOpen:             "mono.dll", 0x2655E0, 0x40, 0x18, 0xA0, 0x920, 0x64; // true = 1051931443, false = 1056964608  
    int IsCured:                           0x1445E08, 0xA8, 0x58, 0x110, 0x180, 0x160, 0x1A0, 0x70, 0x5F8;//1059857727 = true //alt: 0x1445DF8, 0xA8, 0x58, 0x110, 0x180, 0x160, 0x190, 0x20, 0xA58;
    int IsRocketGo:            "mono.dll", 0x27EAD8, 0x40, 0x70, 0x50, 0x90, 0x30, 0x8, 0x80;
    int BPsUnlocked:                       0x142B8E8, 0x1C8, 0x58, 0x58, 0x128, 0x8, 0x18, 0x158, 0x48;
    int InventoryItemCount:    "mono.dll", 0x17FBE70, 0x8, 0x10, 0x30, 0x1A8, 0x28, 0x38, 0x94;//not working
    int Oxygen:                            0x142ADA8, 0x8, 0x10, 0x30, 0x30, 0x18, 0x28, 0x70;
    int IsMovingX:                         0x13940D8, 0x840;
    int IsMovingZ:                         0x1443878, 0x8, 0x358, 0x3A8, 0x280, 0x2A8;
    float XCoord:                          0x142B8C8, 0x180, 0x40, 0xA8, 0x7C0; // 0 in menu
    float YCoord:                          0x142B8C8, 0x180, 0x40, 0xA8, 0x7C4; //1.75 in menu
    float ZCoord:                          0x142B8C8, 0x180, 0x40, 0xA8, 0x7C8; // 0 in menu
    bool died:                             0x13B0650, 0x358, 0x8, 0x38, 0x0, 0x0, 0x108, 0x14;
    string128 Biome:                       0x142b908, 0x180, 0x128, 0x80, 0x1D0, 0x8, 0x248, 0x1D0, 0x14;
} 

state("Subnautica", "March 2023")
{
    bool introCinematicActive: "UnityPlayer.dll", 0x179B680, 0x88, 0x198, 0x338, 0x30, 0x28, 0x28, 0x87;
    bool NotMainMenu:          "UnityPlayer.dll", 0x18AB130, 0x48, 0x0, 0x6C;
    bool IsLoadingScreen:      "UnityPlayer.dll", 0x18AB2E0, 0x430, 0x8, 0x10, 0x48, 0x30, 0x7AC;
    bool IsAnimationPlaying:   "UnityPlayer.dll", 0x17FBE70, 0x8, 0x10, 0x30, 0x58, 0x28, 0x284;
    bool IsPortalLoading:      "UnityPlayer.dll", 0x17FBE70, 0x10, 0x10, 0x30, 0x1F8, 0x28, 0x28;
    bool IsEggsHatching:        "fmodstudio.dll", 0x2CED70, 0x78, 0x18, 0x190, 0x4D8, 0xB0, 0x20, 0x28;
    bool IsNotInWater:         "UnityPlayer.dll", 0x18AB130, 0x48, 0x0, 0x68;
    int IsFabiMenu:         "mono-2.0-bdwgc.dll", 0x499C40, 0xE84;
    int IsPDAOpen:          "mono-2.0-bdwgc.dll", 0x499C40, 0xE84; // true = 1051931443, false = 1056964608    
    int IsCured:                "fmodstudio.dll", 0x2CED70, 0x78, 0x18, 0x190, 0x550, 0xB8, 0x20, 0x58;   
    int IsRocketGo:            "UnityPlayer.dll", 0x17FC238, 0x10, 0x3C; //256 = true
    int BPsUnlocked:           "UnityPlayer.dll", 0x296BC8, 0x20, 0x928, 0x58, 0x38;// not working
    int InventoryItemCount:    "UnityPlayer.dll", 0x17FBE70, 0x8, 0x10, 0x30, 0x1A8, 0x28, 0x38, 0x94;
    int Oxygen:                "UnityPlayer.dll", 0x184DDD0, 0x60, 0x0, 0x0, 0x8, 0x38, 0x20, 0x30, 0x70;
    int IsMovingX:             "UnityPlayer.dll", 0x17FBC28, 0x30, 0x98; //false = 0
    int IsMovingZ:             "UnityPlayer.dll", 0x17FBC28, 0x30, 0x150; //false = 0
    float XCoord:              "UnityPlayer.dll", 0x1839CE0, 0x28, 0x10, 0x150, 0xA58; // 0 in menu
    float YCoord:              "UnityPlayer.dll", 0x1839CE0, 0x28, 0x10, 0x150, 0xA5C; //1.75 in menu
    float ZCoord:              "UnityPlayer.dll", 0x1839CE0, 0x28, 0x10, 0x150, 0xA60; // 0 in menu
    bool died:                 "UnityPlayer.dll", 0x17FBE70, 0x8, 0x10, 0x30, 0x318, 0x28, 0x50;
    string128 Biome:           "UnityPlayer.dll", 0x17fbe70, 0x8, 0x10, 0x30, 0x58, 0x28, 0x1f0, 0x14;
}

startup
{   
    vars.categoryName = timer.Run.CategoryName.ToString();
    if      (vars.categoryName.IndexOf("Creative", StringComparison.OrdinalIgnoreCase) >= 0 &&
             vars.categoryName.IndexOf("Any%", StringComparison.OrdinalIgnoreCase) >= 0)
    {
        vars.shortCategoryName = "Creative";
    }
    else if((vars.categoryName.IndexOf("Survival", StringComparison.OrdinalIgnoreCase) >= 0 &&
             vars.categoryName.IndexOf("Any%", StringComparison.OrdinalIgnoreCase) >= 0) || vars.categoryName == "LoadingScreen%")
    {
        vars.shortCategoryName = "Survival";
    }
    else if((vars.categoryName.IndexOf("Hardcore", StringComparison.OrdinalIgnoreCase) >= 0 &&
             vars.categoryName.IndexOf("Any%", StringComparison.OrdinalIgnoreCase) >= 0) || vars.categoryName.Contains("HC"))
    {
        vars.shortCategoryName = "Hardcore";
    }
    else
    {
        vars.shortCategoryName = "Unkown";
    }
    settings.Add("reset", false, "Reset");
    settings.Add("load", true, "SRC loadtimes");
    settings.SetToolTip("reset", "Resets when you come back to the main menu\nBoth reset check boxes have to be checked for the reset to work");
    settings.SetToolTip("load", "This will add time to the actual load times to match the IGT shown on Speedrun.com (can be up to 0.1s inaccurate)");

    
    switch((string)vars.shortCategoryName)
    {
        case "Creative":
            settings.Add("Start");
            settings.CurrentDefaultParent = "Start";
            settings.Add("MovedStart", true, "Start when you move");
            settings.Add("FabricatorStart", true, "Start when you interact with the fabricator");
            settings.SetToolTip("FabricatorStart", "Only works on old patch for now");
            settings.Add("PDAStart", true, "Start when you open your PDA");

            settings.CurrentDefaultParent = null;
            settings.Add("Split");
            settings.CurrentDefaultParent = "Split";
            settings.Add("PCFTabletSplit", true, "Split on PCF entrence tablet insert");
            settings.Add("PortalSplit", true, "Split on Portal entry");
            settings.Add("HatchSplit", false, "Split on hatching eggs");
            settings.Add("CureSplit", true, "Split on Cure");
            settings.Add("BoostersSplit", false, "Split on Boosters");
            settings.Add("FuelreserveSplit", false, "Split on Fuel Reserve");
            settings.SetToolTip("BoostersSplit", "cg only");
            settings.SetToolTip("FuelreserveSplit", "cg only");
            settings.Add("GunSplit", true, "Split on Gun deactivation");
            settings.Add("RocketSplit", true, "Split on Rocket launch");
            settings.SetToolTip("CureSplit", "WARNING: not consistant  yet");
        break;

        case "Survival":
            settings.CurrentDefaultParent = null;
            settings.Add("Split");
            settings.CurrentDefaultParent = "Split";
            settings.Add("RocketSplit", true, "Split on Rocket launch");
            settings.Add("Glitched", false, "Glitched");
            settings.CurrentDefaultParent = "Glitched";
            settings.Add("SGBaseSplit", true, "Split Base");
            settings.Add("SGTeethSplit", true, "Split Teeth"); 
            settings.Add("SGAuroraSplit", true, "Split Aurora");
            settings.Add("MountainSplit", true, "Split Mountain");
            settings.Add("ATPSplit", true, "Split Ion BP");
            settings.Add("HatchSplit", false, "Split on hatching eggs");
            settings.Add("CureSplit", false, "Split on Cure"); 
            settings.Add("GunDeathSplit", true, "Split Gun Death");
            settings.Add("SGSparseSplit", true, "Split Sparse");
            settings.SetToolTip("CureSplit", "WARNING: not consistant yet");
            settings.SetToolTip("SGBaseSplit", "Split when you die next to your main base(includes clip A and C)");
            settings.SetToolTip("SGTeethSplit", "Split when you leave the Kelp Forest with 1 or more Creepvine samples");
            settings.SetToolTip("SGAuroraSplit", "Split when you die in the Aurora");
            settings.SetToolTip("MountainSplit", "Split when you descend under the arch after getting out of bounds");
            settings.SetToolTip("ATPSplit", "Split when you die in the Alien Thermal Plant");
            settings.SetToolTip("GunDeathSplit", "Split when you die in the Alien Gun Room");
            settings.SetToolTip("SGSparseSplit", "Split when you die in the biomes: Sea Treader Path or Sparse Reef");

            settings.CurrentDefaultParent = "Split";
            settings.Add("Glitchless", false, "Glitchless");
            settings.CurrentDefaultParent = "Glitchless";
            settings.Add("SGLBaseSplit", true, "Split Base");
            settings.Add("SGLShallowsSplit", true, "Split Shallows");
            settings.Add("SGLUpperTabletSplit", true, "Split Upper Tablet");
            settings.Add("SGLIonSplit", true, "Split Ion BP");
            settings.Add("PCFSplits", true, "Split PCF");
            settings.CurrentDefaultParent = "PCFSplits";
            settings.Add("PCFTabletSplit", true, "Split on PCF entrence tablet insert");
            settings.Add("PCFPoolSplit", false, "Split when entering the aquarium from moonpool");
            settings.CurrentDefaultParent = "Glitchless";
            settings.Add("GunSplit", true, "Split on Gun deactivation");
            settings.Add("SGLSparseSplit", true, "Split Sparse");
            settings.Add("SGLAuroraSplit", true, "Split Aurora");
            settings.SetToolTip("SGLBaseSplit", "Split when you enter your main base near the seaglide wreck for the first time");
            settings.SetToolTip("SGLShallowsSplit", "Split when you leave your main base with an extra O2 tank in your inv");
            settings.SetToolTip("SGLUpperTabletSplit", "Split when you pick up the upper purple tablet that lies next to the gun entrence");
            settings.SetToolTip("SGLIonSplit", "Split when you unstuck in the Ion BP room");
            settings.SetToolTip("SGLSparseSplit", "Split when the current biome changes from Sparse to shallows or kelp forest");
            settings.SetToolTip("SGLAuroraSplit", "Split when the current biome changes from Aurora to shallows or kelp forest");
        break;

        case "Hardcore":
            settings.CurrentDefaultParent = null;
            settings.Add("Split");
            settings.CurrentDefaultParent = "Split";
            settings.Add("RocketSplit", true, "Split on Rocket launch");
            settings.Add("Glitched", false, "Glitched");
            settings.CurrentDefaultParent = "Glitched";
            settings.Add("SGTeethSplit", true, "Split Teeth"); 
            settings.Add("HCShallowsSplit", true, "Split Shallows");
            settings.Add("MountainSplit", true, "Split Mountain");
            settings.Add("HCIonSplit", true, "Split Ion BP");
            settings.Add("HatchSplit", false, "Split on hatching eggs");
            settings.Add("CureSplit", false, "Split on Cure"); 
            settings.Add("GunSplit2", true, "Split on Gun deactivation");
            settings.Add("HCAuroraSplit", true, "Split Aurora");
            settings.Add("HCSparseSplit", true, "Split Sparse");
            settings.SetToolTip("CureSplit", "WARNING: not consistant yet");
            settings.SetToolTip("SGTeethSplit", "Split when you leave the Kelp Forest with 1 or more Creepvine samples");
            settings.SetToolTip("MountainSplit", "Split when you descend under the arch after getting out of bounds");
            settings.SetToolTip("HCIonSplit", "Split when you grab the Ion BP");
            settings.SetToolTip("HCAuroraSplit", "Split when you exit the Aurora after unlocking the Rocket");
            settings.SetToolTip("HCSparseSplit", "Split when you enter your main base with a ruby (includes clip A and C)");

            settings.CurrentDefaultParent = "Split";
            settings.Add("Glitchless", false, "Glitchless");
            settings.CurrentDefaultParent = "Glitchless";
            settings.Add("SGLBaseSplit", true, "Split Base");
            settings.Add("SGLShallowsSplit", true, "Split Shallows");
            settings.Add("SGLUpperTabletSplit", true, "Split Upper Tablet");
            settings.Add("SGLIonSplit", true, "Split Ion BP");
            settings.Add("PCFSplits", true, "Split PCF");
            settings.CurrentDefaultParent = "PCFSplits";
            settings.Add("PCFTabletSplit", true, "Split on PCF entrence tablet insert");
            settings.Add("PCFPoolSplit", false, "Split when entering the aquarium from moonpool");
            settings.CurrentDefaultParent = "Glitchless";
            settings.Add("GunSplit", true, "Split on Gun deactivation");
            settings.Add("SGLSparseSplit", true, "Split Sparse");
            settings.Add("SGLAuroraSplit", true, "Split Aurora");
            settings.SetToolTip("SGLBaseSplit", "Split when you enter your main base near the seaglide wreck for the first time");
            settings.SetToolTip("SGLShallowsSplit", "Split when you leave your main base with an extra O2 tank in your inv");
            settings.SetToolTip("SGLUpperTabletSplit", "Split when you pick up the upper purple tablet that lies next to the gun entrence");
            settings.SetToolTip("SGLIonSplit", "Split when you unstuck in the Ion BP room");
            settings.SetToolTip("SGLSparseSplit", "Split when the current biome changes from Sparse to shallows or kelp forest");
            settings.SetToolTip("SGLAuroraSplit", "Split when the current biome changes from Aurora to shallows or kelp forest");
        break;
        
        default:
            settings.Add("Start");
            settings.CurrentDefaultParent = "Start";
            settings.Add("CreativeStarts", false, "Creative starts");
            settings.CurrentDefaultParent = "CreativeStarts";
            settings.Add("MovedStart", true, "Start when you move");
            settings.Add("FabricatorStart", true, "Start when you interact with the fabricator");
            settings.Add("PDAStart", true, "Start when you open your PDA");

            settings.CurrentDefaultParent = null;
            settings.Add("Split");
            settings.CurrentDefaultParent = "Split";
            settings.Add("GeneralSplits", true, "General splits");

            settings.CurrentDefaultParent = "GeneralSplits";
            settings.Add("PCFSplits", true, "Split PCF");
            settings.CurrentDefaultParent = "PCFSplits";
            settings.Add("PCFTabletSplit", true, "Split on PCF entrence tablet insert");
            settings.Add("PCFPoolSplit", false, "Split when entering the aquarium from moonpool");
            settings.CurrentDefaultParent = "GeneralSplits";
            settings.Add("HatchSplit", false, "Split on hatching eggs");
            settings.Add("CureSplit", false, "Split on Cure");
            settings.Add("RocketSplit", true, "Split on Rocket launch");
            settings.Add("DeathSplit", false, "Split on death");

            settings.CurrentDefaultParent = "Split";
            settings.Add("CreativeSplits", false, "Creative splits");
            settings.CurrentDefaultParent = "CreativeSplits";
            settings.Add("PortalSplit", true, "Split on Portal entry");
            settings.Add("BoostersSplit", false, "Split on Boosters");
            settings.Add("FuelreserveSplit", false, "Split on Fuel Reserve");
            settings.Add("GunSplit", true, "Split on Gun deactivation");

            settings.CurrentDefaultParent = "Split";
            settings.Add("SurvivalSplits", true, "Survival splits");
            settings.CurrentDefaultParent = "SurvivalSplits";
            settings.Add("Glitched", false, "Glitched");
            settings.CurrentDefaultParent = "Glitched";
            settings.Add("SGBaseSplit", true, "Split Base"); 
            settings.Add("SGTeethSplit", true, "Split Teeth"); 
            settings.Add("SGAuroraSplit", true, "Split Aurora");
            settings.Add("MountainSplit", true, "Split Mountain");
            settings.Add("ATPSplit", true, "Split Ion BP");
            settings.Add("GunDeathSplit", true, "Split Gun Death");
            settings.Add("SGSparseSplit", true, "Split Sparse");
            settings.CurrentDefaultParent = "SurvivalSplits";
            settings.Add("Glitchless", false, "Glitchless");
            settings.CurrentDefaultParent = "Glitchless";
            settings.Add("SGLBaseSplit", true, "Split Base");
            settings.Add("SGLShallowsSplit", true, "Split Shallows");
            settings.Add("SGLUpperTabletSplit", true, "Split Upper Tablet");
            settings.Add("SGLIonSplit", true, "Split Ion BP");
            settings.Add("SGLSparseSplit", true, "Split Sparse");
            settings.Add("SGLAuroraSplit", true, "Split Aurora");

            settings.SetToolTip("FabricatorStart", "Old patch only");
            settings.SetToolTip("SGBaseSplit", "Split when you die next to your main base(includes clip A and C)");
            settings.SetToolTip("SGTeethSplit", "Split when you leave the Kelp Forest with 1 or more Creepvine samples");
            settings.SetToolTip("SGAuroraSplit", "Split when you die in the Aurora");
            settings.SetToolTip("MountainSplit", "Split when you descend under the arch after getting out of bounds");
            settings.SetToolTip("ATPSplit", "Split when you die in the Alien Thermal Plant");
            settings.SetToolTip("GunDeathSplit", "Split when you die in the Alien Gun Room");
            settings.SetToolTip("SGSparseSplit", "Split when you die in the biomes: Sea Treader Path or Sparse Reef");
            settings.SetToolTip("SGLBaseSplit", "Split when you enter your main base near the seaglide wreck for the first time");
            settings.SetToolTip("SGLShallowsSplit", "Split when you leave your main base with an extra O2 tank in your inv");
            settings.SetToolTip("SGLUpperTabletSplit", "Split when you pick up the upper purple tablet that lies next to the gun entrence");
            settings.SetToolTip("SGLIonSplit", "Split when you unstuck in the Ion BP room");
            settings.SetToolTip("SGLSparseSplit", "Split when the current biome changes from sparse to shallows or kelp forest");
            settings.SetToolTip("SGLAuroraSplit", "Split when the current biome changes from aurora to shallows or kelp forest");
            settings.SetToolTip("CureSplit", "WARNING: not consistant yet");
        break;
    }

    vars.StartedOxygenBefore = false;
    vars.StartedBefore = false;
    vars.CuredBefore = false;
    vars.GunedBefore = false;
    vars.DescendedBefore = false;
    vars.EnteredBaseBefore = false;
    vars.TeethBefore = false;
    vars.ShallowsBefore = false;
    vars.HCShallowsBefore = false;
    vars.HCSparseBefore = false;
    vars.FirstTimeAuroraHC = true;
    vars.oldBPsCount = 0;
    vars.counter = 0;
    
    vars.waitingFor1 = false;
    vars.waitingFor0 = false;

    vars.IsWithinBoundsFunc = (Func<float, float, float, float, float, float, float, float, float, bool>)((X1, X2, Y1, Y2, Z1, Z2, x, y, z) =>
    {
        if (x >= Math.Min(X1, X2) && x <= Math.Max(X1, X2) &&
            y >= Math.Min(Y1, Y2) && y <= Math.Max(Y1, Y2) &&
            z >= Math.Min(Z1, Z2) && z <= Math.Max(Z1, Z2))
        {
            return true;
        }
        else
        {
            return false;
        }
    }); 
}

init 
{
    int firstModuleSize = modules.First().ModuleMemorySize;
    print(firstModuleSize.ToString());
    switch (firstModuleSize)
    {
        case 23801856:
            version = "September 2018";
            print("[Autosplitter] Version is sept 2018");
            break;
        case 675840:
            version = "March 2023";
            print("[Autosplitter] Version is mar 2023");
            break;
        default:
            print("[Autosplitter] No valid version found");
            break;
    }
}

onStart
{
    vars.CuredBefore = false;
    vars.GunedBefore = false;
    vars.DescendedBefore = false;
    vars.EnteredBaseBefore = false;
    vars.TeethBefore = false;
    vars.ShallowsBefore = false;
    vars.HCShallowsBefore = false;
    vars.HCSparseBefore = false;
    vars.FirstTimeAuroraHC = true;
    vars.oldBPsCount = 0;
    vars.counter = 0;
    vars.waitingFor1 = false;
    vars.waitingFor0 = false;
}

update
{
    print("[Autosplitter] "+current.InventoryItemCount);
    print("[Autosplitter] "+current.Biome);
    print("[Autosplitter] "+current.XCoord);
    print("[Autosplitter] "+current.YCoord);
    print("[Autosplitter] "+current.ZCoord);
    print("[Autosplitter] "+current.IsNotInWater);
    if(!current.NotMainMenu)
    {
        vars.StartedOxygenBefore = false;
        vars.StartedBefore = false;
    }
}

start
{
    if((!current.introCinematicActive && old.introCinematicActive) || (current.Oxygen == 45 && old.Oxygen != 45))
    {
        print("[Autosplitter] start of intro");
        return true;
    }

    if(!current.IsLoadingScreen && current.NotMainMenu)
    {
        if(settings["MovedStart"] && (current.IsMovingX != 0 && old.IsMovingX == 0 || current.IsMovingZ != 0 && old.IsMovingZ == 0))
        {
            print("[Autosplitter] start of move");
            vars.StartedBefore = 1;
            return true;
        }

        if(settings["FabricatorStart"] && current.IsFabiMenu == 1 && current.IsFabiMenu != old.IsFabiMenu)
        {
            print("[Autosplitter] start of fabbi");
            vars.StartedBefore = 1;
            return true;
        }

        if(settings["PDAStart"] && current.IsPDAOpen == 1051931443 && current.IsPDAOpen != old.IsPDAOpen)
        {
            print("[Autosplitter] start of pda");
            vars.StartedBefore = 1;
            return true;
        }
    } 
}   


split
{
    if(settings["SGTeethSplit"] && !vars.TeethBefore)//will make this shit a function
    {
        var IsWithinBounds = vars.IsWithinBoundsFunc(-212, 27, -100, 100, 159, 177, current.XCoord, current.YCoord, current.ZCoord);
        if(IsWithinBounds)
        {
        var baseAddr = modules.First(m => m.ModuleName == "mono.dll").BaseAddress;
        IntPtr ptr1 = memory.ReadPointer((IntPtr)(baseAddr + 0x296BC8));
        IntPtr ptr2 = memory.ReadPointer((IntPtr)(ptr1 + 0x20));
        IntPtr ptr3 = memory.ReadPointer((IntPtr)(ptr2 + 0xA40));
        IntPtr ptr4 = memory.ReadPointer((IntPtr)(ptr3 + 0x0));
        IntPtr ptr5 = memory.ReadPointer((IntPtr)(ptr4 + 0x40));
        IntPtr ptr6 = memory.ReadPointer((IntPtr)(ptr5 + 0x58));
        IntPtr ptr7 = memory.ReadPointer((IntPtr)(ptr6 + 0x20));
        IntPtr finalAddr = (IntPtr)(ptr7 + 0x18);//address of mercuryOre, 0x8 begins the inventory
        IntPtr startAddr = (IntPtr)(finalAddr + 0x8);//inventory begins here and each item takes up 0x4 after

        for (int i = 0; i < 48; i++)
        {
            int itemID = memory.ReadValue<int>((IntPtr)startAddr + 0x4*i);
            print("[Autosplitter] TeethitemID " + i + ".: "+ itemID);
            if(itemID == 2529)//id for creepvine sample
            {
                print("[Autosplitter] Teeth split");
                vars.TeethBefore = true;
                return true;
            }
        }
        }
    }
    if(settings["SGLShallowsSplit"] && !vars.ShallowsBefore && !current.IsNotInWater && old.IsNotInWater)
    {
        var baseAddr = modules.First(m => m.ModuleName == "UnityPlayer.dll").BaseAddress;
        IntPtr ptr1 = memory.ReadPointer((IntPtr)(baseAddr + 0x17FBE70));
        IntPtr ptr2 = memory.ReadPointer((IntPtr)(ptr1 + 0x8));
        IntPtr ptr3 = memory.ReadPointer((IntPtr)(ptr2 + 0x10));
        IntPtr ptr4 = memory.ReadPointer((IntPtr)(ptr3 + 0x30));
        IntPtr ptr5 = memory.ReadPointer((IntPtr)(ptr4 + 0x1A8));
        IntPtr ptr6 = memory.ReadPointer((IntPtr)(ptr5 + 0x28));
        IntPtr ptr7 = memory.ReadPointer((IntPtr)(ptr6 + 0x38));
        IntPtr ptr8 = memory.ReadPointer((IntPtr)(ptr7 + 0x58));
        IntPtr ptr9 = memory.ReadPointer((IntPtr)(ptr8 + 0x18));
        IntPtr finalAddr = (IntPtr)(ptr9 + 0x18);//address of mercuryOre 0x8 begins the inventory
        IntPtr startAddr = (IntPtr)(finalAddr + 0x8);//inventory begins here and each item takes up 0x18 after

        for (int i = 0; i < 48; i++)
        {
            int itemID = memory.ReadValue<int>((IntPtr)startAddr + 0x18*i);
            print("[Autosplitter] SGLitemID " + i + ".: "+ itemID);
            if(itemID == 528)//id for double o2 tank
            {
                print("[Autosplitter] SGL Shallows split");
                vars.ShallowsBefore = true;
                return true;
            }
        }
    }
    if(settings["HCSparseSplit"] && current.IsAnimationPlaying && !old.IsAnimationPlaying)
    {
        var IsWithinBoundsClipC = vars.IsWithinBoundsFunc(-142, -132, -20, -5, 82, 90, current.XCoord, current.YCoord, current.ZCoord);
        var IsWithinBoundsClipA = vars.IsWithinBoundsFunc(-48, -55, -20, -5, 106, 111, current.XCoord, current.YCoord, current.ZCoord);
        if((IsWithinBoundsClipC || IsWithinBoundsClipA) && !vars.HCSparseBefore)
        {
            var baseAddr = modules.First(m => m.ModuleName == "mono.dll").BaseAddress;
            IntPtr ptr1 = memory.ReadPointer((IntPtr)(baseAddr + 0x296BC8));
            IntPtr ptr2 = memory.ReadPointer((IntPtr)(ptr1 + 0x20));
            IntPtr ptr3 = memory.ReadPointer((IntPtr)(ptr2 + 0xA40));
            IntPtr ptr4 = memory.ReadPointer((IntPtr)(ptr3 + 0x0));
            IntPtr ptr5 = memory.ReadPointer((IntPtr)(ptr4 + 0x40));
            IntPtr ptr6 = memory.ReadPointer((IntPtr)(ptr5 + 0x58));
            IntPtr ptr7 = memory.ReadPointer((IntPtr)(ptr6 + 0x20));
            IntPtr finalAddr = (IntPtr)(ptr7 + 0x18);//address of mercuryOre, 0x8 begins the inventory
            IntPtr startAddr = (IntPtr)(finalAddr + 0x8);//inventory begins here and each item takes up 0x4 after

            for (int i = 0; i < 48; i++)
            {
                int itemID = memory.ReadValue<int>((IntPtr)startAddr + 0x4*i);
                print("[Autosplitter] HCSparse itemID " + i + ".: "+ itemID);
                if(itemID == 52)//id for ruby
                {
                    print("[Autosplitter] HC Sparse split");
                    vars.HCSparseBefore = true;
                    return true;
                }  
            }
        }
    }
    
    if(settings["PCFTabletSplit"] && current.IsAnimationPlaying && !old.IsAnimationPlaying)
    {
        var IsWithinBounds = vars.IsWithinBoundsFunc(216, 224, -1445, -1453, -267, -276, current.XCoord, current.YCoord, current.ZCoord);
        if(IsWithinBounds)
        {
            print("[Autosplitter] PCF Tablet split");
            return true;
        }        
    }
    if(settings["PCFPoolSplit"] && current.Biome == "Prison_Aquarium_Upper" && old.Biome == "Prison_Moonpool")
    {
        print("[Autosplitter] PCF Pool split");
        return true;
    }
    if(settings["PortalSplit"] && current.IsPortalLoading != old.IsPortalLoading && current.IsPortalLoading)
    {
        var IsWithinBounds = vars.IsWithinBoundsFunc(240, 250, -1580, -1590, -2000, 2000, current.XCoord, current.YCoord, current.ZCoord);
        if(IsWithinBounds)
        {
            print("[Autosplitter] Portal split");
            return true;
        }        
    }  

    if(settings["HatchSplit"] && current.IsEggsHatching && current.IsEggsHatching != old.IsEggsHatching)
    {   
        print("[Autosplitter] Hatch split");
        return true;
    }

    if(settings["CureSplit"] && current.IsCured != old.IsCured && !vars.CuredBefore)
    {
        if(current.IsCured == 1059857727 || current.IsCured == 1)
        {
            print("[Autosplitter] Cure split");
            vars.CuredBefore = true;
            return true;
        }          
    }

    if(settings["BoostersSplit"] && current.BPsUnlocked == 225 && old.BPsUnlocked == 224)
    {
        print("[Autosplitter] Boosters split");
        return true;
    }

    if(settings["FuelreserveSplit"] && current.BPsUnlocked == 226 && old.BPsUnlocked == 225)
    {
        print("[Autosplitter] Fuel reserve split");
        return true;
    }

    if((settings["GunSplit"] || settings["GunSplit2"]) && current.IsAnimationPlaying && current.IsAnimationPlaying != old.IsAnimationPlaying && !vars.GunedBefore)
    {        
        var IsWithinBounds = vars.IsWithinBoundsFunc(359, 365, -66, -75, 1079, 1085, current.XCoord, current.YCoord, current.ZCoord);     
        if(IsWithinBounds)
        {                  
            print("[Autosplitter] Gun split");
            vars.GunedBefore = true;
            return true;
        }            
    }

    if(settings["RocketSplit"] && current.IsRocketGo != old.IsRocketGo)
    {    
        if(current.IsRocketGo == 1 || current.IsRocketGo == 256 || current.IsRocketGo == 244)
        {
            print("[Autosplitter] Rocket split");
            return true;
        }           
    }

    if(settings["DeathSplit"] && current.died && !old.died)
    {        
        print("[Autosplitter] death split");
        return true;
    }


    if(settings["SGBaseSplit"] && current.died && current.died != old.died)
    {
        var IsWithinBoundsClipC = vars.IsWithinBoundsFunc(-155, -133, -20, -10, 96, 73, current.XCoord, current.YCoord, current.ZCoord);
        var IsWithinBoundsClipA = vars.IsWithinBoundsFunc(33, 65, -20, -8, 118, 96, current.XCoord, current.YCoord, current.ZCoord);
        if(IsWithinBoundsClipC || IsWithinBoundsClipA)
        {
            print("[Autosplitter] Base split 2018");
            return true;
        }
    }

    if(settings["SGAuroraSplit"] && current.died && current.died != old.died && current.Biome == "crashedShip")
    {
        print("[Autosplitter] Aurora split 2018");
        return true;
    }

    
    if(settings["MountainSplit"] && !vars.DescendedBefore)
    {
        var IsWithinBounds = vars.IsWithinBoundsFunc(521, 534, -190.6f, -210, 764.3f, 796.4f, current.XCoord, current.YCoord, current.ZCoord);
        if(IsWithinBounds)
        {
            print("[Autosplitter] Mountain split");
            vars.DescendedBefore = true;
            return true;
        }

    }

    if(settings["ATPSplit"] && current.died && current.died != old.died && 
      (new[] { "Precursor_LavaCastleBase", "ILZCastleChamber", "PrecursorThermalRoom" }.Contains((string)current.Biome)))
    {
        print("[Autosplitter] ATP split split");
        return true;
    }

    if(settings["GunDeathSplit"] && current.died && current.died != old.died && current.Biome == "Precursor_Gun_ControlRoom")
    {
        print("[Autosplitter] GunDeath split");
        return true;    
    }

    if(settings["SGSparseSplit"] && current.died && current.died != old.died &&
    (new[] { "sparseReef", "seaTreaderPath", "seaTreaderPath_wreck" }.Contains((string)current.Biome)))
    {
        print("[Autosplitter] Sparse split 2018");
        return true;
    }

    if(settings["SGLBaseSplit"] && current.IsNotInWater && current.IsNotInWater != old.IsNotInWater && vars.EnteredBaseBefore == false)
    {
        var IsWithinBounds = vars.IsWithinBoundsFunc(20, 80, -45, -17, 290, 360, current.XCoord, current.YCoord, current.ZCoord);
        if(IsWithinBounds)
        {
            print("[Autosplitter] Base split 2023");
            vars.EnteredBaseBefore = true;
            return true;
        }
    }
    if(settings["SGLUpperTabletSplit"] && current.InventoryItemCount > old.InventoryItemCount)
    {
        var IsWithinBounds = vars.IsWithinBoundsFunc(380, 386, 10, 30, 1084, 1090, current.XCoord, current.YCoord, current.ZCoord);
        if(IsWithinBounds)
        {
            print("[Autosplitter] Upper Tablet split");
            return true;
        }  
    }
    if(settings["SGLIonSplit"] && current.Biome == "PrecursorThermalRoom" && current.IsAnimationPlaying && !old.IsAnimationPlaying)
    {
        print("[Autosplitter] Ion split 2023");
        return true;
    }
    if(settings["SGLSparseSplit"] && 
      (new[] { "sparseReef", "seaTreaderPath", "seaTreaderPath_wreck" }.Contains((string)old.Biome) && 
      (new[] { "safeShallows", "kelpForest" }.Contains((string)current.Biome))))
    {
        print("[Autosplitter] Sparse split 2023");
        return true;
    }
    if(settings["SGLAuroraSplit"] && 
      (new[] { "crashedShip", "generatorRoom" }.Contains((string)old.Biome) &&
      (new[] { "safeShallows", "kelpForest" }.Contains((string)current.Biome))))
    {
        print("[Autosplitter] Aurora split 2023");
        return true;
    }

    if(settings["HCShallowsSplit"] && !vars.HCShallowsBefore)
    {
        var IsWithinBounds = vars.IsWithinBoundsFunc(-200, 130, -100, 50, 477, 479, current.XCoord, current.YCoord, current.ZCoord);
        if(IsWithinBounds)
        {
            vars.HCShallowsBefore = true;
            print("[Autosplitter] HC Shallows split");
            return true;
        }
    }
    if(settings["HCIonSplit"] && current.Biome == "PrecursorThermalRoom" && current.BPsUnlocked > old.BPsUnlocked)
    {
        print("[Autosplitter] Hardcore Ion split");
        return true;
    }
    if(settings["HCAuroraSplit"])
    {
        var IsWithinBounds = vars.IsWithinBoundsFunc(545, 550, -10, 10, -265, -256, current.XCoord, current.YCoord, current.ZCoord);
        if(IsWithinBounds)
        {
            if(vars.oldBPsCount < current.BPsUnlocked && !vars.FirstTimeAuroraHC)
            {
                vars.FirstTimeAuroraHC = true;
                print("[Autosplitter] Hardcore Aurora split");
                return true;
            }
            vars.oldBPsCount = current.BPsUnlocked;
            vars.FirstTimeAuroraHC = false;
        } 
    }
}

reset
{
    if(current.XCoord == 0 && current.ZCoord == 0 && current.YCoord == 1.75f && old.YCoord != current.YCoord)
    {
        print("reset of coords");
        return true;
    }
}



isLoading
{
    if(!settings["load"])
    {
        if(current.IsPortalLoading)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    else
    {
        if (current.IsPortalLoading && !old.IsPortalLoading)
        {
            var IsWithinBounds = vars.IsWithinBoundsFunc(240, 250, -1580, -1590, -2000, 2000, current.XCoord, current.YCoord, current.ZCoord);
            if(IsWithinBounds)
            {
                vars.waitingFor1 = true;
                vars.waitingFor0 = false;
                if(version == "September 2018")
                {
                    vars.counter = 29;
                }
                else
                {
                    vars.counter = 34;
                }
                
            }        
        }
        else if (!current.IsPortalLoading && old.IsPortalLoading)
        {
            vars.waitingFor0 = true;
            vars.waitingFor1 = false;
            if(version == "September 2018")
            {
                vars.counter = 22;
            }
            else
            {
                vars.counter = 0;
            }
        }

        if (vars.counter > 0)
        {
            vars.counter--;
        }
        else
        {
            if (vars.waitingFor1)
            {
                return true;
            }
            else if (vars.waitingFor0)
            {
                return false;
            }
        }
    }   
}
