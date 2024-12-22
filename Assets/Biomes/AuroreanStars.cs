using Terraria;
using Terraria.ModLoader;

namespace Urdveil.Assets.Biomes
{
    internal class AuroreanStars : ModSceneEffect
    {
        public override int Music => MusicLoader.GetMusicSlot(Mod, "Assets/Music/CountingStars");
        public override SceneEffectPriority Priority => SceneEffectPriority.Event;
        public override bool IsSceneEffectActive(Player player)
        {
            return false;
        }
        public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle => ModContent.Find<ModSurfaceBackgroundStyle>("Urdveil/StarbloomBackgroundStyle");

        public override void SpecialVisuals(Player player, bool isActive)
        {
            player.ManageSpecialBiomeVisuals("Urdveil:Starbloom", isActive, player.Center);

        }
    }
}