using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace Urdveil.Common.EnemySystem
{
    internal class Limb
    {
        private Vector2 _prevLocalPosition;
        public Limb()
        {
            Joints = new List<Joint>();
        }
        public List<Joint> Joints { get; init; }
        public Limb Parent { get; set; }
        public Joint ParentJoint { get; set; }
        public Vector2 LocalOffset { get; set; }
        public bool DrawBackwards { get; set; }
        public void AddJoint(Joint joint)
        {
            Joints.Add(joint);
        }

        public Limb AddNewJoint(Vector2 direction, float length)
        {
            Joint joint = new Joint(_prevLocalPosition);
            joint.StartDirection = direction.SafeNormalize(Vector2.Zero);
            joint.Length = length;
            AddJoint(joint);
            _prevLocalPosition += joint.StartDirection * length;
            return this;
        }
        
        public Limb AddNewJoint(Vector2 direction, float length, string texture)
        {
            Joint joint = new Joint(_prevLocalPosition);
            joint.StartDirection = direction.SafeNormalize(Vector2.Zero);
            joint.Length = length;
            joint.Texture = ModContent.Request<Texture2D>(texture).Value;
            AddJoint(joint);
            _prevLocalPosition += joint.StartDirection * length;
            return this;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 basePosition, Vector2 screenPos, Color drawColor)
        {
            if (DrawBackwards)
            {
                for (int i = Joints.Count - 1; i > -1; i--)
                {
                    Joint joint = Joints[i];
                    Vector2 jointDrawPos = basePosition;
                    if (ParentJoint != null)
                    {
                        jointDrawPos += ParentJoint.LocalPosition;
                    }
                    jointDrawPos += LocalOffset;
                    joint.Draw(spriteBatch, jointDrawPos, ref drawColor);
                }
            }
            else
            {
                for (int i = 0; i < Joints.Count; i++)
                {
                    Joint joint = Joints[i];
                    Vector2 jointDrawPos = basePosition;
                    if (ParentJoint != null)
                    {
                        jointDrawPos += ParentJoint.LocalPosition;
                    }
                    jointDrawPos += LocalOffset;
                    joint.Draw(spriteBatch, jointDrawPos, ref drawColor);
                }
            }
        }
    }
}
