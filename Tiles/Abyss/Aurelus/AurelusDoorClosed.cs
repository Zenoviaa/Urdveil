
using Microsoft.Xna.Framework;
using Urdveil.Items.Harvesting;
using Terraria.ModLoader;

namespace Urdveil.Tiles.Abyss.Aurelus
{
    //TODO: Smart Cursor Outlines and tModLoader support
    public class AurelusDoorClosed : LockedDoor
    {
        public override int KeyType => ModContent.ItemType<Cinderscrap>();
        public override string FailString => "You're not ready yet! Key needed!";
        public override Color FailColor => Color.LightSkyBlue;
    }
}
