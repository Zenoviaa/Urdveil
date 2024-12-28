using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;

namespace Urdveil.UI
{
    internal abstract class SimpleUIBackground : UIElement
    {
        public string Texture => (GetType().Namespace + "." + GetType().Name).Replace('.', '/');
        public Asset<Texture2D> TextureAsset;
        public SimpleUIBackground() : base()
        {

        }

        public override void OnInitialize()
        {
            base.OnInitialize();
            TextureAsset = ModContent.Request<Texture2D>(Texture, AssetRequestMode.ImmediateLoad);
            Width.Pixels = TextureAsset.Width();
            Height.Pixels = TextureAsset.Height();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);
            Rectangle rectangle = GetDimensions().ToRectangle();

            //Draw Backing
            Color color2 = Color.White;
            Vector2 pos = rectangle.TopLeft();
            spriteBatch.Draw(TextureAsset.Value, rectangle.TopLeft(), null, color2, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
        }
    }
}
