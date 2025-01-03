﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Urdveil.Common.Particles;
using Urdveil.Common.Shaders;
using Urdveil.Common.Shaders.MagicTrails;
using Urdveil.Helpers;
using Urdveil.Trails;
using Urdveil.Visual.Particles;
using Terraria;
using Terraria.ModLoader;

namespace Urdveil.Items.MoonlightMagic.Elements
{
    internal class MoonElement : BaseElement
    {
        public override int GetOppositeElementType()
        {
            return ModContent.ItemType<RadianceElement>();
        }

        public override void SetDefaults()
        {
            base.SetDefaults();

        }

        public override Color GetElementColor()
        {
            return ColorFunctions.MoonGreen;
        }

        public override bool DrawTextShader(SpriteBatch spriteBatch, Item item, DrawableTooltipLine line, ref int yOffset)
        {
            base.DrawTextShader(spriteBatch, item, line, ref yOffset);
            EnchantmentDrawHelper.DrawTextShader(spriteBatch, item, line, ref yOffset,
                glowColor: ColorFunctions.MoonGreen,
                primaryColor: Color.White,
                noiseColor: Color.DarkGreen);
            return true;
        }

        public override void SpecialInventoryDraw(Item item, SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            base.SpecialInventoryDraw(item, spriteBatch, position, frame, drawColor, itemColor, origin, scale);
            DrawHelper.DrawGlowInInventory(item, spriteBatch, position, ColorFunctions.MoonGreen);
        }

        public override void AI()
        {
            base.AI();
            AI_Particles();
        }

        private void AI_Particles()
        {
            if (MagicProj.GlobalTimer % 8 == 0)
            {
                for (int i = 0; i < MagicProj.OldPos.Length - 1; i++)
                {
                    if (!Main.rand.NextBool(4))
                        continue;
                    Vector2 offset = Main.rand.NextVector2Circular(16, 16);
                    Vector2 spawnPoint = MagicProj.OldPos[i] + offset + Projectile.Size / 2;
                    Vector2 velocity = MagicProj.OldPos[i + 1] - MagicProj.OldPos[i];
                    velocity = velocity.SafeNormalize(Vector2.Zero) * -8;


                    Color color = Color.Lerp(Color.White, Color.Turquoise, 0.5f);
                    color.A = 0;
                    Particle.NewBlackParticle<GlowParticle>(spawnPoint, velocity, color, Scale: 0.33f * MagicProj.ScaleMultiplier);
                }
            }
        }

        public override void OnKill()
        {
            base.OnKill();
            SpawnDeathParticles();
        }

        private void SpawnDeathParticles()
        {
            //Kill Trail
            for (int i = 0; i < MagicProj.OldPos.Length - 1; i++)
            {
                Vector2 offset = Main.rand.NextVector2Circular(16, 16);
                Vector2 spawnPoint = MagicProj.OldPos[i] + offset + Projectile.Size / 2;
                Vector2 velocity = MagicProj.OldPos[i + 1] - MagicProj.OldPos[i];
                velocity = velocity.SafeNormalize(Vector2.Zero) * -2;

                Color color = Color.Lerp(Color.White, Color.Turquoise, 0.5f);
                color.A = 0;
                Particle.NewBlackParticle<GlowParticle>(spawnPoint, velocity, color, Scale: 0.5f * MagicProj.ScaleMultiplier);
            }

            for (float f = 0f; f < 1f; f += 0.2f)
            {
                float rot = f * MathHelper.TwoPi;
                Vector2 spawnPoint = Projectile.position;
                Vector2 velocity = rot.ToRotationVector2() * Main.rand.NextFloat(0f, 4f);

                Color color = Color.Lerp(Color.White, Color.Turquoise, 0.5f);
                color.A = 0;
                Particle.NewBlackParticle<GlowParticle>(spawnPoint, velocity, color, Scale: 0.5f * MagicProj.ScaleMultiplier);
            }
        }

        #region Visuals

        public override void DrawForm(SpriteBatch spriteBatch, Texture2D formTexture, Vector2 drawPos, Color drawColor, Color lightColor, float drawRotation, float drawScale)
        {
            base.DrawForm(spriteBatch, formTexture, drawPos, drawColor, lightColor, drawRotation, drawScale);
        }

        public override void DrawTrail()
        {
            base.DrawTrail();
            var shader = MagicMoonShader.Instance;
            shader.PrimaryTexture = TrailRegistry.GlowTrail;
            shader.NoiseTexture = TrailRegistry.SpikyTrail1;
            shader.BlendState = BlendState.Additive;
            shader.SamplerState = SamplerState.PointWrap;
            shader.Speed = 0.5f;
            shader.Repeats = 1f;
            //This just applis the shader changes
            TrailDrawer.Draw(Main.spriteBatch, MagicProj.OldPos, Projectile.oldRot, ColorFunction, WidthFunction, shader, offset: Projectile.Size / 2);
        }

        private Color ColorFunction(float completionRatio)
        {
            return Color.Lerp(new Color(69, 96, 182), Color.SkyBlue, completionRatio);
        }

        private float WidthFunction(float completionRatio)
        {
            float w = 120;
            float ew = w / 10;
            float width = w * MagicProj.ScaleMultiplier;

            float p = completionRatio / 0.5f;
            float ep = Easing.OutCirc(p);
            float circleWidth = MathHelper.Lerp(0, w * MagicProj.ScaleMultiplier, ep);
            float trailWidth = MathHelper.Lerp(width, 0, Easing.OutCirc(completionRatio));
            return MathHelper.Lerp(circleWidth, trailWidth, Easing.OutExpo(completionRatio));
        }

        #endregion
    }
}
