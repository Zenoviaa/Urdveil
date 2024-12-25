using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.GameContent.Creative;
using Terraria.Localization;
using Terraria.ModLoader;
using Urdveil.Tiles;
using Urdveil.UI.TabletSystem;

namespace Urdveil.TilesNew.SpringHills
{
    public class SpringTabletItem : DecorativeWallItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Super silk!");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;

        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.createWall = ModContent.WallType<SpringTablet>();
        }
    }
    public class SpringTabletDashItem : DecorativeWallItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Super silk!");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;

        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.createWall = ModContent.WallType<SpringTabletDash>();
        }
    }
    public class SpringTabletXixianFlaskItem : DecorativeWallItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Super silk!");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;

        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.createWall = ModContent.WallType<SpringTabletXixianFlask>();
        }
    }
    internal abstract class BaseTablet : DecorativeWall
    {
        public override string LocalizationCategory => "Tablets";
        public override string Texture => (typeof(BaseTablet).FullName + "_S").Replace(".", "/");
        public LocalizedText Title { get; private set; }
        public LocalizedText Message { get; private set; }
        public Asset<Texture2D> Image { get; private set; } 
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            ClickFunc = ClickFunction;
            Title = this.GetLocalization("Title");
            Message = this.GetLocalization("Message");

            string imagePath = (this.GetType().FullName).Replace(".", "/");
            Image = ModContent.Request<Texture2D>(imagePath);
        }

        public virtual void ClickFunction()
        {
            TabletUISystem tabletUISystem = ModContent.GetInstance<TabletUISystem>();
            tabletUISystem.OpenUI(Image, Title.Value, Message.Value);
        }
    }

    internal class SpringTablet : DecorativeWall
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }
    }
    internal class SpringTabletXixianFlask : BaseTablet
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

        }

        public override void ClickFunction()
        {
            base.ClickFunction();

        }
    }
    internal class SpringTabletDash : BaseTablet
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

        }

        public override void ClickFunction()
        {
            base.ClickFunction();

        }
    }
}
