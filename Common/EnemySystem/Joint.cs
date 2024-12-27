using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace Urdveil.Common.EnemySystem
{
    internal class Joint
    {
        private float _rotation;
        public Joint(Vector2 localPosition)
        {
            //Defaults
            Color = Color.White;
            Position = localPosition;
            LocalPosition = localPosition;
            DrawScale = 1;
            Rotation = 0;
            Length = 1;
            SpriteEffects = SpriteEffects.None;
        }

        //Joint Vars
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }

        //This variable will be used to calculate the rig
        public Vector2 LocalPosition { get; set; }
        public Vector2 DrawOrigin { get; set; }
        public Vector2 StartDirection { get; set; }
        public Color Color { get; set; }
        public float DrawScale { get; set; }
        public float Rotation
        {
            get
            {
                return _rotation + OffsetRotation;
            }
            set
            {
                _rotation = value;
            }
        }
        public float OffsetRotation { get; set; }
        public float Length { get; set; }
        public SpriteEffects SpriteEffects { get; set; }
        public void Draw(SpriteBatch spriteBatch, Vector2 basePosition, ref Color lightColor)
        {
            Vector2 drawPosition = basePosition + Position - Main.screenPosition;
            Color drawColor = Color.MultiplyRGB(lightColor);
            float drawRotation = Rotation;
            spriteBatch.Draw(Texture, drawPosition, null, drawColor, drawRotation, DrawOrigin, DrawScale, SpriteEffects, layerDepth: 0);
        }
    }
}
