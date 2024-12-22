using Terraria.ModLoader;

namespace Urdveil
{
    internal class UrdveilKeybinds : ModSystem
    {
        public static ModKeybind DashKeybind { get; private set; }
        public override void Load()
        {
            // Register keybinds            
            DashKeybind = KeybindLoader.RegisterKeybind(Mod, "Dash", "F");
        }
    }
}
