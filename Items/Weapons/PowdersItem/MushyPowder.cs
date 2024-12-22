using Urdveil.Items.Weapons.Igniters;
using Urdveil.Projectiles.IgniterExplosions;
using Terraria.Audio;
using Terraria.ModLoader;

namespace Urdveil.Items.Weapons.PowdersItem
{
    internal class MushyPowder : BasePowder
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            //Percent increase, 1 is +100% damage
            DamageModifier = 2;
            ExplosionType = ModContent.ProjectileType<MushyBoom>();

            SoundStyle explosionSoundStyle = new SoundStyle("Urdveil/Assets/Sounds/Green");
            explosionSoundStyle.PitchVariance = 0.15f;
            ExplosionSound = explosionSoundStyle;
            ExplosionScreenshakeAmt = 4f;
        }
    }
}