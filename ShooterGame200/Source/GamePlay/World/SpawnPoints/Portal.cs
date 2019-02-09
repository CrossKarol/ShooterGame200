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
    public class Portal : SpawnPoint
    {


        public Portal(Vector2 POS, int OWNERID, XElement DATA) 
            : base("2D\\SpawnPoints\\Portal", POS, new Vector2(45, 45), OWNERID, DATA)
        {

            health = 15;
            healthMax = health;
        }

        public override void Update(Vector2 OFFSET)
        {
            base.Update(OFFSET);
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

                    tempMob = (Mob)(Activator.CreateInstance(sType, new Vector2(pos.X, pos.Y), ownerId));
                   
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
