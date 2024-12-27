using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace Urdveil.Common.EnemySystem
{
    internal abstract class BaseKnightNPC : ModNPC
    {
        //Joints
        public Joint LeftForeArm;
        public Joint LeftShoulder;

        public Joint RightForeArm;
        public Joint RightShoulder;

        public Joint LeftThigh;
        public Joint LeftKnee;
        public Joint LeftLeg;

        public Joint RightThigh;
        public Joint RightKnee;
        public Joint RightLeg;

        public Joint Head;
        public Joint Torso;
        public Joint Waist;
     
    }
}
