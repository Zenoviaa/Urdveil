
using Microsoft.Xna.Framework;
using Urdveil.Items.Harvesting;
using Terraria.ModLoader;

namespace Urdveil.Tiles.Structures.AlcadizNGovheil
{
    //TODO: Smart Cursor Outlines and tModLoader support
    public class GothivDoorClosed : LockedDoor
    {
        public override int KeyType => ModContent.ItemType<Cinderscrap>();
        public override string FailString => "Hun, you cant open this door yet :(";
        public override Color FailColor => Color.Gold;
    }
}
