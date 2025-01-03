﻿using Terraria;
using Terraria.ModLoader;

namespace Urdveil.NPCs.Bosses.Verlia.Projectiles
{
    public class Strummer : ModProjectile
    {
        public int timer = 0;
        public override void SetDefaults()
        {
            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.friendly = false;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.ignoreWater = true;
            Projectile.hostile = true;
            Projectile.timeLeft = 70;
        }

        public override void AI()
        {
            Projectile.velocity *= 0.98f;
            var entitySource = Projectile.GetSource_FromAI();
            timer++;
            if (timer == 30)
            {
            }
            if (timer == 60)
            {
                if (StellaMultiplayer.IsHost)
                {
                    NPC.NewNPC(entitySource, (int)Projectile.Center.X, (int)Projectile.Center.Y, ModContent.NPCType<Viola>());
                }
            }
        }
    }
}