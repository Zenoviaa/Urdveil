using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using Terraria.ModLoader;

namespace Urdveil.Helpers
{
    internal static class TextureRegistry
    {
        public static string MyDirectory(this object obj)
        {
            return PathHere(obj.GetType());
        }

        public static string PathHere(Type type)
        {
            string path = (type.Namespace).Replace('.', '/');
            return path;
        }
        public static string PathHere(this ModType t)
        {
            string path = (t.GetType().Namespace).Replace('.', '/');
            return path;
        }
        public static string EmptyTexture => "Urdveil/Assets/Textures/Empty";
        public static string EmptyBigTexture => "Urdveil/Assets/Textures/EmptyBig";
        public static string EmptyGlowParticle => "Urdveil/Visual/Particles/GlowCircleBoomParticle";
        public static string EmptyLongGlowParticle => "Urdveil/Visual/Particles/GlowCircleLongBoomParticle";
        public static string FlowerTexture => "Urdveil/Assets/NoiseTextures/Flower";
        public static string FlyingSlashTexture => "Urdveil/Assets/NoiseTextures/FlyingSlash";
        public static string CircleOutline => "Urdveil/Assets/NoiseTextures/Extra_67";
        public static string NormalNoise1 => "Urdveil/Assets/NoiseTextures/NormalNoise1";
        public static string ZuiEffect => "Urdveil/Assets/NoiseTextures/ZuiEffect";
        public static string VoxTexture3 => "Urdveil/Assets/Effects/VoxTexture3";

        public static string VoxTexture4 => "Urdveil/Assets/Effects/VoxTexture5";

        public static string BoreParticleWhite => "Urdveil/Particles/BoreParticleWhite";
        public static Asset<Texture2D> Clouds7 => ModContent.Request<Texture2D>("Urdveil/Assets/NoiseTextures/Clouds7");
        public static Asset<Texture2D> Clouds6 => ModContent.Request<Texture2D>("Urdveil/Assets/NoiseTextures/Clouds6");
        public static Asset<Texture2D> BasicGlow => ModContent.Request<Texture2D>("Urdveil/Assets/NoiseTextures/BasicGlow");
        public static Asset<Texture2D> StarNoise => ModContent.Request<Texture2D>("Urdveil/Assets/NoiseTextures/StarNoise");
        public static Asset<Texture2D> StarNoise2 => ModContent.Request<Texture2D>("Urdveil/Assets/NoiseTextures/StarNoise2");
        public static Asset<Texture2D> CloudNoise => ModContent.Request<Texture2D>("Urdveil/Assets/NoiseTextures/CloudNoise");
        public static Asset<Texture2D> CloudNoise2 => ModContent.Request<Texture2D>("Urdveil/Assets/NoiseTextures/CloudNoise2");
        public static Asset<Texture2D> CloudNoise3 => ModContent.Request<Texture2D>("Urdveil/Assets/NoiseTextures/CloudNoise3");
        public static Asset<Texture2D> BlurryPerlinNoise2 => ModContent.Request<Texture2D>("Urdveil/Assets/NoiseTextures/BlurryPerlinNoise2");
        public static Asset<Texture2D> LavaDepths => ModContent.Request<Texture2D>("Urdveil/Assets/NoiseTextures/LavaDepths");
        public static Asset<Texture2D> CloudTexture => ModContent.Request<Texture2D>("Urdveil/Assets/Effects/CloudTexture");
        public static Asset<Texture2D> IrraTexture => ModContent.Request<Texture2D>("Urdveil/Assets/Effects/IrraTexture2");
        public static Asset<Texture2D> SmallNoise => ModContent.Request<Texture2D>("Urdveil/Assets/NoiseTextures/SmallNoise");
        public static Asset<Texture2D> FourPointedStar => ModContent.Request<Texture2D>("Urdveil/Assets/NoiseTextures/Extra_63");
    }
}
