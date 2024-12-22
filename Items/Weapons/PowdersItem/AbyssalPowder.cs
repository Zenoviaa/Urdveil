using Urdveil.Items.Weapons.Igniters;
using Urdveil.Projectiles;
using Terraria.Audio;
using Terraria.ModLoader;

namespace Urdveil.Items.Weapons.PowdersItem
{
    internal class AbyssalPowder : BasePowder
    {
        public override void SetDefaults()
        {
            base.SetDefaults();

            DamageModifier = 5;
            ExplosionType = ModContent.ProjectileType<VoidKaboom>();

            SoundStyle explosionSoundStyle = new SoundStyle($"Urdveil/Assets/Sounds/ExplosionBurstBomb");
            explosionSoundStyle.PitchVariance = 0.15f;
            ExplosionSound = explosionSoundStyle;
            ExplosionScreenshakeAmt = 4;
        }
    }
}