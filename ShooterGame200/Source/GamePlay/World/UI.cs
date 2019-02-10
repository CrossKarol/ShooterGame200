﻿#region Includes
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
        public Basic2D pauseOverlay;

        public SpriteFont font;

        public QuantityDisplayBar healthBar;

        public UI()
        {
            pauseOverlay = new Basic2D("2D\\Misc\\PauseOverlay", new Vector2(Globals.screenWidth/2, Globals.screenHeight/2), new Vector2(300, 300));

            font = Globals.content.Load<SpriteFont>("Fonts\\Arial16");

            healthBar = new QuantityDisplayBar(new Vector2(104, 16), 2, Color.Red);
        }
        public void Update(World WORLD)
        {
            healthBar.Update(WORLD.user.hero.health, WORLD.user.hero.healthMax);
        }

        public void Draw(World WORLD)
        {
            Globals.normalEffect.Parameters["xSize"].SetValue(1.0f);
            Globals.normalEffect.Parameters["ySize"].SetValue(1.0f);
            Globals.normalEffect.Parameters["xDraw"].SetValue(1.0f);
            Globals.normalEffect.Parameters["yDraw"].SetValue(1.0f);
            Globals.normalEffect.Parameters["filterColor"].SetValue(Color.White.ToVector4());
            Globals.normalEffect.CurrentTechnique.Passes[0].Apply();

            string tempStr = "Score: " + GameGlobals.score;
            Vector2 strDims = font.MeasureString(tempStr);
            Globals.spriteBatch.DrawString(font, tempStr,new Vector2(Globals.screenWidth/2 - strDims.X/2, Globals.screenHeight - 40), Color.Black);

            if (WORLD.user.hero.dead || WORLD.user.buildings.Count <= 0)
            {
                tempStr = "Press Enter to Restart!";
                strDims = font.MeasureString(tempStr);
                Globals.spriteBatch.DrawString(font, tempStr, new Vector2(Globals.screenWidth / 2 - strDims.X / 2, Globals.screenHeight / 2), Color.Black);
            }

            healthBar.Draw(new Vector2(20, Globals.screenHeight - 50));

            if(GameGlobals.paused)
            {
                pauseOverlay.Draw(Vector2.Zero);
            }

        }
    }
}
