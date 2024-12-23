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
            WindSwayMagnitude = 0.2f;

            //How fast it sways
            WindSwaySpeed = 0.02f;
        }
    }

    public class SpringFlowerBlueBushItem : DecorativeWallItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Super silk!");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;

        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.createWall = ModContent.WallType<SpringFlowerBlueBush>();
        }
    }
    internal class SpringFlowerBlueBush : DecorativeWall
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            //idk
            WindSwayOffset = 0f;

            //The max it can sway
            WindSwayMagnitude = 0.2f;

            //How fast it sways
            WindSwaySpeed = 0.02f;
        }
    }

    public class SpringFlowerDarkPurpleItem : DecorativeWallItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Super silk!");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;

        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.createWall = ModContent.WallType<SpringFlowerDarkPurple>();
        }
    }
    internal class SpringFlowerDarkPurple : DecorativeWall
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            //idk
            WindSwayOffset = 0f;

            //The max it can sway
            WindSwayMagnitude = 0.2f;

            //How fast it sways
            WindSwaySpeed = 0.02f;
        }
    }


    public class SpringFlowerGrassItem : DecorativeWallItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Super silk!");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;

        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.createWall = ModContent.WallType<SpringFlowerGrass>();
        }
    }
    internal class SpringFlowerGrass : DecorativeWall
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            //idk
            WindSwayOffset = 0f;

            //The max it can sway
            WindSwayMagnitude = 0.2f;

            //How fast it sways
            WindSwaySpeed = 0.02f;
        }
    }

    public class SpringFlowerGrassSmallItem : DecorativeWallItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Super silk!");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;

        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.createWall = ModContent.WallType<SpringFlowerGrassSmall>();
        }
    }
    internal class SpringFlowerGrassSmall : DecorativeWall
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            //idk
            WindSwayOffset = 0f;

            //The max it can sway
            WindSwayMagnitude = 0.2f;

            //How fast it sways
            WindSwaySpeed = 0.02f;
        }
    }


    public class SpringFlowerPurpleBushItem : DecorativeWallItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Super silk!");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;

        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.createWall = ModContent.WallType<SpringFlowerPurpleBush>();
        }
    }
    internal class SpringFlowerPurpleBush : DecorativeWall
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            //idk
            WindSwayOffset = 0f;

            //The max it can sway
            WindSwayMagnitude = 0.2f;

            //How fast it sways
            WindSwaySpeed = 0.02f;
        }
    }

    public class SpringFlowerPurpleLeafItem : DecorativeWallItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Super silk!");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;

        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.createWall = ModContent.WallType<SpringFlowerPurpleLeaf>();
        }
    }
    internal class SpringFlowerPurpleLeaf : DecorativeWall
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            //idk
            WindSwayOffset = 0f;

            //The max it can sway
            WindSwayMagnitude = 0.2f;

            //How fast it sways
            WindSwaySpeed = 0.02f;
        }
    }
    public class SpringFlowerRedBushItem : DecorativeWallItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Super silk!");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;

        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.createWall = ModContent.WallType<SpringFlowerRedBush>();
        }
    }
    internal class SpringFlowerRedBush : DecorativeWall
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            //idk
            WindSwayOffset = 0f;

            //The max it can sway
            WindSwayMagnitude = 0.2f;

            //How fast it sways
            WindSwaySpeed = 0.02f;
        }
    }


    public class SpringFlowerVineItem : DecorativeWallItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Super silk!");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;

        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.createWall = ModContent.WallType<SpringFlowerVine>();
        }
    }
    internal class SpringFlowerVine : DecorativeWall
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            //idk
            WindSwayOffset = 0f;

            //The max it can sway
            WindSwayMagnitude = 0.2f;

            //How fast it sways
            WindSwaySpeed = 0.02f;
        }
    }

    public class SpringFlowerWhiteItem : DecorativeWallItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Super silk!");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;

        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.createWall = ModContent.WallType<SpringFlowerWhite>();
        }
    }
    internal class SpringFlowerWhite : DecorativeWall
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            //idk
            WindSwayOffset = 0f;

            //The max it can sway
            WindSwayMagnitude = 0.2f;

            //How fast it sways
            WindSwaySpeed = 0.02f;
        }
    }

    public class SpringFlowerWhiteBudItem : DecorativeWallItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Super silk!");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;

        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.createWall = ModContent.WallType<SpringFlowerWhiteBud>();
        }
    }
    internal class SpringFlowerWhiteBud : DecorativeWall
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            //idk
            WindSwayOffset = 0f;

            //The max it can sway
            WindSwayMagnitude = 0.2f;

            //How fast it sways
            WindSwaySpeed = 0.02f;
        }
    }

    public class SpringFlowerWhiteBudSmallItem : DecorativeWallItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Super silk!");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;

        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.createWall = ModContent.WallType<SpringFlowerWhiteBudSmall>();
        }
    }
    internal class SpringFlowerWhiteBudSmall : DecorativeWall
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            //idk
            WindSwayOffset = 0f;

            //The max it can sway
            WindSwayMagnitude = 0.2f;

            //How fast it sways
            WindSwaySpeed = 0.02f;
        }
    }
}
