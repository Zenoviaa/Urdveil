using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Urdveil.NPCs.Colosseum.Common
{
    public class ColosseumSystem : ModSystem
    {
        public int enemyCount;
        public bool completedBronzeColosseum;
        public bool completedSilverColosseum;
        public bool completedGoldColosseum;
        public bool completedTrueColosseum;
        public static bool IsActive => NPC.AnyNPCs(ModContent.NPCType<ColosseumWaveNPC>());
        public override void NetSend(BinaryWriter writer)
        {
            base.NetSend(writer);
            writer.Write(completedBronzeColosseum);
            writer.Write(completedSilverColosseum);
            writer.Write(completedGoldColosseum);
            writer.Write(completedTrueColosseum);
        }

        public override void NetReceive(BinaryReader reader)
        {
            base.NetReceive(reader);
            completedBronzeColosseum = reader.ReadBoolean();
            completedSilverColosseum = reader.ReadBoolean();
            completedGoldColosseum = reader.ReadBoolean();
            completedTrueColosseum = reader.ReadBoolean();
        }

        public override void SaveWorldData(TagCompound tag)
        {
            base.SaveWorldData(tag);
            tag["bronze"] = completedBronzeColosseum;
            tag["silver"] = completedSilverColosseum;
            tag["gold"] = completedGoldColosseum;
            tag["true"] = completedTrueColosseum;
        }

        public override void LoadWorldData(TagCompound tag)
        {
            base.LoadWorldData(tag);
            completedBronzeColosseum = tag.GetBool("bronze");
            completedSilverColosseum = tag.GetBool("silver");
            completedGoldColosseum = tag.GetBool("gold");
            completedTrueColosseum = tag.GetBool("true");
        }


        public void Reset()
        {
            completedBronzeColosseum = false;
            completedSilverColosseum = false;
            completedGoldColosseum = false;
            completedTrueColosseum = false;
        }
    }
}
