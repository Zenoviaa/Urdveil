﻿using Terraria;

namespace Urdveil.Items.Weapons.Igniters
{
    internal class EYIgniter : BaseIgniterCard
    {
        public override void SetClassSwappedDefaults()
        {
            base.SetClassSwappedDefaults();
            Item.damage = 1;
            Item.mana = 0;
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.damage = 2;
        }

        public override int GetPowderSlotCount()
        {

            return 3;
        }
    }
}