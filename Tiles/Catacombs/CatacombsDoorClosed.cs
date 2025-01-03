﻿
using Microsoft.Xna.Framework;
using Urdveil.Items.Harvesting;
using Terraria.ModLoader;

namespace Urdveil.Tiles.Catacombs
{
    //TODO: Smart Cursor Outlines and tModLoader support
    public class CatacombsDoorClosed : LockedDoor
    {
        public override int KeyType => ModContent.ItemType<Cinderscrap>();
        public override Color FailColor => Color.Gold;
        public override string FailString => "Kill wall of flesh! Key needed!";
    }
}
