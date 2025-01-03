﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Urdveil.Items.Accessories
{
    internal class SawtoothNecklace : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 48;
            Item.value = 2500;
            Item.rare = ItemRarityID.LightRed;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            base.UpdateAccessory(player, hideVisual);

            //Increased armor pen
            player.GetArmorPenetration(DamageClass.Generic) += 12;
        }
    }
}
