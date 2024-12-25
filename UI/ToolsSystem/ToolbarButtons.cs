using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.GameContent.UI.Elements;
using Terraria.GameInput;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria;
using Urdveil.Common.Foggy;
using Urdveil.UI.StructureSelector;
using Urdveil.Helpers;
using Terraria.Audio;
using Terraria.ID;
using Urdveil.WorldG.StructureManager;

namespace Urdveil.UI.ToolsSystem
{
    internal abstract class BaseToolbarButton : UIButtonIcon
    {

    }
    internal class FogButton : BaseToolbarButton
    {
        public override void OnButtonClick(UIMouseEvent evt, UIElement listeningElement)
        {
            base.OnButtonClick(evt, listeningElement);
            FogSystem fogSystem = ModContent.GetInstance<FogSystem>();
            fogSystem.doDraws = !fogSystem.doDraws;
        }
    }
    internal class HitboxButton : BaseToolbarButton
    {
        public override void OnButtonClick(UIMouseEvent evt, UIElement listeningElement)
        {
            base.OnButtonClick(evt, listeningElement);
            ToolsUISystem uiSystem = ModContent.GetInstance<ToolsUISystem>();
            uiSystem.ShowHitboxes = !uiSystem.ShowHitboxes;
        }
    }
    internal class StructureSelectorButton : BaseToolbarButton
    {
        public override void OnButtonClick(UIMouseEvent evt, UIElement listeningElement)
        {
            base.OnButtonClick(evt, listeningElement);
            StructureSelectorUISystem uiSystem = ModContent.GetInstance<StructureSelectorUISystem>();
            uiSystem.ToggleUI();
        }
    }
    internal class TilePainterButton : BaseToolbarButton
    {
        public override void OnButtonClick(UIMouseEvent evt, UIElement listeningElement)
        {
            base.OnButtonClick(evt, listeningElement);
            ToolsUISystem uiSystem = ModContent.GetInstance<ToolsUISystem>();
            uiSystem.ToggleTilePainterUI();
        }
    }
    internal class ResetBossButton : BaseToolbarButton
    {
        public override void OnButtonClick(UIMouseEvent evt, UIElement listeningElement)
        {
            base.OnButtonClick(evt, listeningElement);
            DownedBossSystem.ResetFlags();
            Main.NewText("Reset Boss Flags");
            SoundEngine.PlaySound(SoundID.AchievementComplete);
        }
    }
    internal class UndoButton : BaseToolbarButton
    {
        public override void OnButtonClick(UIMouseEvent evt, UIElement listeningElement)
        {
            base.OnButtonClick(evt, listeningElement);
            SnapshotSystem system = ModContent.GetInstance<SnapshotSystem>();
            system.Undo();
            // We can do stuff in here!
            SoundEngine.PlaySound(SoundID.MenuTick);
        }
    }
}
