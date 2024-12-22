
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace Urdveil.Assets.Biomes
{
    public class IshtarWaterStyle : ModWaterStyle
    {
        public override int ChooseWaterfallStyle() => ModContent.Find<ModWaterfallStyle>("Urdveil/IshtarWaterfallStyle").Slot;
        public override int GetSplashDust() => DustID.BoneTorch;
        public override int GetDropletGore() => GoreID.WaterDripIce;
        public override Color BiomeHairColor() => Color.DarkBlue;


    }
}