using LiveSplit.Model;
using LiveSplit.Subnautica.Settings;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Voxif.AutoSplitter;

namespace LiveSplit.Subnautica
{
    public class SubnauticaBaseSettings : UserControl
    {
        public List<SubnauticaSplit> Splits { get; set; }
        public virtual RadioButton Alpha { get; set; }


        public LiveSplitState State;
        public bool IsLoading = false;

        private SubnauticaSplitSetting _dragItem;
        private int _dragTargetIndex = -1;
        private int _insertMarkerY = -1;
        private Control _insertBeforeControl;
        private Control _highlightControl;

        public virtual FlowLayoutPanel MainPanel { get; set; }
        public virtual FlowLayoutPanel Options { get; set; }

        #region Buttons
        public void BtnAddSplitClick(object sender, EventArgs e, bool isSubCondition = false)
        {
            var dialog = new SelectSplitType(this, isSubCondition);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var setting = dialog.Func(isSubCondition);
                MainPanel.Controls.Add(setting);
                UpdateSplits();
            }
        }

        public void BtnRemoveClick(object sender, EventArgs e)
        {
            for (int i = MainPanel.Controls.Count - 1; i > 0; i--)
            {
                if (MainPanel.Controls[i].Contains((Control)sender))
                {
                    RemoveHandlers((SubnauticaSplitSetting)((Button)sender).Parent);

                    MainPanel.Controls.RemoveAt(i);
                    break;
                }
            }
            UpdateSplits();
        }

        public void BtnEditClick(object sender, EventArgs e)
        {
            foreach (var setting in MainPanel.Controls.OfType<SubnauticaSplitSetting>())
            {
                if (ReferenceEquals(setting.BtnEdit, sender))
                {
                    bool anyEnabled = setting.ComboBox.Enabled || (setting.ComboBox2?.Enabled ?? false);
                    if (anyEnabled) DisableEdit(setting);
                    else EnableEdit(setting);
                    break;
                }
            }
        }
        #endregion Buttons

        public void RdSortCheckedChanged(object sender, EventArgs e)
        {
            MainPanel.SuspendLayout();

            foreach (var setting in MainPanel.Controls.OfType<SubnauticaSplitSetting>())
                ApplyDataSources(setting, Alpha.Checked);

            MainPanel.ResumeLayout();
        }

        private void EnableEdit(SubnauticaSplitSetting setting)
        {
            setting.BtnEdit.Text = "✔";
            ApplyDataSources(setting, Alpha.Checked);
            setting.ComboBox.Enabled = true;
            if (setting.ComboBox2 != null)
                setting.ComboBox2.Enabled = true;
        }

        private void DisableEdit(SubnauticaSplitSetting setting)
        {
            setting.BtnEdit.Text = "✏";
            setting.ComboBox.Enabled = false;
            if (setting.ComboBox2 != null)
                setting.ComboBox2.Enabled = false;
        }

        public virtual void ControlChanged(object sender, EventArgs e) => UpdateSplits();

        public virtual void UpdateSplits()
        {
            if (IsLoading)
                return;

            Splits.Clear();
            foreach (var setting in MainPanel.Controls.OfType<SubnauticaSplitSetting>())
                if (!string.IsNullOrEmpty(setting.ComboBox.Text))
                    Splits.Add(setting.Split);
        }

        private static List<ComboItem<TEnum>> BuildEnumList<TEnum>(int skip, Func<TEnum, string> display) where TEnum : struct
        {
            return Enum.GetValues(typeof(TEnum))
                       .Cast<TEnum>()
                       .Skip(skip)
                       .Select(x => new ComboItem<TEnum> { Value = x, Display = display(x) })
                       .ToList();
        }

        private static readonly StringComparer AlphaComparer = StringComparer.OrdinalIgnoreCase;

        public static readonly Lazy<IReadOnlyList<ComboItem<SplitName>>> Prefabs =
            new Lazy<IReadOnlyList<ComboItem<SplitName>>>(() => BuildEnumList<SplitName>(6, e => e.GetDescription())
                .Where(x => x.Value != SplitName.Build)
                .ToList());

        public static readonly Lazy<IReadOnlyList<ComboItem<InventoryItem>>> Items =
            new Lazy<IReadOnlyList<ComboItem<InventoryItem>>>(() => BuildEnumList<InventoryItem>(1, e => Localization.GetDisplayName(e)));

        public static readonly Lazy<IReadOnlyList<ComboItem<Unlockable>>> Blueprints =
            new Lazy<IReadOnlyList<ComboItem<Unlockable>>>(() => BuildEnumList<Unlockable>(1, e => Localization.GetDisplayName(e)));

        public static readonly Lazy<IReadOnlyList<ComboItem<EncyEntry>>> EncyEntries =
            new Lazy<IReadOnlyList<ComboItem<EncyEntry>>>(() => BuildEnumList<EncyEntry>(1, e => Localization.GetDisplayName(e)));

        public static readonly Lazy<IReadOnlyList<ComboItem<Biome>>> Biomes =
            new Lazy<IReadOnlyList<ComboItem<Biome>>>(() => BuildEnumList<Biome>(1, e => Localization.GetDisplayName(e)));

        public static readonly Lazy<IReadOnlyList<ComboItem<Craftable>>> Craftables =
            new Lazy<IReadOnlyList<ComboItem<Craftable>>>(() => BuildEnumList<Craftable>(1, e => Localization.GetDisplayName(e)));

        public static readonly Lazy<IReadOnlyList<ComboItem<Buildable>>> Buildables =
            new Lazy<IReadOnlyList<ComboItem<Buildable>>>(() => BuildEnumList<Buildable>(1, e => Localization.GetDisplayName(e)));

        public static readonly Lazy<IReadOnlyList<ComboItem<SplitName>>> PrefabAlpha =
            new Lazy<IReadOnlyList<ComboItem<SplitName>>>(() => Prefabs.Value.OrderBy(x => x.Display ?? string.Empty, AlphaComparer).ToList());

        public static readonly Lazy<IReadOnlyList<ComboItem<InventoryItem>>> ItemsAlpha =
            new Lazy<IReadOnlyList<ComboItem<InventoryItem>>>(() => Items.Value.OrderBy(x => x.Display ?? string.Empty, AlphaComparer).ToList());

        public static readonly Lazy<IReadOnlyList<ComboItem<Unlockable>>> BlueprintsAlpha =
            new Lazy<IReadOnlyList<ComboItem<Unlockable>>>(() => Blueprints.Value.OrderBy(x => x.Display ?? string.Empty, AlphaComparer).ToList());

        public static readonly Lazy<IReadOnlyList<ComboItem<EncyEntry>>> EncyEntriesAlpha =
            new Lazy<IReadOnlyList<ComboItem<EncyEntry>>>(() => EncyEntries.Value.OrderBy(x => x.Display ?? string.Empty, AlphaComparer).ToList());

        public static readonly Lazy<IReadOnlyList<ComboItem<Biome>>> BiomesAlpha =
            new Lazy<IReadOnlyList<ComboItem<Biome>>>(() => Biomes.Value.OrderBy(x => x.Display ?? string.Empty, AlphaComparer).ToList());

        public static readonly Lazy<IReadOnlyList<ComboItem<Craftable>>> CraftablesAlpha =
            new Lazy<IReadOnlyList<ComboItem<Craftable>>>(() => Craftables.Value.OrderBy(x => x.Display ?? string.Empty, AlphaComparer).ToList());

        public static readonly Lazy<IReadOnlyList<ComboItem<Buildable>>> BuildablesAlpha =
            new Lazy<IReadOnlyList<ComboItem<Buildable>>>(() => Buildables.Value.OrderBy(x => x.Display ?? string.Empty, AlphaComparer).ToList());

        public void AddHandlers(SubnauticaSplitSetting setting)
        {
            setting.ComboBox.SelectedIndexChanged += new EventHandler(ControlChanged);
            setting.BtnRemove.Click += new EventHandler(BtnRemoveClick);
            setting.BtnEdit.Click += new EventHandler(BtnEditClick);
        }

        public void RemoveHandlers(SubnauticaSplitSetting setting)
        {
            setting.ComboBox.SelectedIndexChanged -= ControlChanged;
            setting.BtnRemove.Click -= BtnRemoveClick;
            setting.BtnEdit.Click -= BtnEditClick;
        }

        public void ApplyDataSources(SubnauticaSplitSetting setting, bool alpha)
        {
            switch (setting)
            {
                case SubnauticaItemSplit _:
                    BindCombo(setting.ComboBox, alpha ? ItemsAlpha.Value : Items.Value, setting.ComboBox.SelectedValue);
                    break;
                case SubnauticaBlueprintSplit _:
                    BindCombo(setting.ComboBox, alpha ? BlueprintsAlpha.Value : Blueprints.Value, setting.ComboBox.SelectedValue);
                    break;
                case SubnauticaEncySplit _:
                    BindCombo(setting.ComboBox, alpha ? EncyEntriesAlpha.Value : EncyEntries.Value, setting.ComboBox.SelectedValue);
                    break;
                case SubnauticaBiomeSplit _:
                    BindCombo(setting.ComboBox, alpha ? BiomesAlpha.Value : Biomes.Value, setting.ComboBox.SelectedValue);
                    BindCombo(setting.ComboBox2, alpha ? BiomesAlpha.Value : Biomes.Value, setting.ComboBox2.SelectedValue ?? setting.ComboBox.SelectedValue);
                    break;
                case SubnauticaCraftSplit _:
                    BindCombo(setting.ComboBox, alpha ? CraftablesAlpha.Value : Craftables.Value, setting.ComboBox.SelectedValue);
                    break;
                case SubnauticaBuildSplit _:
                    BindCombo(setting.ComboBox, alpha ? BuildablesAlpha.Value : Buildables.Value, setting.ComboBox.SelectedValue);
                    break;
                default:
                    BindCombo(setting.ComboBox, alpha ? PrefabAlpha.Value : Prefabs.Value, setting.ComboBox.SelectedValue);
                    break;
            }
        }

        private T CreateSplit<T, TEnum>(IEnumerable<ComboItem<TEnum>> data, Func<T, ComboBox> getCombo, bool isSubCondition = false) where T : SubnauticaSplitSetting, new()
        {
            var setting = new T();           
            var combo = getCombo(setting);
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.MouseWheel += (o, e) => ((HandledMouseEventArgs)e).Handled = true;

            combo.DisplayMember = "Display";
            combo.ValueMember = "Value";
            combo.DataSource = data.ToList();

            if (combo.Items.Count > 0)
                combo.SelectedIndex = 0;

            setting.IsSubCondition = isSubCondition;            
            setting.Split.IsSubCondition = isSubCondition;            
            setting.BtnEdit.Text = "✔";
            AddHandlers(setting);
            return setting;
        }

        public SubnauticaPrefabSplit CreatePrefabSplit(bool isSubCondition) => CreateSplit<SubnauticaPrefabSplit, SplitName>(Alpha.Checked ? PrefabAlpha.Value : Prefabs.Value, s => s.cboName, isSubCondition);
        public SubnauticaItemSplit CreateItemSplit(bool isSubCondition) => CreateSplit<SubnauticaItemSplit, InventoryItem>(Alpha.Checked ? ItemsAlpha.Value : Items.Value, s => s.cboItem, isSubCondition);
        public SubnauticaBlueprintSplit CreateBlueprintSplit(bool isSubCondition) => CreateSplit<SubnauticaBlueprintSplit, Unlockable>(Alpha.Checked ? BlueprintsAlpha.Value : Blueprints.Value, s => s.cboBlueprint, isSubCondition);
        public SubnauticaEncySplit CreateEncySplit(bool isSubCondition) => CreateSplit<SubnauticaEncySplit, EncyEntry>(Alpha.Checked ? EncyEntriesAlpha.Value : EncyEntries.Value, s => s.cboEncy, isSubCondition);
        public SubnauticaCraftSplit CreateCraftSplit(bool isSubCondition) => CreateSplit<SubnauticaCraftSplit, Craftable>(Alpha.Checked ? CraftablesAlpha.Value : Craftables.Value, s => s.cboCraftables, isSubCondition);
        public SubnauticaBuildSplit CreateBuildSplit(bool isSubCondition) => CreateSplit<SubnauticaBuildSplit, Buildable>(Alpha.Checked ? BuildablesAlpha.Value : Buildables.Value, s => s.cboBuildables, isSubCondition);
        public SubnauticaBiomeSplit CreateBiomeSplit(bool isSubCondition)
        {
            var setting = new SubnauticaBiomeSplit();
            var data = Alpha.Checked ? BiomesAlpha : Biomes;
            BindCombo(setting.cboBiome1, data.Value, null);
            BindCombo(setting.cboBiome2, data.Value, null);
            setting.IsSubCondition = isSubCondition;
            setting.Split.IsSubCondition = isSubCondition;
            setting.btnEdit.Text = "✔";
            AddHandlers(setting);

            if (isSubCondition)
            {
                setting.ComboBox2.Visible = false;
                setting.pictureBox1.Visible = false;
                setting.picHandle.Left = 3;
                setting.picHandle.Top = 13;
                setting.btnEdit.Top = 16;
                setting.btnRemove.Top = 16;
                setting.BtnOptions.Top = 16;
            }

            return setting;
        }

        private static void BindCombo<T>(ComboBox combo, IEnumerable<ComboItem<T>> data, object previousSelected)
        {
            combo.BeginUpdate();
            try
            {
                combo.BindingContext = new BindingContext();
                var list = (data as IList<ComboItem<T>>) ?? data.ToList();
                combo.DisplayMember = "Display";
                combo.ValueMember = "Value";
                combo.DataSource = new List<ComboItem<T>>(list);
                if (previousSelected is T t) combo.SelectedValue = t;
            }
            finally
            {
                combo.EndUpdate();
            }
        }

        public void CreateTextComponent(string id)
        {
            var existing = State.Layout.Components
                .Where(c => c.GetType().Name == "TextComponent")
                .Select(c => c.GetType().GetProperty("Settings").GetValue(c))
                .FirstOrDefault(s => (string)s.GetType().GetProperty("Text1").GetValue(s) == id);

            if (existing != null)
                return;

            var asm = Assembly.LoadFrom("Components\\LiveSplit.Text.dll");
            var comp = Activator.CreateInstance(asm.GetType("LiveSplit.UI.Components.TextComponent"), State);

            State.Layout.LayoutComponents.Add(new LiveSplit.UI.Components.LayoutComponent("LiveSplit.Text.dll", comp as LiveSplit.UI.Components.IComponent));

            var settings = comp.GetType().GetProperty("Settings").GetValue(comp);
            settings.GetType().GetProperty("Text1").SetValue(settings, id);
        }

        public void UpdateTextComponent(string id, string text)
        {
            var setting = State.Layout.Components
                .Where(c => c.GetType().Name == "TextComponent")
                .Select(c => c.GetType().GetProperty("Settings").GetValue(c))
                .FirstOrDefault(s => (string)s.GetType().GetProperty("Text1").GetValue(s) == id);

            if (setting == null)
                return;

            setting.GetType().GetProperty("Text2").SetValue(setting, text);
        }

        public void DestroyTextComponent(string id)
        {
            var compEntry = State.Layout.LayoutComponents
                .FirstOrDefault(lc => lc.Component.GetType().Name == "TextComponent" && (string)lc.Component.GetType()
                .GetProperty("Settings")
                .GetValue(lc.Component)
                .GetType()
                .GetProperty("Text1")
                .GetValue(
                    lc.Component.GetType()
                        .GetProperty("Settings")
                        .GetValue(lc.Component)
                ) == id
            );

            if (compEntry == null)
                return;

            State.Layout.LayoutComponents.Remove(compEntry);
        }

        public virtual void LoadSettings()
        {
            SubnauticaSplitSetting[] settings = new SubnauticaSplitSetting[Splits.Count];

            try
            {
                MainPanel.SuspendLayout();

                for (int i = MainPanel.Controls.Count - 1; i > 0; i--)
                    MainPanel.Controls.RemoveAt(i);

                for (int i = 0; i < Splits.Count; i++)
                {
                    var split = Splits[i];
                    SubnauticaSplitSetting setting = new SubnauticaSplitSetting();
                    switch (split)
                    {
                        case ItemSplit s:
                            setting = new SubnauticaItemSplit(s) { IsLoadingGetter = () => this.IsLoading };
                            ApplyDataSources(setting, Alpha.Checked);
                            setting.ComboBox.SelectedValue = ((ItemSplit)setting.Split).Item;
                            break;

                        case BlueprintSplit s:
                            setting = new SubnauticaBlueprintSplit(s) { IsLoadingGetter = () => this.IsLoading };
                            ApplyDataSources(setting, Alpha.Checked);
                            setting.ComboBox.SelectedValue = ((BlueprintSplit)setting.Split).Blueprint;
                            break;

                        case EncySplit s:
                            setting = new SubnauticaEncySplit(s) { IsLoadingGetter = () => this.IsLoading };
                            ApplyDataSources(setting, Alpha.Checked);
                            setting.ComboBox.SelectedValue = ((EncySplit)setting.Split).Entry;
                            break;

                        case BiomeSplit s:
                            setting = new SubnauticaBiomeSplit(s) { IsLoadingGetter = () => this.IsLoading };
                            ApplyDataSources(setting, Alpha.Checked);
                            setting.ComboBox.SelectedValue = ((BiomeSplit)setting.Split).Biomes.Biome1;
                            setting.ComboBox2.SelectedValue = ((BiomeSplit)setting.Split).Biomes.Biome2;
                            break;

                        case CraftSplit s:
                            setting = new SubnauticaCraftSplit(s) { IsLoadingGetter = () => this.IsLoading };
                            ApplyDataSources(setting, Alpha.Checked);
                            setting.ComboBox.SelectedValue = ((CraftSplit)setting.Split).Craftable;
                            break;

                        case BuildSplit s:
                            setting = new SubnauticaBuildSplit(s) { IsLoadingGetter = () => this.IsLoading };
                            ApplyDataSources(setting, Alpha.Checked);
                            setting.ComboBox.SelectedValue = ((BuildSplit)setting.Split).Buildable;
                            break;

                        case PrefabSplit s:
                            setting = new SubnauticaPrefabSplit(s) { IsLoadingGetter = () => this.IsLoading };
                            ApplyDataSources(setting, Alpha.Checked);
                            setting.ComboBox.SelectedValue = ((PrefabSplit)setting.Split).SplitName;
                            break;

                        default: break;
                    }

                    setting.ComboBox.Enabled = false;
                    if (setting.ComboBox2 != null) setting.ComboBox2.Enabled = false;

                    AddHandlers(setting);
                    settings[i] = setting;
                }
            }
            finally
            {
                MainPanel.Controls.AddRange(settings);
                MainPanel.ResumeLayout();
            }
        }

        #region Dragging
        public void flowMainPaint(object sender, PaintEventArgs e)
        {
            if (_insertMarkerY < 0)
                return;

            using (var pen = new Pen(Color.DodgerBlue, 3))
            {
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                int margin = 4;

                e.Graphics.DrawLine(
                    pen,
                    margin,
                    _insertMarkerY,
                    MainPanel.ClientSize.Width - margin,
                    _insertMarkerY
                );
            }
        }
        public void flowMainDragEnter(object sender, DragEventArgs e)
        {
            _dragItem = GetDraggedSetting(e);

            if (_dragItem != null)
            {
                e.Effect = DragDropEffects.Move;
                _insertMarkerY = -1;
                MainPanel.Invalidate();
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        public void flowMainDragLeave(object sender, EventArgs e)
        {
            _dragItem = null;
            _dragTargetIndex = -1;
            _insertMarkerY = -1;
            _insertBeforeControl = null;

            if (_highlightControl != null)
            {
                _highlightControl.BackColor = SystemColors.Control;
                _highlightControl = null;
            }

            MainPanel.Invalidate();
        }

        public void flowMainDragDrop(object sender, DragEventArgs e)
        {
            var panel = (FlowLayoutPanel)sender;

            if (_dragItem != null && _dragTargetIndex > 0)
            {
                panel.SuspendLayout();

                int minIndex = GetMinSplitIndex(panel);

                int index = _dragTargetIndex;
                if (index < minIndex)
                    index = minIndex;
                if (index > panel.Controls.Count)
                    index = panel.Controls.Count;

                int oldIndex = panel.Controls.IndexOf(_dragItem);

                if (oldIndex >= 0 && index > oldIndex)
                    index--;

                if (index >= panel.Controls.Count)
                    index = panel.Controls.Count - 1;

                panel.Controls.SetChildIndex(_dragItem, index);

                panel.ResumeLayout();
            }

            _dragItem = null;
            _dragTargetIndex = -1;
            _insertMarkerY = -1;
            _insertBeforeControl = null;

            if (_highlightControl != null)
            {
                _highlightControl.BackColor = SystemColors.Control;
                _highlightControl = null;
            }

            MainPanel.Invalidate();

            UpdateSplits();
        }

        public void flowMainDragOver(object sender, DragEventArgs e)
        {
            var panel = (FlowLayoutPanel)sender;

            if (_dragItem == null)
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            e.Effect = DragDropEffects.Move;

            Point clientPoint = panel.PointToClient(new Point(e.X, e.Y));

            const int scrollRegion = 25;
            const int scrollStep = 15;

            if (clientPoint.Y < scrollRegion &&
                panel.VerticalScroll.Value > panel.VerticalScroll.Minimum)
            {
                panel.VerticalScroll.Value = Math.Max(
                    panel.VerticalScroll.Value - scrollStep,
                    panel.VerticalScroll.Minimum);
            }
            else if (clientPoint.Y > panel.ClientSize.Height - scrollRegion &&
                     panel.VerticalScroll.Value < panel.VerticalScroll.Maximum)
            {
                panel.VerticalScroll.Value = Math.Min(
                    panel.VerticalScroll.Value + scrollStep,
                    panel.VerticalScroll.Maximum);
            }

            int minIndex = GetMinSplitIndex(panel);
            int targetIndex = minIndex;

            Control insertBefore = null;

            for (int i = minIndex; i < panel.Controls.Count; i++)
            {
                var c = panel.Controls[i];
                if (c == _dragItem)
                    continue;

                int controlMidY = c.Bounds.Top + c.Bounds.Height / 2;

                if (clientPoint.Y < controlMidY)
                {
                    targetIndex = i;
                    insertBefore = c;
                    break;
                }

                targetIndex = i + 1;
            }

            if (insertBefore == null && panel.Controls.Count > 0)
            {
                targetIndex = panel.Controls.Count;
                insertBefore = null;
            }

            if (targetIndex < minIndex)
                targetIndex = minIndex;
            if (targetIndex > panel.Controls.Count)
                targetIndex = panel.Controls.Count;

            _dragTargetIndex = targetIndex;
            _insertBeforeControl = insertBefore;

            Control newHighlight = _insertBeforeControl;

            if (newHighlight != null && !(newHighlight is SubnauticaSplitSetting))
            {
                newHighlight = null;
            }

            if (_highlightControl != newHighlight)
            {
                if (_highlightControl != null)
                    _highlightControl.BackColor = SystemColors.Control;

                _highlightControl = newHighlight;

                if (_highlightControl != null)
                    _highlightControl.BackColor = Color.FromArgb(230, 240, 255);
            }

            if (_insertBeforeControl != null)
            {
                _insertMarkerY = _insertBeforeControl.Bounds.Top;
            }
            else if (panel.Controls.Count > 0)
            {
                var last = panel.Controls[panel.Controls.Count - 1];
                _insertMarkerY = last.Bounds.Bottom;
            }
            else
            {
                _insertMarkerY = -1;
            }

            panel.Invalidate();
        }
        int GetMinSplitIndex(FlowLayoutPanel panel)
        {
            int settingsIndex = panel.Controls.IndexOf(Options);
            if (settingsIndex < 0)
                settingsIndex = 0;
            return settingsIndex + 1;
        }
        private SubnauticaSplitSetting GetDraggedSetting(DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(SubnauticaSplitSetting)))
                return (SubnauticaSplitSetting)e.Data.GetData(typeof(SubnauticaSplitSetting));
            if (e.Data.GetDataPresent(typeof(SubnauticaBlueprintSplit)))
                return (SubnauticaSplitSetting)e.Data.GetData(typeof(SubnauticaBlueprintSplit));
            if (e.Data.GetDataPresent(typeof(SubnauticaItemSplit)))
                return (SubnauticaSplitSetting)e.Data.GetData(typeof(SubnauticaItemSplit));
            if (e.Data.GetDataPresent(typeof(SubnauticaPrefabSplit)))
                return (SubnauticaSplitSetting)e.Data.GetData(typeof(SubnauticaPrefabSplit));
            if (e.Data.GetDataPresent(typeof(SubnauticaEncySplit)))
                return (SubnauticaSplitSetting)e.Data.GetData(typeof(SubnauticaEncySplit));
            if (e.Data.GetDataPresent(typeof(SubnauticaBiomeSplit)))
                return (SubnauticaSplitSetting)e.Data.GetData(typeof(SubnauticaBiomeSplit));
            if (e.Data.GetDataPresent(typeof(SubnauticaCraftSplit)))
                return (SubnauticaSplitSetting)e.Data.GetData(typeof(SubnauticaCraftSplit));
            if (e.Data.GetDataPresent(typeof(SubnauticaBuildSplit)))
                return (SubnauticaSplitSetting)e.Data.GetData(typeof(SubnauticaBuildSplit));

            return null;
        }
        #endregion Dragging
    }

    public sealed class ComboItem<T>
    {
        public T Value { get; set; }
        public string Display { get; set; }
    }
}
