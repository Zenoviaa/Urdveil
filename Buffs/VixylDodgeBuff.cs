using Terraria;
using Terraria.ModLoader;

namespace Urdveil.Buffs
{
    internal class VixylDodgeBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {

        }
    }
}
