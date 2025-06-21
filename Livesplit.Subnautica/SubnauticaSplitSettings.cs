using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Livesplit.Subnautica
{
    public partial class SubnauticaSplitSettings : UserControl
    {
        public string Split { get; set; } = "";
        public SubnauticaSplitSettings()
        {
            InitializeComponent();
            cboName.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void cboName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string splitDescription = cboName.SelectedValue.ToString();
            SplitName split = GetSplitName(splitDescription);
            Split = split.ToString();

            MemberInfo info = typeof(SplitName).GetMember(split.ToString())[0];
            DescriptionAttribute description = (DescriptionAttribute)info.GetCustomAttributes(typeof(DescriptionAttribute), false)[0];
            ToolTipAttribute tooltip = (ToolTipAttribute)info.GetCustomAttributes(typeof(ToolTipAttribute), false)[0];
            ToolTips.SetToolTip(cboName, tooltip.ToolTip);
        }
        public static SplitName GetSplitName(string text)
        {
            foreach (SplitName split in Enum.GetValues(typeof(SplitName)))
            {
                string name = split.ToString();
                MemberInfo info = typeof(SplitName).GetMember(name)[0];
                DescriptionAttribute description = (DescriptionAttribute)info.GetCustomAttributes(typeof(DescriptionAttribute), false)[0];

                if (name.Equals(text, StringComparison.OrdinalIgnoreCase) || description.Description.Equals(text, StringComparison.OrdinalIgnoreCase))
                {
                    return split;
                }
            }
            return SplitName.RocketSplit;            
        }

        public enum SplitName
        {
            [Description("Rocket Split"), ToolTip("Splits when you start the Neptune Rocket")]
            RocketSplit,
            [Description("Portal Split"), ToolTip("Splits when you enter a portal for the first time")]
            PortalSplit,
            [Description("Hatch Split"), ToolTip("Splits when you hatch the eggs in the prison aquarium")]
            HatchSplit,
            [Description("Cure Split"), ToolTip("Splits when you cure yourself")]
            CureSplit,
            [Description("Boosters Split"), ToolTip("Splits when you build the boosters section of the Neptune Rocket\nCreative 2018 only")]
            BoostersSplit,
            [Description("Fuel Reserves Split"), ToolTip("Splits when you build the fuel reserves section of the Neptune Rocket\nCreative 2018 only")]
            FuelReservesSplit,
            [Description("Mountain Descend Split"), ToolTip("Splits when you descend under the arch after getting out of bounds")]
            MountainDescendSplit,
            [Description("PCF Tablet Split"), ToolTip("Splits when you insert the tablet at the PCF entrance")]
            PCFTabletSplit,
            [Description("PCF Pool Split"), ToolTip("Splits when you enter the prison aquarium the normal way")]
            PCFPoolSplit,            
            [Description("Gun Deactivation Split"), ToolTip("Splits when you deactivate the gun")]
            GunDeactivationSplit,
            [Description("Glitchless Shallows Split"), ToolTip("Split when you exit the main base with an extra High Capacity O2 tank in your inventory")]
            SGLShallowsSplit,
            [Description("Glitchless Base Split"), ToolTip("Splits when you enter the main base near the seaglide wreck for the first time")]
            SGLBaseSplit,
            [Description("Base Death Split (includes Clip A and Clip C)"), ToolTip("Splits when you die next to the main base (includes Clip A and Clip C)")]
            BaseDeathSplit,
            [Description("Gun Death Split"), ToolTip("Splits when you die in the gun room")]
            GunDeathSplit,           
            [Description("Aurora Death Split"), ToolTip("Splits when you die in the Aurora")]
            AuroraDeathSplit,            
            [Description("Sparse Death Split"), ToolTip("Splits when you die in the biomes: Sea Treader Path or Sparse Reef")]
            SparseDeathSplit,
            [Description("Death Split"), ToolTip("Splits when you die")]
            DeathSplit,
            [Description("Ion Death Split"), ToolTip("Splits when you die in the Alien Thermal Plant")]
            IonDeathSplit,
            [Description("Ion Unstuck Split"), ToolTip("Splits when you unstuck in the Ion BP room")]
            IonUnstuckSplit,
            [Description("Ion Unlock Split"), ToolTip("Splits when you unlock the Ion BP")]
            IonUnlockSplit,
            [Description("Rocket Unlock Split"), ToolTip("Splits when you unlock the Neptune Rocket")]
            RocketUnlockSplit,
            [Description("Leave Kelp Forest Split"), ToolTip("Splits when you leave the Kelp Forest with one or more Creepvine samples")]
            LeaveKelpForestSplit,
            [Description("4-Tooth Split"), ToolTip("Splits when you collect four Stalker teeth")]
            FourToothSplit,                                                       
            [Description("Upper Tablet Split"), ToolTip("Splits when you grab the purple tablet above the Alien Gun Entrence")]
            UpperTabletSplit,            
            [Description("Sparse Biome Change Split"), ToolTip("Splits when the biome changes from Sparse to Shallows or Kelp Forest")]
            SparseBiomeSplit,
            [Description("Aurora Biome Change Split"), ToolTip("Splits when the biome changes from Aurora to Shallows or Kelp Forest")]
            AuroraBiomeSplit,
            [Description("Eyestalk Split"), ToolTip("Splits when you collect an Eyestalk Sample")]
            EyestalkSplit,            
            [Description("Aurora Exit Split"), ToolTip("Splits when you exit the Aurora through the old patch hole after unlocking the rocket")]
            AuroraExitSplit,
            [Description("HCG Sparse Split (includes clip A and C)"), ToolTip("Splits when you enter the main base with a ruby (includes clip A and C)")]
            HCGSparseSplit,
        }
        public class ToolTipAttribute : Attribute
        {
            public string ToolTip { get; set; }
            public ToolTipAttribute(string text)
            {
                ToolTip = text;
            }
        }
    }
    }
