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
    public class Player
    {
        public int id;
        public Hero hero;
        public List<Unit> units = new List<Unit>();
        public List<SpawnPoint> spawnPoints = new List<SpawnPoint>();


        public Player(int ID)
        {
            id = ID;
        }

        public virtual void Update(Player ENEMY, Vector2 OFFSET)
        {
            if (hero != null)
            {
                hero.Update(OFFSET);
            }

            for (int i = 0; i < spawnPoints.Count; i++)
            {
                spawnPoints[i].Update(OFFSET);

                if (spawnPoints[i].dead)
                {

                    spawnPoints.RemoveAt(i);
                    i--;
                }
            }

            for (int i = 0; i < units.Count; i++)
            {
                units[i].Update(OFFSET, ENEMY);

                if (units[i].dead)
                {
                    ChangeScore(1);
                    units.RemoveAt(i);
                    i--;
                }
            }
        }

        public virtual void AddUnit(object INFO)
        {
            Unit tempUnit = (Unit)INFO;
            tempUnit.ownerId = id;
            units.Add(tempUnit);
        }

        public virtual void AddSpawnPoint(object INFO)
        {
            SpawnPoint tempSpawnPoint = (SpawnPoint)INFO;
            tempSpawnPoint.ownerId = id;
            spawnPoints.Add(tempSpawnPoint);
        }

        public virtual void ChangeScore(int SCORE)
        {

        }

        public virtual void Draw(Vector2 OFFSET)
        {
            if(hero != null)
            {
                hero.Draw(OFFSET);
            }

            for (int i = 0; i < units.Count; i++)
            {
                units[i].Draw(OFFSET);
            }

            for (int i = 0; i < spawnPoints.Count; i++)
            {
                spawnPoints[i].Draw(OFFSET);
            }

        }

    }
}
