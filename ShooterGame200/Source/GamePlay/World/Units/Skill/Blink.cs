#region Includes
using Microsoft.Xna.Framework;
#endregion

namespace ShooterGame200
{
    public class Blink : Skill
    {

        public Blink(AttackableObject OWNER) : base(OWNER)
        {
            targetEffect = null;

        }
        public override void Targeting(Vector2 OFFSET, Player ENEMY)
        {
            GameGlobals.PassEffect(new BlinkEffect(Globals.mouse.newMousePos - OFFSET, new Vector2(owner.dims.X, owner.dims.Y), 266));
            GameGlobals.PassEffect(new BlinkEffect(new Vector2(owner.pos.X, owner.pos.Y), new Vector2(owner.dims.X, owner.dims.Y), 266));

            owner.pos = new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y) - OFFSET;
     
            active = false;
            done = true;
        }
    }
}
