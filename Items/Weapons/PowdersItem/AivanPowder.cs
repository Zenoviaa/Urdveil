﻿using Urdveil.Items.Weapons.Igniters;
using Urdveil.Projectiles;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Urdveil.Items.Weapons.PowdersItem
{
    internal class AivanPowder : BasePowder
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            //Percent increase, 1 is +100% damage
            DamageModifier = 7;
            ExplosionType = ModContent.ProjectileType<AivanKaboom>();

            SoundStyle explosionSoundStyle = SoundID.DD2_ExplosiveTrapExplode;
            explosionSoundStyle.PitchVariance = 0.15f;
            ExplosionSound = explosionSoundStyle;
            ExplosionScreenshakeAmt = 2;
        }
    }
}