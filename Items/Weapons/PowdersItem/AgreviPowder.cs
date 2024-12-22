using Urdveil.Items.Weapons.Igniters;
using Urdveil.Projectiles.IgniterExplosions;
using Terraria.Audio;
using Terraria.ModLoader;

namespace Urdveil.Items.Weapons.PowdersItem
{
    internal class AgreviPowder : BasePowder
    {
        public override void SetDefaults()
        {
            base.SetDefaults();

            //Percent increase, 1 is +100% damage
            DamageModifier = 5;
            ExplosionType = ModContent.ProjectileType<AgreviBoom>();

            SoundStyle explosionSoundStyle = new SoundStyle($"Urdveil/Assets/Sounds/Kaboom");
            explosionSoundStyle.PitchVariance = 0.15f;
            ExplosionSound = explosionSoundStyle;
            ExplosionScreenshakeAmt = 8;
        }
    }
}