using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Urdveil.Common.Players;
using Urdveil.Dusts;
using Urdveil.Helpers;
using Urdveil.Tiles;

namespace Urdveil.TilesNew.TriggerTiles
{

    internal abstract class BaseMapMarker : DecorativeWall
    {
        public override string Texture => (typeof(BaseMapMarker).FullName + "_S").Replace(".", "/");
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            FrameCount = 4;
            FrameSpeed = 4f;
            AdditiveDraw = true;
        }

        public override void Update(int i, int j)
        {
            base.Update(i, j);
            Player player = Main.LocalPlayer;
            Vector2 tileCheckPos = new Vector2(i, j).ToWorldCoordinates();
            bool canCollect = CanCollect(player, tileCheckPos);
            float distanceToPlayer = Vector2.Distance(player.Center, tileCheckPos);
            if (distanceToPlayer < 64 && canCollect)
            {
                Collect(player, tileCheckPos);
            }
            if (Main.rand.NextBool(8))
            {
                Texture2D texture = TextureAssets.Tile[Type].Value;
                Dust.NewDustPerfect(tileCheckPos - Main.rand.NextVector2Circular(64, 64) - new Vector2(42, 48) / 2, ModContent.DustType<GlowSparkleDust>(), (Vector2.One * Main.rand.NextFloat(0.2f, 0.4f)).RotatedByRandom(19.0), 0,
                    Color.White, 0.5f).noGravity = true;
            }
        }

        public virtual bool CanCollect(Player player, Vector2 position)
        {
            return true;
        }

        public virtual void Collect(Player player, Vector2 position)
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
            int c = CombatText.NewText(player.getRect(), Color.LightGoldenrodYellow, "Teleport Spot Unlocked!", dramatic: true);
            Main.combatText[c].lifeTime *= 3;
        }

        public virtual bool CanTeleport()
        {
            return true;
        }
        public virtual void Teleport()
        {
            MapMarkerUtil.TeleportToMarker(Main.LocalPlayer, Type);
        }
    }
    public class SpringHillsInnerMarkerItem : DecorativeWallItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Super silk!");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;

        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.createWall = ModContent.WallType<SpringHillsInnerMarker>();
        }
    }

    internal class SpringHillsInnerMarker : BaseMapMarker
    {
        public override bool CanTeleport()
        {
            MapPlayer mapPlayer = Main.LocalPlayer.GetModPlayer<MapPlayer>();
            return mapPlayer.teleportSpotSpringHillsInner;
        }

        public override bool CanCollect(Player player, Vector2 position)
        {
            MapPlayer mapPlayer = player.GetModPlayer<MapPlayer>();
            return !mapPlayer.teleportSpotSpringHillsInner;
        }
        public override void Collect(Player player, Vector2 position)
        {
            base.Collect(player, position);
            MapPlayer mapPlayer = player.GetModPlayer<MapPlayer>();
            mapPlayer.teleportSpotSpringHillsInner=true;
        }
    }
    public class SpringHillsOuterMarkerItem : DecorativeWallItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Super silk!");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;

        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.createWall = ModContent.WallType<SpringHillsOuterMarker>();
        }
    }
    internal class SpringHillsOuterMarker : BaseMapMarker
    {
        public override bool CanTeleport()
        {
            MapPlayer mapPlayer = Main.LocalPlayer.GetModPlayer<MapPlayer>();
            return mapPlayer.teleportSpotSpringHillsOuter;
        }
        public override bool CanCollect(Player player, Vector2 position)
        {
            MapPlayer mapPlayer = player.GetModPlayer<MapPlayer>();
            return !mapPlayer.teleportSpotSpringHillsOuter;
        }
        public override void Collect(Player player, Vector2 position)
        {
            base.Collect(player, position);
            MapPlayer mapPlayer = player.GetModPlayer<MapPlayer>();
            mapPlayer.teleportSpotSpringHillsOuter = true;
        }
    }
    public class WarriorsDoorMarkerItem : DecorativeWallItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Super silk!");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;

        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.createWall = ModContent.WallType<WarriorsDoorMarker>();
        }
    }
    internal class WarriorsDoorMarker : BaseMapMarker
    {
        public override bool CanTeleport()
        {
            MapPlayer mapPlayer = Main.LocalPlayer.GetModPlayer<MapPlayer>();
            return mapPlayer.teleportSpotWarriorsDoor;
        }
        public override bool CanCollect(Player player, Vector2 position)
        {
            MapPlayer mapPlayer = player.GetModPlayer<MapPlayer>();
            return !mapPlayer.teleportSpotWarriorsDoor;
        }
        public override void Collect(Player player, Vector2 position)
        {
            base.Collect(player, position);
            MapPlayer mapPlayer = player.GetModPlayer<MapPlayer>();
            mapPlayer.teleportSpotWarriorsDoor = true;
        }
    }
    public class WitchTownMarkerItem : DecorativeWallItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Super silk!");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;

        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.createWall = ModContent.WallType<WitchTownMarker>();
        }
    }
    internal class WitchTownMarker : BaseMapMarker
    {
        public override bool CanTeleport()
        {
            MapPlayer mapPlayer = Main.LocalPlayer.GetModPlayer<MapPlayer>();
            return mapPlayer.teleportSpotWitchTown;
        }
        public override bool CanCollect(Player player, Vector2 position)
        {
            MapPlayer mapPlayer = player.GetModPlayer<MapPlayer>();
            return !mapPlayer.teleportSpotWitchTown;
        }
        public override void Collect(Player player, Vector2 position)
        {
            base.Collect(player, position);
            MapPlayer mapPlayer = player.GetModPlayer<MapPlayer>();
            mapPlayer.teleportSpotWitchTown = true;
        }
    }
}
