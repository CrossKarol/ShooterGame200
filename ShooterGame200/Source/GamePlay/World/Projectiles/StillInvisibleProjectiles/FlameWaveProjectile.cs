#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
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

        public override void Update(Vector2 OFFSET, List<AttackableObject> UNITS)
        {
            base.Update(OFFSET, UNITS);
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
