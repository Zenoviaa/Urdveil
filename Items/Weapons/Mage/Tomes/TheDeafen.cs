using Microsoft.Xna.Framework;
using Urdveil.Common.Bases;
using Urdveil.Dusts;
using Urdveil.Helpers;
using Urdveil.Projectiles.Magic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Urdveil.Items.Weapons.Mage.Tomes
{
    internal class TheDeafen : BaseMagicTomeItem
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.shoot = ModContent.ProjectileType<TheDeafenTome>();
            Item.shootSpeed = 6f;
        }
    }

    internal class TheDeafenTome : BaseMagicTomeProjectile
    {
        private float _dustTimer;
        public override string Texture => this.PathHere() + "/TheDeafen";
        public override void SetDefaults()
        {
            base.SetDefaults();
            //How often it shoots
            AttackRate = 30;

            //How fast it drains mana, better to change the mana use in the item instead of this tho
            ManaConsumptionRate = 4;

            //How far the tome is held from the player
            HoldDistance = 36;

            //The glow effect around it
            GlowDistanceOffset = 4;
            GlowRotationSpeed = 0.05f;
        }

        public override void AI()
        {
            base.AI();
            _dustTimer++;
            if (_dustTimer % 16 == 0)
            {
                Dust.NewDustPerfect(Projectile.Center, ModContent.DustType<GlyphDust>(), Projectile.velocity * 0.1f, 0, Color.RosyBrown, Main.rand.NextFloat(1f, 1.5f));
            }
        }

        protected override void Shoot(Player player, IEntitySource source, Vector2 position, Vector2 velocity, int damage, float knockback)
        {
            base.Shoot(player, source, position, velocity, damage, knockback);
            if (Main.myPlayer == Projectile.owner)
            {
                Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<DeafenProj>(), damage, knockback, Projectile.owner);
            }
        }
    }
}