﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Urdveil.Buffs
{
    internal class MarksMan : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = false;
            Main.buffNoTimeDisplay[Type] = true;
            BuffID.Sets.TimeLeftDoesNotDecrease[Type] = true;
        }
    }
}
