using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Urdveil.UI.TitleSystem;

namespace Urdveil.BiomesNew
{
    public abstract class BaseUrdveilBiome : ModBiome
    {
        public override void OnEnter(Player player)
        {
            base.OnEnter(player);
            TitleCardUISystem uiSystem = ModContent.GetInstance<TitleCardUISystem>();
            uiSystem.OpenUI(DisplayName.Value, 7);
            uiSystem.titleUIState.titleCardUI.LineTexture = ModContent.Request<Texture2D>(TitleCardUISystem.RootTexturePath + "UnderlineBiome");
        }
    }
}
