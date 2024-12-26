using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;

namespace Urdveil.UI.TileEntityEditorSystem
{
    internal abstract class BaseModTileEditor : UIPanel
    {
        public virtual void Load(ModTileEntity modTileEntity) { }
        public virtual void Apply(ModTileEntity modTileEntity) { }
    }
}
