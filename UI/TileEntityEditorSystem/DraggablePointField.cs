using Microsoft.Xna.Framework;

namespace Urdveil.UI.TileEntityEditorSystem
{
    internal class DraggablePointField
    {
        public int X;
        public int Y;
        public Point Point
        {
            get
            {
                return new Point(X, Y);
            }
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }
    }
}
