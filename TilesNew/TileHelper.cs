using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Urdveil.WorldG;

namespace Urdveil.TilesNew
{
    internal static class TileHelper
    {
        public static void DrawInvisTile(int i, int j, SpriteBatch spriteBatch)
        {
            Vector2 pos2 = (new Vector2(i , j) + VeilGen.TileAdj) * 16;
            pos2 -= Main.screenPosition;
            Texture2D texture = ModContent.Request<Texture2D>("Urdveil/Tiles/InvisibileTile").Value;
            spriteBatch.Draw(texture,
              pos2,
              null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0);
        }
        public static void DrawInvisTileNoAdj(int i, int j, SpriteBatch spriteBatch)
        {
            Vector2 pos2 = (new Vector2(i, j)) * 16;
            pos2 -= Main.screenPosition;
            Texture2D texture = ModContent.Request<Texture2D>("Urdveil/Tiles/InvisibileTile").Value;
            spriteBatch.Draw(texture,
              pos2,
              null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0);
        }
    }
}
