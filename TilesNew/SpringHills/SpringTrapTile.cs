using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Urdveil.TilesNew.SpringHills
{
    public class SpringArrow : ModProjectile
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.width = 2;
            Projectile.height = 2;
            Projectile.friendly = false;
            Projectile.hostile = true;

        }
        public override void AI()
        {
            base.AI();
            Projectile.rotation = Projectile.velocity.ToRotation();
        }
    }

    // This item shows off using 1 class to load multiple items. This is an alternate to typical inheritance.
    // Read the comments in this example carefully, as there are many parts necessary to make this approach work.
    // The real strength of this approach is when you have many items that vary by small changes, like how these 2 trap items vary only by placeStyle.
    public class SpringTrap : ModItem
    {

        public override void SetDefaults()
        {
            // With all the setup above, placeStyle will be either 0 or 1 for the 2 ExampleTrap instances we've loaded.
            Item.DefaultToPlaceableTile(ModContent.TileType<SpringTrapTile>());

            Item.width = 12;
            Item.height = 12;
            Item.value = 10000;
            Item.mech = true; // lets you see wires while holding.
        }
    }
    public class SpringTrapTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            TileID.Sets.DrawsWalls[Type] = true;
            TileID.Sets.DontDrawTileSliced[Type] = true;
            TileID.Sets.IgnoresNearbyHalfbricksWhenDrawn[Type] = true;
            TileID.Sets.IsAMechanism[Type] = true;

            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
            TileObjectData.newTile.Height = 4;
            TileObjectData.newTile.Width = 4;

            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16, 16 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.addTile(Type);

            // These 2 AddMapEntry and GetMapOption show off multiple Map Entries per Tile. Delete GetMapOption and all but 1 of these for your own ModTile if you don't actually need it.
            AddMapEntry(new Color(21, 179, 192), Language.GetText("MapObject.Trap")); // localized text for "Trap"
        }

        public override bool IsTileDangerous(int i, int j, Player player) => true;


        // PlaceInWorld is needed to facilitate styles and alternates since this tile doesn't use a TileObjectData. Placing left and right based on player direction is usually done in the TileObjectData, but the specifics of that don't work for how we want this tile to work. 
        public override void PlaceInWorld(int i, int j, Item item)
        {
            int style = Main.LocalPlayer.HeldItem.placeStyle;
            Tile tile = Main.tile[i, j];
            if (Main.LocalPlayer.direction == 1)
            {
                tile.TileFrameX += 36;
            }
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                NetMessage.SendTileSquare(-1, Player.tileTargetX, Player.tileTargetY, 1, TileChangeType.None);
            }
        }

        // This progression matches vanilla tiles, you don't have to follow it if you don't want. Some vanilla traps don't have 6 states, only 4. This can be implemented with different logic in Slope. Making 8 directions is also easily done in a similar manner.
        private static int[] frameXCycle = { 1, 0 };
        // We can use the Slope method to override what happens when this tile is hammered.
        public override bool Slope(int i, int j)
        {
            Tile tile = Main.tile[i, j];
            int nextFrameX = frameXCycle[tile.TileFrameX / 36];
            tile.TileFrameX = (short)(nextFrameX * 36);
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                NetMessage.SendTileSquare(-1, Player.tileTargetX, Player.tileTargetY, 1, TileChangeType.None);
            }
            return false;
        }

        public override void HitWire(int i, int j)
        {
            Tile tile = Main.tile[i, j];
            int style = tile.TileFrameY / 18;
            Vector2 spawnPosition;
            // This logic here corresponds to the orientation of the sprites in the spritesheet, change it if your tile is different in design.
            int horizontalDirection = (tile.TileFrameX == 0) ? -1 : ((tile.TileFrameX == 18) ? 1 : 0);
            int verticalDirection = (tile.TileFrameX < 36) ? 0 : ((tile.TileFrameX < 72) ? -1 : 1);
            // Each trap style within this Tile shoots different projectiles.
            // Wiring.CheckMech checks if the wiring cooldown has been reached. Put a longer number here for less frequent projectile spawns. 200 is the dart/flame cooldown. Spear is 90, spiky ball is 300
            if (Wiring.CheckMech(i, j, 60))
            {
                spawnPosition = new Vector2(i * 16 + 8 + 0 * horizontalDirection, j * 16 + 9 + 0 * verticalDirection); // The extra numbers here help center the projectile spawn position if you need to.

                // In a real mod you should be spawning projectiles that are both hostile and friendly to do damage to both players and NPC, as Terraria traps do.
                // Make sure to change velocity, projectile, damage, and knockback.
                Projectile.NewProjectile(Wiring.GetProjectileSource(i, j), spawnPosition, new Vector2(horizontalDirection, verticalDirection) * 6f,
                    ModContent.ProjectileType<SpringArrow>(), 20, 2f, Main.myPlayer);
            }
        }
    }
}
