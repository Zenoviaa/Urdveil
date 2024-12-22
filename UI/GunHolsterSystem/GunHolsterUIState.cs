using Terraria.UI;

namespace Urdveil.UI.GunHolsterSystem
{
    internal class GunHolsterUIState : UIState
    {
        public GunHolsterUI gunHolsterUI;
        public GunHolsterUIState() : base()
        {

        }

        public override void OnInitialize()
        {
            gunHolsterUI = new GunHolsterUI();
            Append(gunHolsterUI);
        }
    }
}
