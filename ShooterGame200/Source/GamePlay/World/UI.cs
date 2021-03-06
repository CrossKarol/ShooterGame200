﻿#region Includes
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
#endregion

namespace ShooterGame200
{
    public class UI
    {
        public Basic2D pauseOverlay;

        public Button2d resetBtn;

        public SpriteFont font;

        public QuantityDisplayBar healthBar;
        public Player ENEMY;

        public UI(PassObject RESET)
        {
            pauseOverlay = new Basic2D("2D\\Misc\\pause_icon", new Vector2(Globals.screenWidth/2, Globals.screenHeight/2), new Vector2(200, 200));

            font = Globals.content.Load<SpriteFont>("Fonts\\Arial16");

            resetBtn = new Button2d("2D\\Misc\\button1", new Vector2(0, 0), new Vector2(96, 32), "Fonts\\Arial16", "Reset", RESET, null);

            healthBar = new QuantityDisplayBar(new Vector2(104, 16), 2, Color.Red);
        }
        public void Update(World WORLD)
        {
            healthBar.Update(WORLD.user.hero.health, WORLD.user.hero.healthMax);


            if (WORLD.user.hero.dead || WORLD.user.buildings.Count <= 0)
            {
                resetBtn.Update(new Vector2(Globals.screenWidth / 2, Globals.screenHeight / 2 + 100));
            }

        }

        public void Draw(World WORLD)
        {
            Globals.normalEffect.Parameters["xSize"].SetValue(1.0f);
            Globals.normalEffect.Parameters["ySize"].SetValue(1.0f);
            Globals.normalEffect.Parameters["xDraw"].SetValue(1.0f);
            Globals.normalEffect.Parameters["yDraw"].SetValue(1.0f);
            Globals.normalEffect.Parameters["filterColor"].SetValue(Color.White.ToVector4());
            Globals.normalEffect.CurrentTechnique.Passes[0].Apply();

            string tempStr = "Gold: " + WORLD.user.gold;
            Vector2 strDims = font.MeasureString(tempStr);
            Globals.spriteBatch.DrawString(font, tempStr, new Vector2(40, 40), Color.Black);

            tempStr = "Score: " + GameGlobals.score;
            strDims = font.MeasureString(tempStr);
            Globals.spriteBatch.DrawString(font, tempStr,new Vector2(Globals.screenWidth/2 - strDims.X/2, Globals.screenHeight - 40), Color.Black);

            if (WORLD.user.hero.dead || WORLD.user.spawnPoints.Equals(0))
            {
                tempStr = "Press Enter or click Button to Restart!";
                strDims = font.MeasureString(tempStr);
                Globals.spriteBatch.DrawString(font, tempStr, new Vector2(Globals.screenWidth / 2 - strDims.X / 2, Globals.screenHeight / 2), Color.Black);

                resetBtn.Draw(new Vector2(Globals.screenWidth / 2, Globals.screenHeight / 2 + 100));
            }

            if (WORLD.user.gold>50|| WORLD.user.buildings.Count <= 0)
            {
                tempStr = "You won click enter to play again!";
                strDims = font.MeasureString(tempStr);
                
                Globals.spriteBatch.DrawString(font, tempStr, new Vector2(Globals.screenWidth / 2 - strDims.X / 2, Globals.screenHeight / 2), Color.Black);

                resetBtn.Draw(new Vector2(Globals.screenWidth / 2, Globals.screenHeight / 2 + 100));
            }


            healthBar.Draw(new Vector2(20, Globals.screenHeight - 50));

            if(GameGlobals.paused&&WORLD.user.gold<50)
            {
                pauseOverlay.Draw(Vector2.Zero);
            }

        }
    }
}
