using Urdveil.NPCs.Town;
using Urdveil.UI.DialogueTowning;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Urdveil.Common.QuestSystem.Quests
{
    public class TalkToZui : Quest
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            AddReward(ItemID.Wood, 10);

        }

        public override bool CanGiveQuest(Player player)
        {
            return true;
        }

        public override void StartQuest(Player player)
        {
            base.StartQuest(player);
        }

        public override bool CheckCompletion(Player player)
        {
            return ModContent.GetInstance<DialogueTowningUISystem>().WhosTalking == ModContent.NPCType<Zui>();
        }
    }
}
