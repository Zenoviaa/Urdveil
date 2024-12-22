using Terraria.UI;

namespace Urdveil.UI.ArmorShopSystem
{
    internal class ArmorShopUIState : UIState
    {
        public ArmorShopUI ui;
        public ArmorShopUIState() : base()
        {

        }

        public override void OnInitialize()
        {
            ui = new ArmorShopUI();
            Append(ui);
        }
    }
}
