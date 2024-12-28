using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using Urdveil.Common.Players;
using Urdveil.Helpers;

namespace Urdveil.TilesNew.CollectibleTiles
{
    internal abstract class MapCollectible : BaseCollectibleTile
    {
        public override string Texture => (typeof(MapCollectible).FullName).Replace(".", "/");
        public override bool CanCollect(Player player, Vector2 position)
        {
            return base.CanCollect(player, position);

        }
        public override void Collect(Player player, Vector2 position)
        {
            SoundEngine.PlaySound(new SoundStyle("Urdveil/Assets/Sounds/ItemHarvested"), player.position);
            for (float i = 0; i < 12; i++)
            {
                float rot = MathHelper.TwoPi * Main.rand.NextFloat(0f, 1f);
                Vector2 velocity = rot.ToRotationVector2() * Main.rand.NextFloat(5f, 25f);
                var particle = FXUtil.GlowStretch(position, velocity);
                particle.InnerColor = Color.White;
                particle.GlowColor = Color.LightCyan;
                particle.OuterGlowColor = Color.Black;
                particle.Duration = Main.rand.NextFloat(25, 50);
                particle.BaseSize = Main.rand.NextFloat(0.04f, 0.07f);
                particle.VectorScale *= 0.5f;
            }
            int c = CombatText.NewText(player.getRect(), Color.LightGoldenrodYellow, "Map Expanded!", dramatic: true);
            Main.combatText[c].lifeTime *= 3;
        }
    }

    internal class SpringHillsInnerMapCollectibleItem : BaseCollectibleTileItem
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.createTile = ModContent.TileType<SpringHillsInnerMapCollectible>();
        }
    }

    internal class SpringHillsInnerMapCollectible : MapCollectible
    {
        public override bool CanCollect(Player player, Vector2 position)
        {
            MapPlayer mapPlayer = player.GetModPlayer<MapPlayer>();
            return !mapPlayer.mapPieceSpringHillsInner;
        }

        public override void Collect(Player player, Vector2 position)
        {
            base.Collect(player, position);
            MapPlayer mapPlayer = player.GetModPlayer<MapPlayer>();
            mapPlayer.mapPieceSpringHillsInner = true;
        }
    }
    internal class WitchTownMapCollectibleItem : BaseCollectibleTileItem
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.createTile = ModContent.TileType<WitchTownMapCollectible>();
        }
    }

    internal class WitchTownMapCollectible : MapCollectible
    {
        public override bool CanCollect(Player player, Vector2 position)
        {
            MapPlayer mapPlayer = player.GetModPlayer<MapPlayer>();
            return !mapPlayer.mapPieceWitchTown;
        }

        public override void Collect(Player player, Vector2 position)
        {
            base.Collect(player, position);
            MapPlayer mapPlayer = player.GetModPlayer<MapPlayer>();
            mapPlayer.mapPieceWitchTown = true;
        }
    }

    internal class WarriorsDoorCollectibleItem : BaseCollectibleTileItem
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.createTile = ModContent.TileType<WarriorsDoorCollectible>();
        }
    }

    internal class WarriorsDoorCollectible : MapCollectible
    {
        public override bool CanCollect(Player player, Vector2 position)
        {
            MapPlayer mapPlayer = player.GetModPlayer<MapPlayer>();
            return !mapPlayer.mapPieceWarriorsDoor;
        }
        public override void Collect(Player player, Vector2 position)
        {
            base.Collect(player, position);
            MapPlayer mapPlayer = player.GetModPlayer<MapPlayer>();
            mapPlayer.mapPieceWarriorsDoor = true;
        }
    }

}
