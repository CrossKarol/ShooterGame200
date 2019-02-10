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
    public class Mob : Unit
    {

        public Mob(string PATH, Vector2 POS, Vector2 DIMS, Vector2 FRAMES, int OWNERID)
            : base(PATH, POS, DIMS, FRAMES, OWNERID)
        {
            speed = 2.0f;
        }

        public override void Update(Vector2 OFFSET, Player ENEMY, SquareGrid GRID)
        {
            AI(ENEMY, GRID);

            base.Update(OFFSET, ENEMY, GRID);
        }

        public virtual void AI(Player ENEMY, SquareGrid GIRD)
        {
            pos += Globals.RadialMovement(ENEMY.hero.pos, pos, speed);
            rot = Globals.RotateTowards(pos, ENEMY.hero.pos);


            if(Globals.GetDistance(pos, ENEMY.hero.pos) < 15)
            {
                ENEMY.hero.GetHit(1);
                dead = true;
            }
        }


        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }

    }
}
