using Terraria.UI;

namespace Urdveil.UI.ToolsSystem
{
    internal class TilePainterUIState : UIState
    {
        public TilePainterUI ui;
        public TilePainterUIState() : base()
        {

        }

        public override void OnInitialize()
        {
            ui = new TilePainterUI();
            Append(ui);
        }
    }
}
