﻿using Microsoft.Xna.Framework;
using Urdveil.Common.Bases;
using Urdveil.Helpers;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Urdveil.Items.Accessories.Runes
{
    internal class RuneOfCorsagePlayer : ModPlayer
    {
        public bool hasRuneOfCorsage;
        public override void ResetEffects()
        {
            base.ResetEffects();
            hasRuneOfCorsage = false;
        }

        public override void PostUpdateEquips()
        {
            base.PostUpdateEquips();
            if (hasRuneOfCorsage)
            {
                NPC[] npcsInRange = NPCHelper.FindNPCsInRange(Player.Center, maxDetectDistance: 128, -1);
                foreach (NPC npc in npcsInRange)
                {
                    npc.AddBuff(BuffID.Poisoned, 60);
                }
            }
        }
    }

    internal class RuneOfCorsage : BaseRune
    {
        private float _dustTimer;
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.width = 20;
            Item.height = 20;
            Item.value = Item.sellPrice(gold: 1);

        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.velocity == Vector2.Zero)
            {
                player.lifeRegen += 3;
                _dustTimer++;
                if (!hideVisual)
                {
                    if (_dustTimer % 8 == 0)
                    {
                        Vector2 pos = player.Center + Main.rand.NextVector2CircularEdge(64, 64);
                        Vector2 velocity = player.Center - pos;
                        velocity *= 0.2f;
                        Dust.NewDustPerfect(pos, DustID.JungleGrass, velocity, Scale: 0.5f);
                    }
                }
            }

            RuneOfCorsagePlayer runeOfCorsagePlayer = player.GetModPlayer<RuneOfCorsagePlayer>();
            runeOfCorsagePlayer.hasRuneOfCorsage = true;
        }
    }
}