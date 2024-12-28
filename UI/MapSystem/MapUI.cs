using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace Urdveil.UI.MapSystem
{
    internal class MapUI : UIPanel
    {
        internal int RelativeLeft => Main.screenWidth / 2 - (int)Width.Pixels / 2;
        internal int RelativeTop => Main.screenHeight / 2 - (int)Height.Pixels / 2;
        public Background Background { get; set; }
        public SpringHills SpringHills { get; set; }
        public WarriorsDoor WarriorsDoor { get; set; }
        public WitchTown WitchTown { get; set; }
        public Compass Compass { get; set; }    
        public Border Border { get; set; }

        public MapButton SpringHillsInnerButton { get; set; }
        public MapButton SpringHillsOuterButton { get; set; }
        public MapButton WarriorsDoorButton { get; set; }
        public MapButton WitchTownButton { get; set; }
        public MapMarker MapMarker { get; set; }
        public AreaPreview AreaPreview { get; set; }
        public MapUI()
        {
            Background = new Background();
            SpringHills = new SpringHills();
            WarriorsDoor = new WarriorsDoor();
            WitchTown = new WitchTown();
            Compass = new Compass();
            Border = new Border();
            MapMarker = new MapMarker();
            AreaPreview = new AreaPreview();

            SpringHillsInnerButton = new MapButton("SpringHillsInner", this, TeleportToSpringHillsInner);
            SpringHillsOuterButton = new MapButton("SpringHillsOuter", this, TeleportToSpringHillsOuter);
            WarriorsDoorButton = new MapButton("WarriorsDoor", this, TeleportToSpringHillsWarriorsDoor);
            WitchTownButton = new MapButton("WitchTown", this, TeleportToSpringHillsWitchTown);
        }

        public override void OnInitialize()
        {
            base.OnInitialize();
            Width.Pixels = 1280;
            Height.Pixels = 720;
            BackgroundColor = Color.Transparent;
            BorderColor = Color.Transparent;




    
            Append(Background);
            Append(SpringHills);
            Append(WarriorsDoor);
            Append(WitchTown);
            Append(Compass);
            Append(Border);
     

            Append(SpringHillsInnerButton);
            Append(SpringHillsOuterButton);
            Append(WarriorsDoorButton);
            Append(WitchTownButton);
            Append(MapMarker); 
            
            Append(AreaPreview);
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Left.Pixels = RelativeLeft;
            Top.Pixels = RelativeTop;


            //Set inner button hitbox
            SpringHillsInnerButton.Left.Pixels = 580;
            SpringHillsInnerButton.Top.Pixels = 300;
            SpringHillsInnerButton.Width.Pixels = 24;
            SpringHillsInnerButton.Height.Pixels = 80;

            //Set outer button hitbox
            SpringHillsOuterButton.Left.Pixels = 656;
            SpringHillsOuterButton.Top.Pixels = 300;
            SpringHillsOuterButton.Width.Pixels = 32;
            SpringHillsOuterButton.Height.Pixels = 96;

            //Set warriors door button hitbox
            WarriorsDoorButton.Left.Pixels = 605;
            WarriorsDoorButton.Top.Pixels = 320;
            WarriorsDoorButton.Width.Pixels = 48;
            WarriorsDoorButton.Height.Pixels = 48;

            //Set witch town hitbox
            WitchTownButton.Left.Pixels = 605;
            WitchTownButton.Top.Pixels = 293;
            WitchTownButton.Width.Pixels = 48;
            WitchTownButton.Height.Pixels = 24;

            AreaPreview.Left.Pixels = 16;
            AreaPreview.Top.Pixels = 32;
        }


        private void TeleportToSpringHillsInner()
        {

        }

        private void TeleportToSpringHillsOuter()
        {

        }

        private void TeleportToSpringHillsWarriorsDoor()
        {

        }

        private void TeleportToSpringHillsWitchTown()
        {

        }
    }

    internal class MapUIState : UIState
    {
        public MapUI ui;
        public MapUIState() : base()
        {

        }

        public override void OnInitialize()
        {
            base.OnInitialize();
            ui = new MapUI();
            Append(ui);
        }
    }
}
