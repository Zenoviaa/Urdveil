﻿using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Urdveil.Items.Armors.Ducanblitz
{
    // The AutoloadEquip attribute automatically attaches an equip texture to this item.
    // Providing the EquipType.Legs value here will result in TML expecting a X_Legs.png file to be placed next to the item's main texture.
    [AutoloadEquip(EquipType.Legs)]
    public class DucanblitzThighs : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Celestia Moon Leggings");
            /* Tooltip.SetDefault("Magical essence of an empress!"
				+ "\n5% increased movement speed" +
				"\n+20 Health"); */

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 18; // Width of the item
            Item.height = 18; // Height of the item
            Item.value = Item.sellPrice(gold: 1); // How many coins the item is worth
            Item.rare = ItemRarityID.LightRed; // The rarity of the item
            Item.defense = 20; // The amount of defense the item will give when equipped
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.4f;
            player.maxRunSpeed += 0.4f; // Increase the movement speed of the player
            player.statLifeMax2 += 10;
            player.GetArmorPenetration(DamageClass.Melee) += 15f;
            player.GetDamage(DamageClass.Melee) *= 1.02f;
        }
        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.

    }
}