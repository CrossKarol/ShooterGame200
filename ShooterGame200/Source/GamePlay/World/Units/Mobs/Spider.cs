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
    public class Spider : Mob
    {


        public McTimer spawnTimer;

        public Spider(Vector2 POS, Vector2 FRAMES, int OWNERID) 
            : base("2D\\Units\\Mobs\\Spider", POS, new Vector2(45, 45), FRAMES, OWNERID)
        {
            speed = 1.5f;
            health = 3;
            healthMax = health;

            spawnTimer = new McTimer(8000);
            spawnTimer.AddToTimer(4000);
        }

        public override void Update(Vector2 OFFSET, Player ENEMY, SquareGrid GRID)
        {

            spawnTimer.UpdateTimer();
            if (spawnTimer.Test())
            {

                SpawnEggSac();
                spawnTimer.ResetToZero();
            }


            base.Update(OFFSET, ENEMY, GRID);
        }


        public virtual void SpawnEggSac()
        {
            GameGlobals.PassSpawnPoint(new SpidderEggSac(new Vector2(pos.X, pos.Y), new Vector2(1, 1), ownerId, null));
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }

    }
}
