#region Includes
using System.Xml.Linq;
using Microsoft.Xna.Framework;
#endregion

namespace ShooterGame200
{
    public class AIPlayer : Player
    {

        public AIPlayer(int ID, XElement DATA) 
            : base(ID, DATA)
        {       
        }

        public override void Update(Player ENEMY, Vector2 OFFSET, SquareGrid GRID)
        {
            base.Update(ENEMY, OFFSET, GRID);
        }
        public override void ChangeScore(int SCORE)
        {
            GameGlobals.score += SCORE;
        }

    }
}
