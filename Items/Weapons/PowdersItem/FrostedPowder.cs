using Urdveil.Items.Weapons.Igniters;
using Urdveil.Projectiles;
using Terraria.Audio;
using Terraria.ModLoader;

namespace Urdveil.Items.Weapons.PowdersItem
{
    internal class FrostedPowder : BasePowder
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            //Percent increase, 1 is +100% damage
            DamageModifier = 4;
            ExplosionType = ModContent.ProjectileType<FrostbiteProj>();

            SoundStyle explosionSoundStyle = new SoundStyle($"Urdveil/Assets/Sounds/Frosty");
            explosionSoundStyle.PitchVariance = 0.15f;
            ExplosionSound = explosionSoundStyle;
            ExplosionScreenshakeAmt = 2;
        }
    }
}