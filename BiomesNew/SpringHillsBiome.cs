﻿using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Graphics.Capture;
using Terraria.Graphics.Effects;
using Terraria.ModLoader;

namespace Urdveil.BiomesNew
{
    public class SpringHillsBiome : ModBiome
    {
        // Select all the scenery
        public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle => ModContent.Find<ModSurfaceBackgroundStyle>("Urdveil/StarbloomBackgroundStyle");
        public override CaptureBiome.TileColorStyle TileColorStyle => CaptureBiome.TileColorStyle.Normal;
        // Select Music
        public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh;
        public override int Music => MusicLoader.GetMusicSlot(Mod, "Assets/Music/ADemise");
        public override void SpecialVisuals(Player player, bool isActive)
        {

        }

        public override bool IsBiomeActive(Player player) => BiomeTileCountsNew.InSpringHills;
        public override string BestiaryIcon => base.BestiaryIcon;
        public override string BackgroundPath => base.BackgroundPath;
        public override Color? BackgroundColor => base.BackgroundColor;

        // Use SetStaticDefaults to assign the display name
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Cathedral of the Moon");
        }


        public override void OnEnter(Player player) => player.GetModPlayer<BiomePlayer>().ZoneSpringHills = true;
        public override void OnLeave(Player player) => player.GetModPlayer<BiomePlayer>().ZoneSpringHills = false;
    }
}
