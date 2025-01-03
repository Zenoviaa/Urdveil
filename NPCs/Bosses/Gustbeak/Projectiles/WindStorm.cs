﻿using Microsoft.Xna.Framework;
using Urdveil.Helpers;
using Urdveil.Trails;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Urdveil.NPCs.Bosses.Gustbeak.Projectiles
{
    internal class WindStorm : BaseWindProjectile
    {
        public override string Texture => TextureRegistry.EmptyTexture;
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            ProjectileID.Sets.TrailCacheLength[Type] = 16;
            ProjectileID.Sets.TrailingMode[Type] = 2;
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.width = 16;
            Projectile.height = 256;
            Projectile.hostile = true;
            Projectile.timeLeft = 300;
            Projectile.light = 0.2f;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
        }

        public override void AI()
        {
            base.AI();
            Wind.WidthFunc = WindWidthFunction;
            Wind.ColorFunc = WindColorFunction;
            Wind.TrailTexture = TrailRegistry.Dashtrail;
            ShadowScale = 0f;
            if (Timer == 1)
            {
                SoundStyle windStorm = new SoundStyle("Urdveil/Assets/Sounds/WindStorm");
                SoundEngine.PlaySound(windStorm);
            }


            if (Timer % 30 == 0)
            {
                if (Main.myPlayer == Projectile.owner)
                {
                    Vector2 debrisPos = Vector2.Lerp(Projectile.Bottom, Projectile.Top, Main.rand.NextFloat(0f, 1f));
                    float offset = Main.rand.NextBool(2) ? -1 : 1;
                    debrisPos.X += offset * 1024;
                    debrisPos.Y -= 128;
                    Vector2 velocity = Projectile.Center - debrisPos;
                    velocity = velocity.SafeNormalize(Vector2.Zero);
                    velocity.Y = 0;
                    velocity.X *= 11;
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), debrisPos, velocity,
                        ModContent.ProjectileType<WindStormDebris>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
                }
            }

            if (Timer % 6 == 0)
            {
                //Spawn new slashes on our little wind orb
                for (int i = 0; i < 8; i++)
                {
                    float progress = (float)i / 8f;
                    Vector2 offset = Vector2.Lerp(Vector2.Zero, -Vector2.UnitY * 256, progress);
                    offset.X -= Projectile.width / 2;
                    offset.Y += Projectile.height / 2;
                    float rotation = 0;
                    var slash = Wind.NewSlash(offset, rotation);
                    slash.swingXRadius = MathHelper.Lerp(16, 64, progress);
                    slash.swingYRadius = MathHelper.Lerp(8, 32, progress);
                    slash.duration *= 8f;
                    slash.swingRange *= 2;
                }
            }

            if (Timer % 4 == 0)
            {
                float dir = Main.rand.NextFloat(-1f, 1f);
                Vector2 vel = Vector2.UnitX * dir;
                Dust d = Dust.NewDustPerfect(Projectile.Bottom, DustID.GemDiamond, vel, Scale: 0.66f);
                d.noGravity = true;
            }

            Wind.ExpandMultiplier = MathHelper.Lerp(4.5f, 5f, MathF.Sin(Main.GlobalTimeWrappedHourly * 0.2f));

            /*
            Vector2 startHitscanPos = Projectile.Bottom - new Vector2(0, 64);
            float length = ProjectileHelper.PerformBeamHitscan(startHitscanPos, Vector2.UnitY, maxBeamLength: 2400);
            Vector2 pos = startHitscanPos;
            pos.Y += length;
            Projectile.Bottom = pos;
            */
            foreach (var player in Main.ActivePlayers)
            {
                float distanceToPlayer = Vector2.Distance(Projectile.Center, player.Center);
                if (distanceToPlayer < 1024)
                {
                    Vector2 suckVelocity = Projectile.Center - player.Center;
                    Vector2 vel = suckVelocity;
                    vel.Y = 0;
                    player.velocity += vel * 0.0005f;
                }
            }
        }

        private float WindWidthFunction(float progress)
        {
            float easedProgress = Easing.SpikeOutCirc(progress);
            return MathHelper.Lerp(64, 64, easedProgress);
        }
        private Color WindColorFunction(float progress)
        {
            float easedProgress = Easing.SpikeOutCirc(progress);
            Color color = Color.White * 0.5f;
            float outProgress = progress + Main.GlobalTimeWrappedHourly;
            color = Color.Lerp(color, Color.Transparent, MathF.Sin(progress * 2f));
            if (Timer > 240)
            {
                color = Color.Lerp(color, Color.Transparent, (Timer - 240) / 60f);
            }
            return color;
        }

        public override void OnKill(int timeLeft)
        {
            base.OnKill(timeLeft);

        }
    }
}
