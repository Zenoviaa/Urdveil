using Urdveil.Helpers;
using Urdveil.NPCs.Bosses.GothiviaTheSun.GOS;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Urdveil.UI.Dialogue
{
    internal class GothiviaDialogue : Dialogue
    {
        //The number of steps in this dialogue
        public override int Length => 3;

        public override void Next(int index)
        {
            base.Next(index);

            //This starts the dialogue
            switch (index)
            {
                case 0:
                    //Set the texture of the portrait
                    DialogueSystem.SetPortrait("Urdveil/UI/Dialogue/GothiviaDialoguePortrait");

                    //Put your dialogue in Mods.Urdveil.Dialogue.hjson, then get it like this
                    DialogueSystem.WriteText(GetLocalizedText("GothiviaDialogue1"));
                    break;
                case 1:
                    DialogueSystem.WriteText(GetLocalizedText("GothiviaDialogue2"));
                    break;
                case 2:
                    DialogueSystem.WriteText(GetLocalizedText("GothiviaDialogue3"));
                    break;
            }
        }

        public override void Update(int index)
        {
            base.Update(index);
            //If you want stuff to happen while they're talking you can do it here ig
            //But that might not be a good idea since you can just speed through dialogues
        }

        public override void Complete()
        {

            //Do something when the dialogue is completely finished

            if (Main.netMode != NetmodeID.SinglePlayer)
            {
                Urdveil.WriteToPacket(Urdveil.Instance.GetPacket(),
                    (byte)MessageType.StartBossFromDialogue,
                    (int)DialogueType.Start_Goth).Send(-1);
            }
            else
            {
                foreach (NPC npc in Main.ActiveNPCs)
                {
                    if (npc.type == ModContent.NPCType<StartGoth>())
                    {
                        StartGoth verlia = npc.ModNPC as StartGoth;
                        verlia.State = StartGoth.ActionState.Death;
                        verlia.ResetTimers();
                    }
                }
            }

            base.Complete();
        }
    }
}
