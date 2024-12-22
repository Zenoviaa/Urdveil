using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Urdveil.Helpers;
using Terraria;
using Terraria.ModLoader;

namespace Urdveil.Particles.Sparkles
{
    public class CircleSparkle : RaritySparkle
    {
        public CircleSparkle(int lifetime, float scale, float initialRotation, float rotationSpeed, Vector2 position, Vector2 velocity)
        {
            Lifetime = lifetime;
            Scale = 0;
            MaxScale = scale;
            Rotation = initialRotation;
            RotationSpeed = rotationSpeed;
            Position = position;
            Velocity = velocity;
            DrawColor = Color.Lerp(Color.White, Color.White, Main.rand.NextFloat(1f));
            Texture = ModContent.Request<Texture2D>("Urdveil/Particles/MagicCircle2").Value;
            BaseFrame = null;
        }
    }
}
