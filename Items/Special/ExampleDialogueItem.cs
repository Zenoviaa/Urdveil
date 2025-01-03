﻿using Urdveil.Helpers;
using Urdveil.UI.Dialogue;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Urdveil.Items.Special
{
    internal class ExampleDialogueItem : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.rare = ModContent.RarityType<GoldenSpecialRarity>();
        }


        public override bool? UseItem(Player player)
        {
            //1. Get the dialogue system
            DialogueSystem dialogueSystem = ModContent.GetInstance<DialogueSystem>();

            //2. Create a new instance of your dialogue
            ExampleDialogue exampleDialogue = new ExampleDialogue();

            //3. Start it
            dialogueSystem.StartDialogue(exampleDialogue);
            return true;
        }
    }
}
