using Terraria;

namespace Urdveil.Items.MoonlightMagic.Movements
{
    internal class LobberMovement : BaseMovement
    {
        public override void AI()
        {

            Projectile.velocity.Y += 0.2f;
        }
    }
}
