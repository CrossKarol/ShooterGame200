#region Includes
using System.Collections.Generic;
using Microsoft.Xna.Framework;
#endregion

namespace ShooterGame200
{
    public class StillInvisibleProjectile : Projectile2d
    {

        float ticks;
        float currentTick;

        public StillInvisibleProjectile(Vector2 POS, Vector2 DIMS, AttackableObject OWNER, Vector2 TARGET, int MSEC)
            : base("2d\\Misc\\bar", POS, DIMS, OWNER, TARGET)
        {
            ticks = 3;
            currentTick = 0;

            timer = new McTimer(MSEC);
        }

        public override void Update(Vector2 OFFSET, List<AttackableObject> UNITS)
        {
            base.Update(OFFSET, UNITS);


            if(timer.Timer >= timer.MSec * (currentTick/(ticks - 1)))
            {

                for(int i=0; i<UNITS.Count; i++)
                {
                    if(Globals.GetDistance(UNITS[i].pos, pos) <= dims.X/2)
                    {
                        UNITS[i].GetHit(owner, 1.0f);
                    }
                }

                currentTick=currentTick+1;
            }
        }

        public override void ChangePosition()
        {
            
        }

        public override bool HitSomething(List<AttackableObject> UNITS)
        {
            return false;
        }

        public override void Draw(Vector2 OFFSET)
        {
            
        }
    }
}
