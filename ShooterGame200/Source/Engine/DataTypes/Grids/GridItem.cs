#region Includes
using Microsoft.Xna.Framework;
#endregion


namespace ShooterGame200
{
   

    public class GridItem : Animated2d
    {

        public Rectangle CollisionBox;

        public GridItem(string PATH, Vector2 POS, Vector2 DIMS, Vector2 FRAMES) : base(PATH, POS, DIMS, FRAMES, Color.White)
        {

        }

        public virtual void SetPosition(Vector2 position)
        {
            position = new Vector2(pos.X, pos.Y);

            CollisionBox = new Rectangle((int)(pos.X - (Globals.screenWidth / 2)), (int)(pos.Y - (Globals.screenHeight / 2)), Globals.screenWidth, Globals.screenHeight);
        }
    }
}
