﻿using Terraria;

namespace Urdveil.Items.MoonlightMagic.Weapons
{
    internal class PlatinumWand : BaseStaff
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.damage = 14;
            Item.shootSpeed = 10;
            Item.useTime = 18;
            Item.useAnimation = 36;
            Size = 8;
            TrailLength = 16;
        }

        public override int GetNormalSlotCount()
        {
            return 3;
        }

        public override int GetTimedSlotCount()
        {
            return 1;
        }
    }
}