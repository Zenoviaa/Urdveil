﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Urdveil.Helpers;
using Urdveil.Items.Consumables;
using Urdveil.Items.Placeable;
using Urdveil.NPCs.BossBars;
using Urdveil.NPCs.Bosses.EliteCommander.Projectiles;
using Urdveil.NPCs.Bosses.StarrVeriplant.Projectiles;
using Urdveil.UI.Systems;

namespace Urdveil.NPCs.Bosses.StarrVeriplant
{
    [AutoloadBossHead] // This attribute looks for a texture called "ClassName_Head_Boss" and automatically registers it as the NPC boss head ic
    public class StarrVeriplant : ModNPC
    {
        private enum ActionState
        {
            Spawn,
            Idle,
            Stomp,
            Stomp_Multi,
            Stomp_Super
        }

        private ActionState State
        {
            get => (ActionState)NPC.ai[0];
            set => NPC.ai[0] = (float)value;
        }

        private ref float Timer => ref NPC.ai[1];
        private ref float AttackCounter => ref NPC.ai[2];
        private ref float StompCounter => ref NPC.ai[3];

        private Player Target => Main.player[NPC.target];
        private bool InPhase2 => NPC.life < NPC.lifeMax / 2;
        private bool HasDoneStomp;
        private bool CanSuperStomp;
        private bool CanMultiStomp;
        private bool DrawOutline;
        private float OutlineOpacity;
        private float StompSpeed = 1;
        private Vector2 StompPos;
        private float Spawner;

        public override bool CanHitPlayer(Player target, ref int cooldownSlot)
        {
            bool isInStompState = State == ActionState.Stomp || State == ActionState.Stomp_Multi || State == ActionState.Stomp_Super;
            switch (State)
            {
                case ActionState.Stomp:
                    return AttackCounter == 2;
                case ActionState.Stomp_Multi:
                    return AttackCounter == 1;
                case ActionState.Stomp_Super:
                    return AttackCounter == 2;
            }
            return false;
        }

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 1;
            NPCID.Sets.TrailCacheLength[Type] = 10;
            NPCID.Sets.TrailingMode[Type] = 1;
            NPCID.Sets.BossBestiaryPriority.Add(Type);
            NPCID.Sets.MPAllowedEnemies[NPC.type] = true;

            // Influences how the NPC looks in the Bestiary
            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers()
            {
                CustomTexturePath = "Urdveil/NPCs/Bosses/StarrVeriplant/StarrPreview",
                PortraitScale = 0.8f, // Portrait refers to the full picture when clicking on the icon in the bestiary
                PortraitPositionYOverride = 0f,
            };

            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);
        }

        public override void SetDefaults()
        {
            NPC.width = 80;
            NPC.height = 44;
            NPC.damage = 25;
            NPC.lifeMax = 600;
            NPC.HitSound = new SoundStyle("Urdveil/Assets/Sounds/Gintze_Hit") with { PitchVariance = 0.1f };
            NPC.DeathSound = new SoundStyle("Urdveil/Assets/Sounds/Gintze_Death") with { PitchVariance = 0.1f };
            NPC.knockBackResist = 0f;
            NPC.noGravity = true;
            NPC.value = Item.buyPrice(copper: 40);
            NPC.SpawnWithHigherTime(30);
            NPC.boss = true;
            NPC.npcSlots = 10f;

            // Take up open spawn slots, preventing random NPCs from spawning during the fight
            // Don't set immunities like this as of 1.4:
            // NPC.buffImmune[BuffID.Confused] = true;
            // immunities are handled via dictionaries through NPCID.Sets.DebuffImmunitySets

            // Custom AI, 0 is "bound town NPC" AI which slows the NPC down and changes sprite orientation towards the target
            NPC.aiStyle = -1;

            // Custom boss bar
            NPC.BossBar = ModContent.GetInstance<MiniBossBar>();

            // The following code assigns a music track to the boss in a simple way.
            if (!Main.dedServ)
            {
                Music = MusicLoader.GetMusicSlot(Mod, "Assets/Music/StoneGolem");
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            SpriteEffects Effects = SpriteEffects.None;

            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive, Main.DefaultSamplerState, DepthStencilState.None, RasterizerState.CullNone, null, Main.GameViewMatrix.TransformationMatrix);

            Color startTrailColor = Color.LightGoldenrodYellow;
            Color endTrailColor = Color.DarkGoldenrod;
            startTrailColor *= 0.5f;
            endTrailColor *= 0.5f;
            for (int k = 0; k < NPC.oldPos.Length; k++)
            {
                Vector2 drawPos = NPC.oldPos[k] - Main.screenPosition + NPC.Size / 2 + new Vector2(0f, NPC.gfxOffY);
                drawPos.Y -= 54;
                Color color = NPC.GetAlpha(Color.Lerp(startTrailColor, endTrailColor, 1f / NPC.oldPos.Length * k) * (1f - 1f / NPC.oldPos.Length * k));
                spriteBatch.Draw(TextureAssets.Npc[NPC.type].Value, drawPos, NPC.frame, color, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, Effects, 0f);
            }

            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, RasterizerState.CullNone, null, Main.GameViewMatrix.TransformationMatrix);

            Texture2D outlineTexture = ModContent.Request<Texture2D>(Texture + "_Outline").Value;
            Vector2 outlineDrawPos = NPC.position - Main.screenPosition + NPC.Size / 2 + new Vector2(0f, NPC.gfxOffY);
            outlineDrawPos.Y -= 54;
            Color outlineColor = Color.Lerp(Color.Transparent, Color.Red, OutlineOpacity);
            spriteBatch.Draw(outlineTexture, outlineDrawPos, NPC.frame, outlineColor, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, Effects, 0);

            return base.PreDraw(spriteBatch, screenPos, drawColor);
        }

        public override void SendExtraAI(BinaryWriter writer)
        {
            base.SendExtraAI(writer);
            writer.WriteVector2(StompPos);
            writer.Write(StompSpeed);
            writer.Write(HasDoneStomp);
            writer.Write(CanMultiStomp);
            writer.Write(CanSuperStomp);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            base.ReceiveExtraAI(reader);
            StompPos = reader.ReadVector2();
            StompSpeed = reader.ReadSingle();
            HasDoneStomp = reader.ReadBoolean();
            CanMultiStomp = reader.ReadBoolean();
            CanSuperStomp = reader.ReadBoolean();
        }

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * balance);
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // Sets the description of this NPC that is listed in the bestiary
            bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement> {
                new MoonLordPortraitBackgroundProviderBestiaryInfoElement(), // Plain black background
				new FlavorTextBestiaryInfoElement(LangText.Bestiary(this, "A beloved magical stone guardian, protected the natural life and would petrify anyone who disturbs it."))
            });
        }

        public override bool? CanFallThroughPlatforms()
        {
            bool isStompState = State == ActionState.Stomp || State == ActionState.Stomp_Multi;
            if (isStompState && NPC.HasValidTarget && Main.player[NPC.target].Top.Y > NPC.Bottom.Y)
            {
                // If Flutter Slime is currently falling, we want it to keep falling through platforms as long as it's above the player
                return true;
            }

            return false;
            // You could also return null here to apply vanilla behavior (which is the same as false for custom AI)
        }

        public override void AI()
        {
            base.AI();

            Vector2 startPos = NPC.position;
            Vector2 endPos = Target.position;

            //Only check vertically
            endPos.X = startPos.X;
            NPC.noTileCollide = !Collision.CanHitLine(startPos, 1, 1, endPos, 1, 1);
            Spawner++;
            if (InPhase2)
            {
                float finalStompSpeed = 0.5f;
                //Gradually faster over time, but we limit it so it doesn't get out of hand
                StompSpeed -= 0.001f;
                StompSpeed = MathF.Max(StompSpeed, finalStompSpeed);
            }

            NPC.rotation = MathHelper.Lerp(NPC.rotation, NPC.velocity.X * 0.05f, 0.1f);
            if (DrawOutline)
            {
                OutlineOpacity = MathHelper.Lerp(OutlineOpacity, 1f, 0.1f);
            }
            else
            {
                OutlineOpacity = MathHelper.Lerp(OutlineOpacity, 0f, 0.1f);
            }

            
            if (!NPC.HasValidTarget)
            {
                NPC.TargetClosest();
                if (!NPC.HasValidTarget)
                {
                    NPC.noTileCollide = true;
                    NPC.EncourageDespawn(60);
                    NPC.velocity -= Vector2.UnitY;
                    return;
                }
    
            }

            //AI States
            switch (State)
            {
                case ActionState.Spawn:
                    AI_Spawn();
                    break;
                case ActionState.Idle:
                    AI_Idle();
                    break;
                case ActionState.Stomp:
                    AI_Stomp();
                    break;
                case ActionState.Stomp_Multi:
                    AI_MultiStomp();
                    break;
                case ActionState.Stomp_Super:
                    AI_StompSuper();
                    break;
            }
        }

        private void AI_Spawn()
        {
            Timer++;
            //Give some initial velocity
            if (Timer == 1)
            {
                NPC.TargetClosest();
                if (NPC.HasValidTarget)
                {
                //    NPC.Center = Target.Center + new Vector2(0, -384);
                }
                NPC.velocity.Y = 1;
            }

            //Calculate Stomp Velocity
            if (Timer < 8)
            {
                NPC.velocity.Y *= 1.5f;
            }

            if (NPC.collideY)
            {
                MyPlayer myPlayer = Main.LocalPlayer.GetModPlayer<MyPlayer>();
                myPlayer.ShakeAtPosition(NPC.Center, 1024f, 30f);

                for (int i = 0; i < 16; i++)
                {
                    float radius = 150;
                    Vector2 offset = Vector2.UnitX * Main.rand.Next(-1, 1);
                    offset *= Main.rand.NextFloat(1f, radius);
                    offset += new Vector2(radius / 2, 0);

                    Vector2 velocity = Vector2.UnitX * Main.rand.Next(-1, 1);
                    velocity *= Main.rand.NextFloat(1f, 2f);
                    Dust.NewDustPerfect(NPC.Bottom + offset, ModContent.DustType<Dusts.TSmokeDust>(), velocity, 0, Color.Black * 0.5f,
                        Main.rand.NextFloat(0.3f, 0.7f));
                }
                //Stomp happens, so the code would be here
                NPC.velocity.Y = 0;
                Timer = 0;
                SwitchState(ActionState.Idle);
            }
        }

        private void AI_Idle()
        {
            //Despawn code
            if (!NPC.HasValidTarget)
            {
                NPC.TargetClosest();
                if (!NPC.HasValidTarget)
                {
                    NPC.EncourageDespawn(60);
                }
            }

            //Idle state and then choose attack
            Timer++;
            if (Timer >= 60)
            {
                if (StellaMultiplayer.IsHost)
                {
                    //We want him to always use multi stomp the moment he goes into phase 2
                    //So we have a bool for that
                    bool doStomp = (!HasDoneStomp || (Main.rand.NextBool(3) && CanMultiStomp));
                    bool doSuperStomp = Main.rand.NextBool(2) && CanSuperStomp;
                    if (InPhase2 && doStomp)
                    {
                        CanMultiStomp = false;
                        HasDoneStomp = true;
                        SwitchState(ActionState.Stomp_Multi);
                    } else if (InPhase2 && doSuperStomp)
                    {
                        CanSuperStomp = false;
                        SwitchState(ActionState.Stomp_Super);
                    }
                    else
                    {
                        SwitchState(ActionState.Stomp);
                    }
                }
            }
        }

        private void AI_Stomp()
        {
            switch (AttackCounter)
            {
                case 0:
                    //Target a player
                    Timer++;
                    DrawOutline = true;
                    if (Timer == 1)
                    {
                        NPC.TargetClosest();
                        SoundEngine.PlaySound(SoundID.Item69, NPC.position);
                    }

                    //Hover up
                    Vector2 targetPos = Target.Center + new Vector2(0, -232);
                    Vector2 targetVelocity = (targetPos - NPC.Center).SafeNormalize(Vector2.Zero);
                    float distanceToTarget = Vector2.Distance(NPC.Center, targetPos);
                    float moveSpeed = MathF.Min(distanceToTarget, 12);
                    targetVelocity *= moveSpeed;
                    NPC.velocity = targetVelocity;
                    if (distanceToTarget <= 2 || Timer > 60)
                    {
                        Timer = 0;
                        AttackCounter++;
                        NPC.velocity.X = 0;
                        NPC.velocity.Y = 0;
                    }
                    break;

                case 1:
                    //Hover Left/Right
                    Timer++;
                    Vector2 horizontalVelocity = (Target.Center - NPC.Center);
                    float xMove = horizontalVelocity.X;

                    if (Timer > 60 * StompSpeed)
                    {
                        NPC.velocity.X *= 0.95f;
                    }
                    else
                    {
                        NPC.velocity.X = xMove;
                    }

                    if (Timer >= 100 * StompSpeed)
                    {
                        NPC.velocity.X = 0;
                        Timer = 0;
                        AttackCounter++;
                    }
                    break;

                case 2:
                    Timer++;
                    DrawOutline = false;

                    //Give some initial velocity
                    if (Timer == 1)
                    {

                        NPC.velocity.Y = 1;
                    }

                    //Calculate Stomp Velocity
                    if (Timer < 8)
                    {
                        NPC.velocity.Y *= 1.5f;
                    }

                    if (NPC.collideY || Timer > 60)
                    {
                        MyPlayer myPlayer = Main.LocalPlayer.GetModPlayer<MyPlayer>();
                        myPlayer.ShakeAtPosition(NPC.Center, 1024f, 30f);
                        ShakeModSystem.Shake = 2;
                        SoundStyle boom = SoundID.DD2_ExplosiveTrapExplode;
                        boom.PitchVariance = 0.3f;
                        SoundEngine.PlaySound(boom, NPC.position);
                        for (int i = 0; i < 16; i++)
                        {
                            float radius = 150;
                            Vector2 offset = Vector2.UnitX * Main.rand.Next(-1, 1);
                            offset *= Main.rand.NextFloat(1f, radius);
                            offset += new Vector2(radius / 2, 0);

                            Vector2 velocity = Vector2.UnitX * Main.rand.Next(-1, 1);
                            velocity *= Main.rand.NextFloat(1f, 2f);
                            Dust.NewDustPerfect(NPC.Bottom + offset, ModContent.DustType<Dusts.TSmokeDust>(), velocity, 0, Color.Black * 0.5f,
                                Main.rand.NextFloat(0.3f, 0.7f));
                        }

                        FXUtil.GlowCircleBoom(NPC.Bottom,
                           innerColor: Color.White,
                           glowColor: Color.Black,
                           outerGlowColor: Color.Black, duration: 25, baseSize: 0.24f);
                        for (float i = 0; i < 4; i++)
                        {
                            float progress = i / 4f;
                            float rot = progress * MathHelper.ToRadians(240);
                            Vector2 offset = rot.ToRotationVector2() * 24;
                            var particle = FXUtil.GlowCircleDetailedBoom1(NPC.Bottom,
                                innerColor: Color.White,
                                glowColor: Color.Black,
                                outerGlowColor: Color.Black,
                                baseSize: 0.24f);
                            particle.Rotation = rot + MathHelper.ToRadians(45);
                        }

                        for (int i = 0; i < 7; i++)
                        {
                            Vector2 velocity = -Vector2.UnitY.RotatedByRandom(MathHelper.ToRadians(30)) * Main.rand.NextFloat(15f, 35f);
                            var particle = FXUtil.GlowStretch(NPC.Bottom, velocity);
                            particle.InnerColor = Color.White;
                            particle.GlowColor = Color.LightCyan;
                            particle.OuterGlowColor = Color.Black;
                            particle.Duration = Main.rand.NextFloat(25, 50);
                            particle.BaseSize = Main.rand.NextFloat(0.045f, 0.09f);
                            particle.VectorScale *= 0.5f;
                        }

                        SoundEngine.PlaySound(new SoundStyle("Urdveil/Assets/Sounds/Vinger"), NPC.position);
                        //Stomp happens, so the code would be here
                        NPC.velocity.Y = 0;
                        Timer = 0;
                        AttackCounter++;
                    }
                    break;
                case 3:
                    NPC.velocity.X = 0;
                    NPC.velocity.Y = 0;
                    CanMultiStomp = true;
                    Timer++;
                    if (Timer >= 24 * StompSpeed)
                    {
                        //Stomp
                        SwitchState(ActionState.Idle);
                    }
                    break;
            }
        }

        private void AI_MultiStomp()
        {
            switch (AttackCounter)
            {
                case 0:
                    //Target a player
                    Timer++;
                    DrawOutline = true;
                    if (Timer == 1)
                    {
                        NPC.TargetClosest();
                        StompPos = NPC.Center + new Vector2(0, -252 - StompCounter * 16);
                        SoundEngine.PlaySound(SoundID.Item69, NPC.position);
                    }

                    //Hover up
                    Vector2 targetVelocity = (StompPos - NPC.Center).SafeNormalize(Vector2.Zero);
                    float distanceToTarget = Vector2.Distance(NPC.Center, StompPos);
                    float moveSpeed = MathF.Min(distanceToTarget, 12);
                    targetVelocity *= moveSpeed;
                    NPC.velocity = targetVelocity;
                    if (distanceToTarget <= 2 || Timer > 60)
                    {
                        Timer = 0;
                        AttackCounter++;
                        NPC.velocity.X = 0;
                        NPC.velocity.Y = 0;
                    }
                    break;
                case 1:
                    Timer++;
                    DrawOutline = false;
                    //Give some initial velocity
                    if (Timer == 1)
                    {
                        NPC.velocity.Y = 1;
                    }

                    //Calculate Stomp Velocity
                    if (Timer < 8)
                    {
                        NPC.velocity.Y *= 1.5f;
                    }

                    if (NPC.collideY)
                    {
                        MyPlayer myPlayer = Main.LocalPlayer.GetModPlayer<MyPlayer>();
                        myPlayer.ShakeAtPosition(NPC.Center, 1024f, 30f);
                        ShakeModSystem.Shake = 2;
                        SoundStyle boom = SoundID.DD2_ExplosiveTrapExplode;
                        boom.PitchVariance = 0.3f;
                        SoundEngine.PlaySound(boom, NPC.position);
                        for (int i = 0; i < 16; i++)
                        {
                            float radius = 150;
                            Vector2 offset = Vector2.UnitX * Main.rand.Next(-1, 1);
                            offset *= Main.rand.NextFloat(1f, radius);
                            offset += new Vector2(radius / 2, 0);

                            Vector2 velocity = Vector2.UnitX * Main.rand.Next(-1, 1);
                            velocity *= Main.rand.NextFloat(1f, 2f);
                            Dust.NewDustPerfect(NPC.Bottom + offset, ModContent.DustType<Dusts.TSmokeDust>(), velocity, 0, Color.Black * 0.5f,
                                Main.rand.NextFloat(0.3f, 0.7f));
                        }
                        if (StellaMultiplayer.IsHost)
                        {
                            //This is the part where you spawn the cool ahh shockwaves
                            //But we have to make cool ahh shockwaves :(
                            int shockwaveDamage = 10;
                            int knockback = 1;
                            Vector2 velocity = Vector2.UnitX;
                            velocity *= 4;
                            Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Bottom, velocity,
                                ModContent.ProjectileType<WindShockwave>(), shockwaveDamage, knockback, Main.myPlayer);
                            velocity = -velocity;
                            Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Bottom, velocity,
                                ModContent.ProjectileType<WindShockwave>(), shockwaveDamage, knockback, Main.myPlayer);
                        }

                        FXUtil.GlowCircleBoom(NPC.Bottom,
                           innerColor: Color.White,
                           glowColor: Color.Black,
                           outerGlowColor: Color.Black, duration: 25, baseSize: 0.18f);
                        for (float i = 0; i < 4; i++)
                        {
                            float progress = i / 4f;
                            float rot = progress * MathHelper.ToRadians(240);
                            Vector2 offset = rot.ToRotationVector2() * 24;
                            var particle = FXUtil.GlowCircleDetailedBoom1(NPC.Bottom,
                                innerColor: Color.White,
                                glowColor: Color.Black,
                                outerGlowColor: Color.Black,
                                baseSize: 0.24f);
                            particle.Rotation = rot + MathHelper.ToRadians(45);
                        }

                        for (int i = 0; i < 4; i++)
                        {
                            Vector2 velocity = -Vector2.UnitY.RotatedByRandom(MathHelper.ToRadians(30)) * Main.rand.NextFloat(15f, 50f);
                            var particle = FXUtil.GlowStretch(NPC.Bottom, velocity);
                            particle.InnerColor = Color.White;
                            particle.GlowColor = Color.LightCyan;
                            particle.OuterGlowColor = Color.Black;
                            particle.Duration = Main.rand.NextFloat(25, 50);
                            particle.BaseSize = Main.rand.NextFloat(0.045f, 0.09f);
                            particle.VectorScale *= 0.5f;
                        }

                        //Stomp happens, so the code would be here
                        NPC.velocity.Y = 0;
                        Timer = 0;
                        AttackCounter++;
                    }
                    break;
                case 2:
                    CanSuperStomp = true;
                    StompCounter++;
                    if (StompCounter >= 3)
                    {
                        SwitchState(ActionState.Idle);
                    }
                    else
                    {
                        Timer = 0;
                        AttackCounter = 0;
                    }
                    break;
            }
        }

        private void AI_StompSuper()
        {
            switch (AttackCounter)
            {
                case 0:
                    //Target a player
                    Timer++;
                    DrawOutline = true;
                    if (Timer == 1)
                    {
                        NPC.TargetClosest();
                        SoundEngine.PlaySound(SoundID.Item69, NPC.position);
                    }

                    //Hover up
                    Vector2 targetPos = Target.Center + new Vector2(0, -384);
                    Vector2 targetVelocity = (targetPos - NPC.Center).SafeNormalize(Vector2.Zero);
                    float distanceToTarget = Vector2.Distance(NPC.Center, targetPos);
                    float moveSpeed = MathF.Min(distanceToTarget, 12);
                    targetVelocity *= moveSpeed;
                    NPC.velocity = targetVelocity;
                    if (distanceToTarget <= 2 || Timer > 60)
                    {
                        Timer = 0;
                        AttackCounter++;
                        NPC.velocity.X = 0;
                        NPC.velocity.Y = 0;
                    }
                    break;

                case 1:
                    //Hover Left/Right
                    Timer++;
                    Vector2 horizontalVelocity = (Target.Center - NPC.Center);
                    float xMove = horizontalVelocity.X;

                    if (Timer > 60 * StompSpeed)
                    {
                        NPC.velocity.X *= 0.95f;
                    }
                    else
                    {
                        NPC.velocity.X = xMove;
                    }

                    if (Timer >= 150 * StompSpeed)
                    {
                        NPC.velocity.X = 0;
                        Timer = 0;
                        AttackCounter++;
                    }
                    break;

                case 2:
                    Timer++;
                    DrawOutline = false;

                    //Give some initial velocity
                    if (Timer == 1)
                    {

                        NPC.velocity.Y = 1;
                    }

                    //Calculate Stomp Velocity
                    if (Timer < 8)
                    {
                        NPC.velocity.Y *= 1.5f;
                    }

                    if (NPC.collideY || Timer > 60)
                    {
                        for (int i = 0; i < 16; i++)
                        {
                            float radius = 150;
                            Vector2 offset = Vector2.UnitX * Main.rand.Next(-1, 1);
                            offset *= Main.rand.NextFloat(1f, radius);
                            offset += new Vector2(radius / 2, 0);

                            Vector2 velocity = Vector2.UnitX * Main.rand.Next(-1, 1);
                            velocity *= Main.rand.NextFloat(1f, 2f);
                            Dust.NewDustPerfect(NPC.Bottom + offset, ModContent.DustType<Dusts.TSmokeDust>(), velocity, 0, Color.Black * 0.5f,
                                Main.rand.NextFloat(0.3f, 0.7f));
                        }

                        for (int i = 0; i < 16; i++)
                        {
                            float radius = 150;
                            Vector2 offset = Vector2.UnitX * Main.rand.Next(-1, 1);
                            offset *= Main.rand.NextFloat(1f, radius);
                            offset += new Vector2(radius / 2, 0);

                            Vector2 velocity = Vector2.UnitX * Main.rand.Next(-1, 1);
                            velocity *= Main.rand.NextFloat(1f, 2f);
                            Dust.NewDustPerfect(NPC.Bottom + offset, ModContent.DustType<Dusts.TSmokeDust>(), velocity, 0, Color.Black * 0.5f,
                                Main.rand.NextFloat(0.3f, 0.7f));
                        }

                        FXUtil.GlowCircleBoom(NPC.Bottom,
                           innerColor: Color.White,
                           glowColor: Color.Black,
                           outerGlowColor: Color.Black, duration: 25, baseSize: 0.34f);
                        for (float i = 0; i < 4; i++)
                        {
                            float progress = i / 4f;
                            float rot = progress * MathHelper.ToRadians(240);
                            Vector2 offset = rot.ToRotationVector2() * 24;
                            var particle = FXUtil.GlowCircleDetailedBoom1(NPC.Bottom,
                                innerColor: Color.White,
                                glowColor: Color.Black,
                                outerGlowColor: Color.Black,
                                baseSize: 0.34f);
                            particle.Rotation = rot + MathHelper.ToRadians(45);
                        }

                        for (int i = 0; i < 15; i++)
                        {
                            Vector2 velocity = -Vector2.UnitY.RotatedByRandom(MathHelper.ToRadians(30)) * Main.rand.NextFloat(15f, 50f);
                            var particle = FXUtil.GlowStretch(NPC.Bottom, velocity);
                            particle.InnerColor = Color.White;
                            particle.GlowColor = Color.LightCyan;
                            particle.OuterGlowColor = Color.Black;
                            particle.Duration = Main.rand.NextFloat(25, 50);
                            particle.BaseSize = Main.rand.NextFloat(0.045f, 0.09f);
                            particle.VectorScale *= 0.5f;
                        }


                        ShakeModSystem.Shake = 16;
                        FXUtil.ShakeCamera(NPC.position, 1024, 129);
                        SoundStyle boom = new SoundStyle("Urdveil/Assets/Sounds/RocketExplosion");
                        boom.PitchVariance = 0.3f;
                        SoundEngine.PlaySound(boom, NPC.position);
                        if (StellaMultiplayer.IsHost)
                        {
                            //This is the part where you spawn the cool ahh shockwaves
                            //But we have to make cool ahh shockwaves :(
                            int shockwaveDamage = 20;
                            int knockback = 1;
                            Vector2 velocity = Vector2.UnitX;
                            velocity *= 4;
                            Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Bottom, velocity,
                                ModContent.ProjectileType<SuperShockwave>(), shockwaveDamage, knockback, Main.myPlayer);
                            velocity = -velocity;
                            Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Bottom, velocity,
                                ModContent.ProjectileType<SuperShockwave>(), shockwaveDamage, knockback, Main.myPlayer);
                        }

                        //Stomp happens, so the code would be here
                        NPC.velocity.Y = 0;
                        Timer = 0;
                        AttackCounter++;
                    }
                    break;
                case 3:
                    NPC.velocity.X = 0;
                    NPC.velocity.Y = 0;
                    CanMultiStomp = true;
                    Timer++;
                    if (Timer >= 24 * StompSpeed)
                    {
                        //Stomp
                        SwitchState(ActionState.Idle);
                    }
                    break;
            }
        }
        private void SwitchState(ActionState state)
        {
            State = state;
            Timer = 0;
            AttackCounter = 0;
            StompCounter = 0;
            NPC.netUpdate = true;
        }

        public override void OnKill()
        {
            NPC.SetEventFlagCleared(ref DownedBossSystem.downedStoneGolemBoss, -1);
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StoneKey>(), 1, 1, 1));
            npcLoot.Add(ItemDropRule.MasterModeCommonDrop(ModContent.ItemType<VeriBossRel>()));
        }
    }
}
