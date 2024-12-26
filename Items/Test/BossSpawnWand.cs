using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Urdveil.TilesNew.TriggerTiles;

namespace Urdveil.Items.Test
{
    internal class BossSpawnWand : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 62;
            Item.height = 32;
            Item.scale = 0.9f;
            Item.rare = ItemRarityID.Green;
            Item.useTime = 2;
            Item.useAnimation = 2;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = false;
            Item.UseSound = new SoundStyle("Urdveil/Assets/Sounds/Balls");
        }

        private ModTileEntity GetModTileEntityAtTile(int i, int j)
        {
            foreach(var tileEntity in TileEntity.manager.EnumerateEntities())
            {
                if(tileEntity.Value.Position.X == i && tileEntity.Value.Position.Y == j)
                {
                    return (ModTileEntity)tileEntity.Value;
                }
            }
            return null;
        }

        public override bool? UseItem(Player player)
        {
            Main.tileSolid[ModContent.TileType<BossSpawnTile>()] = false;
            int x = (int)Main.MouseWorld.X / 16;
            int y = (int)Main.MouseWorld.Y / 16;
            TileEntity tileEntity = TileEntity.ByPosition[new Point16(x, y)];
            if(tileEntity is BossSpawnTileEntity bossSpawnTileEntity)
            {
                bossSpawnTileEntity.BossToSpawn = "Urdveil/StarrVeriplant";
                bossSpawnTileEntity.SpawnOffset = new Point(-36, -24);
                SoundEngine.PlaySound(SoundID.AchievementComplete);
            }
            return true;
        }
    }
}
