#region Includes
using System;
using Microsoft.Xna.Framework;
#endregion


namespace ShooterGame200
{
    public class FlameCircle : Effect2d
    {
        
        public FlameCircle(Vector2 POS, Vector2 DIMS,int MSEC) : base("2D\\Effects\\explosion", POS, new Vector2(220, 220), new Vector2(1, 1), MSEC)
        {            
        }

        public override void Update(Vector2 OFFSET)
        {
            rot += (float)Math.PI * 2.0f / 60.0f;
           base.Update(OFFSET);
        }

    }
}
