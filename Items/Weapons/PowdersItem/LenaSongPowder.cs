using Urdveil.Items.Weapons.Igniters;
using Urdveil.Projectiles.IgniterExplosions;
using Terraria.Audio;
using Terraria.ModLoader;

namespace Urdveil.Items.Weapons.PowdersItem
{
    internal class LenaSongPowder : BasePowder
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            //Percent increase, 1 is +100% damage
            DamageModifier = 3;
            ExplosionType = ModContent.ProjectileType<FableExSps>();

            SoundStyle explosionSoundStyle = new SoundStyle($"Urdveil/Assets/Sounds/LenaSongEx");
            explosionSoundStyle.PitchVariance = 0.15f;
            ExplosionSound = explosionSoundStyle;
            ExplosionScreenshakeAmt = 4f;
        }
    }
}