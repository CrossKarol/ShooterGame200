﻿#region Includes
using System.Collections.Generic;
using Microsoft.Xna.Framework;
#endregion

namespace ShooterGame200
{
    public class Projectile2d : Basic2D
    {
        public bool done;
        public Vector2 direction;

        public AttackableObject owner;

        public float speed;


        public McTimer timer;

        public Projectile2d(string PATH, Vector2 POS, Vector2 DIMS, AttackableObject OWNER, Vector2 TARGET)
            : base(PATH, POS, DIMS)
        {
            done = false;
            speed = 5.0f;
            owner = OWNER;

            direction = TARGET - owner.pos;
            direction.Normalize();

            rot = Globals.RotateTowards(pos, new Vector2(TARGET.X, TARGET.Y));

            timer = new McTimer(1500);
        }

        public virtual void Update(Vector2 OFFSET, List<AttackableObject> UNITS)
        {
            ChangePosition();
            timer.UpdateTimer();
            if (timer.Test())
            {
                done = true;
            }
            if (HitSomething(UNITS))
            {
                done = true;
            }
        }
        public virtual bool HitSomething(List<AttackableObject> UNITS)
        {
            for (int i = 0; i < UNITS.Count; i++)
            {
                if (owner.ownerId != UNITS[i].ownerId && Globals.GetDistance(pos, UNITS[i].pos) < UNITS[i].hitDist)
                {
                    UNITS[i].GetHit(owner, 1);

                    return true;
                }
            }

            return false;
        }
        public virtual void ChangePosition()
        {
            pos += direction * speed;
        }
  


        public override void Draw(Vector2 OFFSET)
        {
            Globals.normalEffect.Parameters["xSize"].SetValue((float)myModel.Bounds.Width);
            Globals.normalEffect.Parameters["ySize"].SetValue((float)myModel.Bounds.Height);
            Globals.normalEffect.Parameters["xDraw"].SetValue((float)((int)dims.X));
            Globals.normalEffect.Parameters["yDraw"].SetValue((float)((int)dims.Y));
            Globals.normalEffect.Parameters["filterColor"].SetValue(Color.White.ToVector4());
            Globals.normalEffect.CurrentTechnique.Passes[0].Apply();

            base.Draw(OFFSET);
        }
    }
}
