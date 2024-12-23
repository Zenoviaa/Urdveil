using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Urdveil.UI.ToolsSystem
{
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
