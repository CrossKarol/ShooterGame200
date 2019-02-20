#region Includes
using Microsoft.Xna.Framework;
#endregion


namespace ShooterGame200
{
    public class Imp : Mob
    {

        public Imp(Vector2 POS, Vector2 FRAMES, int OWNERID) 
            : base("2D\\Units\\cockroach-move", POS, new Vector2(40, 40), new Vector2(8, 1), OWNERID)
        {
            speed = 2.0f;
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
            Globals.normalEffect.Parameters["xSize"].SetValue((float)myModel.Bounds.Width);
            Globals.normalEffect.Parameters["ySize"].SetValue((float)myModel.Bounds.Height);
            Globals.normalEffect.Parameters["xDraw"].SetValue((float)((int)dims.X));
            Globals.normalEffect.Parameters["yDraw"].SetValue((float)((int)dims.Y));
            Globals.normalEffect.Parameters["filterColor"].SetValue(Color.White.ToVector4());
            Globals.normalEffect.CurrentTechnique.Passes[0].Apply();
            base.Draw(OFFSET);
        }

    }
}
