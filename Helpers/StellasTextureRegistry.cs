using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.ModLoader;

// This is in the base namespace for convience with how often textures are used with newer visuals.
// Please maintain Type -> Alphabetical order when adding new textures to the registry.
namespace Urdveil.Helpers.Separate
{
    public static class StellasTextureRegistry
    {


        public static Asset<Texture2D> BloomLine => ModContent.Request<Texture2D>("Urdveil/Assets/NoiseTextures/BloomLine");

        public static Asset<Texture2D> BloomLineSmall => ModContent.Request<Texture2D>("Urdveil/Assets/NoiseTextures/BloomLineSmall");

        public static Asset<Texture2D> Invisible => ModContent.Request<Texture2D>("Urdveil/Assets/NoiseTextures/Invisible");


        public static Asset<Texture2D> LaserCircle => ModContent.Request<Texture2D>("Urdveil/Assets/NoiseTextures/LaserCircle");

        public static Asset<Texture2D> Line => ModContent.Request<Texture2D>("IUrdveil/Assets/NoiseTextures/Line");

        public static string InvisPath => "IUrdveil/Assets/NoiseTextures/Invisible";
    }
}
