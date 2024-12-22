using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Urdveil.Items.MoonlightMagic.Elements;
using Terraria.ModLoader;

namespace Urdveil.Items.MoonlightMagic.Enchantments.RoyalMagic
{
    internal class RechargingShadowsEnchantment : BaseEnchantment
    {

        public override void SetDefaults()
        {
            base.SetDefaults();

        }
        private bool Decreased = false;
        public override void AI()
        {
            base.AI();

            //Count up


            //If greater than time then start homing, we'll just swap the movement type of the projectile
            if (!Decreased)
            {
                foreach (var enchantment in MagicProj.Enchantments)
                {
                    //do a thing here

                    enchantment.time /= 2;


                }

            }



        }

        public override float GetStaffManaModifier()
        {
            return 1f;
        }

        public override int GetElementType()
        {
            return ModContent.ItemType<RoyalMagicElement>();
        }


        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {

            return true;
        }
    }
}
