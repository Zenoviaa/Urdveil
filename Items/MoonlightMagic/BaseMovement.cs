using Terraria;

namespace Urdveil.Items.MoonlightMagic
{
    internal abstract class BaseMovement : IAdvancedMagicAddon
    {
        public AdvancedMagicProjectile MagicProj { get; set; }
        public Projectile Projectile => MagicProj.Projectile;
        public abstract void AI();
    }
}
