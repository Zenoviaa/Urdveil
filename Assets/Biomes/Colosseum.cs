﻿using Microsoft.Xna.Framework;
using Urdveil.NPCs.Colosseum.Common;
using Terraria;
using Terraria.ModLoader;

namespace Urdveil.Assets.Biomes
{
    internal class Colosseum : ModBiome
    {

        public override int Music
        {
            get
            {
                if (NPC.AnyNPCs(ModContent.NPCType<ColosseumWaveNPC>()))
                {
                    return MusicLoader.GetMusicSlot(Mod, "Assets/Music/The_Gintzing_Winds");
                }
                return -1;
            }
        }
        public override SceneEffectPriority Priority => SceneEffectPriority.BossLow;
        public override string BestiaryIcon => base.BestiaryIcon;
        public override string BackgroundPath => MapBackground;
        public override Color? BackgroundColor => base.BackgroundColor;



        public override bool IsBiomeActive(Player player) => BiomeTileCounts.InColosseum;
        public override void OnEnter(Player player)
        {
            player.GetModPlayer<MyPlayer>().ZoneColloseum = true;
            player.ZoneDesert = true;
        }
        public override void OnLeave(Player player)
        {
            player.GetModPlayer<MyPlayer>().ZoneColloseum = false;
            player.ZoneDesert = false;
        }
    }


}
