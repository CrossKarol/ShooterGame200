#region Includes
using Microsoft.Xna.Framework;
#endregion


namespace ShooterGame200
{
    public class BlinkEffect : Effect2d
    {
        
        public BlinkEffect(Vector2 POS, Vector2 DIMS,int MSEC)
            : base("2D\\Effects\\PoisonBlob", POS, DIMS, new Vector2(4, 1), MSEC)
        {
            frameAnimations = true;
            currentAnimation = 0;
            frameAnimationList.Add(new FrameAnimation(new Vector2(frameSize.X, frameSize.Y), frames, new Vector2(0, 0), 4, 33, 0, "Base"));

        }

        public override void Update(Vector2 OFFSET)
        {


            base.Update(OFFSET);
        }

    }
}
