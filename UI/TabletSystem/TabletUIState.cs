using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.UI;
using Urdveil.UI.PowderSystem;

namespace Urdveil.UI.TabletSystem
{
    internal class TabletUIState : UIState
    {
        public TabletUI tabletUI;
        public TabletUIState() : base()
        {

        }

        public override void OnInitialize()
        {
            tabletUI = new TabletUI();
            Append(tabletUI);
        }
    }
}
