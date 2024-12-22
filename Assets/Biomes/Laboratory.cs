
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Urdveil.Assets.Biomes
{
    public class Laboratory : ModBiome
    {

        public override int Music => MusicLoader.GetMusicSlot(Mod, "Assets/Music/Mechanics");
        public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh;
        public override string BestiaryIcon => base.BestiaryIcon;
        public override string BackgroundPath => MapBackground;
        public override Color? BackgroundColor => base.BackgroundColor;
        public override ModWaterStyle WaterStyle => ModContent.Find<ModWaterStyle>("Urdveil/AcidWaterStyle");

        public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle => ModContent.Find<ModSurfaceBackgroundStyle>("Urdveil/MarrowSurfaceBackgroundStyle");

        public override bool IsBiomeActive(Player player) => BiomeTileCounts.InLab;
        public override void OnEnter(Player player) => player.GetModPlayer<MyPlayer>().ZoneLab = true;
        public override void OnLeave(Player player) => player.GetModPlayer<MyPlayer>().ZoneLab = false;
    }
}