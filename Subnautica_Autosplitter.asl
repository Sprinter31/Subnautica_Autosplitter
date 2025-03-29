state("Subnautica", "September 2018")
{
    //int GameMode:                      0x149E490, 0x28, 0x0, 0x10, 0xA0, 0x350, 0x20; //0-3, in menu it's 0 and also randomly changes to 0 when loading
    bool introCinematicActive:           0x142B908, 0x188, 0x150, 0xD0, 0x18, 0x1E8, 0x28, 0x86;
    bool NotMainMenu:        "mono.dll", 0x262A68, 0x80, 0xED8;
    bool IsLoadingScreen:    "mono.dll", 0x266180, 0x50, 0x2C0, 0x0, 0x30, 0x8, 0x18, 0x20, 0x10, 0x44;
    bool IsAnimationPlaying:             0x142B908, 0x180, 0x128, 0x80, 0x1D0, 0x8, 0x248, 0x240;
    bool IsPortalLoading:    "mono.dll", 0x296BC8, 0x20, 0x2A0, 0x0, 0xE8;
    int IsFabiMenu:          "mono.dll", 0x296BC8, 0x20, 0xA58, 0x20; // 2 means that the esc menu is open
    int IsPDAOpen:           "mono.dll", 0x2655E0, 0x40, 0x18, 0xA0, 0x920, 0x64; // true = 1051931443, false = 1056964608  
    int IsCured:                         0x142B710, 0x38, 0x418, 0xE8, 0x20, 0x10, 0x10, 0xD8, 0x28, 0xA58;//1059857727 = true
    int IsRocketGo:          "mono.dll", 0x27EAD8, 0x40, 0x70, 0x50, 0x90, 0x30, 0x8, 0x80;
    int IsMovingX:                       0x13940D8, 0x840; //0 = false
    int IsMovingZ:                       0x1443878, 0x8, 0x358, 0x3A8, 0x280, 0x2A8; //false = 0
    float XCoord:                        0x142B8C8, 0x180, 0x40, 0xA8, 0x7C0; // 0 in menu
    float YCoord:                        0x142B8C8, 0x180, 0x40, 0xA8, 0x7C4; //1.75 in menu
    float ZCoord:                        0x142B8C8, 0x180, 0x40, 0xA8, 0x7C8; // 0 in menu
    bool died:                           0x13B0650, 0x358, 0x8, 0x38, 0x0, 0x0, 0x108, 0x14;
    string128 biome:                     0x142b908, 0x180, 0x128, 0x80, 0x1d0, 0x8, 0x248, 0x1d0, 0x14;
} 

state("Subnautica", "March 2023")
{
    bool introCinematicActive: "UnityPlayer.dll", 0x179B680, 0x88, 0x198, 0x338, 0x30, 0x28, 0x28, 0x87;
    bool NotMainMenu:          "UnityPlayer.dll", 0x18AB130, 0x48, 0x0, 0x6C;
    bool IsLoadingScreen:      "UnityPlayer.dll", 0x18AB2E0, 0x430, 0x8, 0x10, 0x48, 0x30, 0x7AC;
    bool IsAnimationPlaying:   "UnityPlayer.dll", 0x17FBE70, 0x8, 0x10, 0x30, 0x58, 0x28, 0x284;
    bool IsPortalLoading:      "UnityPlayer.dll", 0x17FBE70, 0x10, 0x10, 0x30, 0x1F8, 0x28, 0x28;
    int IsFabiMenu:         "mono-2.0-bdwgc.dll", 0x499C40, 0xE84;
    int IsPDAOpen:          "mono-2.0-bdwgc.dll", 0x499C40, 0xE84; // true = 1051931443, false = 1056964608    
    int IsCured:                "fmodstudio.dll", 0x2CED70, 0x78, 0x18, 0x190, 0x550, 0xB8, 0x20, 0x58;   
    int IsRocketGo:            "UnityPlayer.dll", 0x17FC238, 0x10, 0x3C; //256 = true
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
    settings.Add("reset", false, "Reset");
    settings.Add("load", true, "SRC loadtimes");
    
    settings.Add("Start");
    settings.CurrentDefaultParent = "Start";
    settings.Add("CreativeStarts", true, "Creative starts");
    settings.CurrentDefaultParent = "CreativeStarts";
    settings.Add("MovedStart", true, "Start when you move");
    settings.Add("FabricatorStart", true, "Start when you interact with the fabricator");
    settings.Add("PDAStart", true, "Start when you open your PDA");

    settings.CurrentDefaultParent = "Start";
    settings.Add("SurvivalStarts", true, "Survival starts");
    settings.CurrentDefaultParent = "SurvivalStarts";
    settings.Add("IntroStart", true, "Start after the intro animation");
    
    settings.CurrentDefaultParent = null;
    settings.Add("Split");
    settings.CurrentDefaultParent = "Split";
    settings.Add("GeneralSplits", true, "General splits");

    settings.CurrentDefaultParent = "GeneralSplits";
    settings.Add("HatchSplit", true, "Split on hatching eggs");
    settings.Add("CureSplit", true, "Split on Cure");
    settings.Add("GunSplit", true, "Split on Gun deactivation");
    settings.Add("RocketSplit", true, "Split on Rocket launch");

    settings.CurrentDefaultParent = "Split";
    settings.Add("CreativeSplits", true, "Creative splits");
    settings.CurrentDefaultParent = "CreativeSplits";
    settings.Add("PCFSplit", true, "Split on PCF entrence tablet insert");
    settings.Add("PortalSplit", true, "Split on Portal entry");

    settings.CurrentDefaultParent = "Split";
    settings.Add("SurvivalSplits", false, "Survival splits");
    settings.CurrentDefaultParent = "SurvivalSplits";
    settings.Add("BaseSplit", true, "Split Base"); 
    settings.Add("AuroraSplit", true, "Split Aurora");
    settings.Add("MountainSplit", true, "Split Mountain");
    settings.Add("ATPSplit", true, "Split Ion BP");
    settings.Add("GunDeathSplit", true, "Split Gun Death");
    settings.Add("SparseSplit", true, "Split Sparse");

    settings.SetToolTip("reset", "Resets when you come back to the main menu\nBoth reset check boxes have to be checked for the reset to work");
    settings.SetToolTip("load", "This will add time to the actual load times to match the IGT shown on Speedrun.com (can be up to 0.1s inaccurate)");
    settings.SetToolTip("FabricatorStart", "Only works on old patch for now");
    settings.SetToolTip("BaseSplit", "Split when you die next to your main base(includes clip A and C)");
    settings.SetToolTip("AuroraSplit", "Split when you die in the Aurora");
    settings.SetToolTip("MountainSplit", "Split when you descend under the arch after getting out of bounds");
    settings.SetToolTip("ATPSplit", "Split when you die in the Alien Thermal Plant");
    settings.SetToolTip("GunDeathSplit", "Split when you die in the Alien Gun Room");
    settings.SetToolTip("SparseSplit", "Split when you die in the biomes: Sea Treader Path or Sparse Reef");

    vars.StartedBefore = 0;
    vars.CuredBefore = 0;
    vars.GunedBefore = 0;
    vars.DescendedBefore = 0;
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
            print("Version is sept 2018");
            break;
        case 675840:
            version = "March 2023";
            print("Version is mar 2023");
            break;
        default:
            print("No valid version found");
            break;
    }
}

onStart
{
    vars.CuredBefore = 0;
    vars.GunedBefore = 0;
    vars.DescendedBefore = 0;
    vars.counter = 0;
    vars.waitingFor1 = false;
    vars.waitingFor0 = false;
}

update
{
    //print(""+current.IsCured);
    if(!current.NotMainMenu)
    {
        vars.CuredBefore = 0;
        vars.StartedBefore = 0;
    }
}

start
{
    if(settings["IntroStart"] && old.introCinematicActive && !current.introCinematicActive)
    {
        return true;
    }

    if(vars.StartedBefore == 0 && current.NotMainMenu)
    {
        if(settings["MovedStart"] && (current.IsMovingX != 0 && old.IsMovingX == 0 || current.IsMovingZ != 0 && old.IsMovingZ == 0))
        {
            vars.StartedBefore = 1;
            return true;
        }
    }

    if(settings["FabricatorStart"] && current.IsFabiMenu == 1 && current.IsFabiMenu != old.IsFabiMenu)
    {
        vars.StartedBefore = 1;
        return true;
    }

    if(settings["PDAStart"] && current.IsPDAOpen == 1051931443 && current.IsPDAOpen != old.IsPDAOpen && !current.IsLoadingScreen)
    {
        vars.StartedBefore = 1;
        return true;
    }
}   


split
{   
    if(settings["PCFSplit"] && current.IsAnimationPlaying && current.IsAnimationPlaying != old.IsAnimationPlaying)
    {
        var IsWithinBounds = vars.IsWithinBoundsFunc(216, 224, -1445, -1452, -267, -276, current.XCoord, current.YCoord, current.ZCoord);
        if(IsWithinBounds)
        {
            print("PCF split");
            return true;
        }        
    }
    if(settings["PortalSplit"] && current.IsPortalLoading != old.IsPortalLoading && current.IsPortalLoading)
    {
        var IsWithinBounds = vars.IsWithinBoundsFunc(240, 250, -1580, -1590, -2000, 2000, current.XCoord, current.YCoord, current.ZCoord);
        if(IsWithinBounds)
        {
            print("Portal split");
            return true;
        }        
    }  

    /*if(settings["HatchSplit"] && current.Hatched && current.Hatched != old.Hatched)
    {   
        return true;
    }*/

    if(settings["CureSplit"] && current.IsCured != old.IsCured && vars.CuredBefore == 0)
    {
        if(current.IsCured == 1059857727 || current.IsCured == 1)
        {
            print("Cure split");
            vars.CuredBefore = 1;
            return true;
        }          
    }

    if(settings["GunSplit"] && current.IsAnimationPlaying && current.IsAnimationPlaying != old.IsAnimationPlaying && vars.GunedBefore == 0)
    {        
        var IsWithinBounds = vars.IsWithinBoundsFunc(359, 365, -66, -75, 1079, 1085, current.XCoord, current.YCoord, current.ZCoord);     
        if(IsWithinBounds)
        {                  
            print("Gun split");
            vars.GunedBefore = 1;
            return true;
        }            
    }

    if(settings["RocketSplit"] && current.IsRocketGo != old.IsRocketGo)
    {    
        if(current.IsRocketGo == 1 || current.IsRocketGo == 256 || current.IsRocketGo == 244)
        {
            print("Rocket split");
            return true;
        }           
    }


    if(settings["BaseSplit"] && current.died && current.died != old.died)
    {
        var IsWithinBoundsClipC = vars.IsWithinBoundsFunc(-155, -133, -20, -10, 96, 73, current.XCoord, current.YCoord, current.ZCoord);
        var IsWithinBoundsClipA = vars.IsWithinBoundsFunc(33, 65, -20, -8, 106, 101.5f, current.XCoord, current.YCoord, current.ZCoord);
        if(IsWithinBoundsClipC || IsWithinBoundsClipA)
        {
            return true;
        }
    }

    if(settings["AuroraSplit"] && current.died && current.died != old.died && current.biome == "crashedShip")
    {
        return true;
    }

    
    if(settings["MountainSplit"] && vars.DescendedBefore == 0)
    {
        var IsWithinBounds = vars.IsWithinBoundsFunc(521, 534, -190.6f, -210, 764.3f, 796.4f, current.XCoord, current.YCoord, current.ZCoord);
        if(IsWithinBounds)
        {
            vars.DescendedBefore = 1;
            return true;
        }

    }

    if(settings["ATPSplit"] && current.died && current.died != old.died && 
      (new[] { "Precursor_LavaCastleBase", "ILZCastleChamber", "PrecursorThermalRoom" }.Contains((string)current.biome)))
    {
        return true;
    }

    if(settings["GunDeathSplit"] && current.died && current.died != old.died && current.biome == "Precursor_Gun_ControlRoom")
    {
        return true;    
    }

    if(settings["SparseSplit"] && current.died && current.died != old.died &&
    (new[] { "sparseReef", "seaTreaderPath", "seaTreaderPath_wreck" }.Contains((string)current.biome)))
    {
        return true;
    }
}

reset
{
    if(settings["reset"] && settings.StartEnabled == true && !current.NotMainMenu && current.NotMainMenu != old.NotMainMenu)
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
            //var IsWithinBounds = vars.IsWithinBoundsFunc(240, 250, -1580, -1590, -2000, 2000, current.XCoord, current.YCoord, current.ZCoord);
            //if(IsWithinBounds)
            //{
                vars.waitingFor1 = true;
                vars.waitingFor0 = false;
                if(version == "September 2018")
                {
                    vars.counter = 31;
                }
                else
                {
                    vars.counter = 34;
                }
                
            //}        
        }
        else if (!current.IsPortalLoading && old.IsPortalLoading)
        {
            vars.waitingFor0 = true;
            vars.waitingFor1 = false;
            if(version == "September 2018")
            {
                vars.counter = 20;
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