using Urdveil.Helpers;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Urdveil.Items.Armors.ForestCore
{
    [AutoloadEquip(EquipType.Head)]
    public class ForestCoreHead : ModItem
    {
        public bool Spetalite = false;
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Forest Core Helmet");
            // Tooltip.SetDefault("Increases ranged ramage by 2%");
        }

        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 30;
            Item.value = 10000;
            Item.rare = ItemRarityID.Blue;
            Item.defense = 2;
        }

        public override void UpdateEquip(Player player)
        {
            // player.GetDamage(DamageClass.Ranged) += 0.25f;
            player.GetDamage(DamageClass.Generic).Flat += 2;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<ForestCoreBody>() && legs.type == ModContent.ItemType<ForestCoreLegs>();
        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawShadow = true;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = LangText.SetBonus(this);//"Summons a forest bow to fight for you!");
            Main.LocalPlayer.GetModPlayer<MyPlayer>().FCArmor = true;
        }
    }
}
