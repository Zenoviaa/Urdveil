﻿using Microsoft.Xna.Framework;
using Urdveil.Projectiles.Magic;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Urdveil.Items.Weapons.Mage
{
    internal class ShadegraveStaff : ClassSwapItem
    {

        public override DamageClass AlternateClass => DamageClass.Summon;

        public override void SetClassSwappedDefaults()
        {
            Item.damage = 20;
            Item.mana = 6;
        }
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sun Blast Staff");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.staff[Item.type] = true;
            Item.damage = 40;
            Item.width = 50;
            Item.height = 50;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 4;
            Item.value = Item.sellPrice(0, 1, 1, 29);
            Item.rare = ItemRarityID.Blue;
            Item.shootSpeed = 35;
            Item.autoReuse = true;
            Item.UseSound = SoundID.DD2_BookStaffCast;

            Item.DamageType = DamageClass.Magic;
            Item.shoot = ModContent.ProjectileType<SGBolt>();
            Item.shootSpeed = 15f;
            Item.mana = 20;
            Item.useAnimation = 50;
            Item.useTime = 50;
            Item.consumeAmmoOnLastShotOnly = true;
        }


        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5f, 0f);
        }



    }
}
