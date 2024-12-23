using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using Urdveil.Tiles.Abyss.Aurelus;
using Urdveil.Tiles.Abyss;
using Urdveil.Tiles.Acid;
using Urdveil.Tiles.Catacombs;
using Urdveil.Tiles.Ishtar;
using Urdveil.Tiles.RoyalCapital;
using Urdveil.Tiles.Veil;
using Urdveil.Tiles;
using Urdveil.TilesNew.SpringHills;

namespace Urdveil.BiomesNew
{
    public class BiomeTileCountsNew : ModSystem
    {
        public int SpringGrassCount;
        public static bool InSpringHills => ModContent.GetInstance<BiomeTileCountsNew>().SpringGrassCount > 80;

        public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
        {
            SpringGrassCount = tileCounts[ModContent.TileType<SpringGrass>()];
        }
    }
}
