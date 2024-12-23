using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.GameInput;
using Terraria.ModLoader;
using Terraria.UI;
using Urdveil.UI.StructureSelector;

namespace Urdveil.UI.ToolsSystem
{
    internal class StructureSelectorButton : UIPanel
    {

        private UIPanel _button;
        public override void OnInitialize()
        {
            base.OnInitialize();

            Width.Pixels = 40;
            Height.Pixels = 40;
            BackgroundColor = Color.Transparent;
            BorderColor = Color.Transparent;
            OnLeftClick += OnButtonClick;
        }

        private void OnButtonClick(UIMouseEvent evt, UIElement listeningElement)
        {
            StructureSelectorUISystem uiSystem = ModContent.GetInstance<StructureSelectorUISystem>();
            uiSystem.ToggleUI();
        }
        // We can do stuff in here

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            BackgroundColor = Color.Transparent;
            bool contains = ContainsPoint(Main.MouseScreen);
            if (contains && !PlayerInput.IgnoreMouseInterface)
            {
                Main.LocalPlayer.mouseInterface = true;
            }
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);
            CalculatedStyle dimensions = GetDimensions();
            Point point = new Point((int)dimensions.X, (int)dimensions.Y);
            Texture2D textureToDraw;
            if (IsMouseHovering)
            {
                textureToDraw = ModContent.Request<Texture2D>(ToolsUISystem.RootTexturePath + "StructureSelectorSelected").Value;
            }
            else
            {
                textureToDraw = ModContent.Request<Texture2D>(ToolsUISystem.RootTexturePath + "StructureSelector").Value;
            }
            spriteBatch.Draw(textureToDraw, new Rectangle(point.X, point.Y, textureToDraw.Width, textureToDraw.Height), null, Color.White);
        }
    }
}
