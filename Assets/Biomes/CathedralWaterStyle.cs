using Microsoft.Xna.Framework;
using Urdveil.Dusts;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Urdveil.Assets.Biomes
{
    public class CathedralWaterStyle : ModWaterStyle
    {
        public override int ChooseWaterfallStyle() => Find<ModWaterfallStyle>("Urdveil/CathedralWaterfallStyle").Slot;
        public override int GetSplashDust() => DustType<Solution>();
        public override int GetDropletGore() => Find<ModGore>("Urdveil/EggGore").Type;
        public override void LightColorMultiplier(ref float r, ref float g, ref float b)
        {
            r = 0f;
            g = 0f;
            b = 1f;
        }
        public override Color BiomeHairColor()
            => Color.LightSkyBlue;
    }
}