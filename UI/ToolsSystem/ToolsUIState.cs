using Terraria.UI;

namespace Urdveil.UI.ToolsSystem
{
    internal class ToolsUIState : UIState
    {
        public ToolsUI ui;
        public ToolsUIState() : base()
        {

        }

        public override void OnInitialize()
        {
            ui = new ToolsUI();
            Append(ui);
        }
    }
}
