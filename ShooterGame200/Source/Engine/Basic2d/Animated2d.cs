#region Includes
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
#endregion

namespace ShooterGame200
{
    public class Animated2d : Basic2D
    {
        public bool frameAnimations;
        public int currentAnimation = 0;
        public Vector2 frames;
        public List<FrameAnimation> frameAnimationList = new List<FrameAnimation>();
        public Color color;
      

        public Animated2d(string PATH, Vector2 POS, Vector2 DIMS, Vector2 FRAMES, Color COLOR) : base(PATH, POS, DIMS)
        {
            Frames = new Vector2(FRAMES.X, FRAMES.Y);

            color = COLOR;
        }

        #region Properties
        public Vector2 Frames
        {
            set
            {
                frames = value;
                if (myModel != null)
                {
                    frameSize = new Vector2(myModel.Bounds.Width / frames.X, myModel.Bounds.Height / frames.Y);
                }
            }
            get
            {
                return frames;
            }
        }
        #endregion


        public override void Update(Vector2 OFFSET)
        {
            if (frameAnimations && frameAnimationList != null && frameAnimationList.Count > currentAnimation)
            {
                frameAnimationList[currentAnimation].Update();
            }

            base.Update(OFFSET);
        }

        public virtual int GetAnimationFromName(string ANIMATIONNAME)
        {
            for (int i = 0; i < frameAnimationList.Count; i++)
            {
                if (frameAnimationList[i].name == ANIMATIONNAME)
                {
                    return i;
                }
            }

            return -1;
        }

        public virtual void SetAnimationByName(string NAME)
        {
            int tempAnimation = GetAnimationFromName(NAME);

            if (tempAnimation != -1)
            {
                if (tempAnimation != currentAnimation)
                {
                    frameAnimationList[tempAnimation].Reset();
                }

                currentAnimation = tempAnimation;

            }
        }

        public override void Draw(Vector2 screenShift)
        {

            if (frameAnimations && frameAnimationList[currentAnimation].Frames > 0)
            {
             
                frameAnimationList[currentAnimation].Draw(myModel, dims, frameSize, screenShift, pos, rot, color, new SpriteEffects());

            }
            else
            {
                base.Draw(screenShift);
            }
        }


    }
}
