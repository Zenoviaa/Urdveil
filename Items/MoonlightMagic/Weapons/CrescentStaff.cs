using Urdveil.Items.MoonlightMagic.Forms;

namespace Urdveil.Items.MoonlightMagic.Weapons
{
    internal class CrescentStaff : BaseStaff
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Form = FormRegistry.FourPointedStar.Value;
        }
    }
}
