using Terraria.UI;

namespace Urdveil.UI.WeaponUpgradeSystem
{
    internal class WeaponUpgradeUIState : UIState
    {
        public WeaponUpgradeUI ui;
        public WeaponUpgradeUIState() : base()
        {

        }

        public override void OnInitialize()
        {
            ui = new WeaponUpgradeUI();
            Append(ui);
        }
    }
}
