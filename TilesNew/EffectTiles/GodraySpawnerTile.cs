using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Urdveil.Common.Foggy;
using Urdveil.Common.Shaders;
using Urdveil.Helpers;
using Urdveil.Tiles;

namespace Urdveil.TilesNew.EffectTiles
{


    internal class GodraySpawnerItem : DecorativeWallItem
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.createWall = ModContent.WallType<GodraySpawnerWall>();
        }
    }



    internal class GodraySpawnerWall : FogSpawnerWall
    {
        public override string Texture => this.PathHere() + "/FogSpawnerWall";
        public override void FogCreateFunction(Fog fog)
        {
            fog.blendState = BlendState.Additive;
            fog.texture = ModContent.Request<Texture2D>("Urdveil/Assets/NoiseTextures/Godray");
            fog.startColor = Color.Transparent;
            fog.startScale = new Vector2(Main.rand.NextFloat(0.35f, 1.0f), Main.rand.NextFloat(0.3f, 0.9f)) * 3.5f;
            fog.pulseWidth = Main.rand.NextFloat(0.96f, 0.98f);
            fog.rotation = Main.rand.NextFloat(-0.05f, 0.05f);
            fog.offset = Main.rand.NextVector2Circular(16, 16);
        }

        public override void FogUpdateFunction(Fog fog)
        {
            base.FogUpdateFunction(fog);
            float dayProgress = (float)Main.time / (float)Main.dayLength;
            Color lightColor;
            if (Main.dayTime)
            {
                Color startColor = Color.Lerp(Color.Purple, Color.White, dayProgress);
                Color endColor = Color.Lerp(Color.White, Color.OrangeRed, dayProgress);
                lightColor = Color.Lerp(startColor, endColor, dayProgress);
            }
            else
            {
                Color startColor = Color.Lerp(Color.White, Color.White, dayProgress);
                Color endColor = Color.Lerp(Color.White, Color.White, dayProgress);
                lightColor = Color.Lerp(startColor, endColor, dayProgress);
                lightColor *= 0.24f;
            }

            Color color = Color.Lerp(Color.Transparent, lightColor, VectorHelper.Osc(0.6f, 1f)) * 0.5f;
            fog.startColor = Color.Lerp(fog.startColor, color, 0.1f);
            fog.rotation = MathHelper.Lerp(0, MathHelper.ToRadians(165), dayProgress) - MathHelper.ToRadians(45);
        }

        public override BaseShader FogShaderFunction()
        {
            var fogShader = Fog2Shader.Instance;
            fogShader.FogTexture = ModContent.Request<Texture2D>("Urdveil/Assets/NoiseTextures/Godray");
            fogShader.ProgressPower = 0.75f;
            fogShader.EdgePower = 1f;
            fogShader.Speed = 0f;
            //      fogShader.Offset = Vector2.Zero;
            fogShader.Apply();
            return null;
        }
    }
}