using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.DataStructures;
using Terraria;
using Terraria.ModLoader;
using Urdveil.NPCs.Bosses.CommanderGintzia;
using Urdveil.NPCs.Bosses.EliteCommander;
using Urdveil.NPCs.Bosses.Gustbeak;
using Urdveil.UI.TitleSystem;
using Terraria.ID;
using Urdveil.Items.Ores;
using Urdveil.Helpers;

namespace Urdveil.NPCs.Colosseum.Common
{
    internal class ColosseumWaveNPC : ModNPC
    {
        private bool _hasStarted;
        private int Tier => (int)NPC.ai[0];
        private  int WaveIndex
        {
            get
            {
                return (int)NPC.ai[1];
            }
            set
            {
                NPC.ai[1] = value;
            }
        }

        private int MaxWave
        {
            get
            {
                return 7;
            }
        }
        private int EnemyCount
        {
            get => ModContent.GetInstance<ColosseumSystem>().enemyCount;
            set => ModContent.GetInstance<ColosseumSystem>().enemyCount = value;
        }
        public override string Texture => TextureRegistry.EmptyTexture;
        public override void SetDefaults()
        {
            base.SetDefaults();
            NPC.width = 1;
            NPC.height = 1;
            NPC.lifeMax = 1000;
            NPC.defense = 1;
            NPC.dontCountMe = true;
            NPC.dontTakeDamage = true;
            NPC.dontTakeDamageFromHostiles = true;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
        }

        public override bool CheckActive()
        {
            return false;
        }

        private bool AllPlayersDead()
        {
            foreach (var player in Main.ActivePlayers)
            {
                if (!player.dead)
                    return false;
            }
            return true;
        }

        private bool AllPlayersTooFarAway()
        {
            foreach (var player in Main.ActivePlayers)
            {
                float distance = Vector2.Distance(NPC.Center, player.Center);
                if (distance < 1280)
                    return false;
            }
            return true;
        }

        private void ApplyNoBuildingDebuff()
        {
            foreach (var player in Main.ActivePlayers)
            {
                float distance = Vector2.Distance(NPC.Center, player.Center);
                if (distance < 1280)
                {
                    player.AddBuff(BuffID.NoBuilding, 2);
                }
            }
        }

        public override void AI()
        {
            base.AI();
            if (!_hasStarted)
            {
                StartColosseum();
                _hasStarted = true;
            }
            else
            {
                ApplyNoBuildingDebuff();
                if (AllPlayersDead() || AllPlayersTooFarAway())
                {
                    NPC.active = false;
                }
            }

            if(StellaMultiplayer.IsHost && _hasStarted)
            {
                if (EnemyCount < 0)
                {
                    Spawn();
                    WaveIndex++;
                    NPC.netUpdate = true;
                }
            }
        }
        public void StartColosseum()
        {
            EnemyCount = -1;
            //Spawn Chains so you can't leave
            if (StellaMultiplayer.IsHost)
            {
                Projectile.NewProjectile(new EntitySource_WorldEvent(), NPC.Center + new Vector2(0, -266), Vector2.Zero,
                    ModContent.ProjectileType<GoldChain>(), 25, 4, Main.myPlayer);
                Projectile.NewProjectile(new EntitySource_WorldEvent(), NPC.Center + new Vector2(0, 412), Vector2.Zero,
                    ModContent.ProjectileType<GoldChain>(), 25, 4, Main.myPlayer);
                NPC.NewNPC(new EntitySource_WorldEvent(), (int)NPC.Center.X, (int)NPC.Center.Y - 180,
                    ModContent.NPCType<CommanderGintziaTaunting>());
            }
        }

        private void Spawn()
        {
            SpawnWave(WaveIndex);
            if (WaveIndex >= MaxWave)
            {
                CompleteColosseum();
            }
            else
            {
                TitleCardUISystem uiSystem = ModContent.GetInstance<TitleCardUISystem>();
                uiSystem.OpenUI($"Wave {WaveIndex + 1}", duration: 3);
            }
        }

        public void SpawnWave(int index)
        {
            if (!StellaMultiplayer.IsHost)
                return;

            switch (Tier)
            {
                case 0:
                    SpawnBronzeWave(index);
                    break;
                case 1:
                    SpawnSilverWave(index);
                    break;
                case 2:
                    SpawnGoldWave(index);
                    break;
            }
        }

        private void SpawnBronzeWave(int index)
        {
            switch (index)
            {
                case 0:
                    Spawn(new Point(-33, 0), ModContent.NPCType<GintzeSolider>());
                    Spawn(new Point(33, 0), ModContent.NPCType<GintzeSolider>());
                    break;
                case 1:
                    Spawn(new Point(-37, 0), ModContent.NPCType<GintzeCaptain>());
                    Spawn(new Point(-33, 0), ModContent.NPCType<GintzeSolider>());
                    Spawn(new Point(-27, 0), ModContent.NPCType<GintzeSolider>());
                    break;
                case 2:
                    Spawn(new Point(37, 0), ModContent.NPCType<GintzeCaptain>());
                    Spawn(new Point(33, 0), ModContent.NPCType<Gintzling>());
                    Spawn(new Point(27, 0), ModContent.NPCType<Gintzling>());
                    break;
                case 3:
                    Spawn(new Point(-33, 0), ModContent.NPCType<Gintzling>());
                    Spawn(new Point(-15, 0), ModContent.NPCType<Gintzling>());
                    Spawn(new Point(33, 0), ModContent.NPCType<Gintzling>());
                    Spawn(new Point(15, 0), ModContent.NPCType<Gintzling>());
                    break;
                case 4:
                    Spawn(new Point(-33, 0), ModContent.NPCType<GintzeSolider>());
                    Spawn(new Point(-15, 0), ModContent.NPCType<GintzeSolider>());
                    Spawn(new Point(33, 0), ModContent.NPCType<GintzeSolider>());
                    Spawn(new Point(15, 0), ModContent.NPCType<GintzeSolider>());
                    Spawn(new Point(33, 10), ModContent.NPCType<Gintzling>());
                    Spawn(new Point(0, 10), ModContent.NPCType<GintzeCaptain>());
                    Spawn(new Point(15, 10), ModContent.NPCType<Gintzling>());
                    break;
                case 5:
                    Spawn(new Point(0, 10), ModContent.NPCType<GintzeCaptain>());
                    Spawn(new Point(-33, 0), ModContent.NPCType<GintzeSolider>());
                    Spawn(new Point(33, 0), ModContent.NPCType<GintzeSolider>());
                    Spawn(new Point(-15, 10), ModContent.NPCType<Gintzling>());
                    Spawn(new Point(15, 10), ModContent.NPCType<Gintzling>());
                    break;
                case 6:
                    Spawn(new Point(27, 0), ModContent.NPCType<EliteCommander>());
                    break;
            }
        }

        private void SpawnSilverWave(int index)
        {
            switch (index)
            {
                case 0:
                    Spawn(new Point(-33, 0), ModContent.NPCType<Gintzling>());
                    Spawn(new Point(-33, 10), ModContent.NPCType<Gintzling>());
                    Spawn(new Point(33, 0), ModContent.NPCType<Gintzling>());
                    Spawn(new Point(33, 10), ModContent.NPCType<Gintzling>());
                    break;
                case 1:
                    Spawn(new Point(-33, 0), ModContent.NPCType<Gintzling>());
                    Spawn(new Point(-33, 10), ModContent.NPCType<GintzeWindRider>());
                    Spawn(new Point(33, 10), ModContent.NPCType<Gintzling>());
                    Spawn(new Point(33, 0), ModContent.NPCType<GintzeWindRider>());
                    break;
                case 2:
                    Spawn(new Point(-33, -10), ModContent.NPCType<GintzeWindRider>());
                    Spawn(new Point(-15, -10), ModContent.NPCType<GintzeWindRider>());
                    Spawn(new Point(15, -10), ModContent.NPCType<GintzeWindRider>());
                    Spawn(new Point(33, -10), ModContent.NPCType<GintzeWindRider>());
                    break;
                case 3:
                    Spawn(new Point(-33, 0), ModContent.NPCType<GintzeSpearman>());
                    Spawn(new Point(-33, 10), ModContent.NPCType<GintzeSpearman>());
                    Spawn(new Point(0, 10), ModContent.NPCType<GintzeCaptain>());
                    Spawn(new Point(33, 0), ModContent.NPCType<GintzeSpearman>());
                    Spawn(new Point(33, 10), ModContent.NPCType<GintzeSpearman>());
                    break;
                case 4:
                    Spawn(new Point(33, 10), ModContent.NPCType<Gintzling>());
                    Spawn(new Point(-15, 10), ModContent.NPCType<Gintzling>());
                    Spawn(new Point(15, 10), ModContent.NPCType<Gintzling>());
                    Spawn(new Point(-33, 10), ModContent.NPCType<Gintzling>());
                    Spawn(new Point(-33, -10), ModContent.NPCType<GintzeWindRider>());
                    Spawn(new Point(33, -10), ModContent.NPCType<GintzeWindRider>());
                    break;

                case 5:
                    Spawn(new Point(33, 10), ModContent.NPCType<GintzeCaptain>());
                    Spawn(new Point(-15, 10), ModContent.NPCType<Gintzling>());
                    Spawn(new Point(15, 10), ModContent.NPCType<Gintzling>());
                    Spawn(new Point(-33, 10), ModContent.NPCType<GintzeCaptain>());
                    Spawn(new Point(-27, -13), ModContent.NPCType<GintzeWindRider>());
                    Spawn(new Point(27, -13), ModContent.NPCType<GintzeWindRider>());
                    break;
                case 6:
                    Spawn(new Point(-33, -64), ModContent.NPCType<Gustbeak>());
                    break;
            }
        }

        private void SpawnGoldWave(int index)
        {
            switch (index)
            {
                case 0:
                    Spawn(new Point(0, 10), ModContent.NPCType<GintzeCaptain>());
                    Spawn(new Point(-15, 10), ModContent.NPCType<Gintzling>());
                    Spawn(new Point(15, 10), ModContent.NPCType<Gintzling>());
                    Spawn(new Point(-33, 10), ModContent.NPCType<GintzeCaptain>());
                    Spawn(new Point(-27, -13), ModContent.NPCType<GintzeWindRider>());
                    Spawn(new Point(27, -13), ModContent.NPCType<GintzeWindRider>());
                    Spawn(new Point(35, 0), ModContent.NPCType<GintzeWindRider>());
                    Spawn(new Point(35, 0), ModContent.NPCType<GintzeWindRider>());
                    break;
                case 1:
                    Spawn(new Point(-33, 0), ModContent.NPCType<GintzeTumbleWeed>());
                    Spawn(new Point(-33, 10), ModContent.NPCType<GintzeTumbleWeed>());
                    Spawn(new Point(0, 10), ModContent.NPCType<GintzeTumbleWeed>());
                    Spawn(new Point(33, 0), ModContent.NPCType<GintzeTumbleWeed>());
                    Spawn(new Point(33, 10), ModContent.NPCType<GintzeTumbleWeed>());
                    break;
                case 2:
                    Spawn(new Point(-33, 0), ModContent.NPCType<GintzeTumbleWeed>());
                    Spawn(new Point(-33, 10), ModContent.NPCType<GintzeTumbleWeed>());
                    Spawn(new Point(0, 10), ModContent.NPCType<GintzeCaptain>());
                    Spawn(new Point(33, 0), ModContent.NPCType<GintzeTumbleWeed>());
                    Spawn(new Point(33, 10), ModContent.NPCType<GintzeTumbleWeed>());
                    Spawn(new Point(-27, -13), ModContent.NPCType<GintzeWindRider>());
                    Spawn(new Point(27, -13), ModContent.NPCType<GintzeWindRider>());

                    break;
                case 3:
                    Spawn(new Point(-33, 0), ModContent.NPCType<GintzeSpearman>());
                    Spawn(new Point(-33, 10), ModContent.NPCType<GintzeSpearman>());
                    Spawn(new Point(0, 10), ModContent.NPCType<GintzeCaptain>());
                    Spawn(new Point(33, 0), ModContent.NPCType<GintzeSpearman>());
                    Spawn(new Point(33, 10), ModContent.NPCType<GintzeSpearman>());
                    Spawn(new Point(-33, 10), ModContent.NPCType<GintzeTumbleWeed>());
                    Spawn(new Point(33, 10), ModContent.NPCType<GintzeTumbleWeed>());
                    break;
                case 4:
                    Spawn(new Point(-33, 0), ModContent.NPCType<GintzeTumbleWeed>());
                    Spawn(new Point(-33, 10), ModContent.NPCType<GintzeCaptain>());
                    Spawn(new Point(0, 10), ModContent.NPCType<GintzeCaptain>());
                    Spawn(new Point(33, 10), ModContent.NPCType<GintzeCaptain>());
                    Spawn(new Point(33, 0), ModContent.NPCType<GintzeTumbleWeed>());
                    Spawn(new Point(33, -10), ModContent.NPCType<GintzeTumbleWeed>());
                    Spawn(new Point(-33, -10), ModContent.NPCType<GintzeTumbleWeed>());
                    break;
                case 5:
                    Spawn(new Point(33, 0), ModContent.NPCType<GintzeTumbleWeed>());
                    Spawn(new Point(-33, 0), ModContent.NPCType<GintzeTumbleWeed>());
                    Spawn(new Point(35, 10), ModContent.NPCType<EliteCommander>());
                    Spawn(new Point(-35, 10), ModContent.NPCType<EliteCommander>());
                    break;
                case 6:
                    Spawn(new Point(0, -30), ModContent.NPCType<CommanderGintzia>());
                    break;
            }
        }

        public void Spawn(Point tileOffset, int npcType)
        {
            EnemyCount++;
            Point colosseumTile = NPC.position.ToTileCoordinates();
            Point spawnPoint = colosseumTile + tileOffset;
            Vector2 spawnWorld = spawnPoint.ToWorldCoordinates();
            NPC.NewNPC(new EntitySource_WorldEvent(), (int)spawnWorld.X, (int)spawnWorld.Y,
                ModContent.NPCType<SpawnerNPC>(), ai0: npcType);
        }

        public void CompleteColosseum()
        {
            ColosseumSystem colosseumSystem = ModContent.GetInstance<ColosseumSystem>();
            int x = (int)NPC.Center.X;
            int y = (int)NPC.Center.Y;
            switch (Tier)
            {
                case 0:
                    NPC.NewNPC(new EntitySource_WorldEvent(), (int)x, (int)y,
                        ModContent.NPCType<CoinSpawnerNPC>(), ai1: 500, ai3: ItemID.SilverCoin);
                    NPC.NewNPC(new EntitySource_WorldEvent(), (int)x, (int)y,
                        ModContent.NPCType<CoinSpawnerNPC>(), ai1: 30, ai3: ModContent.ItemType<GintzlMetal>());
                    NPC.SetEventFlagCleared(ref colosseumSystem.completedBronzeColosseum, -1);
                    break;
                case 1:
                    NPC.NewNPC(new EntitySource_WorldEvent(), (int)x, (int)y,
                        ModContent.NPCType<CoinSpawnerNPC>(), ai1: 750, ai3: ItemID.SilverCoin);
                    NPC.NewNPC(new EntitySource_WorldEvent(), (int)x, (int)y,
                        ModContent.NPCType<CoinSpawnerNPC>(), ai1: 50, ai3: ModContent.ItemType<GintzlMetal>());
                    NPC.SetEventFlagCleared(ref colosseumSystem.completedSilverColosseum, -1);
                    break;
                case 2:
                    NPC.NewNPC(new EntitySource_WorldEvent(), (int)x, (int)y,
                        ModContent.NPCType<CoinSpawnerNPC>(), ai1: 1000, ai3: ItemID.SilverCoin);
                    NPC.NewNPC(new EntitySource_WorldEvent(), (int)x, (int)y,
                        ModContent.NPCType<CoinSpawnerNPC>(), ai1: 100, ai3: ModContent.ItemType<GintzlMetal>());
                    NPC.SetEventFlagCleared(ref colosseumSystem.completedGoldColosseum, -1);
                    break;
                case 3:
                    NPC.SetEventFlagCleared(ref colosseumSystem.completedTrueColosseum, -1);
                    break;
            }

            NPC.active = false;
            NetMessage.SendData(MessageID.WorldData);
        }
    }
}
