using Microsoft.Xna.Framework;
using Urdveil.Helpers;
using Terraria;

namespace Urdveil.Projectiles.IgniterExplosions
{
    internal class SepsisExSps : BaseIgniterExplosion
    {
        public override int FrameCount => 23;

        public override void Start()
        {
            base.Start();
            if (Main.myPlayer == Projectile.owner)
            {
                var circle = EffectsHelper.SimpleExplosionCircle(Projectile, Color.Orange);
            }
        }
    }
}
