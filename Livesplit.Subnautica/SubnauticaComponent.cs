using LiveSplit.Model;
using LiveSplit.UI;
using LiveSplit.UI.Components.AutoSplit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Livesplit.Subnautica
{
    public class SubnauticaComponent : AutoSplitComponent
    {
        private static SubnauticaSettings settings = new SubnauticaSettings();
        static SubnauticaSplitter splitter = new SubnauticaSplitter(settings);
        internal SubnauticaComponent(LiveSplitState state) : base(splitter, state)
        {
            state.OnReset += OnReset;
        }

        public override string ComponentName => "Subnautica Autosplitter";

        public override void Dispose()
        {
        }

        public override void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
        {
            splitter.Update();
            base.Update(invalidator, state, width, height, mode);
        }

        public void OnReset(object sender, TimerPhase t)
        {
            splitter.OnReset(t);
        }

        public override XmlNode GetSettings(XmlDocument document) { return settings.UpdateSettings(document); }
        public override void SetSettings(XmlNode document) { settings.SetSettings(document); }
        public override Control GetSettingsControl(LayoutMode mode) { return settings; }

        private void WriteDebug(string message)
        {
            Debug.WriteLine($"[Subnautica Component] {message}");
        }
    }
}
