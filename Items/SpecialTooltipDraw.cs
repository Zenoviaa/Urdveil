﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Urdveil.Helpers;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI.Chat;

namespace Urdveil.Items
{
    internal class SpecialTooltipDraw : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            base.ModifyTooltips(item, tooltips);
            Cauldron cauldron = ModContent.GetInstance<Cauldron>();
            if (cauldron.IsResult(item))
            {
                var brew = cauldron.FindBrew(item);
                TooltipLine tooltipLine;
                tooltipLine = new TooltipLine(Mod, $"CauldronCraftHelp_{ModContent.GetModItem(brew.mold).Texture}_{ModContent.GetModItem(brew.material).Texture}_",
                            LangText.Misc("CauldronCraft"));
                tooltipLine.OverrideColor = Color.Lerp(new Color(80, 187, 124), Color.Black, 0.5f);
                tooltips.Add(tooltipLine);
            }

            if (cauldron.IsMaterialOrMold(item.type))
            {
                TooltipLine tooltipLine;
                tooltipLine = new TooltipLine(Mod, "CauldronMaterialHelp",
                            LangText.Misc("CauldronMaterial"));
                tooltips.Add(tooltipLine);
            }

            if (cauldron.IsMold(item.type))
            {
                TooltipLine tooltipLine;
                tooltipLine = new TooltipLine(Mod, "CauldronMoldHelp",
                            LangText.Misc("CauldronMold"));
                tooltipLine.OverrideColor = Color.Gray;
                tooltips.Add(tooltipLine);
            }

            if (cauldron.IsMaterial(item.type))
            {
                TooltipLine tooltipLine;
                tooltipLine = new TooltipLine(Mod, "CauldronElementHelp",
                            LangText.Misc("CauldronElement"));
                tooltipLine.OverrideColor = Color.Gray;
                tooltips.Add(tooltipLine);
            }
        }

        public override bool PreDrawTooltipLine(Item item, DrawableTooltipLine line, ref int yOffset)
        {
            SpriteBatch spriteBatch = Main.spriteBatch;
            if (line.Mod == "Urdveil" && line.Name.Contains("CauldronMaterial"))
            {
                line.X += 15;
                Vector2 textPosition = new Vector2(line.X, line.Y);
                //Draw BackGlow
                Vector2 scale = new Vector2(0.45f, 0.15f);
                Color glowColor = Color.White;
                glowColor.A = 0;
                glowColor *= 0.5f;
                spriteBatch.End();
                spriteBatch.Begin(default, BlendState.AlphaBlend, default, default, default, default, Main.UIScaleMatrix);

                //Draw Flaming Text
                ChatManager.DrawColorCodedString(Main.spriteBatch, line.Font, line.Text, textPosition, line.Color, line.Rotation, line.Origin, line.BaseScale);

                spriteBatch.End();
                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive, default, default, default, default, Main.UIScaleMatrix);

                ChatManager.DrawColorCodedString(Main.spriteBatch, line.Font, line.Text, textPosition, line.Color * VectorHelper.Osc(0.5f, 1f), line.Rotation, line.Origin, line.BaseScale);

                spriteBatch.End();
                spriteBatch.Begin(default, default, default, default, default, default, Main.UIScaleMatrix);
                return false;
            }

            return base.PreDrawTooltipLine(item, line, ref yOffset);
        }



        public override void PostDrawTooltipLine(Item item, DrawableTooltipLine line)
        {
            base.PostDrawTooltipLine(item, line);
            if (line.Mod == "Urdveil" && line.Name.Contains("CauldronMaterial"))
            {
                Texture2D texture = ModContent.Request<Texture2D>("Urdveil/Items/CauldronIcon").Value;
                SpriteBatch spriteBatch = Main.spriteBatch;
                Vector2 textPosition = new(line.X, line.Y - 4);
                Vector2 drawPos = textPosition + new Vector2(0, texture.Size().Y / 3.5f) - new Vector2(15, 6);
                spriteBatch.Draw(texture, drawPos, null, Color.White, 0f, texture.Size() * 0.5f, 0.5f, SpriteEffects.None, 0f);
            }

            if (line.Mod == "Urdveil" && line.Name.Contains("CauldronCraftHelp_"))
            {

                int startIndex = line.Name.IndexOf("_") + 1;
                int endIndex = line.Name.IndexOf("_", startIndex + 1);
                string textureName = line.Name.Substring(startIndex, endIndex - startIndex);
                Texture2D texture = ModContent.Request<Texture2D>(textureName).Value;

                SpriteBatch spriteBatch = Main.spriteBatch;
                Vector2 textPosition = new(line.X, line.Y);
                Vector2 drawPos = textPosition + new Vector2(0, texture.Size().Y / 3.5f) + new Vector2(115, 6);
                spriteBatch.Draw(texture, drawPos, null, Color.White, 0f, texture.Size() * 0.5f, 0.8f, SpriteEffects.None, 0f);


                startIndex = endIndex + 1;
                endIndex = line.Name.IndexOf("_", startIndex + 1);
                textureName = line.Name.Substring(startIndex, endIndex - startIndex);
                texture = ModContent.Request<Texture2D>(textureName).Value;

                textPosition = new(line.X, line.Y);
                drawPos = textPosition + new Vector2(0, texture.Size().Y / 3.5f) + new Vector2(145, 6);
                spriteBatch.Draw(texture, drawPos, null, Color.White, 0f, texture.Size() * 0.5f, 0.8f, SpriteEffects.None, 0f);
            }
        }
    }
}
