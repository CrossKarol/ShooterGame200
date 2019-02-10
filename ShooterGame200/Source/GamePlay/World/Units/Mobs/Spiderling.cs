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
    public class Spiderling : Mob
    {


        public McTimer spawnTimer;

        public Spiderling(Vector2 POS, Vector2 FRAMES, int OWNERID) 
            : base("2D\\Units\\Mobs\\Spider", POS, new Vector2(25, 25), FRAMES,  OWNERID)
        {
            speed = 2.5f;
        }

        public override void Update(Vector2 OFFSET, Player ENEMY, SquareGrid GRID)
        {
            base.Update(OFFSET, ENEMY, GRID);
        }

        public override void AI(Player ENEMY, SquareGrid GIRD)
        {
            Building temp = null;
            for(int i=0; i<ENEMY.buildings.Count; i++)
            {
                if(ENEMY.buildings[i].GetType().ToString() == "ShooterGame200.Tower")
                {
                    temp = ENEMY.buildings[i];
                }

            }

            if (temp != null)
            {
                if (pathNodes == null || pathNodes.Count == 0 && pos.X == moveTo.X && pos.Y == moveTo.Y)
                {
                    pathNodes = FindPath(GIRD, GIRD.GetSlotFromPixel(temp.pos, Vector2.Zero));
                    moveTo = pathNodes[0];
                    pathNodes.RemoveAt(0);
                }
                else
                {

                    MoveUnit();

                    if (Globals.GetDistance(pos, temp.pos) < GIRD.slotDims.X * 1.2f)
                    {
                        temp.GetHit(1);
                        dead = true;
                    }
                }
            }
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }

    }
}
