using Microsoft.Xna.Framework;
using Urdveil.Tiles;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Urdveil.TilesNew.SpringHills
{
    //Wall Version
    public class StoneUnderBlock : DecorativeWallItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Super silk!");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;

        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.createWall = ModContent.WallType<StoneUnder>();
        }
    }

    internal class StoneUnder : DecorativeWall
    {
        public override void SetStaticDefaults()
        {

            base.SetStaticDefaults();
            Origin = DrawOrigin.TopDown;
            StructureColor = Color.Gray;
            //If you need other static defaults it go here
        }
    }

    public class BrokenCarraigeBlock : DecorativeWallItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Super silk!");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;

        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.createWall = ModContent.WallType<BrokenCarraige>();
        }
    }

    internal class BrokenCarraige : DecorativeWall
    {
        public override void SetStaticDefaults()
        {
            
            base.SetStaticDefaults();
            StructureColor = Color.Gray;
            //If you need other static defaults it go here
        }
    }
}
