using Terraria;
using Terraria.ModLoader;


namespace Urdveil.Buffs
{
    public class GintzelSheildCD : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
            // DisplayName.SetDefault("Acid Flame");
            // Description.SetDefault("'An Acidic force melts your insides'");
        }
    }
}