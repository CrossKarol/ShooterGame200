#region Includes
using Microsoft.Xna.Framework;
#endregion


namespace ShooterGame200
{
    public class Monster : Mob
    {


        public McTimer spawnTimer;

        public Monster(Vector2 POS, Vector2 FRAMES, int OWNERID) 
            : base("2D\\Units\\chitiniac-move", POS, new Vector2(40, 40), new Vector2(8,1), OWNERID)
        {
            speed = 1.5f;
            health = 3;
            healthMax = health;
            killValue = 5;
            spawnTimer = new McTimer(8000);
            spawnTimer.AddToTimer(4000);

            frameAnimations = true;
            currentAnimation = 0;
            frameAnimationList.Add(new FrameAnimation(new Vector2(frameSize.X, frameSize.Y), frames, new Vector2(0, 0), 8, 133, 0, "Walk"));
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
