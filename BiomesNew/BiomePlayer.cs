using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Urdveil.Gores.Foreground;
using Urdveil.Helpers;

namespace Urdveil.BiomesNew
{
    internal class BiomePlayer : ModPlayer
    {
        private float _windCounter;
        public bool ZoneSpringHills;
        public override void ResetEffects()
        {
            base.ResetEffects();
        }
        public override void PreUpdate()
        {
            if (Main.hasFocus)
                AddForegroundOrBackground();
        }

        private void AddForegroundOrBackground()
        {
            SpringHillsForegroundBackground();
        }

        private void SpringHillsForegroundBackground()
        {
            //Only do this in spring hills
            if (!ZoneSpringHills)
                return;
            _windCounter--;
            if(_windCounter <= 0)
            {
                if (Main.rand.NextBool(2))
                {
                    Main.windSpeedTarget = (float)Main.rand.Next(-50, -25) * 0.01f;
                }
                else
                {
                    Main.windSpeedTarget = (float)Main.rand.Next(25, 50) * 0.01f;
                }
            
                _windCounter = 1200;
            }
       

            int spawnChance = -1;
            //CHERRY BLOSSOM

            spawnChance = Cherryblossom.SpawnChance(Player);
            if (spawnChance != -1 && Main.rand.NextBool(spawnChance))
            {
                bool spawnForegroundItem = true;
                bool spawnOnPlayerLayer = true;
                Vector2 pos = Player.Center - new Vector2(Main.rand.Next(-(int)(Main.screenWidth * 2f), (int)(Main.screenWidth * 2f)), Main.screenHeight * 0.52f);
                ForegroundHelper.AddItem(new Cherryblossom(pos), spawnForegroundItem, spawnOnPlayerLayer);
            }

            spawnChance = SpringFallingFlower.SpawnChance(Player);
            if (spawnChance != -1 && Main.rand.NextBool(spawnChance))
            {
                bool spawnForegroundItem = true;
                bool spawnOnPlayerLayer = true;
                Vector2 pos = Player.Center - new Vector2(Main.rand.Next(-(int)(Main.screenWidth * 2f), (int)(Main.screenWidth * 2f)), Main.screenHeight * 0.52f);
                ForegroundHelper.AddItem(new SpringFallingFlower(pos), spawnForegroundItem, spawnOnPlayerLayer);
            }
        }
    }
}
