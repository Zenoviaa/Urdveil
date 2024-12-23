﻿using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Urdveil.Items.Materials;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace Urdveil.TilesNew.SpringHills
{
    class SpringTree : ModTree
    {
        public override TreePaintingSettings TreeShaderSettings => new TreePaintingSettings
        {
            UseSpecialGroups = true,
            SpecialGroupMinimalHueValue = 11f / 72f,
            SpecialGroupMaximumHueValue = 0.25f,
            SpecialGroupMinimumSaturationValue = 0.88f,
            SpecialGroupMaximumSaturationValue = 1f
        };

        public override void SetStaticDefaults() => GrowsOnTileId = new int[] { ModContent.TileType<SpringGrass>() };
        public override int CreateDust() => 22;
        public override int DropWood() => ModContent.ItemType<Ivythorn>();
        public override Asset<Texture2D> GetTexture() => ModContent.Request<Texture2D>("Urdveil/TilesNew/SpringHills/SpringTree");
        public override Asset<Texture2D> GetTopTextures() => ModContent.Request<Texture2D>("Urdveil/TilesNew/SpringHills/SpringTree_Top");
        public override Asset<Texture2D> GetBranchTextures() => ModContent.Request<Texture2D>("Urdveil/TilesNew/SpringHills/SpringTree_Branches");

        public override int SaplingGrowthType(ref int style)
        {
            style = 0;
            return ModContent.TileType<SpringTreeSapling>();
        }

        public override void SetTreeFoliageSettings(Tile tile, ref int xoffset, ref int treeFrame, ref int floorY, ref int topTextureFrameWidth, ref int topTextureFrameHeight)
        {
            topTextureFrameWidth = 142;
            topTextureFrameHeight = 114;
            xoffset = 62;
            floorY = 2;
        }
    }
}