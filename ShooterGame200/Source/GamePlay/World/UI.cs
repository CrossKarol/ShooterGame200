#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

#endregion

namespace ShooterGame200
{
    public class UI
    {
        public SpriteFont font;

        public QuantityDisplayBar healthBar;

        public UI()
        {
            font = Globals.content.Load<SpriteFont>("Fonts\\Arial16");

            healthBar = new QuantityDisplayBar(new Vector2(104, 16), 2, Color.Red);
        }
        public void Update(World WORLD)
        {
            healthBar.Update(WORLD.hero.health, WORLD.hero.healthMax);
        }

        public void Draw(World WORLD)
        {
            string tempStr = "Num killed = " + WORLD.numKilled;
            Vector2 strDims = font.MeasureString(tempStr);
            Globals.spriteBatch.DrawString(font, tempStr,new Vector2(Globals.screenWidth/2 - strDims.X/2, Globals.screenHeight - 40), Color.Black);

            healthBar.Draw(new Vector2(20, Globals.screenHeight - 50));

            if (WORLD.hero.dead)
            {
                tempStr = "Press Enter to Restart!" ;
                strDims = font.MeasureString(tempStr);
                Globals.spriteBatch.DrawString(font, tempStr, new Vector2(Globals.screenWidth / 2 - strDims.X / 2, Globals.screenHeight/2), Color.Black);
            }
        }
    }
}
