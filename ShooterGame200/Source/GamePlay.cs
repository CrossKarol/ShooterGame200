#region Includes
using System;
using Microsoft.Xna.Framework;
#endregion

namespace ShooterGame200
{
    public class GamePlay
    {
        World world;

        WorldMap worldMap;
        int playState;

     
   
        PassObject ChangeGameState;

        public GamePlay(PassObject CHANGEGAMESTATE)
        {
            playState = 1;

            ChangeGameState = CHANGEGAMESTATE;

            ResetWorld(null);
            worldMap = new WorldMap(ChangePlayState);

        }

        public virtual void Update()
        {
            if(playState == 0)
            {
                world.Update();
            }
            
            else if (playState == 1)
            {
                worldMap.Update();
            }
           
        }


        public virtual void ChangeWorld(object INFO)
        {
            int levelId = 2;

            world = new World(ResetWorld, levelId, ChangeGameState);
        }
        public virtual void ChangePlayState(object INFO)
        {
            playState = 0;

            world = new World(ResetWorld, Convert.ToInt32(INFO, Globals.culture), ChangeGameState);
        }

        public virtual void ResetWorld(object INFO)
        {
            try
            {
                int a = Convert.ToInt32(INFO.ToString());
                world = new World(ResetWorld, a, ChangeGameState);
            }
            catch(Exception e)
            {
                int levelId = 1;
                if (world != null)
                {
                    levelId = world.levelId;
                }

                world = new World(ResetWorld, levelId, ChangeGameState);
            }
            
       
        }
       

        public virtual void Draw()
        {
            if (playState == 0)
            {
                world.Draw(Vector2.Zero);
            }
            else if (playState == 1)
            {
                worldMap.Draw();
            }
          
        }
    }
}
