using Terraria.UI;

namespace Urdveil.UI.StructureSelector
{
    internal class MagicWandUIState : UIState
    {
        public MagicWandUI ui;
        public MagicWandUIState() : base()
        {

        }

        public override void OnInitialize()
        {
            ui = new MagicWandUI();
            Append(ui);
        }
    }
}
