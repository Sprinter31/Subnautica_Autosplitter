state("Subnautica", "September 2018")
{
    //int GameMode:                        0x149E490, 0x28, 0x0, 0x10, 0xA0, 0x350, 0x20; //0-3, in menu it's 0 and also randomly changes to 0 when loading
    int NotMainMenu:         "mono.dll", 0x262A68, 0x80, 0xED8;
    int IsFabiMenu:          "mono.dll", 0x296BC8, 0x20, 0xA58, 0x20; // 2 means that the esc menu is open
    int IsPDAOpen:           "mono.dll", 0x2655E0, 0x40, 0x18, 0xA0, 0x920, 0x64; // true = 1051931443, false = 1056964608  
    int IsLoadingScreen:     "mono.dll", 0x266180, 0x50, 0x2C0, 0x0, 0x30, 0x8, 0x18, 0x20, 0x10, 0x44;
    int IsCured:                         0x142B710, 0x38, 0x418, 0xE8, 0x20, 0x10, 0x10, 0xD8, 0x28, 0xA58;//1059857727 = true
    int IsAnimationPlaying:              0x142B908, 0x180, 0x128, 0x80, 0x1D0, 0x8, 0x248, 0x240; //used for gun split with coordinates
    int IsRocketGo:          "mono.dll", 0x27EAD8, 0x40, 0x70, 0x50, 0x90, 0x30, 0x8, 0x80;
    int IsPortalLoading:     "mono.dll", 0x296BC8, 0x20, 0x2A0, 0x0, 0xE8;
    int IsMovingX:                       0x13940D8, 0x840; //0 = false
    int IsMovingZ:                       0x1443878, 0x8, 0x358, 0x3A8, 0x280, 0x2A8; //false = 0
    float XCoord:                        0x142B8C8, 0x180, 0x40, 0xA8, 0x7C0; // 0 in menu
    float YCoord:                        0x142B8C8, 0x180, 0x40, 0xA8, 0x7C4; //1.75 in menu
    float ZCoord:                        0x142B8C8, 0x180, 0x40, 0xA8, 0x7C8; // 0 in menu
} 

state("Subnautica", "March 2023")
{
    int NotMainMenu:        "UnityPlayer.dll", 0x18AB130, 0x48, 0x0, 0x6C;
    int IsFabiMenu:      "mono-2.0-bdwgc.dll", 0x499C40, 0xE84;
    int IsPDAOpen:       "mono-2.0-bdwgc.dll", 0x499C40, 0xE84; //Alt: "UnityPlayer.dll", 0x17D80F0, 0x70, 0x118, 0xE94;
    int IsLoadingScreen:    "UnityPlayer.dll", 0x18AB2E0, 0x430, 0x8, 0x10, 0x48, 0x30, 0x7AC;
    int IsCured:             "fmodstudio.dll", 0x2CED70, 0x78, 0x18, 0x190, 0x550, 0xB8, 0x20, 0x58;
    int IsAnimationPlaying: "UnityPlayer.dll", 0x17FBE70, 0x8, 0x10, 0x30, 0x58, 0x28, 0x284;
    int IsRocketGo:         "UnityPlayer.dll", 0x17FC238, 0x10, 0x3C; //256 = true
    int IsPortalLoading:    "UnityPlayer.dll", 0x17FBE70, 0x10, 0x10, 0x30, 0x1F8, 0x28, 0x28;
    int IsMovingX:          "UnityPlayer.dll", 0x17FBC28, 0x30, 0x98; //false = 0
    int IsMovingZ:          "UnityPlayer.dll", 0x17FBC28, 0x30, 0x150; //false = 0
    float XCoord:           "UnityPlayer.dll", 0x17F2E30, 0x150, 0xA58; // 0 in menu
    float YCoord:           "UnityPlayer.dll", 0x17F2E30, 0x150, 0xA5C; //1.75 in menu
    float ZCoord:           "UnityPlayer.dll", 0x17F2E30, 0x150, 0xA60; // 0 in menu
}

startup
{   
    settings.Add("load", true, "SRC loadtimes");
    settings.SetToolTip("load", "This will add time to the actual load times to match the IGT shown on Speedrun.com (can be up to 0.1s inaccurate)");
    settings.Add("Start");
    settings.CurrentDefaultParent = "Start";
    settings.Add("Moved", true, "Start when you move");
    settings.Add("Fabricator", true, "Start when you interact with the fabricator");
    settings.SetToolTip("Fabricator", "Only works on old patch for now");
    settings.Add("PDA", true, "Start when you open your PDA");
    settings.CurrentDefaultParent = null;
    settings.Add("Split");
    settings.CurrentDefaultParent = "Split";
    settings.Add("PCF", true, "Split on PCF entrence tablet insert");
    settings.Add("Portal", true, "Split on Portal entry");
    settings.Add("Cure", true, "Split on Cure");
    settings.Add("Gun", true, "Split on Gun deactivation");
    settings.Add("Rocket", true, "Split on Rocket launch");
}

init 
{
    vars.StartedBefore = 0;
    vars.CuredBefore = 0;
    vars.GunedBefore = 0;
    vars.counter = 0;
    vars.waitingFor1 = false;
    vars.waitingFor0 = false;

    int firstModuleSize = modules.First().ModuleMemorySize;
    print(firstModuleSize.ToString());
    switch (firstModuleSize)
    {
        case 23801856:
            version = "September 2018";
            print("Version is sept 2018");
            break;
        case 671744:
            version = "December 2021";
            print("Version is dec 2021");
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
    vars.counter = 0;
    vars.waitingFor1 = false;
    vars.waitingFor0 = false;
}

update
{
    print(""+current.IsRocketGo);
    if(current.NotMainMenu == 0)
    {
        vars.CuredBefore = 0;
        vars.StartedBefore = 0;
    }
}

start
{
    if(vars.StartedBefore == 0 && current.NotMainMenu == 1)
    {
        if(settings["Moved"] && (current.IsMovingX != 0 && old.IsMovingX == 0) || (current.IsMovingZ != 0 && old.IsMovingZ == 0))
        {
            vars.StartedBefore = 1;
            return true;
        }
    }

    if(settings["Fabricator"] && current.IsFabiMenu == 1 && current.IsFabiMenu != old.IsFabiMenu)
    {
        vars.StartedBefore = 1;
        return true;
    }
    if(settings["PDA"] && current.IsPDAOpen == 1051931443 && current.IsPDAOpen != old.IsPDAOpen && current.IsLoadingScreen == 0)
    {
        vars.StartedBefore = 1;
        return true;
    }
}   


split
{   
    if(settings["PCF"] && current.IsAnimationPlaying == 1 && current.IsAnimationPlaying != old.IsAnimationPlaying)
    {
        if(current.XCoord > 216 && current.XCoord < 224)
        {   
            if(current.YCoord < -1445 && current.YCoord > -1452)
            {
                if(current.ZCoord < -267 && current.ZCoord > -276)
                print("PCF split");
                {
                    return true;
                }               
            }  
        }            
    }
        if(settings["Portal"] && current.IsPortalLoading != old.IsPortalLoading)    
        {
            if(current.IsPortalLoading == 1)
            {      
                if(current.XCoord > 240 && current.XCoord < 250)
                {
                    if(current.YCoord < -1580 && current.YCoord > -1590)
                    {
                        print("Portal split");
                        return true;
                    }  
                }      
            }         
        }  

        if(settings["Cure"] && current.IsCured != old.IsCured && vars.CuredBefore == 0)
        {
            if(current.IsCured == 1059857727 || current.IsCured == 1)
            {
                print("Cure split");
                vars.CuredBefore = 1;
                return true;
            }          
        }

        if(settings["Gun"] && current.IsAnimationPlaying == 1 && current.IsAnimationPlaying != old.IsAnimationPlaying && vars.GunedBefore == 0)
        {
            if(current.XCoord > 359 && current.XCoord < 365)
            {   
                if(current.YCoord < -66 && current.YCoord > -75)
                {
                    if(current.ZCoord > 1079 && current.ZCoord < 1085)
                    {
                        print("Gun split");
                        vars.GunedBefore = 1;
                        return true;
                    }               
                }  
            }            
        }

        if(settings["Rocket"] && current.IsRocketGo != old.IsRocketGo)
        {
            if(current.IsRocketGo == 1 || current.IsRocketGo == 256 || current.IsRocketGo == 244)
            {
                print("Rocket split");
                return true;
            }           
        }
}

reset
{
    if(settings.StartEnabled == true && current.NotMainMenu == 0 && current.NotMainMenu != old.NotMainMenu)
    {
        return true;
    } 
}



isLoading
{
    if(!settings["load"])
    {
        if(current.IsPortalLoading == 1)
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
    if (current.IsPortalLoading == 1 && old.IsPortalLoading == 0)
    {
        if(current.IsPortalLoading == 1)
            {      
                if(current.XCoord > 240 && current.XCoord < 250)
                {
                    if(current.YCoord < -1580 && current.YCoord > -1590)
                    {
                        vars.waitingFor1 = true;
                        vars.waitingFor0 = false;
                        vars.counter = 31;
                    }
                }
            }
    }
    else if (current.IsPortalLoading == 0 && old.IsPortalLoading == 1)
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