
using Microsoft.Xna.Framework;
using Urdveil.Dusts;
using Terraria;
using Terraria.ModLoader;

namespace Urdveil.Tiles
{
    public class HuntiacWall : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = false;

            DustType = ModContent.DustType<Sparkle>();
            RegisterItemDrop(ModContent.ItemType<Items.Materials.HuntiacwallBlock>());

            AddMapEntry(new Color(200, 200, 200));
        }
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
        public override bool CanExplode(int i, int j) => false;
    }
}