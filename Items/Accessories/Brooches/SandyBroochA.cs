﻿using Urdveil.Buffs.Charms;
using Urdveil.Common.Bases;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Urdveil.Items.Accessories.Brooches
{
    public class SandyBroochA : BaseBrooch
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.width = 24;
            Item.height = 28;
            Item.value = Item.buyPrice(0, 0, 90);
            Item.rare = ItemRarityID.Blue;
            Item.accessory = true;
            Item.buffType = ModContent.BuffType<SandyB>();
        }
    }
}