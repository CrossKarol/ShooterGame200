#region Includes
using Microsoft.Xna.Framework;
#endregion


namespace ShooterGame200
{
    public class Tower : Building
    {


        public Tower(Vector2 POS, Vector2 FRAMES, int OWNERID) 
            : base("2D\\Buildings\\Tower", POS, new Vector2(45, 45), FRAMES, OWNERID)
        {
            health = 20;
            healthMax = health;
            hitDist = 35.0f;
        }

        public override void Update(Vector2 OFFSET, Player ENEMY, SquareGrid GRID)
        {
            base.Update(OFFSET, ENEMY, GRID);
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }

    }
}
