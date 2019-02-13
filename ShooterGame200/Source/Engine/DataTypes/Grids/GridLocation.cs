#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
#endregion

namespace ShooterGame200
{
    public class GridLocation
    {
        public bool filled, impassable, unPathable, hasBeenUsed, isViewable;
        public float fScore, cost, currentDist, distLef;
        public Vector2 parent, pos;

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
            cost = COST;
            filled = FILLED;
            impassable = FILLED;
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
