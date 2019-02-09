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

        public Vector2 offset;

        

        public UI ui;

        public User user;
        public AIPlayer aIPlayer;

        public List<Projectile2d> projectiles = new List<Projectile2d>();
        public List<AttackableObject> allObjects = new List<AttackableObject>();


        PassObject ResetWorld;


        public World(PassObject RESETWORLD)
        {
            ResetWorld = RESETWORLD;
           

            GameGlobals.PassProjectile = AddProjectile;
            GameGlobals.PassMob = AddMob;
            GameGlobals.PassSpawnPoint = AddSpawnPoint;
            GameGlobals.CheckScroll = CheckScroll;

            user = new User(1);
            aIPlayer = new AIPlayer(2);

            offset = new Vector2(0, 0);


            ui = new UI();


        }

        public virtual void Update()
        {
            if (!user.hero.dead && user.buildings.Count > 0)
            {

                allObjects.Clear();
                allObjects.AddRange(user.GetAllObjects());    
                allObjects.AddRange(aIPlayer.GetAllObjects());    

                    
                    user.Update(aIPlayer, offset);
                    aIPlayer.Update(user, offset);

                    



                    for (int i = 0; i < projectiles.Count; i++)
                    {
                        projectiles[i].Update(offset, allObjects);

                        if (projectiles[i].done)
                        {
                            projectiles.RemoveAt(i);
                            i--;
                        }
                    }

                   
            }
            else
            {
                if(Globals.keyboard.GetPress("Enter") && (user.hero.dead || user.buildings.Count <= 0))
                {
                    ResetWorld(null);
                }
            }
            ui.Update(this);
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

            aIPlayer.AddUnit((Mob)INFO);
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

            if (tempPos.X < -offset.X + Globals.screenWidth * .4f)
            {
                offset = new Vector2(offset.X + user.hero.speed * 2, offset.Y);
            }
            if (tempPos.X > -offset.X + Globals.screenWidth * .6f)
            {
                offset = new Vector2(offset.X - user.hero.speed * 2, offset.Y);
            }
            if (tempPos.Y < -offset.Y + Globals.screenHeight * .4f)
            {
                offset = new Vector2(offset.X, offset.Y + user.hero.speed * 2);
            }
            if (tempPos.Y > -offset.Y + Globals.screenHeight * .6f)
            {
                offset = new Vector2(offset.X, offset.Y - user.hero.speed * 2);
            }
        }

        public virtual void Draw(Vector2 OFFSET)
        { 
            user.Draw(offset);
            aIPlayer.Draw(offset);

            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Draw(offset);

            }
            ui.Draw(this);

        }
    }
}
