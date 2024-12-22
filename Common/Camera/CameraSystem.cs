using Terraria;
using Terraria.ModLoader;

namespace Urdveil.Common.Camera
{
    [Autoload(Side = ModSide.Client)]
    internal class CameraSystem : ModSystem
    {
        public override void Load()
        {
            base.Load();
            Main.instance.CameraModifiers.Add(new SmoothCameraModifier());
        }
    }
}
