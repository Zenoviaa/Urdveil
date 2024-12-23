﻿using Microsoft.Xna.Framework;
using Urdveil.Buffs.Charms;
using Urdveil.Common.Bases;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Urdveil.Items.Accessories.Brooches
{
    public class FrileBroochPlayer : ModPlayer
    {
        public bool FrileBroochActive => Player.GetModPlayer<BroochSpawnerPlayer>().BroochActive(ModContent.ItemType<FrileBroochA>());
        public int frileBroochCooldown;
        public override void PostUpdateEquips()
        {
            base.PostUpdateEquips();
            frileBroochCooldown--;
            if (frileBroochCooldown <= 0)
                frileBroochCooldown = 0;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            base.OnHitNPC(target, hit, damageDone);
            if (FrileBroochActive && frileBroochCooldown <= 0)
            {
                for (int i = 0; i < 8; i++)
                {
                    float p = (float)i / 8f;
                    float rot = p * MathHelper.TwoPi;
                    Vector2 vel = rot.ToRotationVector2() * 8;
                    Vector2 spawnPos = target.Center;
                    Dust.NewDustPerfect(spawnPos, DustID.Firework_Blue, vel);
                }

                target.AddBuff(BuffID.Slow, 720);
                target.AddBuff(BuffID.Frostburn, 120);
                target.AddBuff(BuffID.Frozen, 120);
                frileBroochCooldown = 30;
            }
        }
    }

    public class FrileBroochA : BaseBrooch
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.width = 24;
            Item.height = 28;
            Item.value = Item.sellPrice(silver: 50);
            Item.rare = ItemRarityID.Green;
            Item.accessory = true;
            Item.buffType = ModContent.BuffType<IceBrooch>();
            BroochType = BroochType.Simple;
        }
    }
}