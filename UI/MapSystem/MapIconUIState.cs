using Terraria.UI;

namespace Urdveil.UI.MapSystem
{
    internal class MapIconUIState : UIState
    {
        public MapIconUI ui;
        public MapIconUIState() : base()
        {

        }

        public override void OnInitialize()
        {
            ui = new MapIconUI();
            Append(ui);
        }
    }
}
