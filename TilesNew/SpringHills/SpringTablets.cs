using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Urdveil.Tiles;

namespace Urdveil.TilesNew.SpringHills
{
    public class SpringTabletItem : DecorativeWallItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Super silk!");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;

        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.createWall = ModContent.WallType<SpringTablet>();
        }
    }
    internal class SpringTablet : DecorativeWall
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }
    }
}
