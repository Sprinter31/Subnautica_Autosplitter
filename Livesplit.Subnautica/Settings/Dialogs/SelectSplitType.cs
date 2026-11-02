using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LiveSplit.Subnautica.Settings
{
    public partial class SelectSplitType : Form
    {
        public Func<bool, SubnauticaSplitSetting> Func { get; set; }
        public SelectSplitType(SubnauticaBaseSettings settings, bool isSubCondition)
        {
            InitializeComponent();
            List<SplitType> items = new List<SplitType>();

            if (!isSubCondition)
            {
                items.Add(new SplitType { Text = "Prefabricated", Func = settings.CreatePrefabSplit });
                items.Add(new SplitType { Text = "Craft", Func = settings.CreateCraftSplit });
                items.Add(new SplitType { Text = "Build", Func = settings.CreateBuildSplit });
            }

            items.Add(new SplitType { Text = "Inventory", Func = settings.CreateItemSplit });
            items.Add(new SplitType { Text = "Blueprint", Func = settings.CreateBlueprintSplit });
            items.Add(new SplitType { Text = "Encyclopedia", Func = settings.CreateEncySplit });
            items.Add(new SplitType { Text = "Biome", Func = settings.CreateBiomeSplit });

            cboSplitType.DisplayMember = nameof(SplitType.Text);
            cboSplitType.ValueMember = nameof(SplitType.Func);
            cboSplitType.DataSource = items;
        }

        private class SplitType
        {
            public string Text { get; set; }
            public Func<bool, SubnauticaSplitSetting> Func { get; set; }

            public override string ToString() => Text;
        }

        private void btnOK_Click(object sender, EventArgs e) => OK();

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void OK()
        {
            if (cboSplitType.SelectedValue is Func<bool, SubnauticaSplitSetting> func)
                Func = func;
            DialogResult = DialogResult.OK;
        }
    }
}
