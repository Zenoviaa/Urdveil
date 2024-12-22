using Microsoft.Xna.Framework;
using Urdveil.Projectiles.Visual;
using Terraria;
using Terraria.ModLoader;

namespace Urdveil.Helpers
{
    internal static class EffectsHelper
    {
        public static IgniterExplosionCircle SimpleExplosionCircle(Projectile baseProjectile, Color explosionColor, float startRadius = 4, float endRadius = 64, float width = 24)
        {
            Projectile p = Projectile.NewProjectileDirect(baseProjectile.GetSource_FromThis(), baseProjectile.Center, Vector2.Zero,
                ModContent.ProjectileType<IgniterExplosionCircle>(), 0, 0, baseProjectile.owner);
            IgniterExplosionCircle circle = p.ModProjectile as IgniterExplosionCircle;
            circle.DrawColor = explosionColor;
            circle.StartRadius = startRadius;
            circle.EndRadius = endRadius;
            circle.Width = width;
            p.netUpdate = true;
            return circle;
        }
    }
}
