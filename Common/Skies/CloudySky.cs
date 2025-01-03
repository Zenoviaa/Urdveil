﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Urdveil.Helpers;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader;

namespace Urdveil.Common.Skies
{
    public class CloudySky : CustomSky
    {
        private float DayProgress
        {
            get
            {
                if (Main.dayTime)
                {
                    float dayProgress = (float)Main.time / (float)Main.dayLength;
                    return dayProgress;
                }
                else if (!Main.dayTime)
                {
                    float dayProgress = (float)Main.time / (float)Main.nightLength;
                    return dayProgress;
                }
                else
                {
                    return 0f;
                }

            }
        }
        private Color LightColor
        {
            get
            {

                Color lightColor;
                if (Main.dayTime)
                {
                    Color startColor = Color.Lerp(Color.Purple, Color.White, DayProgress * 4);

                    float endProgress = 0f;
                    if(DayProgress > 0.9f)
                    {
                        endProgress = (DayProgress - 0.9f) / 0.1f;
                    }
                    Color endColor = Color.Lerp(Color.OrangeRed, Color.Violet, endProgress);
                    lightColor = Color.Lerp(startColor, endColor, DayProgress);
                    lightColor *= 0.5f;
                }
                else
                {
                    Color startColor = Color.Lerp(Color.Violet, Color.White, DayProgress * 4);
                    Color endColor = Color.Lerp(Color.White, Color.Purple, DayProgress);
                    lightColor = Color.Lerp(startColor, endColor, DayProgress);
                    lightColor *= 0.24f;
                }

                return lightColor;
            }
        }
        private Color CloudColor;
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
            CloudColor = Color.Lerp(CloudColor, LightColor, 0.1f);
        }

        private void Parallax()
        {
            Vector2 parallaxAmt = new Vector2(0.5f, 0.25f);
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

            if (maxDepth >= 11 && minDepth < 11)
            {
                // DrawGradient(spriteBatch);
            }
            if (maxDepth >= 10 && minDepth < 10)
            {
                DrawBackClouds(spriteBatch);
            }
            if (maxDepth >= 7 && minDepth < 7)
            {
                DrawMidClouds(spriteBatch);
            }
            if (maxDepth >= 5.2f && minDepth < 5.2f)
            {
                DrawFrontClouds(spriteBatch);
            }
        }

        private void DrawGradient(SpriteBatch spriteBatch)
        {
            var texture = ModContent.Request<Texture2D>("Urdveil/Assets/NoiseTextures/Clouds3");
            var cloudTexture = ModContent.Request<Texture2D>("Urdveil/Assets/NoiseTextures/ColorMap");
            MiscShaderData eff = ShaderRegistry.GradientShader;
            eff.Shader.Parameters["StartGradientColor"].SetValue(Color.Transparent.ToVector4());
            eff.Shader.Parameters["EndGradientColor"].SetValue(Color.LightCyan.ToVector4() * Fogginess);
            eff.Apply();
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, Main.Rasterizer, eff.Shader, Main.BackgroundViewMatrix.TransformationMatrix);

            spriteBatch.Draw(texture.Value, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), CloudColor);

            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, Main.Rasterizer, null, Main.BackgroundViewMatrix.TransformationMatrix);
        }

        private void DrawBackClouds(SpriteBatch spriteBatch)
        {

            var texture = ModContent.Request<Texture2D>("Urdveil/Assets/NoiseTextures/Clouds3");
            var cloudTexture = ModContent.Request<Texture2D>("Urdveil/Assets/NoiseTextures/ColorMap");
            MiscShaderData eff = ShaderRegistry.CloudsShader;
            eff.UseImage1(texture);
            eff.UseImage2(cloudTexture);
            eff.Shader.Parameters["uImageOffset"].SetValue(-_parallax * 0.0005f);
            eff.Shader.Parameters["uIntensity"].SetValue(0.5f);
            eff.Shader.Parameters["uProgress"].SetValue(0.06f);

            float opacity = !Main.dayTime ? 0.06f : 1.0f;
            eff.Shader.Parameters["uOpacity"].SetValue(opacity);
            eff.Shader.Parameters["uTime"].SetValue(_windSpeed / 32f);
            eff.Shader.Parameters["uColorMapSection"].SetValue(0.2f);
            eff.Apply();
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, Main.Rasterizer, eff.Shader, Main.BackgroundViewMatrix.TransformationMatrix);

            spriteBatch.Draw(texture.Value, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), CloudColor);

            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, Main.Rasterizer, null, Main.BackgroundViewMatrix.TransformationMatrix);
        }

        private void DrawMidClouds(SpriteBatch spriteBatch)
        {
            var texture = ModContent.Request<Texture2D>("Urdveil/Assets/NoiseTextures/Clouds2");
            var cloudTexture = ModContent.Request<Texture2D>("Urdveil/Assets/NoiseTextures/ColorMap");
            MiscShaderData eff = ShaderRegistry.CloudsShader;

            eff.UseImage1(texture);
            eff.UseImage2(cloudTexture);
            eff.Shader.Parameters["uImageOffset"].SetValue(-_parallax * 0.0009f);
            eff.Shader.Parameters["uIntensity"].SetValue(1.0f);
            eff.Shader.Parameters["uProgress"].SetValue(0.12f);

            float opacity = !Main.dayTime ? 0.06f : 1.0f;
            eff.Shader.Parameters["uIntensity"].SetValue(opacity);
            eff.Shader.Parameters["uTime"].SetValue(_windSpeed / 32f);
            eff.Shader.Parameters["uColorMapSection"].SetValue(0.2f);
            eff.Apply();
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, Main.Rasterizer, eff.Shader, Main.BackgroundViewMatrix.TransformationMatrix);

            spriteBatch.Draw(texture.Value, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), CloudColor);

            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, Main.Rasterizer, null, Main.BackgroundViewMatrix.TransformationMatrix);
        }

        private void DrawFrontClouds(SpriteBatch spriteBatch)
        {
            var texture = ModContent.Request<Texture2D>("Urdveil/Assets/NoiseTextures/Clouds3");
            var cloudTexture = ModContent.Request<Texture2D>("Urdveil/Assets/NoiseTextures/ColorMap");
            MiscShaderData eff = ShaderRegistry.CloudsFrontShader;

            eff.UseImage1(texture);
            eff.UseImage2(cloudTexture);
            eff.Shader.Parameters["uImageOffset"].SetValue(-_parallax * 0.0011f);

            float opacity = !Main.dayTime ? 0.06f : 1.0f;
            eff.Shader.Parameters["uIntensity"].SetValue(opacity);
            eff.Shader.Parameters["uProgress"].SetValue(0.15f);
            eff.Shader.Parameters["uTime"].SetValue(_windSpeed / 32f);
            eff.Shader.Parameters["uColorMapSection"].SetValue(0.2f);
            eff.Apply();
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, Main.Rasterizer, eff.Shader, Main.BackgroundViewMatrix.TransformationMatrix);

            spriteBatch.Draw(texture.Value, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), CloudColor);

            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, Main.Rasterizer, null, Main.BackgroundViewMatrix.TransformationMatrix);
        }
    }
}