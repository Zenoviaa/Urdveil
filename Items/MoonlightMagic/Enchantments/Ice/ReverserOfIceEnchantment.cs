﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Urdveil.Items.MoonlightMagic.Elements;
using Terraria.ModLoader;

namespace Urdveil.Items.MoonlightMagic.Enchantments.Ice
{
    internal class ReverserOfIceEnchantment : BaseEnchantment
    {

        public override void SetDefaults()
        {
            base.SetDefaults();
            time = 150;
        }

        public override void AI()
        {
            base.AI();

            //Count up
            Countertimer++;
            if (Countertimer >= time)
            {

                //If greater than time then start homing, we'll just swap the movement type of the projectile

                foreach (var enchantment in MagicProj.Enchantments)
                {
                    //do a thing here
                    if (enchantment.Countertimer > enchantment.time)
                    {
                        enchantment.Countertimer = 0;
                    }

                }
            }

        }

        public override float GetStaffManaModifier()
        {
            return 1f;
        }

        public override int GetElementType()
        {
            return ModContent.ItemType<IceElement>();
        }


        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {

            return true;
        }
    }
}
