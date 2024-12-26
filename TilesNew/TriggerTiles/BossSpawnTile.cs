﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.ObjectData;

namespace Urdveil.TilesNew.TriggerTiles
{
    internal class BossSpawnTileItem : ModItem
    {
        public override void SetDefaults()
        {
            // With all the setup above, placeStyle will be either 0 or 1 for the 2 ExampleTrap instances we've loaded.
            Item.DefaultToPlaceableTile(ModContent.TileType<BossSpawnTile>());

            Item.width = 12;
            Item.height = 12;
            Item.value = 10000;
            Item.mech = true; // lets you see wires while holding.
        }
    }

    internal class BossSpawnTileEntity : ModTileEntity
    {
        public string BossToSpawn;
        public Point SpawnOffset;
        public int Width = 4;
        public int Height = 4;
        public override void Update()
        {
            base.Update();
           
            if (StellaMultiplayer.IsHost)
            {
                if (NPC.AnyDanger())
                    return;
                if (string.IsNullOrEmpty(BossToSpawn))
                    return;
                ModNPC modNpc = ModContent.Find<ModNPC>(BossToSpawn);
                if (NPC.AnyNPCs(modNpc.Type))
                    return;

                Vector2 worldPos = Position.ToWorldCoordinates();
                foreach (var player in Main.ActivePlayers)
                {

                    Rectangle rectangle = new Rectangle((int)worldPos.X, (int)worldPos.Y, Width * 16, Height * 16);
                    if (rectangle.Contains((int)player.position.X, (int)player.position.Y))
                    {
                        Point spawnPoint = new Point(Position.X, Position.Y);
                        spawnPoint.X += SpawnOffset.X;
                        spawnPoint.Y += SpawnOffset.Y;
                        NPC.NewNPC(new EntitySource_TileBreak(Position.X, Position.Y), spawnPoint.X * 16, spawnPoint.Y * 16, modNpc.Type);
                    }
                }
            }
        }

        public override void OnNetPlace()
        {
            if (Main.netMode == NetmodeID.Server)
            {
                NetMessage.SendData(MessageID.TileEntitySharing, number: ID, number2: Position.X, number3: Position.Y);
            }
        }



        public override int Hook_AfterPlacement(int i, int j, int type, int style, int direction, int alternate)
        {
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                // Sync the entire multitile's area.  Modify "width" and "height" to the size of your multitile in tiles
                int width = 4;
                int height = 4;
                NetMessage.SendTileSquare(Main.myPlayer, i, j, width, height);

                // Sync the placement of the tile entity with other clients
                // The "type" parameter refers to the tile type which placed the tile entity, so "Type" (the type of the tile entity) needs to be used here instead
                NetMessage.SendData(MessageID.TileEntityPlacement, number: i, number2: j, number3: Type);
                return -1;
            }

            // ModTileEntity.Place() handles checking if the entity can be placed, then places it for you
            int placedEntity = Place(i, j);

            return placedEntity;
        }


        public override bool IsTileValidForEntity(int x, int y)
        {
            Tile tile = Main.tile[x, y];
            //The MyTile class is shown later
            return tile.HasTile && tile.TileType == ModContent.TileType<BossSpawnTile>();
        }

        public override void NetSend(BinaryWriter writer)
        {
            base.NetSend(writer);
            writer.Write(BossToSpawn);
            writer.Write(SpawnOffset.X);
            writer.Write(SpawnOffset.Y);
            writer.Write(Width);
            writer.Write(Height);
        }

        public override void NetReceive(BinaryReader reader)
        {
            base.NetReceive(reader);
            BossToSpawn = reader.ReadString();
            SpawnOffset.X = reader.ReadInt32();
            SpawnOffset.Y = reader.ReadInt32();
            Width = reader.ReadInt32();
            Height = reader.ReadInt32();
        }

        public override void SaveData(TagCompound tag)
        {
            base.SaveData(tag);
            tag["boss"] = BossToSpawn;
            tag["spawnOffset"] = SpawnOffset;
            tag["width"] = Width;
            tag["height"] = Height;
        }

        public override void LoadData(TagCompound tag)
        {
            base.LoadData(tag);
            BossToSpawn = tag.Get<string>("boss");
            SpawnOffset = tag.Get<Point>("spawnOffset");
            Width = tag.Get<int>("width");
            Height = tag.Get<int>("height");
        }
    }

    internal class BossSpawnTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            TileID.Sets.DrawsWalls[Type] = true;
            TileID.Sets.DontDrawTileSliced[Type] = true;
            TileID.Sets.IgnoresNearbyHalfbricksWhenDrawn[Type] = true;

            Main.tileSolid[Type] = false;
            Main.tileBlockLight[Type] = true;
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
            TileObjectData.newTile.Height = 4;
            TileObjectData.newTile.Width = 4;

            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16, 16 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            // MyTileEntity refers to the tile entity mentioned in the previous section
            TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(ModContent.GetInstance<BossSpawnTileEntity>().Hook_AfterPlacement, -1, 0, true);

            // This is required so the hook is actually called.
            TileObjectData.newTile.UsesCustomCanPlace = true;
            TileObjectData.addTile(Type);

            // These 2 AddMapEntry and GetMapOption show off multiple Map Entries per Tile. Delete GetMapOption and all but 1 of these for your own ModTile if you don't actually need it.
            AddMapEntry(new Color(1, 1, 1));
        }

        public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
        {
            return true;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            base.KillMultiTile(i, j, frameX, frameY);
            // ModTileEntity.Kill() handles checking if the tile entity exists and destroying it if it does exist in the world for you
            // The tile coordinate parameters already refer to the top-left corner of the multitile
            ModContent.GetInstance<BossSpawnTileEntity>().Kill(i, j);
        }

        public override bool IsTileDangerous(int i, int j, Player player) => true;


        // PlaceInWorld is needed to facilitate styles and alternates since this tile doesn't use a TileObjectData. Placing left and right based on player direction is usually done in the TileObjectData, but the specifics of that don't work for how we want this tile to work. 
        public override void PlaceInWorld(int i, int j, Item item)
        {
            int style = Main.LocalPlayer.HeldItem.placeStyle;
            Tile tile = Main.tile[i, j];
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                NetMessage.SendTileSquare(-1, Player.tileTargetX, Player.tileTargetY, 1, TileChangeType.None);
            }
        }
    }
}
