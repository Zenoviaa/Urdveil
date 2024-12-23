using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Urdveil.Helpers;
using Urdveil.TilesNew;
using Urdveil.WorldG.StructureManager;

namespace Urdveil.UI.ToolsSystem
{
    internal class TilePainterPreview : ModProjectile
    {
        public override string Texture => TextureRegistry.EmptyTexture;
        private Player Owner => Main.player[Projectile.owner];
        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.penetrate = -1;
            Projectile.timeLeft = int.MaxValue;
            Projectile.tileCollide = false;
        }
        public override void AI()
        {
            base.AI();
            if (Owner.HeldItem.type != ModContent.ItemType<TilePainterTool>())
                Projectile.Kill();


            int x = (int)Main.MouseWorld.X / 16;
            int y = (int)Main.MouseWorld.Y / 16;

            Rectangle rectangle = Structurizer.ReadSavedRectangle(Structurizer.SelectedStructure);
            Vector2 mousePos = new Vector2(x, y) * 16;
            Projectile.position = mousePos;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            SpriteBatch spriteBatch = Main.spriteBatch;
            Color drawColor = Color.White * 0.5f;
            Vector2 drawPos = Projectile.position - Main.screenPosition;
            if(TilePainterTool.SelectedTile != null)
            {
                if(TilePainterTool.SelectedTile is BaseSpecialTile specialTile)
                {
                    int i = (int)(Projectile.position.X / 16);
                    int j = (int)(Projectile.position.Y / 16);
                    specialTile.DrawPreview(i, j);
                }
            } else if (TilePainterTool.SelectedWall != null)
            {
                if (TilePainterTool.SelectedWall is BaseSpecialWall specialTile)
                {
                    int i = (int)(Projectile.position.X / 16);
                    int j = (int)(Projectile.position.Y / 16);
                    specialTile.DrawPreview(i, j);
                }
            }
            return base.PreDraw(ref lightColor);
        }
    }
    internal class TilePainterTool : ModItem
    {
        private bool _erase;
        public static ModTile SelectedTile { get; set; }
        public static ModWall SelectedWall { get; set; }
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.width = 16;
            Item.height = 16;
            Item.useAnimation = 1;
            Item.useTime = 1;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.channel = true;
            Item.autoReuse = true;
        }

        public void SelectTile(ModTile modTile)
        {
            SelectedTile = modTile;
            SelectedWall = null;
        }
        public void SelectWall(ModWall modWall)
        {
            SelectedWall = modWall;
            SelectedTile = null;
        }
        public override void UpdateInventory(Player player)
        {
            base.UpdateInventory(player);
            if (player.HeldItem.type == Type)
            {
                int x = (int)Main.MouseWorld.X / 16;
                int y = (int)Main.MouseWorld.Y / 16;
                Dust.QuickBox(new Vector2(x, y) * 16, new Vector2(x + 1, y + 1) * 16, 2, Color.Red, null);
                if (player.ownedProjectileCounts[ModContent.ProjectileType<TilePainterPreview>()] == 0)
                {
                    Projectile.NewProjectile(player.GetSource_FromThis(), player.position, Vector2.Zero, ModContent.ProjectileType<TilePainterPreview>(), 1, 1, player.whoAmI);
                }

            }
            else
            {

            }
        }


        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool? UseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                if (SelectedTile != null)
                {
                    int i = (int)Main.MouseWorld.X / 16;
                    int j = (int)Main.MouseWorld.Y / 16;
                    WorldGen.KillTile(i, j);
                }
                else if (SelectedWall != null)
                {
                    int i = (int)Main.MouseWorld.X / 16;
                    int j = (int)Main.MouseWorld.Y / 16;
                    WorldGen.KillWall(i, j);
                }
            }
            else
            {
                if (SelectedTile != null)
                {
                    int i = (int)Main.MouseWorld.X / 16;
                    int j = (int)Main.MouseWorld.Y / 16;
                    WorldGen.PlaceTile(i, j, SelectedTile.Type);
                }
                else if (SelectedWall != null)
                {
                    int i = (int)Main.MouseWorld.X / 16;
                    int j = (int)Main.MouseWorld.Y / 16;
                    WorldGen.PlaceWall(i, j, SelectedWall.Type);
                }
            }
            return true;
        }
    }
}
