﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
namespace LiveSplit.HollowKnight {
    public partial class SubnauticaSettings : UserControl {
        public List<SplitName> Splits { get; private set; }
        public bool Ordered { get; set; }
        public bool AutosplitEndRuns { get; set; }
        public SplitName? AutosplitStartRuns { get; set; }
        private static ReaderWriterLockSlim isLoading = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);
        private List<string> availableSplits = new List<string>();
        private List<string> availableSplitsAlphaSorted = new List<string>();

        public SubnauticaSettings() {
            isLoading.EnterWriteLock();
            InitializeComponent();
            string version = Version.Parse("1.0.0.0").ToString();
#if DEBUG
            version += "-dev";
#endif
            this.versionLabel.Text = "Autosplitter Version: " + version;

            Splits = new List<SplitName>();
            isLoading.ExitWriteLock();
        }

        public bool HasSplit(SplitName split) {
            return Splits.Contains(split);
        }

        private void Settings_Load(object sender, EventArgs e) {
            LoadSettings();
        }
        public void LoadSettings() {
            try {
                // 5 seconds, higher priority than UpdateSplits
                if (!isLoading.TryEnterReadLock(5000)) {
                    return;
                }
            } catch (LockRecursionException) {
                return;
            }

            this.flowMain.SuspendLayout();

            for (int i = flowMain.Controls.Count - 1; i > 0; i--) {
                flowMain.Controls.RemoveAt(i);
            }

            chkOrdered.Checked = Ordered;
            chkAutosplitEndRuns.Checked = AutosplitEndRuns;
            chkAutosplitStartRuns.Checked = AutosplitStartRuns != null;

            foreach (SplitName split in Splits) {
                MemberInfo info = typeof(SplitName).GetMember(split.ToString())[0];
                DescriptionAttribute description = (DescriptionAttribute)info.GetCustomAttributes(typeof(DescriptionAttribute), false)[0];

                SubnauticaSplitSettings setting = new SubnauticaSplitSettings();
                setting.cboName.DataSource = new List<string>() { description.Description };
                setting.cboName.Enabled = false;
                setting.cboName.Text = description.Description;
                AddHandlers(setting);

                flowMain.Controls.Add(setting);
            }

            isLoading.ExitReadLock();
            this.flowMain.ResumeLayout(true);
        }
        private void AddHandlers(SubnauticaSplitSettings setting) {
            setting.cboName.SelectedIndexChanged += new EventHandler(ControlChanged);
            setting.btnRemove.Click += new EventHandler(btnRemove_Click);
            setting.btnEdit.Click += new EventHandler(btnEdit_Click);
            setting.btnAddAbove.Click += new EventHandler(btnAddAbove_Click);
            setting.btnAddBelow.Click += new EventHandler(btnAddBelow_Click);
        }
        private void RemoveHandlers(SubnauticaSplitSettings setting) {
            setting.cboName.SelectedIndexChanged -= ControlChanged;
            setting.btnRemove.Click -= btnRemove_Click;
            setting.btnEdit.Click -= btnEdit_Click;
            setting.btnAddAbove.Click -= btnAddAbove_Click;
            setting.btnAddBelow.Click -= btnAddBelow_Click;
        }
        public void btnRemove_Click(object sender, EventArgs e) {
            for (int i = flowMain.Controls.Count - 1; i > 0; i--) {
                if (flowMain.Controls[i].Contains((Control)sender)) {
                    RemoveHandlers((SubnauticaSplitSettings)((Button)sender).Parent);

                    flowMain.Controls.RemoveAt(i);
                    break;
                }
            }
            UpdateSplits();
        }
        public void btnEdit_Click(object sender, EventArgs e) {
            for (int i = flowMain.Controls.Count - 1; i > 0; i--) {
                if (flowMain.Controls[i].Contains((Control)sender)) {
                    SubnauticaSplitSettings setting = (SubnauticaSplitSettings)((Button)sender).Parent;
                    if (setting.cboName.Enabled) {
                        disableEdit(setting);
                    } else {
                        enableEdit(setting);
                    }
                    break;
                }
            }
        }
        private void btnAddAbove_Click(object sender, EventArgs e) {
            for (int i = flowMain.Controls.Count - 1; i > 0; i--) {
                if (flowMain.Controls[i].Contains((Control)sender)) {
                    SubnauticaSplitSettings setting = (SubnauticaSplitSettings)((Button)sender).Parent;
                    int index = setting.Parent.Controls.GetChildIndex(setting);
                    addSplitAtIndex(index);
                }
            }
        }
        private void btnAddBelow_Click(object sender, EventArgs e) {
            for (int i = flowMain.Controls.Count - 1; i > 0; i--) {
                if (flowMain.Controls[i].Contains((Control)sender)) {
                    SubnauticaSplitSettings setting = (SubnauticaSplitSettings)((Button)sender).Parent;
                    int index = setting.Parent.Controls.GetChildIndex(setting);
                    addSplitAtIndex(index + 1);
                }
            }
        }
        private void enableEdit(SubnauticaSplitSettings setting) {
            string currentText = setting.cboName.Text;
            setting.btnEdit.Text = "✔";
            setting.cboName.DataSource = GetAvailableSplits();
            setting.cboName.Text = currentText;
            setting.cboName.Enabled = true;
        }
        private void disableEdit(SubnauticaSplitSettings setting) {
            setting.btnEdit.Text = "✏";
            setting.cboName.Enabled = false;
        }
        public void ControlChanged(object sender, EventArgs e) {
            UpdateSplits();
        }
        public void UpdateSplits() {
            try {
                // NO retry, lower priority than SetSettings and LoadSettings
                if (!isLoading.TryEnterWriteLock(0)) {
                    return;
                }
            } catch (LockRecursionException) {
                return;
            }

            Ordered = chkOrdered.Checked;
            AutosplitEndRuns = chkAutosplitEndRuns.Checked;
            AutosplitStartRuns = chkAutosplitStartRuns.Checked ?
                SubnauticaSplitSettings.GetSplitName(cboStartTriggerName.Text) : null;

            Splits.Clear();
            foreach (Control c in flowMain.Controls) {
                if (c is SubnauticaSplitSettings) {
                    SubnauticaSplitSettings setting = (SubnauticaSplitSettings)c;
                    if (!string.IsNullOrEmpty(setting.cboName.Text)) {
                        SplitName split = SubnauticaSplitSettings.GetSplitName(setting.cboName.Text);
                        Splits.Add(split);
                    }
                }
            }

            isLoading.ExitWriteLock();
        }
        public XmlNode UpdateSettings(XmlDocument document) {
            XmlElement xmlSettings = document.CreateElement("Settings");

            XmlElement xmlOrdered = document.CreateElement("Ordered");
            xmlOrdered.InnerText = Ordered.ToString();
            xmlSettings.AppendChild(xmlOrdered);

            XmlElement xmlAutosplitEndRuns = document.CreateElement("AutosplitEndRuns");
            xmlAutosplitEndRuns.InnerText = AutosplitEndRuns.ToString();
            xmlSettings.AppendChild(xmlAutosplitEndRuns);

            XmlElement xmlAutosplitStartRuns = document.CreateElement("AutosplitStartRuns");
            xmlAutosplitStartRuns.InnerText = AutosplitStartRuns.ToString();
            xmlSettings.AppendChild(xmlAutosplitStartRuns);

            XmlElement xmlSplits = document.CreateElement("Splits");
            xmlSettings.AppendChild(xmlSplits);

            foreach (SplitName split in Splits) {
                XmlElement xmlSplit = document.CreateElement("Split");
                xmlSplit.InnerText = split.ToString();

                xmlSplits.AppendChild(xmlSplit);
            }

            return xmlSettings;
        }

        public void SetSettings(XmlNode settings) {
            try {
                // 5 seconds, higher priority than UpdateSplits
                if (!isLoading.TryEnterWriteLock(5000)) {
                    return;
                }
            } catch (LockRecursionException) {
                return;
            }

            XmlNode splitsNode = settings.SelectSingleNode(".//Splits"); // will be null if it's the WASM autosplitter
            XmlNode customSettingsNode = settings.SelectSingleNode(".//CustomSettings"); // will be null if it's the Default autosplitter

            if (splitsNode != null) {
                // Default autosplitter
                XmlNode orderedNode = settings.SelectSingleNode(".//Ordered");
                XmlNode AutosplitEndRunsNode = settings.SelectSingleNode(".//AutosplitEndRuns");
                XmlNode AutosplitStartRunsNode = settings.SelectSingleNode(".//AutosplitStartRuns");
                bool isOrdered = false;
                bool isAutosplitEndRuns = false;

                if (orderedNode != null) {
                    bool.TryParse(orderedNode.InnerText, out isOrdered);
                }
                if (AutosplitEndRunsNode != null) {
                    bool.TryParse(AutosplitEndRunsNode.InnerText, out isAutosplitEndRuns);
                }
                if (AutosplitStartRunsNode != null) {
                    string splitDescription = AutosplitStartRunsNode.InnerText.Trim();
                    if (!string.IsNullOrEmpty(splitDescription)) {
                        cboStartTriggerName.DataSource = GetAvailableSplits();
                        AutosplitStartRuns = SubnauticaSplitSettings.GetSplitName(splitDescription);
                        MemberInfo info = typeof(SplitName).GetMember(AutosplitStartRuns.ToString())[0];
                        DescriptionAttribute description = (DescriptionAttribute)info.GetCustomAttributes(typeof(DescriptionAttribute), false)[0];
                        cboStartTriggerName.Text = description.Description;
                        chkAutosplitStartRuns.Checked = true;
                    }
                }
                Ordered = isOrdered;
                AutosplitEndRuns = isAutosplitEndRuns;

                Splits.Clear();
                XmlNodeList splitNodes = settings.SelectNodes(".//Splits/Split");
                foreach (XmlNode splitNode in splitNodes) {
                    string splitDescription = splitNode.InnerText;
                    SplitName split = SubnauticaSplitSettings.GetSplitName(splitDescription);
                    Splits.Add(split);
                }

            } else if (customSettingsNode != null) {
                // WASM autosplitter
                bool afterStart = false;
                Ordered = true;
                AutosplitEndRuns = true;

                Splits.Clear();
                XmlNodeList splitNodes = settings.SelectNodes(".//CustomSettings/Setting[@id='splits']/Setting");
                foreach (XmlNode splitNode in splitNodes) {
                    string value = splitNode.Attributes.GetNamedItem("value").Value;
                    if (!afterStart) {
                        afterStart = true;
                        if (value != "LegacyStart") {
                            cboStartTriggerName.DataSource = GetAvailableSplits();
                            AutosplitStartRuns = SubnauticaSplitSettings.GetSplitName(value);
                            MemberInfo info = typeof(SplitName).GetMember(AutosplitStartRuns.ToString())[0];
                            DescriptionAttribute description = (DescriptionAttribute)info.GetCustomAttributes(typeof(DescriptionAttribute), false)[0];
                            cboStartTriggerName.Text = description.Description;
                            chkAutosplitStartRuns.Checked = true;
                        }
                    } else {
                        Splits.Add(SubnauticaSplitSettings.GetSplitName(value));
                    }
                }
            } else {
                // no splits settings, default
                Ordered = false;
                AutosplitEndRuns = false;
                Splits.Clear();
            }

            isLoading.ExitWriteLock();
        }

        private SubnauticaSplitSettings createSetting() {
            SubnauticaSplitSettings setting = new SubnauticaSplitSettings();
            List<string> splitNames = GetAvailableSplits();
            setting.cboName.DataSource = splitNames;
            setting.cboName.Text = splitNames[0];
            setting.btnEdit.Text = "✔";
            AddHandlers(setting);
            return setting;
        }
        private void btnAddSplit_Click(object sender, EventArgs e) {
            SubnauticaSplitSettings setting = createSetting();
            flowMain.Controls.Add(setting);
            UpdateSplits();
        }
        private void addSplitAtIndex(int index) {
            SubnauticaSplitSettings setting = createSetting();
            flowMain.Controls.Add(setting);
            flowMain.Controls.SetChildIndex(setting, index);
            UpdateSplits();
        }
        private List<string> GetAvailableSplits() {
            if (availableSplits.Count == 0) {
                foreach (SplitName split in Enum.GetValues(typeof(SplitName))) {
                    MemberInfo info = typeof(SplitName).GetMember(split.ToString())[0];
                    DescriptionAttribute description = (DescriptionAttribute)info.GetCustomAttributes(typeof(DescriptionAttribute), false)[0];
                    availableSplits.Add(description.Description);
                    availableSplitsAlphaSorted.Add(description.Description);
                }
                availableSplitsAlphaSorted.Sort(delegate (string one, string two) {
                    return one.CompareTo(two);
                });
            }
            return rdAlpha.Checked ? availableSplitsAlphaSorted : availableSplits;
        }
        private void radio_CheckedChanged(object sender, EventArgs e) {
            foreach (Control c in flowMain.Controls) {
                if (c is SubnauticaSplitSettings) {
                    SubnauticaSplitSettings setting = (SubnauticaSplitSettings)c;
                    if (setting.cboName.Enabled) {
                        string text = setting.cboName.Text;
                        setting.cboName.DataSource = GetAvailableSplits();
                        setting.cboName.Text = text;
                    }
                }
            }

            if (chkAutosplitStartRuns.Checked) {
                string text = cboStartTriggerName.Text;
                cboStartTriggerName.DataSource = GetAvailableSplits();
                cboStartTriggerName.Text = text;
            }
        }
        private void flowMain_DragDrop(object sender, DragEventArgs e) {
            UpdateSplits();
        }
        private void flowMain_DragEnter(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Move;
        }
        private void flowMain_DragOver(object sender, DragEventArgs e) {
            SubnauticaSplitSettings data = (SubnauticaSplitSettings)e.Data.GetData(typeof(SubnauticaSplitSettings));
            FlowLayoutPanel destination = (FlowLayoutPanel)sender;
            Point p = destination.PointToClient(new Point(e.X, e.Y));
            var item = destination.GetChildAtPoint(p);
            int index = destination.Controls.GetChildIndex(item, false);
            if (index == 0) {
                e.Effect = DragDropEffects.None;
            } else {
                e.Effect = DragDropEffects.Move;
                int oldIndex = destination.Controls.GetChildIndex(data);
                if (oldIndex != index) {
                    enableEdit(data);
                    destination.Controls.SetChildIndex(data, index);
                    destination.Invalidate();
                }
            }
        }
        private void AutosplitEndChanged(object sender, EventArgs e) {
            UpdateSplits();
        }

        private void AutosplitStartChanged(object sender, EventArgs e) {
            if (chkAutosplitStartRuns.Checked) {
                cboStartTriggerName.Enabled = true;
                cboStartTriggerName.DataSource = GetAvailableSplits();
            }
            else {
                cboStartTriggerName.Text = "";
                cboStartTriggerName.Enabled = false;
                cboStartTriggerName.DataSource = new List<string>();
            }
            UpdateSplits();
        }

        private void cboStartTriggerName_SelectedIndexChanged(object sender, EventArgs e) {
            UpdateSplits();
        }
    }
}
