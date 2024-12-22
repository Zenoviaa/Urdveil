using Urdveil.Items.Weapons.Igniters;
using Urdveil.Projectiles;
using Terraria.Audio;
using Terraria.ModLoader;

namespace Urdveil.Items.Weapons.PowdersItem
{
    internal class BloodPowder : BasePowder
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            //Percent increase, 1 is +100% damage
            DamageModifier = 6;
            ExplosionType = ModContent.ProjectileType<KaBoomKaev>();


            SoundStyle explosionSoundStyle = new SoundStyle($"Urdveil/Assets/Sounds/Suckler");
            explosionSoundStyle.PitchVariance = 0.15f;
            ExplosionSound = explosionSoundStyle;
            ExplosionScreenshakeAmt = 2;
        }
    }
}