using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Urdveil.Helpers;

namespace Urdveil.NPCs.Colosseum.Common
{
    internal class ColosseumGongSpawnerNPC : ModNPC
    {
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
        public override void AI()
        {
            base.AI();
            ColosseumSystem colosseumSystem = ModContent.GetInstance<ColosseumSystem>();
            if (ColosseumSystem.IsActive)
                return;

            if (!StellaMultiplayer.IsHost)
                return;

            int x = (int)NPC.Center.X;
            int y = (int)NPC.Center.Y;  
            if (!colosseumSystem.completedBronzeColosseum)
            {
                if (!NPC.AnyNPCs(ModContent.NPCType<BronzeGong>()))
                {
                    NPC.NewNPC(new EntitySource_WorldEvent(), (int)x, (int)y, ModContent.NPCType<BronzeGong>());
                    NetMessage.SendData(MessageID.WorldData);
                }
            }
            else if (!colosseumSystem.completedSilverColosseum)
            {
                if (!NPC.AnyNPCs(ModContent.NPCType<SilverGong>()))
                {
                    NPC.NewNPC(new EntitySource_WorldEvent(), (int)x, (int)y, ModContent.NPCType<SilverGong>());
                    NetMessage.SendData(MessageID.WorldData);
                }
            }
            else if (!colosseumSystem.completedGoldColosseum)
            {
                if (!NPC.AnyNPCs(ModContent.NPCType<GoldGong>()))
                {
                    NPC.NewNPC(new EntitySource_WorldEvent(), (int)x, (int)y, ModContent.NPCType<GoldGong>());
                    NetMessage.SendData(MessageID.WorldData);
                }
            }
        }
    }
}
