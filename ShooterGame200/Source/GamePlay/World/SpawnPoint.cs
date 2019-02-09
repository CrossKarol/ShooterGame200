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
    public class SpawnPoint : AttackableObject
    {

        public List<MobChoice> mobChoices = new List<MobChoice>();

        public McTimer spawnTimer = new McTimer(2400);

        public SpawnPoint(string PATH, Vector2 POS, Vector2 DIMS, int OWNERID, XElement DATA) 
            : base(PATH, POS, DIMS, OWNERID)
        {
            dead = false;

            health = 3;
            healthMax = health;

            LoadData(DATA);

            hitDist = 35.0f;
        }

        public override void Update(Vector2 OFFSET)
        {
            spawnTimer.UpdateTimer();
            if(spawnTimer.Test())
            {
                SpawnMob();
                spawnTimer.ResetToZero();
            }

            base.Update(OFFSET);
        }

        public virtual void LoadData(XElement DATA)
        {
            if(DATA != null)
            {
                spawnTimer.AddToTimer(Convert.ToInt32(DATA.Element("timerAdd").Value, Globals.culture));

                List<XElement> mobList = (from t in DATA.Descendants("mob")
                                            select t).ToList<XElement>();



                for (int i = 0; i < mobList.Count; i++)
                {
                    mobChoices.Add(new MobChoice(mobList[i].Value, Convert.ToInt32(mobList[i].Attribute("rate").Value, Globals.culture)));

                }
            }
        }

        public virtual void SpawnMob()
        {
            GameGlobals.PassMob(new Imp(new Vector2(pos.X, pos.Y), ownerId));
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }

    }
}
