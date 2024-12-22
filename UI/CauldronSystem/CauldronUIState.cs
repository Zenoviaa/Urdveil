using Terraria.UI;

namespace Urdveil.UI.CauldronSystem
{
    internal class CauldronUIState : UIState
    {
        public CauldronUI cauldronUI;
        public CauldronUIState() : base()
        {

        }

        public override void OnInitialize()
        {
            cauldronUI = new CauldronUI();
            Append(cauldronUI);
        }
    }
}
