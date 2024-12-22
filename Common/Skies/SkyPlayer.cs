using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;

namespace Urdveil.Common.Skies
{
    public class SkyPlayer : ModPlayer
    {
        public override void PostUpdateMiscEffects()
        {
            base.PostUpdateMiscEffects();
            if (Main.netMode == NetmodeID.Server)
                return;

            if (!SkyManager.Instance["Urdveil:CloudySky"].IsActive()
                && Player.ZoneOverworldHeight || Player.ZoneSkyHeight || Player.ZoneUnderworldHeight)
            {
                Vector2 targetCenter = Player.Center;
                SkyManager.Instance.Activate("Urdveil:CloudySky", targetCenter);
            }
            else if (SkyManager.Instance["Urdveil:CloudySky"].IsActive())
            {
                SkyManager.Instance.Deactivate("Urdveil:CloudySky");
            }

            if (!SkyManager.Instance["Urdveil:DesertSky"].IsActive() && Player.ZoneDesert)
            {
                Vector2 targetCenter = Player.Center;
                SkyManager.Instance.Activate("Urdveil:DesertSky", targetCenter);
            }
            else if (SkyManager.Instance["Urdveil:DesertSky"].IsActive())
            {
                SkyManager.Instance.Deactivate("Urdveil:DesertSky");
            }
        }
    }

}
