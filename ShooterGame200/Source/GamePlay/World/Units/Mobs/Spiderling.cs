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

        public Spiderling(Vector2 POS, int OWNERID) 
            : base("2D\\Units\\Mobs\\Spider", POS, new Vector2(25, 25), OWNERID)
        {
            speed = 2.5f;
        }

        public override void Update(Vector2 OFFSET, Player ENEMY)
        {
            base.Update(OFFSET, ENEMY);
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }

    }
}
