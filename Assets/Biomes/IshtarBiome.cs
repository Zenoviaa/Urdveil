
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;


namespace Urdveil.Assets.Biomes
{
    public class IshtarBiome : ModBiome
    {
        //public override ModUndergroundBackgroundStyle UndergroundBackgroundStyle => ModContent.Find<ModUndergroundBackgroundStyle>("SpiritMod/Biomes/SpiritUgBgStyle");
        public override ModUndergroundBackgroundStyle UndergroundBackgroundStyle => ModContent.Find<ModUndergroundBackgroundStyle>("Urdveil/IshtarBackgroundStyle");
        public override ModWaterStyle WaterStyle => ModContent.Find<ModWaterStyle>("Urdveil/IshtarWaterStyle");
        public override int Music => MusicLoader.GetMusicSlot(Mod, "Assets/Music/Ishtar");
        public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh;
        public override string BestiaryIcon => base.BestiaryIcon;
        public override string BackgroundPath => MapBackground;
        public override Color? BackgroundColor => base.BackgroundColor;


        public override bool IsBiomeActive(Player player) => (player.ZoneRockLayerHeight || player.ZoneDirtLayerHeight) && BiomeTileCounts.InIshtar;
        public override void OnEnter(Player player) => player.GetModPlayer<MyPlayer>().ZoneIshtar = true;
        public override void OnLeave(Player player) => player.GetModPlayer<MyPlayer>().ZoneIshtar = false;
    }
}