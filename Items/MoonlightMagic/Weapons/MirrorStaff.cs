﻿using Urdveil.Items.MoonlightMagic.Forms;

namespace Urdveil.Items.MoonlightMagic.Weapons
{
    internal class MirrorStaff : BaseStaff
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.damage = 35;
            Item.shootSpeed = 19;
            Item.useTime = 40;
            Item.useAnimation = 40;
            Size = 20;
            TrailLength = 50;
            Form = FormRegistry.Lantern.Value;
        }


        public override int GetNormalSlotCount()
        {
            return 3;
        }

        public override int GetTimedSlotCount()
        {
            return 4;
        }
    }
}
