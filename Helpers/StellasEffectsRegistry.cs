using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Urdveil.Skies;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;

namespace Urdveil.Helpers.Separate
{
    public static class StellasEffectsRegistry
    {
        #region Texture Shaders
        public static Ref<Effect> FluidSimulatorShader
        {
            get;
            internal set;
        }

        // public static MiscShaderData UnderwaterRayShader => GameShaders.Misc["Urdveil:UnderwaterRays"];
        #endregion

        #region Screen Shaders
        public static Filter BloomShader => Filters.Scene["Urdveil:Bloom"];

        #endregion

        #region Methods
        public static void LoadEffects()
        {
            var assets = Urdveil.Instance.Assets;


            LoadScreenShaders(assets);


        }



        public static void LoadScreenShaders(AssetRepository assets)
        {


            // Flower of the ocean sky.
            Filters.Scene["Urdveil:GovheilSky"] = new Filter(new ScreenShaderData("FilterMiniTower").UseColor(0.1f, 0.2f, 0.5f).UseOpacity(0.53f), EffectPriority.High);
            SkyManager.Instance["Urdveil:GovheilSky"] = new GovheilSky();

            // Fireball shader.





        }
        #endregion
    }
}