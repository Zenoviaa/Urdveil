using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Urdveil.Items.Armors.Winterborn
{
    [AutoloadEquip(EquipType.Legs)]
    public class WinterbornLegs : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Winterborn Legs");
            // Tooltip.SetDefault("Increases movement speed by 10%");
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 22;
            Item.value = 10000;
            Item.rare = ItemRarityID.Blue;
            Item.defense = 2;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.1f;
        }
    }
}
