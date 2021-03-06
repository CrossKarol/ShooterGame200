﻿#region Includes
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
#endregion

namespace ShooterGame200
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Main : Game
    {
        GraphicsDeviceManager graphics;
        //SpriteBatch spriteBatch;

        GamePlay gamePlay;

        MainMenu mainMenu;
        WorldMap worldMap;
        Basic2D cursor;


        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            Globals.screenWidth = 1200;  //1600
            Globals.screenHeight = 700; //900

            graphics.PreferredBackBufferWidth = Globals.screenWidth;
            graphics.PreferredBackBufferHeight = Globals.screenHeight;

            graphics.ApplyChanges();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            Globals.content = this.Content;
            Globals.spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            cursor = new Basic2D("2D\\Misc\\Cursor1", new Vector2(0, 0), new Vector2(18, 18));

            Globals.normalEffect = Globals.content.Load<Effect>("Effects\\Normal");


            Globals.keyboard = new McKeyboard();
            Globals.mouse = new McMouseControl();
            
            mainMenu = new MainMenu(ChangeGameState, ExitGame, ChangeGameState);
            gamePlay = new GamePlay(ChangeGameState);
            worldMap = new WorldMap(ChangeGameState);
           
            

            Globals.soundControl = new SoundControl("Audio\\Muzyka");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            Globals.gameTime = gameTime;
            Globals.keyboard.Update();
            Globals.mouse.Update();

            if (Globals.gameState == 0)
            {

                mainMenu.Update();
            }
            else if (Globals.gameState == 1)
            {
                gamePlay.Update();
            }
            else if (Globals.gameState == 2)
            {
                worldMap.Update();
            }

            Globals.keyboard.UpdateOld();
            Globals.mouse.UpdateOld();
            base.Update(gameTime);
        }

        public virtual void ChangeGameState(object INFO)
        {
            Globals.gameState = Convert.ToInt32(INFO, Globals.culture);
        }
        public virtual void ExitGame(object INFO)
        {
            System.Environment.Exit(0);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            Globals.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);

            if (Globals.gameState == 0)
            {
                mainMenu.Draw();
            }
            else if (Globals.gameState == 1)
            {
                gamePlay.Draw();
            }
            else if (Globals.gameState == 2)
            {
                worldMap.Draw();
            }

            Globals.normalEffect.Parameters["xSize"].SetValue((float)cursor.myModel.Bounds.Width);
            Globals.normalEffect.Parameters["ySize"].SetValue((float)cursor.myModel.Bounds.Height);
            Globals.normalEffect.Parameters["xDraw"].SetValue((float)((int)cursor.dims.X));
            Globals.normalEffect.Parameters["yDraw"].SetValue((float)((int)cursor.dims.Y));
            Globals.normalEffect.Parameters["filterColor"].SetValue(Color.White.ToVector4());
            Globals.normalEffect.CurrentTechnique.Passes[0].Apply();

            cursor.Draw(new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y), new Vector2(0,0), Color.White);
            Globals.spriteBatch.End();



            base.Draw(gameTime);
        }
    }
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        static void Main()
        {
            using (var game = new Main())
                game.Run();
        }
    }
#endif
}
