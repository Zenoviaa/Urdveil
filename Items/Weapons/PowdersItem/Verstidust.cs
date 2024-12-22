using Urdveil.Items.Weapons.Igniters;
using Urdveil.Projectiles.IgniterExplosions;
using Terraria.Audio;
using Terraria.ModLoader;

namespace Urdveil.Items.Weapons.PowdersItem
{
    internal class Verstidust : BasePowder
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            //Percent increase, 1 is +100% damage
            DamageModifier = 5;
            ExplosionType = ModContent.ProjectileType<VerstiExSps>();

            SoundStyle explosionSoundStyle = new SoundStyle($"Urdveil/Assets/Sounds/windpetal");
            explosionSoundStyle.PitchVariance = 0.15f;
            ExplosionSound = explosionSoundStyle;
            ExplosionScreenshakeAmt = 2f;
        }
    }
}