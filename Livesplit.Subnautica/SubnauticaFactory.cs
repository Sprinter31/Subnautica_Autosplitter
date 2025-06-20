using LiveSplit.UI.Components;
using LiveSplit.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Livesplit.Subnautica;

namespace Livesplit.Subnautica
{
    public class SubnauticaFactory : IComponentFactory
    {
        public string ComponentName => "Subnautica Autosplitter";

        public string Description => "Autosplitter for Subnautica";

        public ComponentCategory Category => ComponentCategory.Control;

        public string UpdateName => ComponentName;

        public string XMLURL => UpdateURL + "Subnautica.xml";

        public string UpdateURL => "";

        public Version Version => Version.Parse("1.0.0");

        public IComponent Create(LiveSplitState state) => new SubnauticaComponent(state);
    }
}
