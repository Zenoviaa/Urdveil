﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Urdveil.Helpers;
using Urdveil.Items.MoonlightMagic.Elements;
using Urdveil.Items.MoonlightMagic.Forms;
using Terraria;
using Terraria.ModLoader;

namespace Urdveil.Items.MoonlightMagic.Enchantments.Basic
{
    internal class LampFormEnchantment : BaseEnchantment
    {
        bool HitOnce = false;
        int Attagain = 14;
        public override float GetStaffManaModifier()
        {
            return 0.1f;
        }

        public override int GetElementType()
        {
            return ModContent.ItemType<BasicElement>();
        }


        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {

            return true;
        }

        public override void SpecialInventoryDraw(Item item, SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            base.SpecialInventoryDraw(item, spriteBatch, position, frame, drawColor, itemColor, origin, scale);
            DrawHelper.DrawGlowInInventory(item, spriteBatch, position, Color.Gray);
        }

        public override void SetMagicDefaults()
        {
            float damage = Projectile.damage;
            damage *= 1.1f;
            Projectile.damage = (int)damage;
            MagicProj.Form = FormRegistry.Lamp.Value;
        }
    }
}
