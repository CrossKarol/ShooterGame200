#region Includes
using System.Collections.Generic;
using Microsoft.Xna.Framework;
#endregion

namespace ShooterGame200
{
    public class Unit : AttackableObject
    {
  
        protected Vector2 moveTo;
        protected List<Vector2> pathNodes = new List<Vector2>();
        public Skill currentSkill;
        public List<Skill> skills = new List<Skill>();

        public Unit(string PATH, Vector2 POS, Vector2 DIMS, Vector2 FRAMES, int OWNERID)
            : base(PATH, POS, DIMS, FRAMES, OWNERID)
        {
            moveTo = new Vector2(POS.X, POS.Y);

        }

        public override void Update(Vector2 OFFSET, Player ENEMY, SquareGrid GRID)
        {


            base.Update(OFFSET, ENEMY, GRID);
        }

        public virtual void MoveUnit()
        {
            if (pos.X != moveTo.X || pos.Y != moveTo.Y)
            {
                rot = Globals.RotateTowards(pos, moveTo);

                pos += Globals.RadialMovement(moveTo, pos, speed);
            }
            else if (pathNodes.Count > 0)
            {
                moveTo = pathNodes[0];
                pathNodes.RemoveAt(0);

                pos += Globals.RadialMovement(moveTo, pos, speed);
            }



        }
        public virtual List<Vector2> FindPath(SquareGrid GRID, Vector2 ENDSLOT)
        {

            pathNodes.Clear();


            Vector2 tempStartSlot = GRID.GetSlotFromPixel(pos, Vector2.Zero);


            List<Vector2> tempPath = GRID.GetPath(tempStartSlot, ENDSLOT, true);

            if (tempPath == null || tempPath.Count == 0)
            {

            }


            return tempPath;
        }



        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
