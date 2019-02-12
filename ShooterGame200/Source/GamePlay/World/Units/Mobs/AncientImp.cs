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
    public class AncientImp : Mob
    {

        public AncientImp(Vector2 POS, Vector2 FRAMES, int OWNERID) 
            : base("2D\\Units\\Mobs\\ImpBlue", POS, new Vector2(40, 40), FRAMES, OWNERID)
        {
            speed = 2.0f;

            attackRange = 400;
        }

        public override void Update(Vector2 OFFSET, Player ENEMY, SquareGrid GRID, LevelDrawManager LEVELDRAWMANAGER)
        {

            base.Update(OFFSET, ENEMY, GRID, LEVELDRAWMANAGER);
        }

        public override void AI(Player ENEMY, SquareGrid GIRD)
        {
            if (ENEMY.hero != null && (Globals.GetDistance(pos, ENEMY.hero.pos) < attackRange * .9f || isAttacking))
            {
                isAttacking = true;
                attackTimer.UpdateTimer();

                if(attackTimer.Test())
                {
                    GameGlobals.PassProjectile(new AcidSplash(new Vector2(pos.X, pos.Y), this, new Vector2(ENEMY.hero.pos.X, ENEMY.hero.pos.Y)));


                    attackTimer.ResetToZero();
                    isAttacking = false;
                }
            }
            else
            {
                base.AI(ENEMY, GIRD);
            }
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }

    }
}
