using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Urdveil.BiomesNew
{
    internal class BiomeNPCEdits : GlobalNPC
    {
        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
        {
            base.EditSpawnPool(pool, spawnInfo);
            if (spawnInfo.Player.GetModPlayer<BiomePlayer>().ZoneSpringHills && Main.dayTime)
            {
                //Some goobers
                pool[NPCID.Butterfly] = 1;
                pool[NPCID.LadyBug] = 1;
                pool[NPCID.Grasshopper] = 1;
            }
        }
    }
}
