using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria;
using Urdveil.Tiles;

namespace Urdveil.TilesNew.SpringHills
{
    public class SpringFlowerItem : DecorativeWallItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Super silk!");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;

        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.createWall = ModContent.WallType<SpringFlower>();
        }
    }

    internal class SpringFlower : DecorativeWall
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
    
            //idk
            WindSwayOffset = 0f;

            //The max it can sway
            WindSwayMagnitude = 0.1f;

            //How fast it sways
            WindSwaySpeed = 0.01f;
        }
    }
}
