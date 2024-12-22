using Microsoft.Xna.Framework.Graphics;

namespace Urdveil.Trails
{
    public interface IPixelPrimitiveDrawer
    {
        /// <summary>
        /// Draw primitives you wish to become pixelated here.
        /// </summary>
        public void DrawPixelPrimitives(SpriteBatch spriteBatch);
    }
}