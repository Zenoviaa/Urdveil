using Microsoft.Xna.Framework;
using Urdveil.Common.Bases;
using Terraria.ModLoader;

namespace Urdveil.Items.Discs
{

    internal class AurelusTempleDisc : BaseDiscItem
    {
        public override string MusicPath => "Assets/Music/AurelusTemple";
        public override void SetDiscDefaults()
        {
            base.SetDiscDefaults();
            TileToPlace = ModContent.TileType<AurelusTempleDiscTile>();
            Penetrate = 2;
            TrailColor = Color.LightSkyBlue;
        }
    }

    internal class AurelusTempleDiscTile : BaseRecordTile
    {

    }


    internal class ADemiseDisc : BaseDiscItem
    {
        public override string MusicPath => "Assets/Music/ADemise";
        public override void SetDiscDefaults()
        {
            base.SetDiscDefaults();
            TileToPlace = ModContent.TileType<ADemiseDiscTile>();
            Penetrate = 2;
            TrailColor = Color.LightGray;
        }
    }

    internal class ADemiseDiscTile : BaseRecordTile
    {

    }


    internal class AlcadizHurricaneDisc : BaseDiscItem
    {
        public override string MusicPath => "Assets/Music/AlcadizHurricane";
        public override void SetDiscDefaults()
        {
            base.SetDiscDefaults();
            TileToPlace = ModContent.TileType<AlcadizHurricaneDiscTile>();
            Penetrate = 2;
            TrailColor = Color.LightSalmon;
        }
    }

    internal class AlcadizHurricaneDiscTile : BaseRecordTile
    {

    }

    internal class AlcaricFoxDisc : BaseDiscItem
    {
        public override string MusicPath => "Assets/Music/AlcaricFox";
        public override void SetDiscDefaults()
        {
            base.SetDiscDefaults();
            TileToPlace = ModContent.TileType<AlcaricFoxDiscTile>();
            Penetrate = 2;
            TrailColor = Color.White;
        }
    }

    internal class AlcaricFoxDiscTile : BaseRecordTile
    {

    }

    internal class AshotiDisc : BaseDiscItem
    {
        public override string MusicPath => "Assets/Music/Ashoti";
        public override void SetDiscDefaults()
        {
            base.SetDiscDefaults();
            TileToPlace = ModContent.TileType<AshotiDiscTile>();
            Penetrate = 2;
            TrailColor = Color.Orange;
        }
    }

    internal class AshotiDiscTile : BaseRecordTile
    {

    }

    internal class BloodCathedralDisc : BaseDiscItem
    {
        public override string MusicPath => "Assets/Music/BloodCathedral";
        public override void SetDiscDefaults()
        {
            base.SetDiscDefaults();
            TileToPlace = ModContent.TileType<BloodCathedralDiscTile>();
            Penetrate = 2;
            TrailColor = Color.Red;
        }
    }

    internal class BloodCathedralDiscTile : BaseRecordTile
    {

    }

    internal class STARBOMBERDisc : BaseDiscItem
    {
        public override string MusicPath => "Assets/Music/STARBOMBER";
        public override void SetDiscDefaults()
        {
            base.SetDiscDefaults();
            TileToPlace = ModContent.TileType<STARBOMBERDiscTile>();
            Penetrate = 2;
            TrailColor = Color.Purple;
        }
    }

    internal class STARBOMBERDiscTile : BaseRecordTile
    {

    }

    internal class CatacombsDisc : BaseDiscItem
    {
        public override string MusicPath => "Assets/Music/Catacombs";
        public override void SetDiscDefaults()
        {
            base.SetDiscDefaults();
            TileToPlace = ModContent.TileType<CatacombsDiscTile>();
            Penetrate = 2;
            TrailColor = Color.Brown;
        }
    }

    internal class CatacombsDiscTile : BaseRecordTile
    {

    }

    internal class CindersparkDisc : BaseDiscItem
    {
        public override string MusicPath => "Assets/Music/Cinderspark";
        public override void SetDiscDefaults()
        {
            base.SetDiscDefaults();
            TileToPlace = ModContent.TileType<CindersparkDiscTile>();
            Penetrate = 2;
            TrailColor = Color.OrangeRed;
        }
    }

    internal class CindersparkDiscTile : BaseRecordTile
    {

    }

    internal class CountingStarsDisc : BaseDiscItem
    {
        public override string MusicPath => "Assets/Music/CountingStars";
        public override void SetDiscDefaults()
        {
            base.SetDiscDefaults();
            TileToPlace = ModContent.TileType<CountingStarsDiscTile>();
            Penetrate = 2;
            TrailColor = Color.LightPink;
        }
    }

    internal class CountingStarsDiscTile : BaseRecordTile
    {

    }

    internal class DaedusDisc : BaseDiscItem
    {
        public override string MusicPath => "Assets/Music/Daedus";
        public override void SetDiscDefaults()
        {
            base.SetDiscDefaults();
            TileToPlace = ModContent.TileType<DaedusDiscTile>();
            Penetrate = 2;
            TrailColor = Color.Goldenrod;
        }
    }

    internal class DaedusDiscTile : BaseRecordTile
    {

    }

    internal class DreadHeartDisc : BaseDiscItem
    {
        public override string MusicPath => "Assets/Music/DreadHeart";
        public override void SetDiscDefaults()
        {
            base.SetDiscDefaults();
            TileToPlace = ModContent.TileType<DreadHeartDiscTile>();
            Penetrate = 2;
            TrailColor = Color.DarkRed;
        }
    }

    internal class DreadHeartDiscTile : BaseRecordTile
    {

    }

    internal class EndingDisc : BaseDiscItem
    {
        public override string MusicPath => "Assets/Music/Ending";
        public override void SetDiscDefaults()
        {
            base.SetDiscDefaults();
            TileToPlace = ModContent.TileType<EndingDiscTile>();
            Penetrate = 2;
            TrailColor = Color.LightBlue;
        }
    }

    internal class EndingDiscTile : BaseRecordTile
    {

    }

    internal class EreshkigalDisc : BaseDiscItem
    {
        public override string MusicPath => "Assets/Music/Ereshkigal";
        public override void SetDiscDefaults()
        {
            base.SetDiscDefaults();
            TileToPlace = ModContent.TileType<EreshkigalDiscTile>();
            Penetrate = 2;
            TrailColor = Color.Goldenrod;
        }
    }

    internal class EreshkigalDiscTile : BaseRecordTile
    {

    }

    internal class GintzicaneDisc : BaseDiscItem
    {
        public override string MusicPath => "Assets/Music/Gintzicane";
        public override void SetDiscDefaults()
        {
            base.SetDiscDefaults();
            TileToPlace = ModContent.TileType<GintzicaneDiscTile>();
            Penetrate = 2;
            TrailColor = Color.LightGray;
        }
    }

    internal class GintzicaneDiscTile : BaseRecordTile
    {

    }


    internal class GothiviaDisc : BaseDiscItem
    {
        public override string MusicPath => "Assets/Music/Gothivia";
        public override void SetDiscDefaults()
        {
            base.SetDiscDefaults();
            TileToPlace = ModContent.TileType<GothiviaDiscTile>();
            Penetrate = 2;
            TrailColor = Color.Teal;
        }
    }

    internal class GothiviaDiscTile : BaseRecordTile
    {

    }

    internal class GovheilCastleDisc : BaseDiscItem
    {
        public override string MusicPath => "Assets/Music/GovheilCastle";
        public override void SetDiscDefaults()
        {
            base.SetDiscDefaults();
            TileToPlace = ModContent.TileType<GovheilCastleDiscTile>();
            Penetrate = 2;
            TrailColor = Color.MistyRose;
        }
    }

    internal class GovheilCastleDiscTile : BaseRecordTile
    {

    }

    internal class AurelusBiomeDisc : BaseDiscItem
    {
        public override string MusicPath => "Assets/Music/AurelusBiome";
        public override void SetDiscDefaults()
        {
            base.SetDiscDefaults();
            TileToPlace = ModContent.TileType<AurelusBiomeDiscTile>();
            Penetrate = 2;
            TrailColor = Color.LightCyan;
        }
    }

    internal class AurelusBiomeDiscTile : BaseRecordTile
    {

    }

    internal class PunkerSteamDisc : BaseDiscItem
    {
        public override string MusicPath => "Assets/Music/PunkerSteam";
        public override void SetDiscDefaults()
        {
            base.SetDiscDefaults();
            TileToPlace = ModContent.TileType<PunkerSteamDiscTile>();
            Penetrate = 2;
            TrailColor = Color.LightYellow;
        }
    }

    internal class PunkerSteamDiscTile : BaseRecordTile
    {

    }

    internal class IshtarDisc : BaseDiscItem
    {
        public override string MusicPath => "Assets/Music/Ishtar";
        public override void SetDiscDefaults()
        {
            base.SetDiscDefaults();
            TileToPlace = ModContent.TileType<IshtarDiscTile>();
            Penetrate = 2;
            TrailColor = Color.White;
        }
    }

    internal class IshtarDiscTile : BaseRecordTile
    {

    }
}
