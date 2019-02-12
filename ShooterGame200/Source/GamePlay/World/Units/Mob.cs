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
        public bool currentlyPathing;

        public McTimer rePathTimer = new McTimer(200);

        public Mob(string PATH, Vector2 POS, Vector2 DIMS, Vector2 FRAMES, int OWNERID)
            : base(PATH, POS, DIMS, FRAMES, OWNERID)
        {
            currentlyPathing = false;
            speed = 2.0f;
        }

        public override void Update(Vector2 OFFSET, Player ENEMY, SquareGrid GRID, LevelDrawManager LEVELDRAWMANAGER)
        {
            AI(ENEMY, GRID);

            base.Update(OFFSET, ENEMY, GRID, LEVELDRAWMANAGER);
        }

        public virtual void AI(Player ENEMY, SquareGrid GIRD)
        {
            rePathTimer.UpdateTimer();

            if (pathNodes == null || pathNodes.Count == 0 && pos.X == moveTo.X && pos.Y == moveTo.Y || rePathTimer.Test())
            {

                if (!currentlyPathing)
                {

                    Task repathTask = new Task(() =>
                    {
                        currentlyPathing = true;

                        pathNodes = FindPath(GIRD, GIRD.GetSlotFromPixel(ENEMY.hero.pos, Vector2.Zero));
                        moveTo = pathNodes[0];
                        pathNodes.RemoveAt(0);

                        rePathTimer.ResetToZero();

                        currentlyPathing = false;
                    });

                    repathTask.Start();
                }
            }
            else
            {

                MoveUnit();

                if (Globals.GetDistance(pos, ENEMY.hero.pos) < GIRD.slotDims.X * 1.2f)
                {
                    ENEMY.hero.GetHit(this, 1);
                    dead = true;
                }
            }

        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }

    }
}
