#region Includes
using Microsoft.Xna.Framework;

#endregion


namespace ShooterGame200
{
    public class MonsterTwo : Mob
    {
        public McTimer spawnTimer;

        public MonsterTwo(Vector2 POS, Vector2 FRAMES, int OWNERID) 
            : base("2D\\Units\\bandit-move", POS, new Vector2(35, 35), new Vector2(8, 1),  OWNERID)
        {
            speed = 2.5f;

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
