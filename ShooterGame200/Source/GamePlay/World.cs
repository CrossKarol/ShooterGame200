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
    public class World
    {
        public int levelId;

        public Vector2 offset;

        

        public UI ui;

        public User user;
        public AIPlayer aIPlayer;

        public SquareGrid grid;

        public TileBkg2d bkg;

        public LevelDrawManager levelDrawManager;

        public List<Projectile2d> projectiles = new List<Projectile2d>();
        public List<Effect2d> effects = new List<Effect2d>();
        public List<AttackableObject> allObjects = new List<AttackableObject>();
        public List<SceneItem> sceneItems = new List<SceneItem>();


        PassObject ResetWorld, ChangeGameState;
        PassObject ChangeWorldTwo;


        public World(PassObject RESETWORLD,int LEVELID, PassObject CHANGEGAMESTATE)
        {

            levelId = LEVELID;
            ResetWorld = RESETWORLD;
            ChangeWorldTwo = RESETWORLD;

            ChangeGameState = CHANGEGAMESTATE;

            levelDrawManager = new LevelDrawManager();
           

            GameGlobals.PassProjectile = AddProjectile;
            GameGlobals.PassEffect = AddEffect; 
            GameGlobals.PassMob = AddMob;
            GameGlobals.PassBuilding = AddBuilding;
            GameGlobals.PassSpawnPoint = AddSpawnPoint;
            GameGlobals.CheckScroll = CheckScroll;
            GameGlobals.PassGold = AddGold;

            GameGlobals.paused = false;


            offset = new Vector2(0, 0);

            LoadData(levelId);

            ui = new UI(ResetWorld);

            bkg = new TileBkg2d("2D\\UI\\Backgrounds\\KafelekPodloga", new Vector2(-100, -100), new Vector2(120, 100), new Vector2(grid.totalPhysicalDims.X + 100, grid.totalPhysicalDims.Y + 100));


        }

        public virtual void Update()
        {
            if (!user.hero.dead && user.buildings.Count > 0 && !GameGlobals.paused)
            {

                levelDrawManager.Update();

                allObjects.Clear();
                allObjects.AddRange(user.GetAllObjects());    
                allObjects.AddRange(aIPlayer.GetAllObjects());    

                    
                user.Update(aIPlayer, offset, grid);
                aIPlayer.Update(user, offset, grid);


                for (int i = 0; i < projectiles.Count; i++)
                {
                    projectiles[i].Update(offset, allObjects);

                    if (projectiles[i].done)
                    {
                        projectiles.RemoveAt(i);
                        i--;
                    }
                }

                for (int i = 0; i < effects.Count; i++)
                {
                    effects[i].Update(offset);

                    if (effects[i].done)
                    {
                        effects.RemoveAt(i);
                        i--;
                    }
                }

                for (int i = 0; i < sceneItems.Count; i++)
                {
                    sceneItems[i].Update(offset);

                    sceneItems[i].UpdateDraw(offset, levelDrawManager);
                }
            }
            else
            {
                if(Globals.keyboard.GetPress("Enter") && (user.hero.dead || user.buildings.Count <= 0))
                {
                    ResetWorld(null);
                }
            }

            if(grid != null)
            {
                grid.Update(offset);
            }

            if (Globals.keyboard.GetSinglePress("Back"))
            {
                ResetWorld(null);
                ChangeGameState(1);
            }

            if (Globals.keyboard.GetSinglePress("Y"))
            {
              
                    ResetWorld(null);
                    ChangeGameState(2);
                
            }
            if (Globals.keyboard.GetSinglePress("C"))
            {
                if (user.gold >= 100)
                {
                    ResetWorld(2);
                    user.gold -= 100;
                }

            }

            if (Globals.keyboard.GetSinglePress("Space"))
            {
                GameGlobals.paused = !GameGlobals.paused;
            }

            if (Globals.keyboard.GetSinglePress("G"))
            {
                grid.showGrid = !grid.showGrid;
            }


            ui.Update(this);
        }

        public virtual void AddBuilding(object INFO)
        {

            Building tempBuilding = (Building)INFO;

            if (user.id == tempBuilding.ownerId)
            {
                user.AddBuilding(tempBuilding);
            }
            else if (aIPlayer.id == tempBuilding.ownerId)
            {
                aIPlayer.AddBuilding(tempBuilding);
            }

          //  aIPlayer.AddUnit((Mob)INFO);
        }


        public virtual void AddEffect(object INFO)
        {
            effects.Add((Effect2d)INFO);
        }

        public virtual void AddGold(object INFO)
        {
            PlayerValuePacket packet = (PlayerValuePacket)INFO;

            if (user.id == packet.playerId)
            {
                user.gold += (int)packet.value;
            }
            else if (aIPlayer.id == packet.playerId)
            {
                aIPlayer.gold += (int)packet.value;
            }
        }

        public virtual void AddMob(object INFO)
        {

            Unit tempUnit = (Unit)INFO;

            if(user.id == tempUnit.ownerId)
            {
                user.AddUnit(tempUnit);
            }
            else if(aIPlayer.id == tempUnit.ownerId)
            {
                aIPlayer.AddUnit(tempUnit);  
            }

        //    aIPlayer.AddUnit((Mob)INFO);
        }

        public virtual void AddProjectile(object INFO)
        {
            projectiles.Add((Projectile2d)INFO);
        }


        public virtual void AddSpawnPoint(object INFO)
        {

            SpawnPoint tempSpawnPoint = (SpawnPoint)INFO;

            if (user.id == tempSpawnPoint.ownerId)
            {
                user.AddSpawnPoint(tempSpawnPoint);
            }
            else if (aIPlayer.id == tempSpawnPoint.ownerId)
            {
                aIPlayer.AddSpawnPoint(tempSpawnPoint);
            }

        }

        public virtual void CheckScroll(object INFO)
        {
            Vector2 tempPos = (Vector2)INFO;

            float maxMovement = user.hero.speed * 4.5f;

            float diff = 0;


            if (tempPos.X < -offset.X + Globals.screenWidth * .4f)
            {
                diff = -offset.X + (Globals.screenWidth * .4f) - tempPos.X;

                offset = new Vector2(offset.X + Math.Min(maxMovement, diff), offset.Y);
            }
            if (tempPos.X > -offset.X + Globals.screenWidth * .6f)
            {
                diff = tempPos.X - (-offset.X + (Globals.screenWidth * .6f));

                offset = new Vector2(offset.X - Math.Min(maxMovement, diff), offset.Y);
            }
            if (tempPos.Y < -offset.Y + Globals.screenHeight * .4f)
            {
                diff = -offset.Y + (Globals.screenHeight * .4f) - tempPos.Y;

                offset = new Vector2(offset.X, offset.Y + Math.Min(maxMovement, diff));
            }
            if (tempPos.Y > -offset.Y + Globals.screenHeight * .6f)
            {
                diff = tempPos.Y - (-offset.Y + (Globals.screenHeight * .6f));

                offset = new Vector2(offset.X, offset.Y - Math.Min(maxMovement, diff));
            }

        }

        public virtual void LoadData(int LEVEL)
        {
            XDocument xml = XDocument.Load("XML\\Levels\\Level"+LEVEL+".xml");


            XElement tempElement = null;
            if(xml.Element("Root").Element("User") != null)
            {
                tempElement = xml.Element("Root").Element("User");
            }
            user = new User(1, tempElement);



            tempElement = null;
            if (xml.Element("Root").Element("AIPlayer") != null)
            {
                tempElement = xml.Element("Root").Element("AIPlayer");
            }

            grid = new SquareGrid(new Vector2(25, 25), new Vector2(-100, -100), new Vector2(Globals.screenWidth + 200, Globals.screenHeight + 200), xml.Element("Root").Element("GridItems"));


            aIPlayer = new AIPlayer(2, tempElement);

            List<XElement> sceneItemList = (from t in xml.Element("Root").Element("Scene").Descendants("SceneItem")
                                           select t).ToList<XElement>();



            Type sType = null;
            for (int i = 0; i < sceneItemList.Count; i++)
            {
                sType = Type.GetType("ShooterGame200." + sceneItemList[i].Element("type").Value, true);


                sceneItems.Add((SceneItem)(Activator.CreateInstance(sType, new Vector2(Convert.ToInt32(sceneItemList[i].Element("Pos").Element("x").Value, Globals.culture), Convert.ToInt32(sceneItemList[i].Element("Pos").Element("y").Value, Globals.culture)), new Vector2((float)Convert.ToDouble(sceneItemList[i].Element("scale").Value, Globals.culture)))));
            }

        }

        public virtual void Draw(Vector2 OFFSET)
        {

            bkg.Draw(offset);
            grid.DrawGrid(offset);


            user.Draw(offset);
            aIPlayer.Draw(offset);

            /*for (int i=0; i < sceneItems.Count; i++)
            {
                sceneItems[i].Draw(offset);
            }*/
            if(levelDrawManager != null)
            {
                levelDrawManager.Draw();
            }


            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Draw(offset);

            }
            for (int i = 0; i < effects.Count; i++)
            {
                effects[i].Draw(offset);

            }
            ui.Draw(this);

        }
    }
}
