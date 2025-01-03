﻿using Microsoft.Xna.Framework;
using Urdveil.Helpers;
using System;
using Terraria;

namespace Urdveil.Items.MoonlightMagic.Movements
{
    internal class TentaclingMovement : BaseMovement
    {
        public float maxHomingDetectDistance = 4012;
        float distance = 8;
        int rotationalSpeed = 4;
        int afterImgCancelDrawCount = 0;
        float t = 0;
        bool initialized = false;
        float alphaCounter;
        Vector2 initialSpeed = Vector2.Zero;
        int TimerSpeed = 0;
        int TimerSwitch = 0;

        public override void AI()
        {
            TimerSwitch++;
            Projectile.velocity *= 0.991f;
            alphaCounter += 0.04f;
            int rightValue = (int)Projectile.ai[1] - 1;
            if (rightValue < (double)Main.projectile.Length && rightValue != -1)
            {
                Projectile other = Main.projectile[rightValue];
                Vector2 direction9 = other.Center - Projectile.Center;
                int distance = (int)Math.Sqrt((direction9.X * direction9.X) + (direction9.Y * direction9.Y));
                direction9.Normalize();
            }
            if (!initialized)
            {
                initialSpeed = Projectile.velocity;
                initialized = true;
            }
            if (initialSpeed.Length() < 15)
                initialSpeed *= 1f;
            Projectile.spriteDirection = 1;
            if (TimerSpeed > 0)
            {
                Projectile.spriteDirection = 0;
            }

            distance += 1.2f;
            TimerSpeed += rotationalSpeed;

            Vector2 offset = initialSpeed.RotatedBy(Math.PI / 2);
            offset.Normalize();
            offset *= (float)(Math.Cos(TimerSpeed * (Math.PI / 180)) * (distance / 3));

            if (TimerSwitch > 0 && TimerSwitch < 30)
            {
                Projectile.velocity = initialSpeed + offset;
            }

            if (TimerSwitch > 30 && TimerSwitch < 60)
            {
                NPC npcToChase = ProjectileHelper.FindNearestEnemy(Projectile.Center, maxHomingDetectDistance);
                if (npcToChase != null)
                    Projectile.velocity = ProjectileHelper.SimpleHomingVelocity(Projectile, npcToChase.Center, degreesToRotate: 8);
            }

            if (TimerSwitch > 60)
            {
                TimerSwitch = 0;
            }

        }
    }
}
