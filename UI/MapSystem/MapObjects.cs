using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Urdveil.Common.Players;

namespace Urdveil.UI.MapSystem
{
    internal class Background : SimpleUIBackground
    {

    }

    internal class Border : SimpleUIBackground
    {

    }

    internal class Border2 : SimpleUIBackground
    {

    }

    internal class Compass : SimpleUIBackground
    {

    }

    internal class SpringHills : SimpleUIBackground
    {
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            MapPlayer mapPlayer = Main.LocalPlayer.GetModPlayer<MapPlayer>();
            Color = mapPlayer.mapPieceSpringHillsInner ? Color.White : Color.Lerp(Color.White, Color.Black, 0.8f);
        }
    }

    internal class WarriorsDoor : SimpleUIBackground
    {
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            MapPlayer mapPlayer = Main.LocalPlayer.GetModPlayer<MapPlayer>();
            Color = mapPlayer.mapPieceWarriorsDoor ? Color.White : Color.Lerp(Color.White, Color.Black, 0.8f);
        }
    }
    internal class WitchTown : SimpleUIBackground
    {
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            MapPlayer mapPlayer = Main.LocalPlayer.GetModPlayer<MapPlayer>();
            Color = mapPlayer.mapPieceWitchTown ? Color.White : Color.Lerp(Color.White, Color.Black, 0.8f);
        }
    }
}
