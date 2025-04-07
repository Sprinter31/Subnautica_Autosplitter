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
    int IsCured:                           0x1445E08, 0xA8, 0x58, 0x110, 0x180, 0x160, 0x190, 0x20, 0xA58;//1059857727 = true //alt: 0x1445DF8, 0xA8, 0x58, 0x110, 0x180, 0x160, 0x190, 0x20, 0xA58;
    int IsRocketGo:            "mono.dll", 0x27EAD8, 0x40, 0x70, 0x50, 0x90, 0x30, 0x8, 0x80;
    int Oxygen:                            0x142ADA8, 0x8, 0x10, 0x30, 0x30, 0x18, 0x28, 0x70;
    int IsMovingX:                         0x13940D8, 0x840; //0 = false
    int IsMovingZ:                         0x1443878, 0x8, 0x358, 0x3A8, 0x280, 0x2A8; //false = 0
    float XCoord:                          0x142B8C8, 0x180, 0x40, 0xA8, 0x7C0; // 0 in menu
    float YCoord:                          0x142B8C8, 0x180, 0x40, 0xA8, 0x7C4; //1.75 in menu
    float ZCoord:                          0x142B8C8, 0x180, 0x40, 0xA8, 0x7C8; // 0 in menu
    bool died:                             0x13B0650, 0x358, 0x8, 0x38, 0x0, 0x0, 0x108, 0x14;
    string128 Biome:                       0x142b908, 0x180, 0x128, 0x80, 0x1d0, 0x8, 0x248, 0x1d0, 0x14;
} 

state("Subnautica", "March 2023")
{
    bool introCinematicActive: "UnityPlayer.dll", 0x179B680, 0x88, 0x198, 0x338, 0x30, 0x28, 0x28, 0x87;
    bool NotMainMenu:          "UnityPlayer.dll", 0x18AB130, 0x48, 0x0, 0x6C;
    bool IsLoadingScreen:      "UnityPlayer.dll", 0x18AB2E0, 0x430, 0x8, 0x10, 0x48, 0x30, 0x7AC;
    bool IsAnimationPlaying:   "UnityPlayer.dll", 0x17FBE70, 0x8, 0x10, 0x30, 0x58, 0x28, 0x284;
    bool IsPortalLoading:      "UnityPlayer.dll", 0x17FBE70, 0x10, 0x10, 0x30, 0x1F8, 0x28, 0x28;
    bool IsEggsHatching:        "fmodstudio.dll", 0x2CED70, 0x78, 0x18, 0x190, 0x4D8, 0xB0, 0x20, 0x28;
    bool IsNotInWater:         "UnityPlayer.dll", 0x183AAD8, 0x5C0;
    int IsFabiMenu:         "mono-2.0-bdwgc.dll", 0x499C40, 0xE84;
    int IsPDAOpen:          "mono-2.0-bdwgc.dll", 0x499C40, 0xE84; // true = 1051931443, false = 1056964608    
    int IsCured:                "fmodstudio.dll", 0x2CED70, 0x78, 0x18, 0x190, 0x550, 0xB8, 0x20, 0x58;   
    int IsRocketGo:            "UnityPlayer.dll", 0x17FC238, 0x10, 0x3C; //256 = true
    int Oxygen:                "UnityPlayer.dll", 0x184DDD0, 0x60, 0x0, 0x0, 0x8, 0x38, 0x20, 0x30, 0x70;
    int IsMovingX:             "UnityPlayer.dll", 0x17FBC28, 0x30, 0x98; //false = 0
    int IsMovingZ:             "UnityPlayer.dll", 0x17FBC28, 0x30, 0x150; //false = 0
    float XCoord:              "UnityPlayer.dll", 0x17F2E30, 0x150, 0xA58; // 0 in menu
    float YCoord:              "UnityPlayer.dll", 0x17F2E30, 0x150, 0xA5C; //1.75 in menu
    float ZCoord:              "UnityPlayer.dll", 0x17F2E30, 0x150, 0xA60; // 0 in menu
    bool died:                 "UnityPlayer.dll", 0x17FBE70, 0x8, 0x10, 0x30, 0x318, 0x28, 0x50;
    string128 Biome:           "UnityPlayer.dll", 0x17fbe70, 0x8, 0x10, 0x30, 0x58, 0x28, 0x1f0, 0x14;
}

startup
{   
    vars.categoryName = timer.Run.CategoryName.ToString();

    settings.Add("reset", false, "Reset");
    settings.Add("load", true, "SRC loadtimes");
    settings.SetToolTip("reset", "Resets when you come back to the main menu and might randomly reset when you drop a lead?(needs more testing)\nBoth reset check boxes have to be checked for the reset to work");
    settings.SetToolTip("load", "This will add time to the actual load times to match the IGT shown on Speedrun.com (can be up to 0.1s inaccurate)");
    
    if(vars.categoryName.IndexOf("Creative", StringComparison.OrdinalIgnoreCase) >= 0 &&
       vars.categoryName.IndexOf("Any%", StringComparison.OrdinalIgnoreCase) >= 0)
       {
            settings.Add("Start");
            settings.CurrentDefaultParent = "Start";
            settings.Add("MovedStart", true, "Start when you move");
            settings.Add("FabricatorStart", true, "Start when you interact with the fabricator");
            settings.SetToolTip("FabricatorStart", "Only works on old patch for now");
            settings.Add("PDAStart", true, "Start when you open your PDA");

            settings.CurrentDefaultParent = null;
            settings.Add("Split");
            settings.CurrentDefaultParent = "Split";
            settings.Add("PCFSplit", true, "Split on PCF entrence tablet insert");
            settings.Add("PortalSplit", true, "Split on Portal entry");
            settings.Add("HatchSplit", false, "Split on hatching eggs");
            settings.Add("CureSplit", true, "Split on Cure");     
            settings.Add("GunSplit", true, "Split on Gun deactivation");
            settings.Add("RocketSplit", true, "Split on Rocket launch");
       }
       else if(vars.categoryName.IndexOf("Survival", StringComparison.OrdinalIgnoreCase) >= 0 &&
               vars.categoryName.IndexOf("Any%", StringComparison.OrdinalIgnoreCase) >= 0)
       {
            settings.Add("Start");
            settings.CurrentDefaultParent = "Start";
            settings.Add("IntroStart", true, "Start after the intro animation");
            settings.Add("OxygenStart", true, "Start when your oxygen sets to 45");
            settings.SetToolTip("IntroStart", "The intro needs to start for this to work so start by oxygen is better");
            settings.SetToolTip("OxygenStart", "Only in lifepod");

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
            settings.Add("SGLSparseSplit", true, "Split Sparse");
            settings.Add("SGLAuroraSplit", true, "Split Aurora");
            settings.SetToolTip("SGLBaseSplit", "Split when you enter your main base near the seaglide wreck for the first time");
            settings.SetToolTip("SGLShallowsSplit", "Split when you leave your main base with an extra O2 tank in your inv");
            settings.SetToolTip("SGLSparseSplit", "Split when the current biome changes from Sparse to shallows or kelp forest");
            settings.SetToolTip("SGLAuroraSplit", "Split when the current biome changes from Aurora to shallows or kelp forest");
       }
       else
       {
        settings.Add("Start");
        settings.CurrentDefaultParent = "Start";
        settings.Add("CreativeStarts", false, "Creative starts");
        settings.CurrentDefaultParent = "CreativeStarts";
        settings.Add("MovedStart", true, "Start when you move");
        settings.Add("FabricatorStart", true, "Start when you interact with the fabricator");
        settings.Add("PDAStart", true, "Start when you open your PDA");

        settings.CurrentDefaultParent = "Start";
        settings.Add("SurvivalStarts", false, "Survival starts");
        settings.CurrentDefaultParent = "SurvivalStarts";
        settings.Add("IntroStart", false, "Start after the intro animation");
        settings.Add("OxygenStart", true, "Start when your oxygen sets to 45");
    
        settings.CurrentDefaultParent = null;
        settings.Add("Split");
        settings.CurrentDefaultParent = "Split";
        settings.Add("GeneralSplits", true, "General splits");

        settings.CurrentDefaultParent = "GeneralSplits";
        settings.Add("HatchSplit", false, "Split on hatching eggs");
        settings.Add("CureSplit", false, "Split on Cure");
        settings.Add("RocketSplit", true, "Split on Rocket launch");
        settings.Add("DeathSplit", false, "Split on death");

        settings.CurrentDefaultParent = "Split";
        settings.Add("CreativeSplits", false, "Creative splits");
        settings.CurrentDefaultParent = "CreativeSplits";
        settings.Add("PCFSplit", true, "Split on PCF entrence tablet insert");
        settings.Add("PortalSplit", true, "Split on Portal entry");
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
        settings.Add("SGLSparseSplit", true, "Split Sparse");
        settings.Add("SGLAuroraSplit", true, "Split Aurora");

        settings.SetToolTip("reset", "Resets when you come back to the main menu and might randomly reset when you drop a lead?(needs more testing)\nBoth reset check boxes have to be checked for the reset to work");
        settings.SetToolTip("load", "This will add time to the actual load times to match the IGT shown on Speedrun.com (can be up to 0.1s inaccurate)");
        settings.SetToolTip("FabricatorStart", "Only works on old patch for now");
        settings.SetToolTip("IntroStart", "The intro needs to start for this to work so start by oxygen is better");
        settings.SetToolTip("OxygenStart", "Only in lifepod");
        settings.SetToolTip("SGBaseSplit", "Split when you die next to your main base(includes clip A and C)");
        settings.SetToolTip("SGTeethSplit", "Split when you leave the Kelp Forest with 1 or more Creepvine samples");
        settings.SetToolTip("SGAuroraSplit", "Split when you die in the Aurora");
        settings.SetToolTip("MountainSplit", "Split when you descend under the arch after getting out of bounds");
        settings.SetToolTip("ATPSplit", "Split when you die in the Alien Thermal Plant");
        settings.SetToolTip("GunDeathSplit", "Split when you die in the Alien Gun Room");
        settings.SetToolTip("SGSparseSplit", "Split when you die in the biomes: Sea Treader Path or Sparse Reef");
        settings.SetToolTip("SGLBaseSplit", "Split when you enter your main base near the seaglide wreck for the first time");
        settings.SetToolTip("SGLShallowsSplit", "Split when you leave your main base with an extra O2 tank in your inv");
        settings.SetToolTip("SGLSparseSplit", "Split when the current biome changes from sparse to shallows or kelp forest");
        settings.SetToolTip("SGLAuroraSplit", "Split when the current biome changes from aurora to shallows or kelp forest");
        }
        
    vars.StartedOxygenBefore = 0;
    vars.StartedBefore = 0;
    vars.CuredBefore = 0;
    vars.GunedBefore = 0;
    vars.DescendedBefore = 0;
    vars.EnteredBaseBefore = 0;
    vars.TeethBefore = 0;
    vars.ShallowsBefore = 0;
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
    vars.CuredBefore = 0;
    vars.GunedBefore = 0;
    vars.DescendedBefore = 0;
    vars.EnteredBaseBefore = 0;
    vars.TeethBefore = 0;
    vars.ShallowsBefore = 0;
    vars.counter = 0;
    vars.waitingFor1 = false;
    vars.waitingFor0 = false;
}

update
{
    //if(current.Oxygen != old.Oxygen)
    //print("oxygen: "+current.Oxygen + " StartedOxygenBefore: " + vars.StartedOxygenBefore + "\n" + "biome: "+current.Biome + "\n" + "NotMainMenu: " + current.NotMainMenu + "\n" + "");
    if(current.Biome != old.Biome){
        print("[Autosplitter] "+current.Biome);
    }
    //print("[Autosplitter] "+current.IsAnimationPlaying);
    //print("[Autosplitter] "+current.XCoord);
    //print("[Autosplitter] "+current.YCoord);
    //print("[Autosplitter] "+current.ZCoord);
    if(!current.NotMainMenu)
    {
        vars.StartedOxygenBefore = 0;
        vars.CuredBefore = 0;
        vars.StartedBefore = 0;
    }
}

start
{
    if(settings["IntroStart"] && !current.introCinematicActive && old.introCinematicActive)
    {
        print("[Autosplitter] start of intro");
        return true;
    }
    if(settings["OxygenStart"] && current.Oxygen == 45 && old.Oxygen != current.Oxygen && vars.StartedOxygenBefore == 0)
    {
        print("[Autosplitter] start of oxygen");
        vars.StartedOxygenBefore = 1;
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
    if(settings["SGTeethSplit"] && vars.TeethBefore == 0)
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
            print("[Autosplitter] itemID " + i + ".: "+ itemID);
            if(itemID == 2529)//id for creepvine sample
            {
                vars.TeethBefore = 1;
                return true;
            }
        }
        }
    }
    if(settings["SGLShallowsSplit"] && vars.ShallowsBefore == 0 && !current.IsNotInWater && old.IsNotInWater)
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
            print("[Autosplitter] itemID " + i + ".: "+ itemID);
            if(itemID == 503 || itemID == 528)//id for standard and double o2 tank
            {
                vars.ShallowsBefore = 1;
                return true;
            }
        }
    }

    if(settings["PCFSplit"] && current.IsAnimationPlaying && current.IsAnimationPlaying != old.IsAnimationPlaying)
    {
        var IsWithinBounds = vars.IsWithinBoundsFunc(216, 224, -1445, -1452, -267, -276, current.XCoord, current.YCoord, current.ZCoord);
        if(IsWithinBounds)
        {
            print("[Autosplitter] PCF split");
            return true;
        }        
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

    if(settings["CureSplit"] && current.IsCured != old.IsCured && vars.CuredBefore == 0)
    {
        if(current.IsCured == 1059857727 || current.IsCured == 1)
        {
            print("[Autosplitter] Cure split");
            vars.CuredBefore = 1;
            return true;
        }          
    }

    if(settings["GunSplit"] && current.IsAnimationPlaying && current.IsAnimationPlaying != old.IsAnimationPlaying && vars.GunedBefore == 0)
    {        
        var IsWithinBounds = vars.IsWithinBoundsFunc(359, 365, -66, -75, 1079, 1085, current.XCoord, current.YCoord, current.ZCoord);     
        if(IsWithinBounds)
        {                  
            print("[Autosplitter] Gun split");
            vars.GunedBefore = 1;
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

    
    if(settings["MountainSplit"] && vars.DescendedBefore == 0)
    {
        var IsWithinBounds = vars.IsWithinBoundsFunc(521, 534, -190.6f, -210, 764.3f, 796.4f, current.XCoord, current.YCoord, current.ZCoord);
        if(IsWithinBounds)
        {
            print("[Autosplitter] Mountain split");
            vars.DescendedBefore = 1;
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

    if(settings["SGLBaseSplit"] && current.IsNotInWater && current.IsNotInWater != old.IsNotInWater && vars.EnteredBaseBefore == 0)
    {
        var IsWithinBounds = vars.IsWithinBoundsFunc(20, 80, -45, -17, 290, 360, current.XCoord, current.YCoord, current.ZCoord);
        if(IsWithinBounds)
        {
            print("[Autosplitter] Base split 2023");
            vars.EnteredBaseBefore = 1;
            return true;
        }
    }

    if(settings["SGLSparseSplit"] && 
      (new[] { "sparseReef", "seaTreaderPath", "seaTreaderPath_wreck" }.Contains((string)old.Biome) && 
      (new[] { "safeShallows", "kelpForest" }.Contains((string)current.Biome))))
    {
        print("[Autosplitter] Sparse split 2023");
        return true;
    }
    if(settings["SGLAuroraSplit"] && old.Biome == "crashedShip" &&
       (new[] { "safeShallows", "kelpForest" }.Contains((string)current.Biome)))
    {
        print("[Autosplitter] Aurora split 2023");
        return true;
    }
}

reset
{
    if(settings["reset"] && !current.NotMainMenu && old.NotMainMenu && current.IsPDAOpen == old.IsPDAOpen)
    {
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