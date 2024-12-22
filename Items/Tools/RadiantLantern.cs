using Urdveil.Buffs;
using Urdveil.Common.Bases;
using Urdveil.Projectiles.Lanterns;
using Terraria.ModLoader;

namespace Urdveil.Items.Tools
{
    internal class RadiantLantern : BaseLanternItem
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.buffType = ModContent.BuffType<RadiatingLantern>();
            Item.shoot = ModContent.ProjectileType<RadiantLanternProjectile>();
        }
    }
}
