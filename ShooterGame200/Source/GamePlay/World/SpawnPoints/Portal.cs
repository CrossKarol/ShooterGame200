#region Includes
using System;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
#endregion


namespace ShooterGame200
{
    public class Portal : SpawnPoint
    {


        public Portal(Vector2 POS, Vector2 FRAMES, int OWNERID, XElement DATA) 
            : base("2D\\SpawnPoints\\Portal", POS, new Vector2(55, 55), FRAMES, OWNERID, DATA)
        {

            health = 15;
            healthMax = health;

            killValue = 26;
        }

        public override void Update(Vector2 OFFSET, Player ENEMY, SquareGrid GRID)
        {
            base.Update(OFFSET, ENEMY, GRID);
        }


        public override void SpawnMob()
        {
            int num = Globals.rand.Next(0, 100 + 1);

            Mob tempMob = null;
            int total = 0;

            for (int i=0; i<mobChoices.Count; i++)
            {
                total += mobChoices[i].rate;


                if (num < total)
                {

                    Type sType = Type.GetType("ShooterGame200."+mobChoices[i].mobStr, true);

                    tempMob = (Mob)(Activator.CreateInstance(sType, new Vector2(pos.X, pos.Y), new Vector2(1, 1), ownerId));
                   
                    break;
                }
            }
            if (tempMob != null)
            {
                GameGlobals.PassMob(tempMob);
            }
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }

    }
}
