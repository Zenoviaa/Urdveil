﻿using Urdveil.Buffs.Charms;
using Urdveil.Common.Bases;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Urdveil.Items.Accessories.Brooches
{
    public class DreadBroochA : BaseBrooch
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.width = 24;
            Item.height = 28;
            Item.value = Item.sellPrice(gold: 1);
            Item.rare = ItemRarityID.Green;
            Item.buffType = ModContent.BuffType<DreadB>();
            Item.accessory = true;
        }
        public override void UpdateBrooch(Player player)
        {
            base.UpdateBrooch(player);
            player.statLifeMax2 /= 2;
            player.GetDamage(DamageClass.Generic) += 0.25f;
        }
    }
}