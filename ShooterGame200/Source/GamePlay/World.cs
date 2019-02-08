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

        public Hero hero;

        public List<Projectile2d> projectiles = new List<Projectile2d>();

        public World()
        {
            hero = new Hero("2D\\Hero", new Vector2(300, 300), new Vector2(64, 64));

            GameGlobals.PassProjectile = AddProjectile;

            offset = new Vector2(0, 0);

        }

        public virtual void Update()
        {
            hero.Update();

            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Update(offset, null);
            }
        }

        public virtual void AddProjectile(object INFO)
        {
            projectiles.Add((Projectile2d)INFO);
        }

        public virtual void Draw(Vector2 OFFSET)
        {
            hero.Draw(OFFSET);

            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Draw(offset);
            }

        }
    }
}
