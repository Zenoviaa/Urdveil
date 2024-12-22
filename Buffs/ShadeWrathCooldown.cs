using Terraria;
using Terraria.ModLoader;

namespace Urdveil.Buffs
{
    internal class ShadeWrathCooldown : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
        }
    }
}
