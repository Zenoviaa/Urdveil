using Terraria.ModLoader;
using Terraria.UI;

namespace Urdveil.UI.MapSystem
{
    internal class MapIcon : UIButtonIcon
    {
        public override void OnButtonClick(UIMouseEvent evt, UIElement listeningElement)
        {
            base.OnButtonClick(evt, listeningElement);
            MapUISystem uiSystem = ModContent.GetInstance<MapUISystem>();
            uiSystem.ToggleUI();
        }
    }
}
