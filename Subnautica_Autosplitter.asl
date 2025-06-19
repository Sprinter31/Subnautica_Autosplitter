state("Subnautica", "September 2018")
{
    bool introCinematicActive:                    0x142B908, 0x188, 0x150, 0xD0, 0x18, 0x1E8, 0x28, 0x86;
    bool isLoadingScreen:             "mono.dll", 0x266180, 0x50, 0x2C0, 0x0, 0x30, 0x8, 0x18, 0x20, 0x10, 0x44;
    bool isAnimationPlaying:         "Subnautica", 0x142B740, 0x8, 0x8, 0x10, 0x30, 0xD8, 0x28, 0x6C;
    bool isPortalLoading:                         0x142B740, 0x8, 0x10, 0x30, 0x1F8, 0x28, 0x28; // true in menu
    bool isEggsHatching:        "fmodstudio.dll", 0x304A30, 0x88, 0x18, 0x158, 0x498, 0x108;
    bool isNotInWater:                            0x14BC6A0, 0x7C;
    int isFabiOpen:                   "mono.dll", 0x296BC8, 0x20, 0xA58, 0x20; // 2 means that the esc menu is open
    int isPDAOpen:                    "mono.dll", 0x2655E0, 0x40, 0x18, 0xA0, 0x920, 0x64; // true = 1051931443, false = 1056964608
    //int isRocketLaunching:            "mono.dll", 0x262110, 0x240, 0x0, 0x20, 0x30, 0x30, 0x8, 0x80;
    int isRocketLaunching:            "mono.dll", 0x27EAD8, 0x40, 0x70, 0x50, 0x90, 0x30, 0x8, 0x80;
    int knownTechSize:                "mono.dll", 0x296BC8, 0x20, 0x928, 0x58, 0x38;
    int inventorySize:                "mono.dll", 0x2655E0, 0xA0, 0xAB0, 0x18, 0x30, 0x134;
    int graphicalDetail:                          0x144B828; // high = 0, medium = 1, low = 2
    int oxygen:                                   0x142ADA8, 0x8, 0x10, 0x30, 0x30, 0x18, 0x28, 0x70;
    float timeCured:                  "mono.dll", 0x2655E0, 0xA0, 0x598, 0x0, 0x18, 0x20, 0x898, 0x10, 0x20, 0x2B0;
    float walkDir:                                0x142B8C8, 0x158, 0x40, 0xA0;
    float strafeDir:                              0x142B8C8, 0x158, 0x40, 0x160;
    float posX:                                   0x142B8C8, 0x180, 0x40, 0xA8, 0x7C0; // 0 in menu
    float posY:                                   0x142B8C8, 0x180, 0x40, 0xA8, 0x7C4; // 1.75 in menu
    float posZ:                                   0x142B8C8, 0x180, 0x40, 0xA8, 0x7C8; // 0 in menu
    bool isDying:                                 0x142B740, 0x8, 0x8, 0x10, 0x30, 0x2C8, 0x28, 0x20;
    string128 biome:                              0x142b908, 0x180, 0x128, 0x80, 0x1D0, 0x8, 0x248, 0x1D0, 0x14;
    int INTbiome:                                 0x142b908, 0x180, 0x128, 0x80, 0x1D0, 0x8, 0x248, 0x1D0, 0x14;
}

state("Subnautica", "March 2023")
{
    bool introCinematicActive: "UnityPlayer.dll", 0x179B680, 0x88, 0x198, 0x338, 0x30, 0x28, 0x28, 0x87;
    bool isLoadingScreen:      "UnityPlayer.dll", 0x18AB2E0, 0x430, 0x8, 0x10, 0x48, 0x30, 0x7AC;
    bool isAnimationPlaying:   "UnityPlayer.dll", 0x17FBE70, 0x8, 0x10, 0x30, 0x58, 0x28, 0x284;
    bool isPortalLoading:      "UnityPlayer.dll", 0x17FBE70, 0x10, 0x10, 0x30, 0x1F8, 0x28, 0x28; //true in menu
    bool isEggsHatching:        "fmodstudio.dll", 0x2CED70, 0x78, 0x18, 0x190, 0x4D8, 0xB0, 0x20, 0x28;
    bool isNotInWater:         "UnityPlayer.dll", 0x18AB130, 0x48, 0x0, 0x68;
    int isFabiOpen:            "UnityPlayer.dll", 0x183BF48, 0x8, 0x10, 0x30, 0x30, 0x28, 0x128;
    int isPDAOpen:          "mono-2.0-bdwgc.dll", 0x499C40, 0xE84; // true = 1051931443, false = 1056964608
    int isRocketLaunching:     "UnityPlayer.dll", 0x17FC238, 0x10, 0x3C; //256 = true
    int inventorySize:         "UnityPlayer.dll", 0x17FBE70, 0x8, 0x10, 0x30, 0x1A8, 0x28, 0x38, 0x94;
    int graphicalDetail:       "UnityPlayer.dll", 0x183AB60; // high = 0, medium = 1, low = 2
    float skipProgress:        "UnityPlayer.dll", 0x17FBC48, 0x1F0, 0x1E8, 0x4E0, 0xB10, 0xD0, 0x8, 0x68, 0x30, 0x40, 0x30, 0xF4;
    float timeCured:           "UnityPlayer.dll", 0x179B680, 0x88, 0xC0, 0x288, 0x30, 0x30, 0x38, 0x28, 0x18, 0x30C;
    float walkDir:             "UnityPlayer.dll", 0x17FBC28, 0x30, 0x98;
    float strafeDir:           "UnityPlayer.dll", 0x17FBC28, 0x30, 0x150;
    float posX:                "UnityPlayer.dll", 0x1839CE0, 0x28, 0x10, 0x150, 0xA58; // 0 in menu
    float posY:                "UnityPlayer.dll", 0x1839CE0, 0x28, 0x10, 0x150, 0xA5C; // 1.75 in menu
    float posZ:                "UnityPlayer.dll", 0x1839CE0, 0x28, 0x10, 0x150, 0xA60; // 0 in menu
    bool isDying:              "UnityPlayer.dll", 0x17FBE70, 0x8, 0x10, 0x30, 0x318, 0x28, 0x50;
    string128 biome:           "UnityPlayer.dll", 0x17FBE70, 0x8, 0x10, 0x30, 0x58, 0x28, 0x1f0, 0x14;
    int INTbiome:              "UnityPlayer.dll", 0x17FBE70, 0x8, 0x10, 0x30, 0x58, 0x28, 0x1f0, 0x14;
}

update
{
    // Manage Explosion Time
    if(vars.oldExploSettingState == null) vars.oldExploSettingState = settings["explo"];
    if(settings["explo"] && vars.oldExploSettingState == false)
    {
        vars.manageExploTimeComponent(true);
    }
    if(!settings["explo"] && vars.oldExploSettingState == true)
    {
        vars.manageExploTimeComponent(false);
    }
    vars.oldExploSettingState = settings["explo"];

    // Detect Main Menu Change
    /*if(current.biome == "")
    {
        vars.isInMainMenu = true;
    }
    else
    {
        vars.isInMainMenu = false;
    }*/
    if(current.posX == 0 && current.posZ == 0 && current.posY == 1.75f && old.posY != current.posY)
    {
        vars.isInMainMenu = true;
    }
    if(old.posX == 0 && old.posZ == 0 && old.posY == 1.75f && old.posY != current.posY)
    {
        vars.isInMainMenu = false;
    }

    if(vars.isInMainMenu)
    {
        vars.startedTimerBefore = false;
    }
}

// Starts
start
{
    if(!vars.startedTimerBefore)
    {
        // Survival Starts
        if(version == "September 2018" && current.oxygen > 35 && old.oxygen < 35) {print("[Autosplitter] Start: start of oxyen"); vars.startedBefore = true; return true;}
        if(!current.introCinematicActive && old.introCinematicActive)             {print("[Autosplitter] Start: start of introCinematic"); vars.startedBefore = true; return true;}
        if(version == "March 2023" && current.skipProgress > 0.988f)              {print("[Autosplitter] Start: start of skipProgress"); vars.startedBefore = true; return true;}

        // Creative Starts
        if(!current.isLoadingScreen && !vars.isInMainMenu)
        {
            // Start of Move
            if(settings["startByMove"] && ((current.walkDir != 0 && old.walkDir == 0) || (current.strafeDir != 0 && old.strafeDir == 0)))
            {
                print("[Autosplitter] Start: start of move");
                vars.startedTimerBefore = true;
                return true;
            }

            // Start of Fabricator
            if(settings["startByFabricator"] && current.isFabiOpen == 1 && old.isFabiOpen == 0)
            {
                print("[Autosplitter] Start: start of Fabricator");
                vars.startedTimerBefore = true;
                return true;
            }

            // Start of PDA
            if(settings["startByPDA"] && current.isPDAOpen == 1051931443 && current.isPDAOpen != old.isPDAOpen)
            {
                print("[Autosplitter] Start: start of PDA");
                vars.startedTimerBefore = true;
                return true;
            }
        }
    }
}

// Splits
split
{
    float x = current.posX;
    float y = current.posY;
    float z = current.posZ;

    // Rocket Split
    if(settings["RocketSplit"] && current.isRocketLaunching != old.isRocketLaunching && (current.isRocketLaunching == 1 || current.isRocketLaunching == 256))
    {
        print("[Autosplitter] Split: Rocket Split");
        return true;
    }

    // PCF Tablet Split
    if((settings["C_PCFTabletSplit"] || settings["SGL_PCFTabletSplit"] || settings["HCGL_PCFTabletSplit"]) && 
        current.isAnimationPlaying && !old.isAnimationPlaying && vars.isWithinBounds(vars.PCFEntrenceBounds, x, y, z))
    {
        print("[Autosplitter] Split: PCF Tablet Split");
        return true;
    }

    // Portal Split
    if(settings["C_PortalSplit"] && !vars.splitPortalBefore && current.isPortalLoading && !old.isPortalLoading && vars.isWithinBounds(vars.portalBounds, x, y, z))
    {
        print("[Autosplitter] Split: Portal Split");
        vars.splitPortalBefore = true;
        return true;
    }

    // Hatch Split
    if((settings["C_HatchSplit"] || settings["SG_HatchSplit"] || settings["SGL_HatchSplit"] || settings["HCG_HatchSplit"] || settings["HCGL_HatchSplit"]) && 
        current.isEggsHatching && !old.isEggsHatching)
    {
        print("[Autosplitter] Split: Hatch Split");
        return true;
    }

    // Cure Split
        if((settings["C_CureSplit"] || settings["SG_CureSplit"] || settings["SGL_CureSplit"] || settings["HCG_CureSplit"] || settings["HCGL_CureSplit"]) && 
            current.timeCured > old.timeCured)
        {
            print("[Autosplitter] Split: Cure Split");
            print("[Autosplitter] timeCured: " + current.timeCured);
            return true;
        }
    
    if(version == "September 2018")
    {
        // Boosters Split
        if(settings["C_BoostersSplit"] && current.knownTechSize == 225 && old.knownTechSize == 224)
        {
            print("[Autosplitter] Split: Boosters Split");
            return true;
        }

        // Fuel Reserves Split
        if(settings["C_FuelReservesSplit"] && current.knownTechSize == 226 && old.knownTechSize == 225)
        {
            print("[Autosplitter] Split: Fuel Reserves Split");
            return true;
        }
    }

    // Gun Deactivation Split
    if((settings["C_GunSplit"] || settings["SGL_GunSplit"] || settings["HCGL_GunSplit"]) && 
        !vars.splitGunDeactivationBefore && current.isAnimationPlaying && !old.isAnimationPlaying && vars.isWithinBounds(vars.gunBounds, x, y, z))
    {
        print("[Autosplitter] Split: Gun Deactivation Split");
        vars.splitGunDeactivationBefore = true;
        return true;
    }

    // Base Death Split
    if(settings["SG_BaseSplit"] && current.isDying && !old.isDying && (vars.isWithinBounds(vars.deathClipABounds, x, y, z) || vars.isWithinBounds(vars.deathClipCBounds, x, y, z)))
    {
        print("[Autosplitter] Split: Base Death Split");
        return true;
    }

    // Teeth Split
    if((settings["SG_TeethSplit"] || settings["HCG_TeethSplit"]) && 
        !vars.splitTeethBefore && vars.isWithinBounds(vars.teethBounds, x, y, z) && vars.isItemInInventory(vars.stalkerToothID))
    {
        print("[Autosplitter] Split: Teeth Split");
        vars.splitTeethBefore = true;
        return true;
    }

    // Aurora Death Split
    if((settings["SG_AuroraSplit"] || settings["SGL_AuroraSplit"]) && !vars.splitAuroraBefore && 
        current.isDying && !old.isDying && new[] { "crashedShip", "generatorRoom" }.Contains((string)current.biome))
    {
        print("[Autosplitter] Split: Aurora Death Split");
        vars.splitAuroraBefore = true;
        return true;
    }

    // Mountain Split
    if((settings["SG_MountainSplit"] || settings["HCG_MountainSplit"]) && !vars.splitMountainBefore && vars.isWithinBounds(vars.mountainBounds, x, y, z))
    {
        print("[Autosplitter] Split: Mountain Split");
        vars.splitMountainBefore = true;
        return true;
    }

    // Ion Death Split
    if(settings["SG_IonSplit"] && current.isDying && !old.isDying && 
       new[] { "Precursor_LavaCastleBase", "ILZCastleChamber", "PrecursorThermalRoom" }.Contains((string)current.biome))
    {
        print("[Autosplitter] Split: Ion Death Split");
        return true;
    }

    // Gun Death Split
    if(settings["SG_GunDeathSplit"] && current.isDying && !old.isDying && current.biome == "Precursor_Gun_ControlRoom")
    {
        print("[Autosplitter] Split: Gun Death Split");
        return true;
    }

    // Sparse Death Split
    if(settings["SG_SparseSplit"] && current.isDying && !old.isDying && !vars.splitSurvivalSparseBefore &&
       new[] { "sparseReef", "seaTreaderPath", "seaTreaderPath_wreck" }.Contains((string)current.biome))
    {
        print("[Autosplitter] Split: Sparse Death Split");
        vars.splitSurvivalSparseBefore = true;
        return true;
    }

    // Glitchless Base Split
    if((settings["SGL_BaseSplit"] || settings["HCGL_BaseSplit"]) && 
        !vars.splitSGLBaseBefore && current.isNotInWater && !old.isNotInWater && vars.isWithinBounds(vars.SGLBaseBounds, x, y, z))
    {
        print("[Autosplitter] Split: Glitchless Base Split");
        vars.splitSGLBaseBefore = true;
        return true;
    }

    // Glitchless Shallows Split
    if((settings["SGL_ShallowsSplit"] || settings["HCGL_ShallowsSplit"]) && !vars.splitSGLShallowsBefore && 
        !current.isNotInWater && current.isAnimationPlaying && vars.isWithinBounds(vars.SGLBaseBounds, x, y, z) && vars.isItemInInventory(vars.doubleO2TankID))
    {
        print("[Autosplitter] Split: Glitchless Shallows Split");
        vars.splitSGLShallowsBefore = true;
        return true;
    }

    // Upper Tablet Split
    if(settings["SGL_UpperTabletSplit"] && current.inventorySize > old.inventorySize && vars.isWithinBounds(vars.upperTabletBounds, x, y, z))
    {
        print("[Autosplitter] Split: Upper Tablet Split");
        return true;
    }

    // Ion Unstuck Split
    if((settings["SGL_IonSplit"] || settings["HCGL_IonSplit"]) && current.isAnimationPlaying && !old.isAnimationPlaying && current.biome == "PrecursorThermalRoom")
    {
        print("[Autosplitter] Split: Ion Unstuck Split");
        return true;
    }

    // Prison Aquarium Split
    if((settings["SGL_PCFPoolSplit"] || settings["HCGL_PCFPoolSplit"]) && !vars.splitPrisonAquariumBefore && 
        current.biome == "Prison_Aquarium_Upper" && old.biome == "Prison_Moonpool")
    {
        print("[Autosplitter] Split: Prison Aquarium Split");
        vars.splitPrisonAquariumBefore = true;
        return true;
    }

    // Sparse Biome Change Split
    if((settings["SGL_SparseSplit"] || settings["HCGL_SparseSplit"]) && !vars.splitSurvivalSparseBefore &&
       new[] { "sparseReef", "seaTreaderPath", "seaTreaderPath_wreck" }.Contains((string)old.biome) && 
       new[] { "safeShallows", "kelpForest", "Lifepod" }.Contains((string)current.biome))
    {
        print("[Autosplitter] Split: Sparse Biome Change Split");
        vars.splitSurvivalSparseBefore = true;
        return true;
    }

    // Aurora Biome Change Split
    if(settings["SGL_AuroraSplit"] && !vars.splitAuroraBefore &&
       new[] { "crashedShip", "generatorRoom" }.Contains((string)old.biome) && 
       new[] { "safeShallows", "kelpForest", "Lifepod" }.Contains((string)current.biome))
    {
        print("[Autosplitter] Split: Aurora Biome Change Split");
        vars.splitAuroraBefore = true;
        return true;
    }

    // Crossing Eyestalk Line Split
    if(settings["HCG_ShallowsSplit"] && !vars.splitHCGShallowsBefore && vars.isWithinBounds(vars.eyestalkLineBounds, x, y, z))
    {
        print("[Autosplitter] Split: Crossing Eyestalk Line Split");
        vars.splitHCGShallowsBefore = true;
        return true;
    }

    // Ion Unlock Split
    if(settings["HCG_IonSplit"] && version == "September 2018" && !vars.splitIonUnlockBefore && 
        current.biome == "PrecursorThermalRoom" && current.knownTechSize > old.knownTechSize)
    {
        print("[Autosplitter] Split: Ion Unlock Split");
        vars.splitIonUnlockBefore = true;
        return true;
    }

    // Aurora Exit Split
    if(settings["HCG_AuroraSplit"] && version == "September 2018" && !vars.splitAuroraExitBefore && vars.isWithinBounds(vars.auroraExitBounds, x, y, z))
    {
        if(vars.oldKnownTechSizeBeforeAuroraHC < current.knownTechSize && vars.oldKnownTechSizeBeforeAuroraHC != 0)
        {
            print("[Autosplitter] Split: Aurora Exit Split");
            vars.splitAuroraExitBefore = true;
            return true;
        }
        vars.oldKnownTechSizeBeforeAuroraHC = current.knownTechSize;
    }

    // Base Enter With Ruby Split
    if(settings["HCG_SparseSplit"] && !vars.splitHCGSparseBefore && current.isAnimationPlaying && !old.isAnimationPlaying && 
      (vars.isWithinBounds(vars.enterClipABounds, x, y, z) || vars.isWithinBounds(vars.enterClipCBounds, x, y, z)) && vars.isItemInInventory(vars.rubyID))
    {
        print("[Autosplitter] Split: Base Enter With Ruby Split");
        vars.splitHCGSparseBefore = true;
        return true;
    }
}

reset
{
    if(current.INTbiome == 0 && old.INTbiome != 0)
    {
        print("[Autosplitter] reset of biome");
        return true;
    }
}

isLoading
{
    if(!vars.isInMainMenu)
    {
        if(!settings["load"])
        {
            if(current.isPortalLoading)
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
            // Start of Portal Load
            if (current.isPortalLoading && !old.isPortalLoading)
            {
                vars.fakePortalLoading = true;
                vars.tickCounter = version == "September 2018" ? 30 : 33;
            }

            // End of Portal Load
            else if (!current.isPortalLoading && old.isPortalLoading)
            {
                vars.fakePortalLoading = false;
                vars.tickCounter = version == "September 2018" ? 21 : 0;
            }

            if(vars.tickCounter > 0)
            {
                vars.tickCounter--;
            }
            else
            {
                if(vars.fakePortalLoading)
                return true;
                else
                return false;
            }
        }
    }
}

init
{
    // Detect version
    switch (modules.First().ModuleMemorySize)
    {
        case 23801856: version = "September 2018"; break;
        case 675840: version = "March 2023"; break;
        default: print("[Autosplitter] No valid version found"); version = "Unknown"; break;
    }

    vars.isWithinBounds = (Func<float[], float, float, float, bool>)((posArray, x, y, z) =>
    {       
        if (x >= Math.Min(posArray[0], posArray[1]) && x <= Math.Max(posArray[0], posArray[1]) &&
            y >= Math.Min(posArray[2], posArray[3]) && y <= Math.Max(posArray[2], posArray[3]) &&
            z >= Math.Min(posArray[4], posArray[5]) && z <= Math.Max(posArray[4], posArray[5]))
        {
            return true;
        }
        else
        {
            return false;
        }
    });

    vars.isItemInInventory = (Func<int, bool>)((ItemToSearchFor) =>
    {
        int itemOffset = 0x0;
        IntPtr startAddr = IntPtr.Zero;
        if(version == "September 2018")
        {
            var baseAddr = modules.First(m => m.ModuleName == "mono.dll").BaseAddress;
            IntPtr ptr1 = memory.ReadPointer((IntPtr)(baseAddr + 0x296BC8));
            IntPtr ptr2 = memory.ReadPointer((IntPtr)(ptr1 + 0x20));
            IntPtr ptr3 = memory.ReadPointer((IntPtr)(ptr2 + 0xA40));
            IntPtr ptr4 = memory.ReadPointer((IntPtr)(ptr3 + 0x0));
            IntPtr ptr5 = memory.ReadPointer((IntPtr)(ptr4 + 0x40));
            IntPtr ptr6 = memory.ReadPointer((IntPtr)(ptr5 + 0x58));
            IntPtr ptr7 = memory.ReadPointer((IntPtr)(ptr6 + 0x20));
            IntPtr ptr8 = (IntPtr)(ptr7 + 0x18);//address of mercuryOre, 0x8 begins the inventory
            startAddr = (IntPtr)(ptr8 + 0x8);//inventory begins here and each item takes up 0x4 after
            itemOffset = 0x4;
        }
        else if(version == "March 2023")
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
            IntPtr ptr10 = (IntPtr)(ptr9 + 0x18);//address of mercuryOre, 0x8 begins the inventory
            startAddr = (IntPtr)(ptr10 + 0x8);//inventory begins here and each item takes up 0x18 after
            itemOffset = 0x18;
        }

        for (int i = 0; i < 48; i++)
        {
            int CurrentItemID = memory.ReadValue<int>((IntPtr)startAddr + itemOffset*i);
            print("[Autosplitter] current item id: " + i + ".: "+ CurrentItemID);
            if(CurrentItemID == ItemToSearchFor)
            {
                return true;
            }
        }
        return false;
    });

    vars.manageExploTimeComponent = (Action<bool>)((IsAdd) =>
    {
        var toRemove = timer.Layout.LayoutComponents.Where(x => x.Component.GetType().FullName == "LiveSplit.UI.Components.Component").FirstOrDefault();
        if(IsAdd && toRemove == null)
        {
            var componentPath = "Components\\SubnauticaShipExplosionInfo.dll";
            var asm = Assembly.LoadFrom(componentPath);
            var componentType = asm.GetType("LiveSplit.UI.Components.Component");
            var component = Activator.CreateInstance(componentType, timer);
            timer.Layout.LayoutComponents.Add(new LiveSplit.UI.Components.LayoutComponent("SubnauticaShipExplosionInfo.dll", component as LiveSplit.UI.Components.IComponent));
        }
        else if(!IsAdd && toRemove != null)
        {
            timer.Layout.LayoutComponents.Remove(toRemove);
        }
    });
}

onStart
{
    vars.splitPortalBefore = false;
    vars.splitTeethBefore = false;
    vars.splitAuroraBefore = false;
    vars.splitGunDeactivationBefore = false;
    vars.splitMountainBefore = false;
    vars.splitCureBefore = false;
    vars.splitSGLBaseBefore = false;
    vars.splitSGLShallowsBefore = false;
    vars.splitSGLIonBefore = false;
    vars.splitIonUnlockBefore = false;
    vars.splitPrisonAquariumBefore = false;
    vars.splitHCGShallowsBefore = false;
    vars.splitAuroraExitBefore = false;
    vars.splitHCGSparseBefore = false;
    vars.splitSurvivalSparseBefore = false;

    vars.oldKnownTechSizeBeforeAuroraHC = 0;
    vars.tickCounter = 0;
    vars.fakePortalLoading = false;
}

startup
{
    // Constants
    vars.teethBounds = new float[] { -212f, 27f, -100f, 100f, 159f, 177f };
    vars.auroraExitBounds = new float[] { 545f, 550f, -10f, 10f, -265f, -256f };
    vars.eyestalkLineBounds = new float[] { -200f, 130f, -100f, 50f, 477f, 479f };
    vars.mountainBounds = new float[] { 475f, 534f, -191f, -510f, 745f, 810f };
    vars.PCFEntrenceBounds = new float[] { 216f, 224f, -1445f, -1453f, -267f, -276f };
    vars.portalBounds = new float[] { 240f, 250f, -1580f, -1590f, -2000f, 2000f };
    vars.gunBounds = new float[] { 359f, 365f, -66f, -75f, 1079f, 1085f };
    vars.upperTabletBounds = new float[] { 380f, 386f, 10f, 30f, 1084f, 1090f };
    vars.SGLBaseBounds = new float[] { 20f, 80f, -45f, -17f, 290f, 360f };
    vars.deathClipABounds = new float[] { 33f, 65f, -20f, -8f, 118f, 96f };
    vars.deathClipCBounds = new float[] { -155f, -133f, -20f, -10f, 96f, 73f };
    vars.enterClipABounds = new float[] { 48f, 55f, -20f, -5f, 106f, 111f };
    vars.enterClipCBounds = new float[] { -142f, -132f, -20f, -5f, 82f, 90f };
    vars.stalkerToothID = 2529;
    vars.doubleO2TankID = 528;
    vars.rubyID = 52;

    // Others
    vars.startedTimerBefore = false;
    vars.isInMainMenu = false;
    vars.oldExploSettingState = null;

    vars.splitPortalBefore = false;
    vars.splitTeethBefore = false;
    vars.splitAuroraBefore = false;
    vars.splitCureBefore = false;
    vars.splitGunDeactivationBefore = false;
    vars.splitMountainBefore = false;
    vars.splitSGLBaseBefore = false;
    vars.splitSGLShallowsBefore = false;
    vars.splitSGLIonBefore = false;
    vars.splitIonUnlockBefore = false;
    vars.splitPrisonAquariumBefore = false;
    vars.splitHCGShallowsBefore = false;
    vars.splitAuroraExitBefore = false;
    vars.splitHCGSparseBefore = false;
    vars.splitSurvivalSparseBefore = false;

    vars.oldKnownTechSizeBeforeAuroraHC = 0;
    vars.tickCounter = 0;
    vars.fakePortalLoading = false;
    

    // Detect current category
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

    // Timing Method Warning
    if (timer.CurrentTimingMethod == TimingMethod.RealTime && vars.shortCategoryName == "Creative")
    {
        var timingMessage = MessageBox.Show(
        "The category you are currently playing uses RTA w/o Portal Loads as the main timing method.\n"
        + "LiveSplit is currently set to show Real Time (RTA).\n"
        + "Would you like to set the timing method to RTA w/o Portal Loads?",
        "Subnautica | LiveSplit",
        MessageBoxButtons.YesNo, MessageBoxIcon.Question
        );  
        if (timingMessage == DialogResult.Yes)
        {
            timer.CurrentTimingMethod = TimingMethod.GameTime;
        }
    }
    else if(timer.CurrentTimingMethod == TimingMethod.GameTime && (vars.shortCategoryName == "Survival" || vars.shortCategoryName == "Hardcore"))
    {
        var timingMessage = MessageBox.Show(
        "The category you are currently playing uses Real Time as the main timing method.\n"
        + "LiveSplit is currently set to show Real Time w/o Portal Loads.\n"
        + "Would you like to set the timing method to Real Time?",
        "Subnautica | LiveSplit",
        MessageBoxButtons.YesNo, MessageBoxIcon.Question
        );  
        if (timingMessage == DialogResult.Yes)
        {
            timer.CurrentTimingMethod = TimingMethod.RealTime;
        }
    }

    settings.Add("explo", false, "Show Explosion Time");
    settings.SetToolTip("explo", "Shows when the Aurora is going to explode\nOnly updates the layout when the game is running");

    // setting layouts
    switch((string)vars.shortCategoryName)
    {
        case "Creative":
            settings.Add("load", true, "SRC loadtimes");
            settings.SetToolTip("load", "This will add time to the actual load times to match the IGT shown on Speedrun.com (can be up to 0.1s inaccurate)\nUnchecking this will not turn off the load removal");
            settings.Add("Start");
            settings.CurrentDefaultParent = "Start";
            settings.Add("startByMove", true, "Start when moving horizontally");
            settings.Add("startByFabricator", true, "Start when interacting with the fabricator");
            settings.Add("startByPDA", true, "Start when opening the PDA");
            settings.CurrentDefaultParent = null;
            settings.Add("Split");
            settings.CurrentDefaultParent = "Split";
            settings.Add("C_PCFTabletSplit", false, "Split when inserting the tablet at the PCF entrence");
            settings.Add("C_PortalSplit", false, "Split on Portal entry");
            settings.Add("C_HatchSplit", false, "Split on hatching eggs");
            settings.Add("C_CureSplit", false, "Split on Cure");
            settings.Add("C_BoostersSplit", false, "Split on Boosters");
            settings.SetToolTip("C_BoostersSplit", "CG only");
            settings.Add("C_FuelReservesSplit", false, "Split on Fuel Reserve");
            settings.SetToolTip("C_FuelreserveSplit", "CG only");
            settings.Add("C_GunSplit", false, "Split on Gun deactivation");
            settings.Add("RocketSplit", false, "Split on Rocket launch");
        break;

        case "Survival":
            settings.CurrentDefaultParent = null;
            settings.Add("Split");
            settings.CurrentDefaultParent = "Split";
            settings.Add("RocketSplit", true, "Split on Rocket launch");
            settings.Add("Glitched", false, "Glitched");
            settings.CurrentDefaultParent = "Glitched";
            settings.Add("SG_BaseSplit", true, "Split Base");
            settings.SetToolTip("SG_BaseSplit", "Split when dying next to the main base (includes clip A and C)");
            settings.Add("SG_TeethSplit", true, "Split Teeth");
            settings.SetToolTip("SG_TeethSplit", "Split when leaving the Kelp Forest with 1 or more Creepvine samples");
            settings.Add("SG_AuroraSplit", true, "Split Aurora");
            settings.SetToolTip("SG_AuroraSplit", "Split when dying in the Aurora");
            settings.Add("SG_MountainSplit", true, "Split Mountain");
            settings.SetToolTip("SG_MountainSplit", "Split when descending under the arch after getting out of bounds");
            settings.Add("SG_IonSplit", true, "Split Ion BP");
            settings.SetToolTip("SG_IonSplit", "Split when dying in or near the Alien Thermal Plant");
            settings.Add("SG_HatchSplit", false, "Split on hatching eggs");
            settings.Add("SG_CureSplit", false, "Split on Cure");
            settings.Add("SG_GunDeathSplit", true, "Split Gun Death");
            settings.SetToolTip("SG_GunDeathSplit", "Split when dying in the Alien Gun Room");
            settings.Add("SG_SparseSplit", true, "Split Sparse");
            settings.SetToolTip("SG_SparseSplit", "Split when dying in the biomes: Sea Treader Path or Sparse Reef");

            settings.CurrentDefaultParent = "Split";
            settings.Add("Glitchless", false, "Glitchless");
            settings.CurrentDefaultParent = "Glitchless";
            settings.Add("SGL_BaseSplit", true, "Split Base");
            settings.SetToolTip("SGL_BaseSplit", "Split when entering the main base near the seaglide wreck for the first time");
            settings.Add("SGL_ShallowsSplit", true, "Split Shallows");
            settings.SetToolTip("SGL_ShallowsSplit", "Split when leaving the main base with an extra High Capacity O2 tank in your inventory");
            settings.Add("SGL_UpperTabletSplit", true, "Split Upper Tablet");
            settings.SetToolTip("SGL_UpperTabletSplit", "Split when you pick up the upper purple tablet that lies next to the Gun entrence");
            settings.Add("SGL_IonSplit", true, "Split Ion BP");
            settings.SetToolTip("SGL_IonSplit", "Split when using unstuck in the Ion Blueprint room");
            settings.Add("SGL_PCFSplits", true, "Split PCF");
            settings.CurrentDefaultParent = "SGL_PCFSplits";
            settings.Add("SGL_PCFTabletSplit", true, "Split when inserting the tablet at the PCF entrence");
            settings.Add("SGL_PCFPoolSplit", false, "Split when entering the prison aquarium from moonpool");
            settings.CurrentDefaultParent = "Glitchless";
            settings.Add("SGL_HatchSplit", false, "Split on hatching eggs");
            settings.Add("SGL_CureSplit", false, "Split on Cure");
            settings.Add("SGL_GunSplit", true, "Split on Gun deactivation");
            settings.Add("SGL_SparseSplit", true, "Split Sparse");
            settings.SetToolTip("SGL_SparseSplit", "Split when the current biome changes from Sparse to Shallows or Kelp Forest");
            settings.Add("SGL_AuroraSplit", true, "Split Aurora");
            settings.SetToolTip("SGL_AuroraSplit", "Split when dying in the Aurora\nOR\nWhen the current biome changes from Aurora to Shallows or Kelp Forest");
        break;

        case "Hardcore":
            settings.CurrentDefaultParent = null;
            settings.Add("Split");
            settings.CurrentDefaultParent = "Split";
            settings.Add("RocketSplit", true, "Split on Rocket launch");
            settings.Add("Glitched", false, "Glitched");
            settings.CurrentDefaultParent = "Glitched";
            settings.Add("HCG_TeethSplit", true, "Split Teeth");
            settings.SetToolTip("HCG_TeethSplit", "Split when crossing a certain line with 1 or more Creepvine samples (the line crosses the coral tube entrance)");
            settings.Add("HCG_ShallowsSplit", true, "Split Shallows");
            settings.SetToolTip("HCG_ShallowsSplit", "Split when crossing a certain line after collecting eyestalk");
            settings.Add("HCG_MountainSplit", true, "Split Mountain");
            settings.SetToolTip("HCG_MountainSplit", "Split when descending under the arch after getting out of bounds");
            settings.Add("HCG_IonSplit", true, "Split Ion BP");
            settings.SetToolTip("HCG_IonSplit", "Split when unlocking the Ion blueprint");
            settings.Add("HCG_HatchSplit", false, "Split on hatching eggs");
            settings.Add("HCG_CureSplit", false, "Split on Cure");
            settings.Add("HCG_GunSplit", true, "Split on Gun deactivation");
            settings.Add("HCG_AuroraSplit", true, "Split Aurora");
            settings.SetToolTip("HCG_AuroraSplit", "Split when exiting the Aurora after unlocking the Rocket");
            settings.Add("HCG_SparseSplit", true, "Split Sparse");
            settings.SetToolTip("HCG_SparseSplit", "Split when entering the main base with a ruby (includes clip A and C)");

            settings.CurrentDefaultParent = "Split";
            settings.Add("Glitchless", false, "Glitchless");
            settings.CurrentDefaultParent = "Glitchless";
            settings.Add("HCGL_BaseSplit", true, "Split Base");
            settings.SetToolTip("HCGL_BaseSplit", "Split when entering the main base near the seaglide wreck for the first time");
            settings.Add("HCGL_ShallowsSplit", true, "Split Shallows");
            settings.SetToolTip("HCGL_ShallowsSplit", "Split when leaving the main base with an extra High Capacity O2 tank in your inventory");
            settings.Add("HCGL_UpperTabletSplit", true, "Split Upper Tablet");
            settings.SetToolTip("HCGL_UpperTabletSplit", "Split when you pick up the upper purple tablet that lies next to the Gun entrence");
            settings.Add("HCGL_IonSplit", true, "Split Ion BP");
            settings.SetToolTip("HCGL_IonSplit", "Split when using unstuck in the Ion Blueprint room");
            settings.Add("HCGL_PCFSplits", true, "Split PCF");
            settings.CurrentDefaultParent = "HCGL_PCFSplits";
            settings.Add("HCGL_PCFTabletSplit", true, "Split when inserting the tablet at the PCF entrence");
            settings.Add("HCGL_PCFPoolSplit", false, "Split when entering the prison aquarium from moonpool");
            settings.CurrentDefaultParent = "Glitchless";
            settings.Add("HCGL_HatchSplit", false, "Split on hatching eggs");
            settings.Add("HCGL_CureSplit", false, "Split on Cure");
            settings.Add("HCGL_GunSplit", true, "Split on Gun deactivation");
            settings.Add("HCGL_SparseSplit", true, "Split Sparse");
            settings.SetToolTip("HCGL_SparseSplit", "Split when the current biome changes from Sparse to Shallows or Kelp Forest");
            settings.Add("HCGL_AuroraSplit", true, "Split Aurora");
            settings.SetToolTip("HCGL_AuroraSplit", "Split when the current biome changes from Aurora to Shallows or Kelp Forest");
        break;

        default:
            settings.Add("load", true, "SRC loadtimes");
            settings.SetToolTip("load", "This will add time to the actual load times to match the IGT shown on Speedrun.com (can be up to 0.1s inaccurate)\nUnchecking this will not turn off the load removal");
        
            settings.Add("Start");
            settings.CurrentDefaultParent = "Start";
            settings.Add("startByMove", true, "Start when moving horizontally");
            settings.Add("startByFabricator", true, "Start when interacting with the fabricator");
            settings.Add("startByPDA", true, "Start when opening the PDA");
            settings.CurrentDefaultParent = null;
            settings.Add("Split");
            settings.CurrentDefaultParent = "Split";
            settings.Add("RocketSplit", true, "Split on Rocket launch");

            // Creative
            settings.Add("Creative", false, "Creative");
            settings.CurrentDefaultParent = "Creative";
            settings.Add("C_PCFTabletSplit", false, "Split when inserting the tablet at the PCF entrence");
            settings.Add("C_PortalSplit", false, "Split on Portal entry");
            settings.Add("C_HatchSplit", false, "Split on hatching eggs");
            settings.Add("C_CureSplit", false, "Split on Cure");
            settings.Add("C_BoostersSplit", false, "Split on Boosters");
            settings.SetToolTip("C_BoostersSplit", "CG only");
            settings.Add("C_FuelReservesSplit", false, "Split on Fuel Reserve");
            settings.SetToolTip("C_FuelReservesSplit", "CG only");
            settings.Add("C_GunSplit", false, "Split on Gun deactivation");

            // Survival Glitched
            settings.CurrentDefaultParent = "Split";
            settings.Add("Survival", false, "Survival");
            settings.CurrentDefaultParent = "Survival";
            settings.Add("S_Glitched", false, "Glitched");
            settings.CurrentDefaultParent = "S_Glitched";
            settings.Add("SG_BaseSplit", true, "Split Base");
            settings.SetToolTip("SG_BaseSplit", "Split when dying next to the main base (includes clip A and C)");
            settings.Add("SG_TeethSplit", true, "Split Teeth");
            settings.SetToolTip("SG_TeethSplit", "Split when leaving the Kelp Forest with 1 or more Creepvine samples");
            settings.Add("SG_AuroraSplit", true, "Split Aurora");
            settings.SetToolTip("SG_AuroraSplit", "Split when dying in the Aurora");
            settings.Add("SG_MountainSplit", true, "Split Mountain");
            settings.SetToolTip("SG_MountainSplit", "Split when descending under the arch after getting out of bounds");
            settings.Add("SG_IonSplit", true, "Split Ion BP");
            settings.SetToolTip("SG_IonSplit", "Split when dying in or near the Alien Thermal Plant");
            settings.Add("SG_HatchSplit", false, "Split on hatching eggs");
            settings.Add("SG_CureSplit", false, "Split on Cure");
            settings.Add("SG_GunDeathSplit", true, "Split Gun Death");
            settings.SetToolTip("SG_GunDeathSplit", "Split when dying in the Alien Gun Room");
            settings.Add("SG_SparseSplit", true, "Split Sparse");
            settings.SetToolTip("SG_SparseSplit", "Split when dying in the biomes: Sea Treader Path or Sparse Reef");

            // Survival Glitchless
            settings.CurrentDefaultParent = "Survival";
            settings.Add("S_Glitchless", false, "Glitchless");
            settings.CurrentDefaultParent = "S_Glitchless";
            settings.Add("SGL_BaseSplit", true, "Split Base");
            settings.SetToolTip("SGL_BaseSplit", "Split when entering the main base near the seaglide wreck for the first time");
            settings.Add("SGL_ShallowsSplit", true, "Split Shallows");
            settings.SetToolTip("SGL_ShallowsSplit", "Split when leaving the main base with an extra High Capacity O2 tank in your inventory");
            settings.Add("SGL_UpperTabletSplit", true, "Split Upper Tablet");
            settings.SetToolTip("SGL_UpperTabletSplit", "Split when you pick up the upper purple tablet that lies next to the Gun entrence");
            settings.Add("SGL_IonSplit", true, "Split Ion BP");
            settings.SetToolTip("SGL_IonSplit", "Split when using unstuck in the Ion Blueprint room");
            settings.Add("SGL_PCFSplits", true, "Split PCF");
            settings.CurrentDefaultParent = "SGL_PCFSplits";
            settings.Add("SGL_PCFTabletSplit", true, "Split when inserting the tablet at the PCF entrence");
            settings.Add("SGL_PCFPoolSplit", false, "Split when entering the prison aquarium from moonpool");
            settings.CurrentDefaultParent = "S_Glitchless";
            settings.Add("SGL_HatchSplit", false, "Split on hatching eggs");
            settings.Add("SGL_CureSplit", false, "Split on Cure");
            settings.Add("SGL_GunSplit", true, "Split on Gun deactivation");
            settings.Add("SGL_SparseSplit", true, "Split Sparse");
            settings.SetToolTip("SGL_SparseSplit", "Split when the current biome changes from Sparse to Shallows or Kelp Forest");
            settings.Add("SGL_AuroraSplit", true, "Split Aurora");
            settings.SetToolTip("SGL_AuroraSplit", "Split when dying in the Aurora\nOR\nWhen the current biome changes from Aurora to Shallows or Kelp Forest");

            // Hardcore Glitched
            settings.CurrentDefaultParent = "Split";
            settings.Add("Hardcore", false, "Hardcore");
            settings.CurrentDefaultParent = "Hardcore";
            settings.Add("HC_Glitched", false, "Glitched");
            settings.CurrentDefaultParent = "HC_Glitched";
            settings.Add("HCG_TeethSplit", true, "Split Teeth");
            settings.SetToolTip("HCG_TeethSplit", "Split when crossing a certain line with 1 or more Creepvine samples (the line crosses the coral tube entrance)");
            settings.Add("HCG_ShallowsSplit", true, "Split Shallows");
            settings.SetToolTip("HCG_ShallowsSplit", "Split when crossing a certain line after collecting eyestalk");
            settings.Add("HCG_MountainSplit", true, "Split Mountain");
            settings.SetToolTip("HCG_MountainSplit", "Split when descending under the arch after getting out of bounds");
            settings.Add("HCG_IonSplit", true, "Split Ion BP");
            settings.SetToolTip("HCG_IonSplit", "Split when unlocking the Ion blueprint");
            settings.Add("HCG_HatchSplit", false, "Split on hatching eggs");
            settings.Add("HCG_CureSplit", false, "Split on Cure");
            settings.Add("HCG_GunSplit", true, "Split on Gun deactivation");
            settings.SetToolTip("HCG_GunSplit", "Split when dying in the Alien Gun Room");
            settings.Add("HCG_AuroraSplit", true, "Split Aurora");
            settings.SetToolTip("HCG_AuroraSplit", "Split when exiting the Aurora after unlocking the Rocket");
            settings.Add("HCG_SparseSplit", true, "Split Sparse");
            settings.SetToolTip("HCG_SparseSplit", "Split when entering the main base with a ruby (includes clip A and C)");

            // Hardcore Glitchless
            settings.CurrentDefaultParent = "Hardcore";
            settings.Add("HC_Glitchless", false, "Glitchless");
            settings.CurrentDefaultParent = "HC_Glitchless";
            settings.Add("HCGL_BaseSplit", true, "Split Base");
            settings.SetToolTip("HCGL_BaseSplit", "Split when entering the main base near the seaglide wreck for the first time");
            settings.Add("HCGL_ShallowsSplit", true, "Split Shallows");
            settings.SetToolTip("HCGL_ShallowsSplit", "Split when leaving the main base with an extra High Capacity O2 tank in your inventory");
            settings.Add("HCGL_UpperTabletSplit", true, "Split Upper Tablet");
            settings.SetToolTip("HCGL_UpperTabletSplit", "Split when you pick up the upper purple tablet that lies next to the Gun entrence");
            settings.Add("HCGL_IonSplit", true, "Split Ion BP");
            settings.SetToolTip("HCGL_IonSplit", "Split when using unstuck in the Ion Blueprint room");
            settings.Add("HCGL_PCFSplits", true, "Split PCF");
            settings.CurrentDefaultParent = "HCGL_PCFSplits";
            settings.Add("HCGL_PCFTabletSplit", true, "Split when inserting the tablet at the PCF entrence");
            settings.Add("HCGL_PCFPoolSplit", false, "Split when entering the prison aquarium from moonpool");
            settings.CurrentDefaultParent = "HC_Glitchless";
            settings.Add("HCGL_HatchSplit", false, "Split on hatching eggs");
            settings.Add("HCGL_CureSplit", false, "Split on Cure");
            settings.Add("HCGL_GunSplit", true, "Split on Gun deactivation");
            settings.Add("HCGL_SparseSplit", true, "Split Sparse");
            settings.SetToolTip("HCGL_SparseSplit", "Split when the current biome changes from Sparse to Shallows or Kelp Forest");
            settings.Add("HCGL_AuroraSplit", true, "Split Aurora");
            settings.SetToolTip("HCGL_AuroraSplit", "Split when the current biome changes from Aurora to Shallows or Kelp Forest");
        break;
    }
}
