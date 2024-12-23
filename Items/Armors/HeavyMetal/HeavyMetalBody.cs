using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Urdveil.Items.Armors.HeavyMetal
{
    [AutoloadEquip(EquipType.Body)]
    public class HeavyMetalBody : ModItem
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Heavy Metal Vest");
            // Tooltip.SetDefault("Increases throwing damage by 25%");
        }
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 30;
            Item.value = Item.sellPrice(0, 0, 20, 0);
            Item.rare = ItemRarityID.Blue;
            Item.defense = 3;
        }
    }
}
