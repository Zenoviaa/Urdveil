using Terraria;
using Terraria.ModLoader;

namespace Urdveil.NPCs.Colosseum.Common
{
    public class BronzeGong : BaseGongNPC
    {
        protected override void StartColosseum()
        {
            base.StartColosseum();
            if (StellaMultiplayer.IsHost)
            {
                NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.Bottom.X, (int)NPC.Bottom.Y, ModContent.NPCType<ColosseumWaveNPC>(), ai0: 0);
            }

        }
    }

    public class SilverGong : BaseGongNPC
    {
        protected override void StartColosseum()
        {
            base.StartColosseum();
            if (StellaMultiplayer.IsHost)
            {
                NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.Bottom.X, (int)NPC.Bottom.Y, ModContent.NPCType<ColosseumWaveNPC>(), ai0: 1);
            }
        }
    }

    public class GoldGong : BaseGongNPC
    {
        protected override void StartColosseum()
        {
            base.StartColosseum();
            if (StellaMultiplayer.IsHost)
            {
                NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.Bottom.X, (int)NPC.Bottom.Y, ModContent.NPCType<ColosseumWaveNPC>(), ai0: 2);
            }
        }
    }
}
