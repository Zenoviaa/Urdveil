﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Urdveil.Helpers;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader;

namespace Urdveil.Common.Skies
{
    public class DesertSky : CustomSky
    {
        private Vector2 _parallax;
        private Vector2 _lastCameraPos;
        private bool _active;
        private float _strength;
        private float _windSpeed;

        public float Strength { get => _strength; }
        public float Fogginess { get; set; }

        public override void Activate(Vector2 position, params object[] args)
        {
            _active = true;
        }

        public override void Deactivate(params object[] args)
        {
            _active = false;
        }

        public override bool IsActive() =>
            _strength > 0.001f && !Main.gameMenu;

        public override void Reset()
        {
            _active = false;
        }

        public override void Update(GameTime gameTime)
        {
            Parallax();
            Wind();
        }

        private void Parallax()
        {
            Vector2 parallaxAmt = new Vector2(1.5f, 0.25f);
            Vector2 refPosition = Main.Camera.UnscaledPosition;
            Vector2 diff = _lastCameraPos - refPosition;
            _parallax += diff * parallaxAmt;
            _lastCameraPos = refPosition;
        }

        private void Wind()
        {
            _windSpeed += 0.0025f;// Main.WindForVisuals * 0.005f;
            _windSpeed = _windSpeed % 10f;
        }

        public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
        {
            //Don't
            UrdveilClientConfig clientConfig = ModContent.GetInstance<UrdveilClientConfig>();
            if (!clientConfig.SkiesToggle)
                return;
            if (maxDepth >= 0 && minDepth < 0)
            {
                DrawFrontClouds(spriteBatch);
            }
        }

        private void DrawFrontClouds(SpriteBatch spriteBatch)
        {
            var texture = ModContent.Request<Texture2D>("Urdveil/Assets/NoiseTextures/Clouds5");
            var colorMapTexture = ModContent.Request<Texture2D>("Urdveil/Assets/NoiseTextures/ColorMapYellow");
            MiscShaderData eff = ShaderRegistry.CloudsDesertShader;
            if (!Main.dayTime)
                eff = ShaderRegistry.CloudsDesertNightShader;
            eff.UseImage1(texture);
            eff.UseImage2(colorMapTexture);
            eff.Shader.Parameters["uImageOffset"].SetValue(-_parallax * 0.0011f);


            float opacity = !Main.dayTime ? 0.06f : 1.0f;
            eff.Shader.Parameters["uIntensity"].SetValue(opacity);
            eff.Shader.Parameters["uProgress"].SetValue(0.15f);
            eff.Shader.Parameters["uTime"].SetValue(_windSpeed / 32f);
            eff.Shader.Parameters["uColorMapSection"].SetValue(0.2f);
            eff.Shader.Parameters["uColorMap"].SetValue(colorMapTexture.Value);
            eff.Apply();
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, Main.Rasterizer, eff.Shader, Main.BackgroundViewMatrix.TransformationMatrix);

            spriteBatch.Draw(texture.Value, Vector2.Zero, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), Color.White * 0.3f, 0, Vector2.Zero, 2, SpriteEffects.None, 0);

            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, Main.Rasterizer, null, Main.BackgroundViewMatrix.TransformationMatrix);
        }
    }
}