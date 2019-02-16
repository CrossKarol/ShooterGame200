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
   

    public class GridItem : Animated2d
    {

        public Rectangle CollisionBox;

        public GridItem(string PATH, Vector2 POS, Vector2 DIMS, Vector2 FRAMES) : base(PATH, POS, DIMS, FRAMES, Color.White)
        {

        }

        public virtual void SetPosition(Vector2 position)
        {
            position = new Vector2(pos.X, pos.Y);

            CollisionBox = new Rectangle((int)(pos.X - (Globals.screenWidth / 2)), (int)(pos.Y - (Globals.screenHeight / 2)), Globals.screenWidth, Globals.screenHeight);
        }
    }
}
