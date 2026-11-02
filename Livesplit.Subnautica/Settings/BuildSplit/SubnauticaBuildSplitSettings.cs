using LiveSplit.Subnautica.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LiveSplit.Subnautica
{
    public partial class SubnauticaBuildSplitSettings : SubnauticaBaseSettings
    {
        public bool OnlySplitOnce { get; private set; }

        public override FlowLayoutPanel MainPanel => flowMain;
        public override FlowLayoutPanel Options => flowOptions;
        public override RadioButton Alpha => RdAlpha;

        private void BtnAddCondition_Click(object sender, EventArgs e) => BtnAddSplitClick(sender, e, isSubCondition: true);
        private void BtnRemove_Click(object sender, EventArgs e) => BtnRemoveClick(sender, e);
        private void BtnEdit_Click(object sender, EventArgs e) => BtnEditClick(sender, e);
        private void flowMain_Paint(object sender, PaintEventArgs e) => flowMainPaint(sender, e);
        private void flowMain_DragEnter(object sender, DragEventArgs e) => flowMainDragEnter(sender, e);
        private void flowMain_DragLeave(object sender, EventArgs e) => flowMainDragLeave(sender, e);
        private void flowMain_DragDrop(object sender, DragEventArgs e) => flowMainDragDrop(sender, e);
        private void flowMain_DragOver(object sender, DragEventArgs e) => flowMainDragOver(sender, e);
        private void RdSort_CheckedChanged(object sender, EventArgs e) => RdSortCheckedChanged(sender, e);

        public SubnauticaBuildSplitSettings(BuildSplit split)
        {
            InitializeComponent();

            Splits = split.Conditions != null ? split.Conditions.Select(c => c.DeepCopy()).ToList() : new List<SubnauticaSplit>();
            OnlySplitOnce = split.OnlySplitOnce;

            if (split.IsSubCondition || SubnauticaSettings.OrderedLiveSplit || SubnauticaSettings.OrderedAutoSplits)
                ChkSplitOnce.Enabled = false;

            LoadSettings();
        }

        public override void UpdateSplits()
        {
            OnlySplitOnce = ChkSplitOnce.Checked;

            base.UpdateSplits();
        }

        public override void ControlChanged(object sender, EventArgs e)
        {
            if (IsLoading)
                return;

            UpdateSplits();
        }

        public override void LoadSettings()
        {
            IsLoading = true;
            ChkSplitOnce.Checked = OnlySplitOnce;

            base.LoadSettings();
            IsLoading = false;
        }
    }
}


