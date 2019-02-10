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
    public class Arrow : Projectile2d
    {

        public Arrow(Vector2 POS, AttackableObject OWNER, Vector2 TARGET) 
            : base("2D\\Projectiles\\Arrow", POS, new Vector2(8, 20), OWNER, TARGET)
        {
            speed = 10.0f;

            timer = new McTimer(800);
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
