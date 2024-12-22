using Urdveil.Tiles;
using System;
using Terraria.ModLoader;

namespace Urdveil.UI.Systems
{
    public class StarbloomBiomeTileCount : ModSystem
    {
        public int BlockCount;

        public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
        {
            BlockCount = tileCounts[ModContent.TileType<StarbloomTempleBlock>()];
        }
    }
}
