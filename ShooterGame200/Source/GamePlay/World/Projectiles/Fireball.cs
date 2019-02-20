#region Includes
using System.Collections.Generic;
using Microsoft.Xna.Framework;
#endregion

namespace ShooterGame200
{ 
    public class Fireball : Projectile2d
    {

        public Fireball(Vector2 POS, Unit OWNER, Vector2 TARGET) 
            : base("2D\\Projectiles\\Fireball1", POS, new Vector2(30, 30), OWNER, TARGET)
        {         
        }
        public override void Update(Vector2 OFFSET, List<AttackableObject> UNITS)
        {
            base.Update(OFFSET, UNITS);
        }
        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }

    }
}
