#region Includes

using Microsoft.Xna.Framework;
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

        public bool Active
        {
            get
            {
                return active;
            }

            set
            {
                if (value && !active && targetEffect != null)
                {
                    targetEffect.done = false;
                    GameGlobals.PassEffect(targetEffect);
                }

                active = value;
            }
        }


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
