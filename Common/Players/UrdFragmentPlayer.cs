using System;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Urdveil.Items.Consumables;

namespace Urdveil.Common.Players
{
    internal class UrdFragmentPlayer : ModPlayer
    {
        //Weehee
        //Woohoo
        public bool unlockedSporecroweFragment;
        public bool unlockedAshotiFragment;
        public bool unlockedGothiviaFragment;
        public bool unlockedVerliaFragment;
        public bool unlockedGintziaFragment;
        public bool unlockedNiiviFragment;
        public bool unlockedSanguimiFragment;
        public BaseMedallionFragment HeldFragment;

        public override void PostUpdate()
        {
            base.PostUpdate();
        }

        public override void SaveData(TagCompound tag)
        {
            base.SaveData(tag);
            tag["unlockedSporecroweFragment"] = unlockedSporecroweFragment;
            tag["unlockedAshotiFragment"] = unlockedAshotiFragment;
            tag["unlockedGothiviaFragment"] = unlockedGothiviaFragment;
            tag["unlockedVerliaFragment"] = unlockedVerliaFragment;
            tag["unlockedGintziaFragment"] = unlockedGintziaFragment;
            tag["unlockedNiiviFragment"] = unlockedNiiviFragment;
            tag["unlockedSanguimiFragment"] = unlockedSanguimiFragment;
        }

        public override void LoadData(TagCompound tag)
        {
            base.LoadData(tag);
            unlockedSporecroweFragment = tag.GetBool("unlockedSporecroweFragment");
            unlockedAshotiFragment = tag.GetBool("unlockedAshotiFragment");
            unlockedGothiviaFragment = tag.GetBool("unlockedGothiviaFragment");
            unlockedVerliaFragment = tag.GetBool("unlockedVerliaFragment");
            unlockedGintziaFragment = tag.GetBool("unlockedGintziaFragment");
            unlockedNiiviFragment = tag.GetBool("unlockedNiiviFragment");
            unlockedSanguimiFragment = tag.GetBool("unlockedSanguimiFragment");
        }
    }
}
