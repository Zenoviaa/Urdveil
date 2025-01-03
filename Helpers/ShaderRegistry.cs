﻿using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Urdveil.Common.LoadingSystems;
using Urdveil.Common.Skies;
using Urdveil.Skies;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader;

namespace Urdveil.Helpers
{
    internal static class ShaderRegistry
    {
        private static List<IOrderedLoadable> _loadCache;
        public static string VampKnives_Basic_Trail => "VampKnives:BasicTrail";
        public static string VampKnives_Lightning_Trail => "VampKnives:LightningTrail";
        public static string VampKnives_Generic_Laser_Shader => "VampKnives:GenericLaserShader";
        public static string VampKnives_Light_Beam_Vertex_Shader => "VampKnives:LightBeamVertexShader";

        public static string VampKnives_Fire => "VampKnives:Fire";
        public static string UrdveilFireWhiteShader => "VampKnives:FireWhite";


        private static string Silhouette_Shader => "Urdveil:SilhouetteShader";

        public static string Screen_Black => "Urdveil:Black";
        public static string Screen_Tint => "Urdveil:Tint";
        public static string Screen_NormalDistortion => "Urdveil:NormalDistortion";
        public static string Screen_Vignette => "Urdveil:Vignette";

        public static string Screen_Palette => "Urdveil:Palette";

        //SHADERING
        private static string GlowingDustShader => "Urdveil:GlowingDust";
        public static MiscShaderData MiscGlowingDust => GameShaders.Misc[GlowingDustShader];

        private static string FireWhitePixelShaderName => "Urdveil:FireWhitePixelShader";
        public static MiscShaderData MiscFireWhitePixelShader => GameShaders.Misc[FireWhitePixelShaderName];

        private static string TestPixelShaderName => "Urdveil:TestPixelShader";
        public static MiscShaderData MiscTestPixelShader => GameShaders.Misc[TestPixelShaderName];

        private static string SilShaderName => "Urdveil:SilShader";
        public static MiscShaderData MiscSilPixelShader => GameShaders.Misc[SilShaderName];

        private static string DistortionShaderName => "Urdveil:DistortionShader";
        public static MiscShaderData MiscDistortionShader => GameShaders.Misc[DistortionShaderName];

        public static AssetRepository Assets => Urdveil.Instance.Assets;
        public static MiscShaderData GradientShader => GameShaders.Misc["Urdveil:Gradient"];
        public static MiscShaderData CloudsShader => GameShaders.Misc["Urdveil:Clouds"];
        public static MiscShaderData CloudsFrontShader => GameShaders.Misc["Urdveil:CloudsFront"];
        public static MiscShaderData NightCloudsShader => GameShaders.Misc["Urdveil:NightClouds"];
        public static MiscShaderData CloudsDesertShader => GameShaders.Misc["Urdveil:CloudsDesert"];
        public static MiscShaderData CloudsDesertNightShader => GameShaders.Misc["Urdveil:CloudsDesertNight"];
        private static void RegisterMiscShader(string name, string path, string pass)
        {
            Asset<Effect> miscShader = Assets.Request<Effect>(path, AssetRequestMode.ImmediateLoad);
            var miscShaderData = new MiscShaderData(miscShader, pass);
            GameShaders.Misc[name] = miscShaderData;
        }
        private static void RegisterMiscCrystalShader(string name, string pass)
        {
            string assetPath = $"Effects/CrystalShaders/{name}";
            Asset<Effect> miscShader = Assets.Request<Effect>(assetPath, AssetRequestMode.ImmediateLoad);
            GameShaders.Misc[$"Urdveil:{name}"] = new MiscShaderData(miscShader, pass);
        }
        private static void RegisterScreenShader(string name, string path, EffectPriority effectPriority = EffectPriority.Medium)
        {
            Asset<Effect> paletteShader = Assets.Request<Effect>(path);
            Filters.Scene[name] = new Filter(new ScreenShaderData(paletteShader, "ScreenPass"), effectPriority);

        }
        public static void LoadShaders()
        {
            if (!Main.dedServ)
            {
                Filters.Scene["Urdveil:VeilSky"] = new Filter(new ScreenShaderData("FilterMiniTower").UseColor(0f, 0f, 0f).UseOpacity(0f), EffectPriority.VeryHigh);
                SkyManager.Instance["Urdveil:VeilSky"] = new AuroranSky();

                Filters.Scene["Urdveil:GreenSunSky"] = new Filter(new ScreenShaderData("FilterMiniTower").UseColor(0f, 1f, 0.3f).UseOpacity(0.275f), EffectPriority.VeryHigh);
                SkyManager.Instance["Urdveil:GreenSunSky"] = new GreenSunSky();
            }

            Ref<Effect> BasicTrailRef = new(Assets.Request<Effect>("Effects/Primitives/BasicTrailShader", AssetRequestMode.ImmediateLoad).Value);
            Ref<Effect> LightningTrailRef = new(Assets.Request<Effect>("Effects/Primitives/LightningTrailShader", AssetRequestMode.ImmediateLoad).Value);

            GameShaders.Misc[ShaderRegistry.VampKnives_Basic_Trail] = new MiscShaderData(BasicTrailRef, "TrailPass");
            GameShaders.Misc[ShaderRegistry.VampKnives_Lightning_Trail] = new MiscShaderData(LightningTrailRef, "TrailPass");

            Asset<Effect> shader2 = ModContent.Request<Effect>("Urdveil/Trails/SilhouetteShader", AssetRequestMode.ImmediateLoad);
            GameShaders.Misc[ShaderRegistry.Silhouette_Shader] = new MiscShaderData(new Ref<Effect>(shader2.Value), "SilhouettePass");

            Ref<Effect> genericLaserShader = new(Assets.Request<Effect>("Effects/Primitives/GenericLaserShader", AssetRequestMode.ImmediateLoad).Value);
            GameShaders.Misc[ShaderRegistry.VampKnives_Generic_Laser_Shader] = new MiscShaderData(genericLaserShader, "TrailPass");

            Ref<Effect> LightBeamVertexShader = new(Assets.Request<Effect>("Effects/Primitives/LightBeamVertexShader", AssetRequestMode.ImmediateLoad).Value);
            GameShaders.Misc[ShaderRegistry.VampKnives_Light_Beam_Vertex_Shader] = new MiscShaderData(LightBeamVertexShader, "TrailPass");



            Ref<Effect> shadowflameShader = new(Assets.Request<Effect>("Effects/Primitives/Shadowflame", AssetRequestMode.ImmediateLoad).Value);
            GameShaders.Misc[ShaderRegistry.VampKnives_Fire] = new MiscShaderData(shadowflameShader, "TrailPass");

            Ref<Effect> whiteflameShader = new(Assets.Request<Effect>("Effects/Whiteflame", AssetRequestMode.ImmediateLoad).Value);
            GameShaders.Misc[ShaderRegistry.UrdveilFireWhiteShader] = new MiscShaderData(whiteflameShader, "TrailPass");

            Asset<Effect> glowingDustShader = Assets.Request<Effect>("Effects/GlowingDust");
            GameShaders.Misc[ShaderRegistry.GlowingDustShader] = new MiscShaderData(glowingDustShader, "GlowingDustPass");

            Ref<Effect> SuperSimpleTrailRef = new(Assets.Request<Effect>("Effects/SimpleTrail", AssetRequestMode.ImmediateLoad).Value);
            GameShaders.Misc["VampKnives:SuperSimpleTrail"] = new MiscShaderData(SuperSimpleTrailRef, "TrailPass");

            Ref<Effect> DaedusRobeRef = new(Assets.Request<Effect>("Effects/DaedusRobe", AssetRequestMode.ImmediateLoad).Value);
            GameShaders.Misc["Urdveil:DaedusRobe"] = new MiscShaderData(DaedusRobeRef, "PixelPass");

            Ref<Effect> lightningBoltRef = new(Assets.Request<Effect>("Effects/LightningBolt", AssetRequestMode.ImmediateLoad).Value);
            GameShaders.Misc["Urdveil:LightningBolt"] = new MiscShaderData(lightningBoltRef, "PrimitivesPass");

            Asset<Effect> blackShader = Assets.Request<Effect>("Effects/Black");
            Filters.Scene[ShaderRegistry.Screen_Black] = new Filter(new ScreenShaderData(blackShader, "BlackPass"), EffectPriority.Medium);

            Asset<Effect> tintShader = Assets.Request<Effect>("Effects/Tint");
            Filters.Scene[ShaderRegistry.Screen_Tint] = new Filter(new ScreenShaderData(tintShader, "ScreenPass"), EffectPriority.Medium);

            Asset<Effect> distortionShader = Assets.Request<Effect>("Effects/NormalDistortion");
            Filters.Scene[ShaderRegistry.Screen_NormalDistortion] = new Filter(new ScreenShaderData(distortionShader, "ScreenPass"), EffectPriority.Medium);

            Asset<Effect> vignetteShader = Assets.Request<Effect>("Effects/Vignette");
            Filters.Scene[ShaderRegistry.Screen_Vignette] = new Filter(new ScreenShaderData(vignetteShader, "ScreenPass"), EffectPriority.Medium);


            Asset<Effect> paletteShader = Assets.Request<Effect>("Effects/Palette");
            Filters.Scene[ShaderRegistry.Screen_Palette] = new Filter(new ScreenShaderData(paletteShader, "ScreenPass"), EffectPriority.Medium);

            Ref<Effect> gustArmorRef = new(Assets.Request<Effect>("Effects/GustArmor", AssetRequestMode.ImmediateLoad).Value);
            GameShaders.Misc["Urdveil:GustArmor"] = new MiscShaderData(gustArmorRef, "PixelPass");

            //Palette Shaders
            RegisterScreenShader("Urdveil:PaletteAbyss", "Effects/Palette");
            RegisterScreenShader("Urdveil:PaletteHell", "Effects/PaletteHell");
            RegisterScreenShader("Urdveil:PaletteRoyalCapital", "Effects/PaletteRoyalCapital");
            RegisterScreenShader("Urdveil:PaletteDungeon", "Effects/PaletteDungeon");
            RegisterScreenShader("Urdveil:PaletteDesert", "Effects/PaletteDesert");
            RegisterScreenShader("Urdveil:PaletteDesertTop", "Effects/PaletteDesertTop");
            RegisterScreenShader("Urdveil:PaletteBloodCathedral", "Effects/PaletteBloodCathedral");
            RegisterScreenShader("Urdveil:PaletteBloodHound", "Effects/PaletteBloodHound");
            RegisterScreenShader("Urdveil:PaletteVirulent", "Effects/PaletteVirulent");
            RegisterScreenShader("Urdveil:DarknessVignette", "Effects/DarknessVignette");
            RegisterScreenShader("Urdveil:DarknessCurve", "Effects/DarknessCurve", EffectPriority.High);
            RegisterScreenShader("Urdveil:Blur", "Effects/Blur", EffectPriority.High);
            RegisterScreenShader("Urdveil:BlackWhite", "Effects/BlackWhite");

            Ref<Effect> skyRef = new(Assets.Request<Effect>("Effects/RoyalCapitalSky", AssetRequestMode.ImmediateLoad).Value);
            GameShaders.Misc["Urdveil:RoyalCapitalSky"] = new MiscShaderData(skyRef, "ScreenPass");

            Ref<Effect> starsRef = new(Assets.Request<Effect>("Effects/RoyalCapitalStars", AssetRequestMode.ImmediateLoad).Value);
            GameShaders.Misc["Urdveil:RoyalCapitalStars"] = new MiscShaderData(starsRef, "ScreenPass");

            //White Flame Pixel Shader
            RegisterMiscShader(FireWhitePixelShaderName, "Effects/WhiteflamePixelShader", "TrailPass");

            //Test Shader (For Testing)
            RegisterMiscShader(TestPixelShaderName, "Effects/TestShader", "PixelPass");

            //Sil Shader
            RegisterMiscShader(SilShaderName, "Effects/SilShader", "PixelPass");

            //Distortion Shader
            RegisterMiscShader(DistortionShaderName, "Effects/NormalDistortion", "ScreenPass");

            RegisterMiscShader("Urdveil:SimpleDistortion", "Effects/SimpleDistortion", "PixelPass");
            RegisterMiscShader("Urdveil:SimpleMasking", "Effects/SimpleMasking", "PixelPass");

            Ref<Effect> lavaRef = new(Assets.Request<Effect>("Effects/Lava", AssetRequestMode.ImmediateLoad).Value);
            Filters.Scene["Urdveil:Lava"] = new Filter(new ScreenShaderData(lavaRef, "PrimitivesPass"), EffectPriority.VeryHigh);
            Filters.Scene["Urdveil:Lava"].Load();

            //Skies

            SkyManager.Instance["Urdveil:RoyalCapitalSky"] = new RoyalCapitalSky();
            SkyManager.Instance["Urdveil:RoyalCapitalSky"].Load();

            SkyManager.Instance["Urdveil:NaxtrinSky"] = new NaxtrinSky();
            SkyManager.Instance["Urdveil:NaxtrinSky"].Load();

            SkyManager.Instance["Urdveil:NaxtrinSky2"] = new NaxtrinSky2();
            SkyManager.Instance["Urdveil:NaxtrinSky2"].Load();

            SkyManager.Instance["Urdveil:AlcadSky"] = new NaxtrinSky3();
            SkyManager.Instance["Urdveil:AlcadSky"].Load();

            SkyManager.Instance["Urdveil:SyliaSky"] = new SyliaSky();
            SkyManager.Instance["Urdveil:SyliaSky"].Load();

            SkyManager.Instance["Urdveil:VillageSky"] = new VillageSky();
            SkyManager.Instance["Urdveil:VillageSky"].Load();

            RegisterMiscCrystalShader("Clouds", "ScreenPass");
            RegisterMiscCrystalShader("CloudsFront", "ScreenPass");
            RegisterMiscCrystalShader("NightClouds", "ScreenPass");
            RegisterMiscCrystalShader("CloudsDesert", "ScreenPass");
            RegisterMiscCrystalShader("CloudsDesertNight", "ScreenPass");
            RegisterMiscCrystalShader("Gradient", "ScreenPass");

            //Crystal Moon Skies
            SkyManager.Instance["Urdveil:CloudySky"] = new CloudySky();
            SkyManager.Instance["Urdveil:CloudySky"].Load();
            Filters.Scene["Urdveil:CloudySky"] = new Filter(new ScreenShaderData("FilterMiniTower").UseColor(0f, 0f, 0f).UseOpacity(0f), EffectPriority.VeryHigh);

            SkyManager.Instance["Urdveil:DesertSky"] = new DesertSky();
            SkyManager.Instance["Urdveil:DesertSky"].Load();
            Filters.Scene["Urdveil:DesertSky"] = new Filter(new ScreenShaderData("FilterMiniTower").UseColor(0f, 0f, 0f).UseOpacity(0f), EffectPriority.VeryHigh);
            LoadOrderedLoadables();
        }

        public static void LoadOrderedLoadables()
        {
            _loadCache = new List<IOrderedLoadable>();
            foreach (Type type in Urdveil.Instance.Code.GetTypes())
            {
                if (!type.IsAbstract && type.GetInterfaces().Contains(typeof(IOrderedLoadable)))
                {
                    object instance = Activator.CreateInstance(type);
                    _loadCache.Add(instance as IOrderedLoadable);
                }

                _loadCache.Sort((n, t) => n.Priority.CompareTo(t.Priority));
            }

            for (int k = 0; k < _loadCache.Count; k++)
            {
                _loadCache[k].Load();
            }
        }

        public static void UnloadOrderedLoadables()
        {
            if (_loadCache != null)
            {
                foreach (IOrderedLoadable loadable in _loadCache)
                {
                    loadable.Unload();
                }

                _loadCache = null;
            }
            else
            {
                //   Logger.Warn("load cache was null, IOrderedLoadable's may not have been unloaded...");
            }
        }
    }
}
