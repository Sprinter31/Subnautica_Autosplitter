using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LiveSplit.Subnautica
{
    public partial class SubnauticaBuildSplit : SubnauticaSplitSetting
    {
        public BuildSplit _split;

        private int mX = 0;
        private int mY = 0;
        private bool isDragging = false;

        public SubnauticaBuildSplit() : this(new BuildSplit(Buildable.None, onlySplitOnce: true, isSubCondition: false)) { }
        public SubnauticaBuildSplit(BuildSplit buildSplit)
        {
            InitializeComponent();

            _split = buildSplit ?? new BuildSplit(Buildable.None, onlySplitOnce: true, isSubCondition: false);

            cboBuildables.DropDownStyle = ComboBoxStyle.DropDownList;
            cboBuildables.MouseWheel += (o, e) => ((HandledMouseEventArgs)e).Handled = true;
            cboBuildables.DisplayMember = "Display";
            cboBuildables.ValueMember = "Value";
        }

        private void BtnOptions_Click(object sender, EventArgs e)
        {
            var splitSettings = new SubnauticaBuildSplitSettings(_split);
            var settings = new SplitSettingsDialog(splitSettings) { StartPosition = FormStartPosition.CenterParent };

            if (settings.ShowDialog() == DialogResult.OK)
            {
                _split.OnlySplitOnce = splitSettings.OnlySplitOnce;
                _split.Conditions = splitSettings.Splits;
            }
        }

        private void cboName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsLoading)
                return;

            if (cboBuildables.SelectedValue is Buildable buildable)
                _split.Buildable = buildable;
        }

        private void picHandle_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDragging)
            {
                if (e.Button == MouseButtons.Left)
                {
                    int num1 = mX - e.X;
                    int num2 = mY - e.Y;
                    if (((num1 * num1) + (num2 * num2)) > 20)
                    {
                        DoDragDrop(this, DragDropEffects.All);
                        isDragging = true;
                        return;
                    }
                }
            }
        }

        private void picHandle_MouseDown(object sender, MouseEventArgs e)
        {
            mX = e.X;
            mY = e.Y;
            isDragging = false;
        }

        public override ComboBox ComboBox => this.cboBuildables;
        public override Button BtnEdit => this.btnEdit;
        public override Button BtnRemove => this.btnRemove;
        public override SplitName SplitName => SplitName.Build;
        public override SubnauticaSplit Split => this._split;
    }

    public class BuildSplit : SubnauticaSplit
    {
        public Buildable Buildable { get; set; }

        public BuildSplit(Buildable buildable, bool onlySplitOnce, bool isSubCondition)
        {
            Buildable = buildable;
            this.OnlySplitOnce = onlySplitOnce;
            this.SplitName = SplitName.Build;
            this.IsSubCondition = isSubCondition;
        }
        public override string GetDescription() => $"Build {Localization.GetDisplayName(Buildable)}";
    }
}


