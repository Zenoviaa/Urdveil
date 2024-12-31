using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace Urdveil.Common.EnemySystem
{
    internal abstract class BaseKnightNPC : BaseRiggedNPC
    {
        public Asset<Texture2D>[] Textures { get; private set; }

        //Joints
        public Joint FrontForeArmJoint;
        public Joint FrontShoulderJoint;

        public Joint BackForeArmJoint;
        public Joint BackShoulderJoint;

        public Joint FrontThighJoint;
        public Joint FrontKneeJoint;
        public Joint FrontLegJoint;

        public Joint BackThighJoint;
        public Joint BackKneeJoint;
        public Joint BackLegJoint;

        public Joint HeadJoint;
        public Joint TorsoJoint;
        public Joint WaistJoint;


        //Limbs
        public Limb FrontLegLimb { get; set; }
        public Limb BackLegLimb { get; set; }
        public Limb TorsoLimb { get; set; }
        public Limb FrontArmLimb { get; set; }
        public Limb BackArmLimb { get; set; }

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

        }


        public override void SetDefaults()
        {
            base.SetDefaults();
            NPC.width = 30;
            NPC.height = 80;
            NPC.damage = 32;
            NPC.knockBackResist = 0.5f;
            NPC.lifeMax = 120;

        }

        public override void SetLimbDefaults()
        {
            base.SetLimbDefaults();
            Textures = new Asset<Texture2D>[13];
            Textures[0] = ModContent.Request<Texture2D>(Texture + "_FrontForeArm");
            Textures[1] = ModContent.Request<Texture2D>(Texture + "_FrontShoulder");

            Textures[2] = ModContent.Request<Texture2D>(Texture + "_BackForeArm");
            Textures[3] = ModContent.Request<Texture2D>(Texture + "_BackShoulder");

            Textures[4] = ModContent.Request<Texture2D>(Texture + "_FrontThigh");
            Textures[5] = ModContent.Request<Texture2D>(Texture + "_FrontKnee");
            Textures[6] = ModContent.Request<Texture2D>(Texture + "_FrontLeg");

            Textures[7] = ModContent.Request<Texture2D>(Texture + "_BackThigh");
            Textures[8] = ModContent.Request<Texture2D>(Texture + "_BackKnee");
            Textures[9] = ModContent.Request<Texture2D>(Texture + "_BackLeg");

            Textures[10] = ModContent.Request<Texture2D>(Texture + "_Head");
            Textures[11] = ModContent.Request<Texture2D>(Texture + "_Torso");
            Textures[12] = ModContent.Request<Texture2D>(Texture + "_Waist");

            BackArmLimb = MakeLimb()
                .AddNewJoint(Textures[1])
                .AddNewJoint(Textures[0]);



            BackLegLimb = MakeLimb()
                .AddNewJoint(Textures[7])
                .AddNewJoint(Textures[8])
                .AddNewJoint(Textures[9]);

            TorsoLimb = MakeLimb()
                .AddNewJoint(Textures[10])
                .AddNewJoint(Textures[11])
                .AddNewJoint(Textures[12]);

            FrontLegLimb = MakeLimb()
                .AddNewJoint(Textures[4])
                .AddNewJoint(Textures[5])
                .AddNewJoint(Textures[6]);

            FrontArmLimb = MakeLimb()
                .AddNewJoint(Textures[3])
                .AddNewJoint(Textures[2]);

            //Back Arm Joints
            BackShoulderJoint = BackArmLimb.Joints[0];
            BackForeArmJoint = BackArmLimb.Joints[1];

            //Front Arm Joints
            FrontShoulderJoint = FrontArmLimb.Joints[0];
            FrontForeArmJoint = FrontArmLimb.Joints[1];

            //Front Leg Joints
            FrontThighJoint = FrontLegLimb.Joints[0];
            FrontKneeJoint = FrontLegLimb.Joints[1];
            FrontLegJoint = FrontLegLimb.Joints[2];

            //Back Leg Joints
            BackThighJoint = BackLegLimb.Joints[0];
            BackKneeJoint = BackLegLimb.Joints[1];
            BackLegJoint = BackLegLimb.Joints[2];

            //Torso Joints
            HeadJoint = TorsoLimb.Joints[0];
            TorsoJoint = TorsoLimb.Joints[1];
            WaistJoint = TorsoLimb.Joints[2];

            //Connect Arms
            BackArmLimb.ParentJoint = TorsoJoint;
            BackArmLimb.LocalOffset = new Vector2(8, 6);
            FrontArmLimb.ParentJoint = TorsoJoint;
            FrontArmLimb.LocalOffset = new Vector2(-8, 6);

            //Connect Legs
            BackLegLimb.ParentJoint = WaistJoint;
            BackLegLimb.LocalOffset = new Vector2(8, -4);
            FrontLegLimb.ParentJoint = WaistJoint;
        }
    }
}
