﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Urdveil.Dusts;
using Urdveil.Tiles;

namespace Urdveil.TilesNew.SpringHills
{
    public class HangingBulbSmallItem : DecorativeWallItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Super silk!");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;

        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.createWall = ModContent.WallType<HangingBulbSmall>();
        }
    }

    internal abstract class BaseHangingBulbWall : DecorativeWall
    {
        public override void Update(int i, int j)
        {
            base.Update(i, j);
         
        }
    }

    internal class HangingBulbSmall : BaseHangingBulbWall
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            Origin = DrawOrigin.TopDown;
            //idk
            WindSwayOffset = 0f;

            //The max it can sway
            WindSwayMagnitude = 0.2f;

            //How fast it sways
            WindSwaySpeed = 0.02f;
        }
        public override void Update(int i, int j)
        {
            base.Update(i, j);
            Vector2 worldPos = new Point(i, j).ToWorldCoordinates();
            worldPos += new Vector2(-12, 12).RotatedBy(Rotation);
            if (Main.rand.NextBool(32))
            {
                Vector2 randPos = worldPos + new Vector2(Main.rand.NextFloat(0, 16), Main.rand.NextFloat(0, 16));
                Dust.NewDustPerfect(randPos, ModContent.DustType<GlowDust>(),
                    Velocity: Vector2.Zero,
                    newColor: Color.LightGoldenrodYellow,
                    Scale: Main.rand.NextFloat(0.1f, 0.15f)*2);
            }
            Lighting.AddLight(worldPos, Color.LightGoldenrodYellow.ToVector3() * 0.5f);
        }

    }

    public class HangingBulbLongItem : DecorativeWallItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Super silk!");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;

        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.createWall = ModContent.WallType<HangingBulbLong>();
        }
    }
    internal class HangingBulbLong : BaseHangingBulbWall
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            Origin = DrawOrigin.TopDown;
            //idk
            WindSwayOffset = 0f;

            //The max it can sway
            WindSwayMagnitude = 0.2f;

            //How fast it sways
            WindSwaySpeed = 0.02f;
        }
        public override void Update(int i, int j)
        {
            base.Update(i, j);
            Vector2 worldPos = new Point(i, j).ToWorldCoordinates();
            worldPos += new Vector2(-8, 68).RotatedBy(Rotation);
            if (Main.rand.NextBool(32))
            {
                Vector2 randPos = worldPos + new Vector2(Main.rand.NextFloat(0, 16), Main.rand.NextFloat(0, 16));
                Dust.NewDustPerfect(randPos, ModContent.DustType<GlowDust>(),
                    Velocity: Vector2.Zero,
                    newColor: Color.LightGoldenrodYellow,
                    Scale: Main.rand.NextFloat(0.1f, 0.15f)*2);
            }
            Lighting.AddLight(worldPos, Color.LightGoldenrodYellow.ToVector3() * 0.5f);
        }

    }

    public class HangingBulbLargeItem : DecorativeWallItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Super silk!");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.createWall = ModContent.WallType<HangingBulbLarge>();
        }
    }

    internal class HangingBulbLarge : BaseHangingBulbWall
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            Origin = DrawOrigin.TopDown;
            //idk
            WindSwayOffset = 0f;

            //The max it can sway
            WindSwayMagnitude = 0.2f;

            //How fast it sways
            WindSwaySpeed = 0.02f;
        }
        public override void Update(int i, int j)
        {
            base.Update(i, j);
            Vector2 worldPos = new Point(i, j).ToWorldCoordinates();
            worldPos += new Vector2(-16, 38).RotatedBy(Rotation);
            if (Main.rand.NextBool(32))
            {
                Vector2 randPos = worldPos + new Vector2(Main.rand.NextFloat(0, 16), Main.rand.NextFloat(0, 16));
                Dust.NewDustPerfect(randPos, ModContent.DustType<GlowDust>(),
                    Velocity: Vector2.Zero,
                    newColor: Color.LightGoldenrodYellow,
                    Scale: Main.rand.NextFloat(0.1f, 0.15f) * 2);
            }
            Lighting.AddLight(worldPos, Color.LightGoldenrodYellow.ToVector3() * 0.5f);
        }

    }





}
