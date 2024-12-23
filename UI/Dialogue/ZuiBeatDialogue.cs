﻿using Urdveil.NPCs.Bosses.Zui.Projectiles;
using Terraria;
using Terraria.ModLoader;

namespace Urdveil.UI.Dialogue
{
    internal class ZuiBeatDialogue : Dialogue
    {
        //The number of steps in this dialogue
        public override int Length => 6;

        public override void Next(int index)
        {
            base.Next(index);

            //This starts the dialogue
            switch (index)
            {
                case 0:
                    //Set the texture of the portrait
                    DialogueSystem.SetPortrait("Urdveil/UI/Dialogue/ZuiDialoguePortrait");

                    //Put your dialogue in Mods.Urdveil.Dialogue.hjson, then get it like this
                    DialogueSystem.WriteText(GetLocalizedText("ZuiDialogue6"));
                    break;
                case 1:
                    DialogueSystem.WriteText(GetLocalizedText("ZuiDialogue7"));
                    break;
                case 2:
                    DialogueSystem.WriteText(GetLocalizedText("ZuiDialogue8"));
                    break;

                case 3:
                    DialogueSystem.WriteText(GetLocalizedText("ZuiDialogue9"));
                    break;

                case 4:
                    DialogueSystem.WriteText(GetLocalizedText("ZuiDialogue10"));
                    break;

                case 5:
                    DialogueSystem.WriteText(GetLocalizedText("ZuiDialogue11"));
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
            foreach (NPC npc in Main.ActiveNPCs)
            {
                if (npc.type == ModContent.NPCType<ZuiDeath>())
                {
                    ZuiDeath zui = npc.ModNPC as ZuiDeath;
                    zui.DM = true;

                }
            }
            //Do something when the dialogue is completely finished


            base.Complete();
        }




    }
}
