#region Includes
using System.Collections.Generic;
using Microsoft.Xna.Framework;
#endregion

namespace ShooterGame200
{
    public class FlameWaveProjectile : StillInvisibleProjectile
    {


        public FlameWaveProjectile(Vector2 POS, AttackableObject OWNER, Vector2 TARGET, int MSEC)
            : base(POS, new Vector2(150, 150), OWNER, TARGET, MSEC)
        {
            GameGlobals.PassEffect(new FlameCircle(new Vector2(POS.X, POS.Y), new Vector2(dims.X, dims.Y), MSEC));
        }

        public override void ChangePosition()
        {

        }

        public override void Update(Vector2 OFFSET, List<AttackableObject> UNITS)
        {
            base.Update(OFFSET, UNITS);
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
