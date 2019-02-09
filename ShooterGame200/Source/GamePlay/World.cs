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


        PassObject ResetWorld;


        public World(PassObject RESETWORLD)
        {
            ResetWorld = RESETWORLD;
           

            GameGlobals.PassProjectile = AddProjectile;
            GameGlobals.PassMob = AddMob;
            GameGlobals.CheckScroll = CheckScroll;

            user = new User();
            aIPlayer = new AIPlayer();

            offset = new Vector2(0, 0);


            ui = new UI();


        }

        public virtual void Update()
        {
            if (!user.hero.dead)
            {

                    user.Update(aIPlayer, offset);
                    aIPlayer.Update(user, offset);

                    



                    for (int i = 0; i < projectiles.Count; i++)
                    {
                        projectiles[i].Update(offset, aIPlayer.units.ToList<Unit>());

                        if (projectiles[i].done)
                        {
                            projectiles.RemoveAt(i);
                            i--;
                        }
                    }

                   
            }
            else
            {
                if(Globals.keyboard.GetPress("Enter"))
                {
                    ResetWorld(null);
                }
            }
            ui.Update(this);
        }

        public virtual void AddMob(object INFO)
        {
            aIPlayer.AddUnit((Mob)INFO);
        }

        public virtual void AddProjectile(object INFO)
        {
            projectiles.Add((Projectile2d)INFO);
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
