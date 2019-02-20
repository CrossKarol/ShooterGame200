#region Includes
using Microsoft.Xna.Framework;
#endregion


namespace ShooterGame200
{
    public class TargetingCircle : Effect2d
    {
        
        public TargetingCircle(Vector2 POS, Vector2 DIMS) : base("2D\\Effects\\TargetCircle", POS, DIMS, new Vector2(1, 1), 400)
        {
            noTimer = true;
        }


    }
}
