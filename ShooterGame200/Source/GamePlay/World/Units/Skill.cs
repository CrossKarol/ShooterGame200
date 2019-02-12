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
    public class Skill
    {
        protected bool active;
        public bool done;

        public AttackableObject owner;

        public Effect2d targetEffect;

        public Skill(AttackableObject OWNER)
        {
            active = false;
            done = false;

            owner = OWNER;

            targetEffect = new TargetingCircle(new Vector2(0, 0), new Vector2(150, 150));
        }

        #region Properties

        public bool Active
        {
            get
            {
                return active;
            }

            set
            {
                if (value && !active)
                {
                    targetEffect.done = false;
                    GameGlobals.PassEffect(targetEffect);
                }

                active = value;
            }
        }

        #endregion


        public virtual void Update(Vector2 OFFSET, Player ENEMY)
        {

            if (active && !done)
            {
                Targeting(OFFSET, ENEMY);
            }
        }

        public virtual void Reset()
        {

            active = false;
            done = false;
        }

        public virtual void Targeting(Vector2 OFFSET, Player ENEMY)
        {

            if (Globals.mouse.LeftClickRelease())
            {
                Active = false;
                done = false;

            }
        }
    }
}
