using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Urdveil.Items.Armors.ForestCore
{
    [AutoloadEquip(EquipType.Body)]
    public class ForestCoreBody : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Forest Core Body");
            // Tooltip.SetDefault("Increases ranged crit chance by 2%");
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 30;
            Item.value = Item.sellPrice(0, 0, 20, 0);
            Item.rare = ItemRarityID.Blue;
            Item.defense = 2;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetCritChance(DamageClass.Generic) += 2f;
        }


    }
}
