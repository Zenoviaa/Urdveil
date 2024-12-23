﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.GameInput;
using Terraria.ModLoader;
using Terraria.UI;

namespace Urdveil.UI.CellConverterSystem
{
    internal class ConverterCrystal : UIPanel
    {
        internal event Action<int> OnEmptyMouseover;
        private readonly float _scale = 1f;
        internal ConverterCrystal()
        {
            float scale = 1f;
            var asset = ModContent.Request<Texture2D>(
                $"{CellConverterUISystem.RootTexturePath}Crystal", ReLogic.Content.AssetRequestMode.ImmediateLoad);
            Width.Set(asset.Width() * scale, 0f);
            Height.Set(asset.Height() * scale, 0f);
            OnLeftClick += OnButtonClick;
            OnMouseOver += OnMouseHover;
        }

        private void OnButtonClick(UIMouseEvent evt, UIElement listeningElement)
        {
            CellConverterUISystem uiSystem = ModContent.GetInstance<CellConverterUISystem>();
            if (uiSystem.CanSwap())
            {
                uiSystem.CellConvert();
            }
            // We can do stuff in here!
        }

        private void OnMouseHover(UIMouseEvent evt, UIElement listeningElement)
        {

        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            CalculatedStyle dimensions = GetDimensions();
            Point point = new Point((int)dimensions.X, (int)dimensions.Y);
            Texture2D textureToDraw;
            if (IsMouseHovering)
            {
                textureToDraw = ModContent.Request<Texture2D>($"{CellConverterUISystem.RootTexturePath}CrystalSelected").Value;
            }
            else
            {
                textureToDraw = ModContent.Request<Texture2D>($"{CellConverterUISystem.RootTexturePath}Crystal").Value;
            }
            bool contains = ContainsPoint(Main.MouseScreen);
            if (contains && !PlayerInput.IgnoreMouseInterface)
            {
                Main.LocalPlayer.mouseInterface = true;
            }
            Color drawColor = Color.White;
            CellConverterUISystem uiSystem = ModContent.GetInstance<CellConverterUISystem>();

            //Grey out when crafting won't make anything
            if (!uiSystem.CanSwap())
                drawColor = drawColor.MultiplyRGB(Color.Gray);

            Rectangle rect = new Rectangle(point.X, point.Y, textureToDraw.Width, textureToDraw.Height);
            rect.Location += new Point(0, (int)VectorHelper.Osc(-8f, 8f, 1f));
            float rotation = 0;


            spriteBatch.Draw(textureToDraw, rect, null, drawColor, rotation, Vector2.Zero, SpriteEffects.None, 0);
        }
    }
}
