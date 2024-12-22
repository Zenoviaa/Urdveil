using Urdveil.Tiles.Ishtar;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace Urdveil.Items.Placeable.Ishtar
{
    public class BushyWebs : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("CurtainLeft");
            // Tooltip.SetDefault("Curtain");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<BushyWebss>());
            Item.value = 150;
            Item.maxStack = 9999;
            Item.width = 38;
            Item.height = 24;
        }
    }
}