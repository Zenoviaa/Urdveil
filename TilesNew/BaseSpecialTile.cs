using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace Urdveil.TilesNew
{
    internal abstract class BaseSpecialTile : ModTile
    {
        public virtual void DrawPreview(int i, int j)
        {

        }
    }
    internal abstract class BaseSpecialWall : ModWall
    {
        public virtual void DrawPreview(int i, int j)
        {

        }
    }
}
