﻿#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
#endregion

namespace ShooterGame200
{
    public class Player
    {
        public int gold;
        public int id;
        public Hero hero;
        public List<Unit> units = new List<Unit>();
        public List<SpawnPoint> spawnPoints = new List<SpawnPoint>();
        public List<Building> buildings = new List<Building>();


        public Player(int ID, XElement DATA)
        {
            id = ID;
            gold = 0;
            LoadData(DATA);
        }

        public virtual void Update(Player ENEMY, Vector2 OFFSET, SquareGrid GRID)
        {
            if (hero != null)
            {
                hero.Update(OFFSET, ENEMY, GRID);
            }

            for (int i = 0; i < spawnPoints.Count; i++)
            {
                spawnPoints[i].Update(OFFSET, ENEMY, GRID);

                if (spawnPoints[i].dead)
                {
                    spawnPoints.RemoveAt(i);
                    i--;
                }
            }

            for (int i = 0; i < units.Count; i++)
            {
                units[i].Update(OFFSET, ENEMY, GRID);

                if (units[i].dead)
                {
                    ChangeScore(1);
                    units.RemoveAt(i);
                    i--;
                }
            }


            for (int i = 0; i < buildings.Count; i++)
            {
                buildings[i].Update(OFFSET, ENEMY, GRID);

                if (buildings[i].dead)
                {
                    buildings.RemoveAt(i);
                    i--;
                }
            }
        }


        public virtual void AddSpawnPoint(object INFO)
        {
            SpawnPoint tempSpawnPoint = (SpawnPoint)INFO;
            tempSpawnPoint.ownerId = id;
            spawnPoints.Add(tempSpawnPoint);
        }
        public virtual void AddBuilding(object INFO)
        {
            Building tempBuilding = (Building)INFO;
            tempBuilding.ownerId = id;
            buildings.Add((Building)INFO);
        }

        public virtual void AddUnit(object INFO)
        {
            Unit tempUnit = (Unit)INFO;
            tempUnit.ownerId = id;
            units.Add(tempUnit);
        }

        public virtual void ChangeScore(int SCORE)
        {

        }

        public virtual List<AttackableObject> GetAllObjects()
        {
            List<AttackableObject> tempObject = new List<AttackableObject>();
            tempObject.AddRange(units.ToList<AttackableObject>());
            tempObject.AddRange(spawnPoints.ToList<AttackableObject>());
            tempObject.AddRange(buildings.ToList<AttackableObject>());

            if(hero != null)
            {
                tempObject.Add(hero);
            }

            return tempObject;
        }

        public virtual void LoadData(XElement DATA)
        {
            List<XElement> spawnList = (from t in DATA.Descendants("SpawnPoint")
                                        select t).ToList<XElement>();

            Type sType = null;

            for(int i=0; i<spawnList.Count; i++)
            {
                sType = Type.GetType("ShooterGame200."+spawnList[i].Element("type").Value, true);


                spawnPoints.Add((SpawnPoint)(Activator.CreateInstance(sType, new Vector2(Convert.ToInt32(spawnList[i].Element("Pos").Element("x").Value, Globals.culture), Convert.ToInt32(spawnList[i].Element("Pos").Element("y").Value, Globals.culture)), new Vector2(1, 1), id, spawnList[i])));
                
            }

            List<XElement> buildingList = (from t in DATA.Descendants("Building")
                                        select t).ToList<XElement>();

            for (int i = 0; i < buildingList.Count; i++)
            {
                sType = Type.GetType("ShooterGame200." + buildingList[i].Element("type").Value, true);


                buildings.Add((Building)(Activator.CreateInstance(sType, new Vector2(Convert.ToInt32(buildingList[i].Element("Pos").Element("x").Value, Globals.culture), Convert.ToInt32(buildingList[i].Element("Pos").Element("y").Value, Globals.culture)), new Vector2(1, 1), id)));
            }

            if (DATA.Element("Hero") != null)
            {
                hero = new Hero("2D\\Units\\HeroNice", new Vector2(Convert.ToInt32(DATA.Element("Hero").Element("Pos").Element("x").Value, Globals.culture), Convert.ToInt32(DATA.Element("Hero").Element("Pos").Element("y").Value, Globals.culture)), new Vector2(84, 84), new Vector2(8, 1), id);
            }
        }

        public virtual void Draw(Vector2 OFFSET)
        {
           

            if (hero != null)
            {
                hero.Draw(OFFSET);
            }

            for (int i = 0; i < units.Count; i++)
            {
                units[i].Draw(OFFSET);
            }

            for (int i = 0; i < buildings.Count; i++)
            {
                buildings[i].Draw(OFFSET);
            }

            for (int i = 0; i < spawnPoints.Count; i++)
            {
                spawnPoints[i].Draw(OFFSET);
            }

        }

    }
}
