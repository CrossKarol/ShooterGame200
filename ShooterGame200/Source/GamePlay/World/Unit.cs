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
    public class Unit : AttackableObject
    {

        protected Vector2 moveTo;

        protected List<Vector2> pathNodes = new List<Vector2>();


        public Unit(string PATH, Vector2 POS, Vector2 DIMS, Vector2 FRAMES, int OWNERID) 
            : base(PATH, POS, DIMS, FRAMES, OWNERID)
        {
            moveTo = new Vector2(POS.X, POS.Y);
        }

        public override void Update(Vector2 OFFSET, Player ENEMY, SquareGrid GRID, LevelDrawManager LEVELDRAWMANAGER)
        {
            base.Update(OFFSET,ENEMY, GRID, LEVELDRAWMANAGER);
        }

        public virtual List<Vector2> FindPath(SquareGrid GRID, Vector2 ENDSLOT)
        {
            pathNodes.Clear();

            Vector2 tempStarSlot = GRID.GetSlotFromPixel(pos, Vector2.Zero);

            List<Vector2> tempPath = GRID.GetPath(tempStarSlot, ENDSLOT, true);

            if(tempPath == null || tempPath.Count == 0)
            {

            }
            return tempPath;
        }

        public virtual void MoveUnit()
        {
            if(pos.X != moveTo.X || pos.Y != moveTo.Y)
            {
                rot = Globals.RotateTowards(pos, moveTo);

                pos += Globals.RadialMovement(moveTo, pos, speed);

            }
            else if(pathNodes.Count > 0)
            {
                moveTo = pathNodes[0];
                pathNodes.RemoveAt(0);

                pos += Globals.RadialMovement(moveTo, pos, speed);
            }
          
        }


        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }

    }
}
