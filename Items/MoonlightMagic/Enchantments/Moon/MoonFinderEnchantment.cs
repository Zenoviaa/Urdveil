using Microsoft.Xna.Framework;
using Urdveil.Common.Particles;
using Urdveil.Items.MoonlightMagic.Elements;
using Urdveil.Items.MoonlightMagic.Movements;
using Urdveil.Visual.Particles;
using Terraria;
using Terraria.ModLoader;

namespace Urdveil.Items.MoonlightMagic.Enchantments.Moon
{
    internal class MoonFinderEnchantment : BaseEnchantment
    {

        public override void SetDefaults()
        {
            base.SetDefaults();
            time = 30;
        }

        public override void AI()
        {
            base.AI();

            //Count up
            Countertimer++;

            //If greater than time then start homing, we'll just swap the movement type of the projectile
            if (Countertimer == time)
            {
                for (int i = 0; i < 4; i++)
                {
                    Vector2 spawnPoint = Projectile.Center + Main.rand.NextVector2Circular(8, 8);
                    Vector2 velocity = Main.rand.NextVector2Circular(8, 8);
                    Particle.NewParticle<SparkleWindParticle>(spawnPoint, velocity, Color.White);
                }

                MagicProj.Movement = new OutwardMovement();
            }
        }

        public override float GetStaffManaModifier()
        {
            return 0.2f;
        }

        public override int GetElementType()
        {
            return ModContent.ItemType<MoonElement>();
        }
    }
}
