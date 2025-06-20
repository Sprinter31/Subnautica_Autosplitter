using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static Livesplit.Subnautica.SubnauticaSplitSettings;

namespace Livesplit.Subnautica
{
    public partial class SubnauticaSettings : UserControl
    {
        public List<SplitName> Splits { get; private set; }
        public bool introStart { get; set; }
        public bool creativeStart { get; set; }

        private static ReaderWriterLockSlim isLoading = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);
        private List<string> availableSplits = new List<string>();
        private List<string> availableSplitsAlphaSorted = new List<string>();
        public SubnauticaSettings()
        {
            InitializeComponent();
            Splits = new List<SplitName>();
        }

        private void btnAddSplit_Click(object sender, EventArgs e)
        {
            SubnauticaSplitSettings setting = createSetting();
            flowMain.Controls.Add(setting);
            UpdateSplits();
        }

        public void btnRemove_Click(object sender, EventArgs e)
        {
            for (int i = flowMain.Controls.Count - 1; i > 0; i--)
            {
                if (flowMain.Controls[i].Contains((Control)sender))
                {
                    RemoveHandlers((SubnauticaSplitSettings)((Button)sender).Parent);

                    flowMain.Controls.RemoveAt(i);
                    break;
                }
            }
            UpdateSplits();
        }

        public void btnEdit_Click(object sender, EventArgs e)
        {
            for (int i = flowMain.Controls.Count - 1; i > 0; i--)
            {
                if (flowMain.Controls[i].Contains((Control)sender))
                {
                    SubnauticaSplitSettings setting = (SubnauticaSplitSettings)((Button)sender).Parent;
                    if (setting.cboName.Enabled)
                    {
                        disableEdit(setting);
                    }
                    else
                    {
                        enableEdit(setting);
                    }
                    break;
                }
            }
        }
        private void btnAddAbove_Click(object sender, EventArgs e)
        {
            for (int i = flowMain.Controls.Count - 1; i > 0; i--)
            {
                if (flowMain.Controls[i].Contains((Control)sender))
                {
                    SubnauticaSplitSettings setting = (SubnauticaSplitSettings)((Button)sender).Parent;
                    int index = setting.Parent.Controls.GetChildIndex(setting);
                    addSplitAtIndex(index);
                }
            }
        }
        private void btnAddBelow_Click(object sender, EventArgs e)
        {
            for (int i = flowMain.Controls.Count - 1; i > 0; i--)
            {
                if (flowMain.Controls[i].Contains((Control)sender))
                {
                    SubnauticaSplitSettings setting = (SubnauticaSplitSettings)((Button)sender).Parent;
                    int index = setting.Parent.Controls.GetChildIndex(setting);
                    addSplitAtIndex(index + 1);
                }
            }
        }
        private void addSplitAtIndex(int index)
        {
            SubnauticaSplitSettings setting = createSetting();
            flowMain.Controls.Add(setting);
            flowMain.Controls.SetChildIndex(setting, index);
            UpdateSplits();
        }
        private void enableEdit(SubnauticaSplitSettings setting)
        {
            string currentText = setting.cboName.Text;
            setting.btnEdit.Text = "✔";
            setting.cboName.DataSource = GetAvailableSplits();
            setting.cboName.Text = currentText;
            setting.cboName.Enabled = true;
        }
        private void disableEdit(SubnauticaSplitSettings setting)
        {
            setting.btnEdit.Text = "✏";
            setting.cboName.Enabled = false;
        }
        public void ControlChanged(object sender, EventArgs e)
        {
            UpdateSplits();
        }

        public void UpdateSplits()
        {
            try
            {
                // NO retry, lower priority than SetSettings and LoadSettings
                if (!isLoading.TryEnterWriteLock(0))
                {
                    return;
                }
            }
            catch (LockRecursionException)
            {
                return;
            }

            introStart = chkIntroStart.Checked;
            creativeStart = chkCreativeStart.Checked;

            Splits.Clear();
            foreach (Control c in flowMain.Controls)
            {
                if (c is SubnauticaSplitSettings)
                {
                    SubnauticaSplitSettings setting = (SubnauticaSplitSettings)c;
                    if (!string.IsNullOrEmpty(setting.cboName.Text))
                    {
                        SplitName split = GetSplitName(setting.cboName.Text);
                        Splits.Add(split);
                    }
                }
            }

            isLoading.ExitWriteLock();
        }
        

        private void AddHandlers(SubnauticaSplitSettings setting)
        {
            setting.cboName.SelectedIndexChanged += new EventHandler(ControlChanged);
            setting.btnRemove.Click += new EventHandler(btnRemove_Click);
            setting.btnEdit.Click += new EventHandler(btnEdit_Click);
            setting.btnAddAbove.Click += new EventHandler(btnAddAbove_Click);
            setting.btnAddBelow.Click += new EventHandler(btnAddBelow_Click);
        }
        private void RemoveHandlers(SubnauticaSplitSettings setting)
        {
            setting.cboName.SelectedIndexChanged -= ControlChanged;
            setting.btnRemove.Click -= btnRemove_Click;
            setting.btnEdit.Click -= btnEdit_Click;
            setting.btnAddAbove.Click -= btnAddAbove_Click;
            setting.btnAddBelow.Click -= btnAddBelow_Click;
        }

        public void LoadSettings()
        {
            try
            {
                // 5 seconds, higher priority than UpdateSplits
                if (!isLoading.TryEnterReadLock(5000))
                {
                    return;
                }
            }
            catch (LockRecursionException)
            {
                return;
            }

            this.flowMain.SuspendLayout();

            for (int i = flowMain.Controls.Count - 1; i > 0; i--)
            {
                flowMain.Controls.RemoveAt(i);
            }

            chkIntroStart.Checked = introStart;
            chkCreativeStart.Checked = creativeStart;

            foreach (SplitName split in Splits)
            {
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

        private void Settings_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private SubnauticaSplitSettings createSetting()
        {
            SubnauticaSplitSettings setting = new SubnauticaSplitSettings();
            List<string> splitNames = GetAvailableSplits();
            setting.cboName.DataSource = splitNames;
            setting.cboName.Text = splitNames[0];
            setting.btnEdit.Text = "✔";
            AddHandlers(setting);
            return setting;
        }

        private List<string> GetAvailableSplits()
        {
            if (availableSplits.Count == 0)
            {
                foreach (SplitName split in Enum.GetValues(typeof(SplitName)))
                {
                    MemberInfo info = typeof(SplitName).GetMember(split.ToString())[0];
                    DescriptionAttribute description = (DescriptionAttribute)info.GetCustomAttributes(typeof(DescriptionAttribute), false)[0];
                    availableSplits.Add(description.Description);
                    availableSplitsAlphaSorted.Add(description.Description);
                }
                availableSplitsAlphaSorted.Sort(delegate (string one, string two)
                {
                    return one.CompareTo(two);
                });
            }
            return rdAlpha.Checked ? availableSplitsAlphaSorted : availableSplits;
        }

        private void radio_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control c in flowMain.Controls)
            {
                if (c is SubnauticaSplitSettings)
                {
                    SubnauticaSplitSettings setting = (SubnauticaSplitSettings)c;
                    if (setting.cboName.Enabled)
                    {
                        string text = setting.cboName.Text;
                        setting.cboName.DataSource = GetAvailableSplits();
                        setting.cboName.Text = text;
                    }
                }
            }
        }

        public XmlNode UpdateSettings(XmlDocument document)
        {
            XmlElement xmlSettings = document.CreateElement("Settings");

            XmlElement xmlIntroStart = document.CreateElement("IntroStart");
            xmlIntroStart.InnerText = introStart.ToString();
            xmlSettings.AppendChild(xmlIntroStart);

            XmlElement xmlCreativeStart = document.CreateElement("CreativeStart");
            xmlCreativeStart.InnerText = creativeStart.ToString();
            xmlSettings.AppendChild(xmlCreativeStart);

            XmlElement xmlSplits = document.CreateElement("Splits");
            xmlSettings.AppendChild(xmlSplits);

            foreach (SplitName split in Splits)
            {
                XmlElement xmlSplit = document.CreateElement("Split");
                xmlSplit.InnerText = split.ToString();

                xmlSplits.AppendChild(xmlSplit);
            }

            return xmlSettings;
        }

        public void SetSettings(XmlNode settings)
        {
            try
            {
                // 5 seconds, higher priority than UpdateSplits
                if (!isLoading.TryEnterWriteLock(5000))
                {
                    return;
                }
            }
            catch (LockRecursionException)
            {
                return;
            }

            XmlNode splitsNode = settings.SelectSingleNode(".//Splits");

            if (splitsNode != null)
            {
                XmlNode introStartNode = settings.SelectSingleNode(".//IntroStart");
                XmlNode creativeStartNode = settings.SelectSingleNode(".//CreativeStart");

                bool isIntroStart = false;
                bool isCreativeStart = false;

                if (introStartNode != null)
                {
                    bool.TryParse(introStartNode.InnerText, out isIntroStart);
                }
                if (creativeStartNode != null)
                {
                    bool.TryParse(creativeStartNode.InnerText, out isCreativeStart);
                }                
                introStart = isIntroStart;
                creativeStart = isCreativeStart;

                Splits.Clear();
                XmlNodeList splitNodes = settings.SelectNodes(".//Splits/Split");
                foreach (XmlNode splitNode in splitNodes)
                {
                    string splitDescription = splitNode.InnerText;
                    SplitName split = GetSplitName(splitDescription);
                    Splits.Add(split);
                }

            }
            else
            {
                // no splits settings, default
                introStart = false;
                creativeStart = false;
                Splits.Clear();
            }

            isLoading.ExitWriteLock();
        }
    }
}
