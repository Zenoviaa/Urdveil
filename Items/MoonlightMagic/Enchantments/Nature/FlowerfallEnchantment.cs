﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Urdveil.Common.Particles;
using Urdveil.Helpers;
using Urdveil.Items.MoonlightMagic.Elements;
using Urdveil.Items.MoonlightMagic.Movements;
using Urdveil.Visual.Particles;
using Terraria;
using Terraria.ModLoader;

namespace Urdveil.Items.MoonlightMagic.Enchantments.Nature
{
    internal class FlowerfallEnchantment : BaseEnchantment
    {

        public override void SetDefaults()
        {
            base.SetDefaults();
            time = 15;
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
                    Particle.NewParticle<WhiteFlowerParticle>(spawnPoint, velocity, Color.White);
                    Particle.NewParticle<MusicParticle>(spawnPoint, velocity, Color.White);
                }

                MagicProj.Movement = new LobberMovement();
            }
        }

        public override float GetStaffManaModifier()
        {
            return 0.2f;
        }

        public override int GetElementType()
        {
            return ModContent.ItemType<NaturalElement>();
        }


        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {

            return true;
        }

        public override void SpecialInventoryDraw(Item item, SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            base.SpecialInventoryDraw(item, spriteBatch, position, frame, drawColor, itemColor, origin, scale);
            DrawHelper.DrawGlowInInventory(item, spriteBatch, position, ColorFunctions.NaturalGreen);
        }
    }
}
