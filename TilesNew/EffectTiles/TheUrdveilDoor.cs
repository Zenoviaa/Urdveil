using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Urdveil.Helpers;
using Urdveil.Tiles;

namespace Urdveil.TilesNew.EffectTiles
{
    internal class TheUrdveilDoor : DecorativeWall
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            //Number of frames in the animation
            FrameCount = 1;
            Origin = DrawOrigin.BottomUp;
            ClickFunc = UseDoor;
            HoverFunc = HoverOver;
        }

        private void HoverOver()
        {
            Player player = Main.LocalPlayer;
            player.cursorItemIconID = -1;
            player.cursorItemIconText = LangText.Misc("UrdveilDoor");
            player.cursorItemIconEnabled = true;
        }

        private void UseDoor()
        {
            SoundEngine.PlaySound(SoundID.AchievementComplete);
        }
    }
}
