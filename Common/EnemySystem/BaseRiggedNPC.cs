using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace Urdveil.Common.EnemySystem
{
    internal abstract class BaseRiggedNPC : ModNPC
    {
        private bool _init;
        public List<Limb> Limbs { get; set; }
        public Limb MakeLimb()
        {
            Limbs ??= new List<Limb>();
            Limb limb = new Limb();
            Limbs.Add(limb);
            return limb;
        }

        public override void AI()
        {
            base.AI();
            if (!_init)
            {
                SetLimbDefaults();
                _init = true;
            }
            AI_SolveLimbs();
        }

        public virtual void SetLimbDefaults()
        {

        }

        private void AI_SolveLimbs()
        {
            foreach (Limb limb in Limbs)
            {
                for (int i = 1; i < limb.Joints.Count; i++)
                {
                    Joint joint = limb.Joints[i];
                    Joint prevJoint = limb.Joints[i - 1];
                    joint.Position = (
                        prevJoint.Position +
                        prevJoint.StartDirection.RotatedBy(prevJoint.Rotation) * prevJoint.Length);
                }
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            foreach (Limb limb in Limbs)
            {
                limb.Draw(spriteBatch, NPC.Center, screenPos, drawColor);
            }
            return false;
        }
    }
}
