﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Urdveil.Items.MoonlightMagic.Elements;
using Terraria;
using Terraria.ModLoader;

namespace Urdveil.Items.MoonlightMagic.Enchantments.Veil
{
    internal class SpikyBarnEnchantment : BaseEnchantment
    {

        public override float GetStaffManaModifier()
        {
            return 1.2f;
        }

        public override int GetElementType()
        {
            return ModContent.ItemType<VeilElement>();
        }


        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {

            return true;
        }

        public override void SetMagicDefaults()
        {

            Projectile.penetrate += 2;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            base.OnHitNPC(target, hit, damageDone);
        }
    }
}
