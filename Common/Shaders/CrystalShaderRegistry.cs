using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;

namespace Urdveil.Common.Shaders
{
    internal class CrystalShaderRegistry
    {
        public static AssetRepository Assets => Urdveil.Instance.Assets;
        public static void RegisterMiscShader(string name, string pass)
        {
            string assetPath = $"Effects/CrystalShaders/{name}";
            Asset<Effect> miscShader = Assets.Request<Effect>(assetPath, AssetRequestMode.ImmediateLoad);
            GameShaders.Misc[$"Urdveil:{name}"] = new MiscShaderData(miscShader, pass);
        }

        public static void LoadShaders()
        {
            //Automatically Load All Base Shaders
            foreach (Type type in Urdveil.Instance.Code.GetTypes())
            {
                //Only if it inherits BaseShader
                if (!type.IsAbstract && type.IsSubclassOf(typeof(BaseShader)))
                {
                    //This automatically loads shaders that inherits from BaseShader, so we don't have to keep manually updating the Registry and can just use
                    //The custom classes that we made :)
                    object instance = Activator.CreateInstance(type);
                    BaseShader shader = (BaseShader)instance;
                    string name = shader.EffectPath;
                    string assetPath = $"Effects/CrystalShaders/{name}";
                    Asset<Effect> miscShader = Assets.Request<Effect>(assetPath, AssetRequestMode.ImmediateLoad);
                    GameShaders.Misc[$"Urdveil:{name}"] = new MiscShaderData(miscShader, miscShader.Value.Techniques[0].Passes[0].Name);
                }
            }
            var miscShader9 = new Ref<Effect>(Urdveil.Instance.Assets.Request<Effect>("Effects/CrystalShaders/Water", AssetRequestMode.ImmediateLoad).Value);
            Filters.Scene["Urdveil:Water"] = new Filter(new ScreenShaderData(miscShader9, "PrimitivesPass"), EffectPriority.VeryHigh);
            Filters.Scene["Urdveil:Water"].Load();

            var miscShader7 = new Ref<Effect>(Urdveil.Instance.Assets.Request<Effect>("Effects/CrystalShaders/WaterBasic", AssetRequestMode.ImmediateLoad).Value);
            Filters.Scene["Urdveil:WaterBasic"] = new Filter(new ScreenShaderData(miscShader7, "PrimitivesPass"), EffectPriority.VeryHigh);
            Filters.Scene["Urdveil:WaterBasic"].Load();

        }
    }
}
