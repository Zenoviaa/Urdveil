using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urdveil.Common.EnemySystem;

namespace Urdveil.NPCsUrdveil.SpringHills.ThornKnight
{
    internal class ThornKnight : BaseKnightNPC
    {
        private ref float Timer => ref NPC.ai[0];
        public override void AI()
        {
            base.AI();
            BackShoulderJoint.Rotation += 0.01f;
            BackForeArmJoint.Rotation += 0.01f;
            FrontThighJoint.Rotation += 0.01f;
        }
    }
}
