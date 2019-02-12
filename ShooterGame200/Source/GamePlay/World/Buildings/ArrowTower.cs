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
    public class ArrowTower : Building
    {
        int range;

        McTimer shotTimer = new McTimer(12000);


        public ArrowTower(Vector2 POS, Vector2 FRAMES, int OWNERID) 
            : base("2D\\Buildings\\ArrowTower", POS, new Vector2(45, 45), FRAMES, OWNERID)
        {
            range = 220;

            health = 10;
            healthMax = health;

            hitDist = 35.0f;
        }

        public override void Update(Vector2 OFFSET, Player ENEMY, SquareGrid GRID, LevelDrawManager LEVELDRAWMANAGER)
        {
            shotTimer.UpdateTimer();
            if (shotTimer.Test())
            {
                FireArrow(ENEMY);
                shotTimer.ResetToZero();
            }

            base.Update(OFFSET, ENEMY, GRID,LEVELDRAWMANAGER);
        }
        public virtual void FireArrow(Player ENEMY)
        {
            float closestDist = range, currentDist = 0;
            Unit closest = null;


            for(int i=0; i<ENEMY.units.Count; i++)
            {
                currentDist = Globals.GetDistance(pos, ENEMY.units[i].pos);

                if(closestDist > currentDist)
                {
                    closestDist = currentDist;
                    closest = ENEMY.units[i];
                }
            }


            if(closest != null)
            {
                GameGlobals.PassProjectile(new Arrow(new Vector2(pos.X, pos.Y), this, new Vector2(closest.pos.X, closest.pos.Y)));
            }
        }


        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }

    }
}
