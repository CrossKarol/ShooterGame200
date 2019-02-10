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
    public class GridLocation
    {
        public bool filled, impasible, unPathable;
        public float fScore, cost, currentDist;
        public Vector2 parent, pos;

        public GridLocation(float COST, bool FILLED)
        {
            cost = COST;
            filled = FILLED;

            unPathable = false;
            impasible = false;
        }

        public virtual void SetToFilled(bool IMPASSIBLE)
        {
            filled = true;
            impasible = IMPASSIBLE;
        }
    }
}
