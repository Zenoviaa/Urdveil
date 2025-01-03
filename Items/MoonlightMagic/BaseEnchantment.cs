﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Urdveil.Helpers;
using Urdveil.Items.MoonlightMagic.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Urdveil.Items.MoonlightMagic
{
    internal abstract class BaseEnchantment : BaseMagicItem,
        IAdvancedMagicAddon,
        ICloneable
    {
        private static BaseEnchantment[] _enchantments;
        public static int[] GetTypes()
        {
            BaseEnchantment[] allEnchantments = BaseEnchantment.AllEnchantments;
            int numResults = allEnchantments.Length;
            int[] enchantmentTypes = new int[numResults];
            for (int i = 0; i < enchantmentTypes.Length; i++)
            {
                enchantmentTypes[i] = allEnchantments[i].Type;
            }
            return enchantmentTypes;
        }
        public static BaseEnchantment[] AllEnchantments
        {
            get
            {
                if (_enchantments == null)
                    _enchantments = Urdveil.Instance.GetContent<BaseEnchantment>().ToArray();
                return _enchantments;
            }
        }

        public AdvancedMagicProjectile MagicProj { get; set; }
        public Projectile Projectile => MagicProj.Projectile;
        public override string LocalizationCategory => "Enchantments";

        public int time;

        public int Countertimer;
        public bool isTimedEnchantment => time > 0;
        public virtual float GetStaffManaModifier() { return 0.2f; }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public BaseEnchantment Instantiate()
        {
            return (BaseEnchantment)Clone();
        }

        public virtual int GetElementType()
        {
            return ModContent.ItemType<BasicElement>();
        }



        public override void SetDefaults()
        {
            base.SetDefaults();
        }
        public virtual void SetMagicDefaults() { }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            base.ModifyTooltips(tooltips);
            TooltipLine tooltipLine;

            if (isTimedEnchantment)
            {
                tooltipLine = new TooltipLine(Mod, "EnchantmentTimedHelp",
                    Language.GetTextValue("Mods.Urdveil.Enchantments.EnchantmentCommonTimed", time));
                tooltips.Add(tooltipLine);
            }

            tooltipLine = new TooltipLine(Mod, "EnchantmentHelp",
                Language.GetTextValue("Mods.Urdveil.Enchantments.EnchantmentCommonHelp"));
            tooltipLine.OverrideColor = Color.Gray;
            tooltips.Add(tooltipLine);

            tooltipLine = new TooltipLine(Mod, "EnchantmentManaHelp",
                Language.GetTextValue("Mods.Urdveil.Enchantments.EnchantmentCommonMana",
                GetStaffManaModifier() * 100));
            tooltipLine.OverrideColor = Color.IndianRed;
            tooltips.Add(tooltipLine);
        }

        public virtual void DrawTextShader(SpriteBatch spriteBatch, Item item, DrawableTooltipLine line, ref int yOffset) { }
        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            DrawHelper.DrawGlow2InWorld(Item, spriteBatch, ref rotation, ref scale, whoAmI);
            return base.PreDrawInWorld(spriteBatch, lightColor, alphaColor, ref rotation, ref scale, whoAmI);
        }

        //Enchantment stuff
        public virtual void AI() { }
        public virtual void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) { }
        public virtual void OnKill(int timeLeft) { }
        public virtual bool OnTileCollide(Vector2 oldVelocity) { return true; }
    }
}
