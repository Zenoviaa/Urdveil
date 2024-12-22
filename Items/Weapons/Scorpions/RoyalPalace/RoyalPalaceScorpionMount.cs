using Urdveil.Buffs.Scorpion;
using Urdveil.Common.ScorpionMountSystem;
using Terraria;
using Terraria.ModLoader;

namespace Urdveil.Items.Weapons.Scorpions.RoyalPalace
{
    internal class RoyalPalaceScorpionMount : BaseScorpionMount
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            MountData.buff = ModContent.BuffType<RoyalPalaceScorpionMountBuff>();
            scorpionItem = (BaseScorpionItem)(new Item(ModContent.ItemType<RoyalPalaceScorpion>()).ModItem);
        }
    }
}
