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
    public class User : Player
    {

        public User(int ID, XElement DATA) : base(ID, DATA)
        {
          //  hero = new Hero("2D\\Hero", new Vector2(300, 300), new Vector2(64, 64), id);

          //  buildings.Add(new Tower(new Vector2(Globals.screenWidth/2, Globals.screenHeight - 40), id));
        }

        public override void Update(Player ENEMY, Vector2 OFFSET, SquareGrid GRID)
        {
            base.Update(ENEMY, OFFSET, GRID);
        }

    }
}
