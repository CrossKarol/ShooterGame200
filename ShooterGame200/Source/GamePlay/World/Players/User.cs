#region Includes
using System.Xml.Linq;
using Microsoft.Xna.Framework;
#endregion

namespace ShooterGame200
{
    public class User : Player
    {
     

        public User(int ID, XElement DATA) : base(ID, DATA)
        {
        
        }

        public override void Update(Player ENEMY, Vector2 OFFSET, SquareGrid GRID)
        {
            base.Update(ENEMY, OFFSET, GRID);


           
            if (Globals.keyboard.GetSinglePress("R"))
            {

                if (gold >= 10 && hero.health < 10)
                {
                    hero.health++;
                    if (hero.health <= 0)
                    {

                        hero.dead = true;
                    
                    }
                    
                    gold -= 10;
                }
            }


        }


    }
}
