﻿//This will make it stop trying to use other things oh my god let's goooo
global using Vector2 = Microsoft.Xna.Framework.Vector2;
global using Point = Microsoft.Xna.Framework.Point;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Urdveil.Backgrounds;
using Urdveil.Common.Shaders;
using Urdveil.Helpers;
using Urdveil.Items.Materials;
using Urdveil.Skies;
using System.IO;
using System.Reflection;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.GameContent.UI;
using Terraria.GameContent.UI.Elements;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.UI;


namespace Urdveil
{


    public class Urdveil : Mod
    {
        public const string EMPTY_TEXTURE = "Urdveil/Empty";
        public static Texture2D EmptyTexture
        {
            get;
            private set;
        }
        public int GlobalTimer { get; private set; }

        public Urdveil()
        {
            Instance = this;

        }

        public ModPacket GetPacket(MessageType type, int capacity)
        {
            ModPacket packet = GetPacket(capacity + 1);
            packet.Write((byte)type);
            return packet;
        }

        // this is alright, and i'll expand it so it can still be used, but really this shouldn't be used
        public static ModPacket WriteToPacket(ModPacket packet, byte msg, params object[] param)
        {
            packet.Write(msg);

            for (int m = 0; m < param.Length; m++)
            {
                object obj = param[m];
                if (obj is bool) packet.Write((bool)obj);
                else if (obj is byte) packet.Write((byte)obj);
                else if (obj is int) packet.Write((int)obj);
                else if (obj is float) packet.Write((float)obj);
                else if (obj is double) packet.Write((double)obj);
                else if (obj is short) packet.Write((short)obj);
                else if (obj is ushort) packet.Write((ushort)obj);
                else if (obj is sbyte) packet.Write((sbyte)obj);
                else if (obj is uint) packet.Write((uint)obj);
                else if (obj is decimal) packet.Write((decimal)obj);
                else if (obj is long) packet.Write((long)obj);
                else if (obj is string) packet.Write((string)obj);
            }
            return packet;
        }

        public override void HandlePacket(BinaryReader reader, int whoAmI) => StellaMultiplayer.HandlePacket(reader, whoAmI);


        public static Player PlayerExists(int whoAmI)
        {
            return whoAmI > -1 && whoAmI < Main.maxPlayers && Main.player[whoAmI].active && !Main.player[whoAmI].dead && !Main.player[whoAmI].ghost ? Main.player[whoAmI] : null;
        }





        public static Urdveil Instance;
        public static int MedalCurrencyID;



        public static int MOKCurrencyID;
        public static int MOPCurrencyID;

        public static int MOBCurrencyID;
        public static int MOACurrencyID;
        public static int MOCCurrencyID;
        public static int MOHCurrencyID;
        public static int MOLCurrencyID;
        public override void Load()
        {

            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            if (Main.netMode != NetmodeID.Server)
            {
                ShaderRegistry.LoadShaders();
                CrystalShaderRegistry.LoadShaders();
                MedalCurrencyID = CustomCurrencyManager.RegisterCurrency(new Helpers.Medals(ModContent.ItemType<Medal>(), 999L, "Ruin medals"));

                //----------------------------------------------- Shaders
                Filters.Scene["Urdveil:Daedussss"] = new Filter(new DaedusScreenShaderData("FilterMiniTower").UseColor(-0.3f, -0.3f, -0.3f).UseOpacity(0.375f), EffectPriority.Medium);
                Filters.Scene["Urdveil:Jellyfish1"] = new Filter(new DaedusScreenShaderData("FilterMiniTower").UseColor(-0.3f, -0.3f, -0.3f).UseOpacity(0.375f), EffectPriority.Medium);
                Filters.Scene["Urdveil:Ishtar"] = new Filter(new DaedusScreenShaderData("FilterMiniTower").UseColor(-0.6f, -0.6f, -0.6f).UseOpacity(0.375f), EffectPriority.Medium);
                Filters.Scene["Urdveil:Jellyfish2"] = new Filter(new DaedusScreenShaderData("FilterMiniTower").UseColor(-0.3f, -0.3f, -0.3f).UseOpacity(0.475f), EffectPriority.Medium);
                Filters.Scene["Urdveil:Mechanics"] = new Filter(new DaedusScreenShaderData("FilterMiniTower").UseColor(-0.3f, -0.3f, -0.3f).UseOpacity(0.375f), EffectPriority.Medium);
                Filters.Scene["Urdveil:Aurelus"] = new Filter(new AbyssScreenShaderData("FilterMiniTower").UseColor(0.2f, 0.0f, 1f).UseOpacity(0.375f), EffectPriority.Medium);
              //  Filters.Scene["Urdveil:Verlia"] = new Filter(new VerliaScreenShaderData("FilterMiniTower").UseColor(0.3f, 0.0f, 1f).UseOpacity(0.375f), EffectPriority.Medium);
                Filters.Scene["Urdveil:Acid"] = new Filter(new AcidScreenShaderData("FilterMiniTower").UseColor(0f, 1f, 0.3f).UseOpacity(0.275f), EffectPriority.Medium);
                Filters.Scene["Urdveil:Lab"] = new Filter(new AcidScreenShaderData("FilterMiniTower").UseColor(0f, 1f, 0.3f).UseOpacity(0.275f), EffectPriority.Medium);
             //   Filters.Scene["Urdveil:Veriplant"] = new Filter(new VeriplantScreenShaderData("FilterMiniTower").UseColor(0f, 1f, 0.3f).UseOpacity(0.275f), EffectPriority.Medium);
                Filters.Scene["Urdveil:Starbloom"] = new Filter(new AcidScreenShaderData("FilterMiniTower").UseColor(1f, 0.3f, 0.8f).UseOpacity(0.375f), EffectPriority.Medium);
                Filters.Scene["Urdveil:Govheil"] = new Filter(new AcidScreenShaderData("FilterMiniTower").UseColor(1f, 0.7f, 0f).UseOpacity(0.275f), EffectPriority.Medium);
                Filters.Scene["Urdveil:AuroreanStars"] = new Filter(new AuroreanStarsScreenShaderData("FilterMiniTower").UseColor(1.3f, 0.2f, 0.2f).UseOpacity(0.275f), EffectPriority.Medium);
                Filters.Scene["Urdveil:Gintzing"] = new Filter(new GintzeScreenShaderData("FilterMiniTower").UseColor(0.4f, 0.4f, 0.6f).UseOpacity(0.275f), EffectPriority.Medium);
                Filters.Scene["Urdveil:Caeva"] = new Filter(new CaevaScreenShaderData("FilterMiniTower").UseColor(0.1f, 0.6f, 0.65f).UseOpacity(0.375f), EffectPriority.Medium);
                Filters.Scene["Urdveil:Illuria"] = new Filter(new AuroreanStarsScreenShaderData("FilterMiniTower").UseColor(0.4f, -0.3f, 1.3f).UseOpacity(0.275f), EffectPriority.Medium);


                Filters.Scene["Urdveil:Veil"] = new Filter(new ChaosPScreenShaderData("FilterMiniTower").UseColor(0.7f, 0.1f, 0.2f).UseOpacity(0.275f), EffectPriority.VeryHigh);

                Ref<Effect> screenRef = new Ref<Effect>(ModContent.Request<Effect>("Urdveil/Effects/Shockwave", AssetRequestMode.ImmediateLoad).Value); // The path to the compiled shader file.
                Filters.Scene["Shockwave"] = new Filter(new ScreenShaderData(screenRef, "Shockwave"), EffectPriority.VeryHigh);
                Filters.Scene["Shockwave"].Load();

                Filters.Scene["Urdveil:GreenMoonSky"] = new Filter(new ScreenShaderData("FilterMiniTower").UseColor(0.1f, 0.2f, 0.5f).UseOpacity(0.53f), EffectPriority.High);
                SkyManager.Instance["Urdveil:GreenMoonSky"] = new GreenMoonSky();

                SkyManager.Instance["Urdveil:GovheilSky"] = new GovheilSky();
                Filters.Scene["Urdveil:GovheilSky"] = new Filter((new ScreenShaderData("FilterMiniTower")).UseColor(0f, 0f, 0f).UseOpacity(0f), EffectPriority.VeryHigh);


                Filters.Scene["Urdveil:Starbloom"] = new Filter(new StellaScreenShader("FilterMiniTower").UseColor(0.1f, 0, 0.3f).UseOpacity(0.9f), EffectPriority.VeryHigh);
                Filters.Scene["Urdveil:Starbloom"] = new Filter(new StellaScreenShader("FilterMiniTower").UseColor(0.5f, 0.2f, 0.7f).UseOpacity(0.65f), EffectPriority.VeryHigh);
                SkyManager.Instance["Urdveil:Starbloom"] = new StarbloomSky();
                SkyManager.Instance["Urdveil:NiiviSky"] = new NiiviSky();


                Ref<Effect> GenericLaserShader = new(Assets.Request<Effect>("Effects/LaserShader", AssetRequestMode.ImmediateLoad).Value);
                GameShaders.Misc["Urdveil:LaserShader"] = new MiscShaderData(GenericLaserShader, "TrailPass");

            }




            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


            //``````````````````````````````````````````````````````````````````````````````````````


            //`````````````````````````````````````````````````````````````````````````````





            if (!Main.dedServ && Main.netMode != NetmodeID.Server && ModContent.GetInstance<UrdveilClientConfig>().VanillaTexturesToggle == true)
            {
                Main.instance.LoadTiles(TileID.Dirt);
                TextureAssets.Tile[TileID.Dirt] = ModContent.Request<Texture2D>("Urdveil/Assets/Textures/DirtRE");

                Main.instance.LoadTiles(TileID.IceBlock);
                TextureAssets.Tile[TileID.IceBlock] = ModContent.Request<Texture2D>("Urdveil/Assets/Textures/IceRE");

                Main.instance.LoadTiles(TileID.SnowBlock);
                TextureAssets.Tile[TileID.SnowBlock] = ModContent.Request<Texture2D>("Urdveil/Assets/Textures/SnowRE");

                Main.instance.LoadWall(WallID.Dirt);
                TextureAssets.Wall[WallID.Dirt] = ModContent.Request<Texture2D>("Urdveil/Assets/Textures/DirtWallRE");

                Main.instance.LoadTiles(TileID.Stone);
                TextureAssets.Tile[TileID.Stone] = ModContent.Request<Texture2D>("Urdveil/Assets/Textures/StoneRE");

                Main.instance.LoadTiles(TileID.Grass);
                TextureAssets.Tile[TileID.Grass] = ModContent.Request<Texture2D>("Urdveil/Assets/Textures/GrassRE");

                Main.instance.LoadTiles(TileID.ClayBlock);
                TextureAssets.Tile[TileID.ClayBlock] = ModContent.Request<Texture2D>("Urdveil/Assets/Textures/ClayRE");

                Main.instance.LoadTiles(TileID.Sand);
                TextureAssets.Tile[TileID.Sand] = ModContent.Request<Texture2D>("Urdveil/Assets/Textures/SandRE");

                Main.instance.LoadTiles(TileID.HardenedSand);
                TextureAssets.Tile[TileID.HardenedSand] = ModContent.Request<Texture2D>("Urdveil/Assets/Textures/HardSandRE");

                Main.instance.LoadTiles(TileID.Sandstone);
                TextureAssets.Tile[TileID.Sandstone] = ModContent.Request<Texture2D>("Urdveil/Assets/Textures/StoneSandRE");

                Main.instance.LoadTiles(TileID.Mud);
                TextureAssets.Tile[TileID.Mud] = ModContent.Request<Texture2D>("Urdveil/Assets/Textures/MudRE");

                Main.instance.LoadTiles(TileID.CrimsonGrass);
                TextureAssets.Tile[TileID.CrimsonGrass] = ModContent.Request<Texture2D>("Urdveil/Assets/Textures/CrimGrassRE");

                Main.instance.LoadTiles(TileID.JungleGrass);
                TextureAssets.Tile[TileID.JungleGrass] = ModContent.Request<Texture2D>("Urdveil/Assets/Textures/MudGrassRE");

                Main.instance.LoadTiles(TileID.CorruptGrass);
                TextureAssets.Tile[TileID.CorruptGrass] = ModContent.Request<Texture2D>("Urdveil/Assets/Textures/CrorpGrassRE");

                Main.instance.LoadTiles(TileID.Crimstone);
                TextureAssets.Tile[TileID.Crimstone] = ModContent.Request<Texture2D>("Urdveil/Assets/Textures/CrimStoneRE");

                Main.instance.LoadTiles(TileID.WoodBlock);
                TextureAssets.Tile[TileID.WoodBlock] = ModContent.Request<Texture2D>("Urdveil/Assets/Textures/WoodRE");

                Main.instance.LoadTiles(TileID.GrayBrick);
                TextureAssets.Tile[TileID.GrayBrick] = ModContent.Request<Texture2D>("Urdveil/Assets/Textures/StoneBrickRE");

                Main.instance.LoadTiles(TileID.Pearlstone);
                TextureAssets.Tile[TileID.Pearlstone] = ModContent.Request<Texture2D>("Urdveil/Assets/Textures/PearlstoneRE");

                Main.instance.LoadTiles(TileID.GraniteBlock);
                TextureAssets.Tile[TileID.GraniteBlock] = ModContent.Request<Texture2D>("Urdveil/Assets/Textures/GraniteRE");

                Main.instance.LoadTiles(TileID.Granite);
                TextureAssets.Tile[TileID.Granite] = ModContent.Request<Texture2D>("Urdveil/Assets/Textures/GraniteRE");

                Main.instance.LoadTiles(TileID.MarbleBlock);
                TextureAssets.Tile[TileID.MarbleBlock] = ModContent.Request<Texture2D>("Urdveil/Assets/Textures/MarbRE");

                Main.instance.LoadTiles(TileID.Marble);
                TextureAssets.Tile[TileID.Marble] = ModContent.Request<Texture2D>("Urdveil/Assets/Textures/MarbRE");

                Main.instance.LoadTiles(TileID.MushroomGrass);
                TextureAssets.Tile[TileID.MushroomGrass] = ModContent.Request<Texture2D>("Urdveil/Assets/Textures/MushGrassRE");

                Main.instance.LoadTiles(TileID.Ebonstone);
                TextureAssets.Tile[TileID.Ebonstone] = ModContent.Request<Texture2D>("Urdveil/Assets/Textures/CrorpStoneRE");

                Main.instance.LoadTiles(TileID.Ash);
                TextureAssets.Tile[TileID.Ash] = ModContent.Request<Texture2D>("Urdveil/Assets/Textures/AshingRE");

                Main.instance.LoadTiles(TileID.ObsidianBrick);
                TextureAssets.Tile[TileID.ObsidianBrick] = ModContent.Request<Texture2D>("Urdveil/Assets/Textures/AshedRE");

                Main.instance.LoadTiles(TileID.Cloud);
                TextureAssets.Tile[TileID.Cloud] = ModContent.Request<Texture2D>("Urdveil/Assets/Textures/CloudRE");

                Main.instance.LoadTiles(TileID.Pearlsand);
                TextureAssets.Tile[TileID.Pearlsand] = ModContent.Request<Texture2D>("Urdveil/Assets/Textures/PearlSandRE");

                Main.instance.LoadTiles(TileID.SnowCloud);
                TextureAssets.Tile[TileID.SnowCloud] = ModContent.Request<Texture2D>("Urdveil/Assets/Textures/SnowCloudRE");
            }

            var config = ModContent.GetInstance<UrdveilClientConfig>();

            if (!Main.dedServ && Main.netMode != NetmodeID.Server && config.VanillaUIRespritesToggle)
            {
                //Replace UI
                string categoryPanel = "Urdveil/Assets/Textures/UI/CategoryPanel";
                string categoryPanelHot = "Urdveil/Assets/Textures/UI/CategoryPanelHot";

                TextureAssets.InventoryBack = ModContent.Request<Texture2D>(categoryPanel);
                TextureAssets.InventoryBack2 = ModContent.Request<Texture2D>(categoryPanel);
                TextureAssets.InventoryBack3 = ModContent.Request<Texture2D>(categoryPanel);
                TextureAssets.InventoryBack4 = ModContent.Request<Texture2D>(categoryPanel);
                TextureAssets.InventoryBack5 = ModContent.Request<Texture2D>(categoryPanel);
                TextureAssets.InventoryBack6 = ModContent.Request<Texture2D>(categoryPanel);
                TextureAssets.InventoryBack7 = ModContent.Request<Texture2D>(categoryPanel);
                TextureAssets.InventoryBack8 = ModContent.Request<Texture2D>(categoryPanel);
                TextureAssets.InventoryBack9 = ModContent.Request<Texture2D>(categoryPanel);
                TextureAssets.InventoryBack10 = ModContent.Request<Texture2D>(categoryPanelHot);
                TextureAssets.InventoryBack11 = ModContent.Request<Texture2D>(categoryPanelHot);
                TextureAssets.InventoryBack12 = ModContent.Request<Texture2D>(categoryPanelHot);
                TextureAssets.InventoryBack13 = ModContent.Request<Texture2D>(categoryPanelHot);
                TextureAssets.InventoryBack14 = ModContent.Request<Texture2D>(categoryPanelHot);
                TextureAssets.InventoryBack15 = ModContent.Request<Texture2D>(categoryPanelHot);
                TextureAssets.InventoryBack16 = ModContent.Request<Texture2D>(categoryPanelHot);
                TextureAssets.InventoryBack17 = ModContent.Request<Texture2D>(categoryPanelHot);
                TextureAssets.InventoryBack18 = ModContent.Request<Texture2D>(categoryPanelHot);
                TextureAssets.InventoryBack19 = ModContent.Request<Texture2D>(categoryPanelHot);


                TextureAssets.ScrollLeftButton = ModContent.Request<Texture2D>("Urdveil/Assets/Textures/UI/BackButton");
                TextureAssets.ScrollRightButton = ModContent.Request<Texture2D>("Urdveil/Assets/Textures/UI/ForwardButton");
            }


            On_UIWorldListItem.DrawSelf += (orig, self, spriteBatch) =>
            {
                orig(self, spriteBatch);
                DrawWorldSelectItemOverlay(self, spriteBatch);
            };


            Instance = this;
        }

        private void UnloadTile(int tileID)
        {
            TextureAssets.Tile[tileID] = ModContent.Request<Texture2D>($"Terraria/Images/Tiles_{tileID}");
        }

        private void UnloadWall(int wallID)
        {
            TextureAssets.Wall[wallID] = ModContent.Request<Texture2D>($"Terraria/Images/Wall_{wallID}");
        }

        private string InventoryBackPath(int tileID)
        {
            if (tileID == 0)
                return $"Terraria/Images/Inventory_Back";
            return $"Terraria/Images/Inventory_Back{tileID}";
        }


        public override void Unload()
        {
            StellaMultiplayer.Unload();

            if (!Main.dedServ)
            {
                string backButton = "Terraria/Images/UI/Bestiary/Button_Back";
                string forwardButton = "Terraria/Images/UI/Bestiary/Button_Forward";

                TextureAssets.InventoryBack = ModContent.Request<Texture2D>(InventoryBackPath(0));
                TextureAssets.InventoryBack2 = ModContent.Request<Texture2D>(InventoryBackPath(2));
                TextureAssets.InventoryBack3 = ModContent.Request<Texture2D>(InventoryBackPath(3));
                TextureAssets.InventoryBack4 = ModContent.Request<Texture2D>(InventoryBackPath(4));
                TextureAssets.InventoryBack5 = ModContent.Request<Texture2D>(InventoryBackPath(5));
                TextureAssets.InventoryBack6 = ModContent.Request<Texture2D>(InventoryBackPath(6));
                TextureAssets.InventoryBack7 = ModContent.Request<Texture2D>(InventoryBackPath(7));
                TextureAssets.InventoryBack8 = ModContent.Request<Texture2D>(InventoryBackPath(8));
                TextureAssets.InventoryBack9 = ModContent.Request<Texture2D>(InventoryBackPath(9));
                TextureAssets.InventoryBack10 = ModContent.Request<Texture2D>(InventoryBackPath(10));
                TextureAssets.InventoryBack11 = ModContent.Request<Texture2D>(InventoryBackPath(11));
                TextureAssets.InventoryBack12 = ModContent.Request<Texture2D>(InventoryBackPath(12));
                TextureAssets.InventoryBack13 = ModContent.Request<Texture2D>(InventoryBackPath(13));
                TextureAssets.InventoryBack14 = ModContent.Request<Texture2D>(InventoryBackPath(14));
                TextureAssets.InventoryBack15 = ModContent.Request<Texture2D>(InventoryBackPath(15));
                TextureAssets.InventoryBack16 = ModContent.Request<Texture2D>(InventoryBackPath(16));
                TextureAssets.InventoryBack17 = ModContent.Request<Texture2D>(InventoryBackPath(17));
                TextureAssets.InventoryBack18 = ModContent.Request<Texture2D>(InventoryBackPath(18));
                TextureAssets.InventoryBack19 = ModContent.Request<Texture2D>(InventoryBackPath(19));
                TextureAssets.ScrollLeftButton = ModContent.Request<Texture2D>(backButton);
                TextureAssets.ScrollRightButton = ModContent.Request<Texture2D>(forwardButton);
            }

            if (!Main.dedServ)
            {
                UnloadTile(TileID.Dirt);
                UnloadTile(TileID.IceBlock);
                UnloadTile(TileID.SnowBlock);
                UnloadWall(WallID.Dirt);
                UnloadTile(TileID.Stone);
                UnloadTile(TileID.Grass);
                UnloadTile(TileID.ClayBlock);
                UnloadTile(TileID.Sand);
                UnloadTile(TileID.HardenedSand);
                UnloadTile(TileID.Sandstone);
                UnloadTile(TileID.Mud);
                UnloadTile(TileID.CrimsonGrass);
                UnloadTile(TileID.JungleGrass);
                UnloadTile(TileID.CorruptGrass);
                UnloadTile(TileID.Crimstone);
                UnloadTile(TileID.WoodBlock);
                UnloadTile(TileID.GrayBrick);
                UnloadTile(TileID.Pearlstone);
                UnloadTile(TileID.GraniteBlock);
                UnloadTile(TileID.Granite);
                UnloadTile(TileID.MarbleBlock);
                UnloadTile(TileID.Marble);
                UnloadTile(TileID.MushroomGrass);
                UnloadTile(TileID.Ebonstone);
                UnloadTile(TileID.Ash);
                UnloadTile(TileID.ObsidianBrick);
                UnloadTile(TileID.Cloud);
                UnloadTile(TileID.Pearlsand);
                UnloadTile(TileID.SnowCloud);
            }
        }

        private void DrawWorldSelectItemOverlay(UIWorldListItem uiItem, SpriteBatch spriteBatch)
        {
            //    bool data = uiItem.Data.TryGetHeaderData(ModContent.GetInstance<WorldLoadGen>(), out var _data);
            UIElement WorldIcon = (UIElement)typeof(UIWorldListItem).GetField("_worldIcon", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(uiItem);
            WorldFileData Data = (WorldFileData)typeof(AWorldListItem).GetField("_data", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(uiItem);
            WorldIcon.RemoveAllChildren();


            UIElement worldIcon = WorldIcon;
            UIImage element = new UIImage(ModContent.Request<Texture2D>("Urdveil/Assets/Textures/Menu/LunarTree"))
            {
                Top = new StyleDimension(-10f, 0f),
                Left = new StyleDimension(-6f, 0f),
                IgnoresMouseInteraction = true
            };
            worldIcon.Append(element);


        }

    }
    #region UnopenedWorldIcon


    #endregion;

    public class Stellamenu : ModMenu
    {


        private const string menuAssetPath = "Urdveil/Assets/Textures/Menu"; // Creates a constant variable representing the texture path, so we don't have to write it out multiple times

        public override Asset<Texture2D> Logo => ModContent.Request<Texture2D>($"{menuAssetPath}/Logo");

        //  public override Asset<Texture2D> SunTexture => ModContent.Request<Texture2D>($"{menuAssetPath}/TheSun");

        //   public override Asset<Texture2D> MoonTexture => ModContent.Request<Texture2D>($"{menuAssetPath}/TheMoon");


        public override int Music => MusicLoader.GetMusicSlot(Mod, "Assets/Music/GreatMenu");

        public override ModSurfaceBackgroundStyle MenuBackgroundStyle => ModContent.GetInstance<StarbloomBackgroundStyle>();

        public override string DisplayName => "Urdveil";
        public override void OnSelected()
        {
            SoundEngine.PlaySound(SoundID.Tink);
        }

        public override bool PreDrawLogo(SpriteBatch spriteBatch, ref Vector2 logoDrawCenter, ref float logoRotation, ref float logoScale, ref Color drawColor)
        {
            return true;
        }
    }
}

