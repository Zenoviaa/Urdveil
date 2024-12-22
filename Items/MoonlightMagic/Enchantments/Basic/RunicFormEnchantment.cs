using Urdveil.Items.MoonlightMagic.Elements;
using Urdveil.Items.MoonlightMagic.Forms;
using Terraria;
using Terraria.ModLoader;

namespace Urdveil.Items.MoonlightMagic.Enchantments.Basic
{
    internal class RunicFormEnchantment : BaseEnchantment
    {
        bool HitOnce = false;
        int Attagain = 14;
        public override float GetStaffManaModifier()
        {
            return 0.1f;
        }

        public override int GetElementType()
        {
            return ModContent.ItemType<BasicElement>();
        }

        public override void SetMagicDefaults()
        {
            Projectile.velocity *= 1.5f;
            MagicProj.Form = FormRegistry.Runic.Value;
        }
    }
}
