#region Includes
using Microsoft.Xna.Framework;
#endregion

namespace ShooterGame200
{
    public class GridLocation
    {
  
        public float fScore, cost, currentDist, distLef;
        public Vector2 parent, pos;
        public bool filled, impassable, unPathable, hasBeenUsed, isViewable;

        public GridLocation()
        {
            filled = false;
            impassable = false;
            unPathable = false;
            hasBeenUsed = false;
            isViewable = false;
            cost = 1.0f;

        }

        public GridLocation(float COST, bool FILLED)
        {
            cost = COST;
            filled = FILLED;
            unPathable = false;
            hasBeenUsed = false;
            isViewable = false;
        }

        public GridLocation(Vector2 POS, float COST, bool FILLED, float FSCORE)
        {
            filled = FILLED;
            impassable = FILLED;
            cost = COST;
            unPathable = false;
            hasBeenUsed = false;
            isViewable = false;

            pos = POS;

            fScore = FSCORE;
        }

        public void SetNode(Vector2 PARENT, float FSCORE, float CURRENTDIST)
        {
            parent = PARENT;
            fScore = FSCORE;
            currentDist = CURRENTDIST;
        }

        public virtual void SetToFilled(bool IMPASSIBLE)
        {
            filled = true;
            if (IMPASSIBLE)
            {
                impassable = true;
            }
        }
    }
}
