#region Includes
using System.Collections.Generic;
using Microsoft.Xna.Framework;
#endregion


namespace ShooterGame200
{ 
    public class MainMenu
    {
        public Basic2D bkg;

        public PassObject PlayClickDel, ExitClickDel;
        int playState;
        public List<Button2d> buttons = new List<Button2d>();

        PassObject ChangeGameState;
        public MainMenu(PassObject PLAYCLICKDEL, PassObject EXITCLICKDEL, PassObject CHANGEGAMESTATE)
        {
          
            PlayClickDel = PLAYCLICKDEL;
            ExitClickDel = EXITCLICKDEL;
            ChangeGameState = CHANGEGAMESTATE;

            bkg = new Basic2D("2D\\UI\\Backgrounds\\MenuBackground", new Vector2(Globals.screenWidth/2, Globals.screenHeight/2), new Vector2(Globals.screenWidth, Globals.screenHeight));

            buttons.Add(new Button2d("2D\\Misc\\button1", new Vector2(0, 0), new Vector2(126, 42), "Fonts\\Arial16", "Play", PlayClickDel, 1));

            buttons.Add(new Button2d("2D\\Misc\\button1", new Vector2(0, 0), new Vector2(126, 42), "Fonts\\Arial16", "Exit", ExitClickDel, null));
        }

        public virtual void Update()
        {
            for(int i=0; i<buttons.Count; i++)
            {
                buttons[i].Update(new Vector2(600, 400 + 55 * i));
            }
        }

        public virtual void Draw()
        {
            bkg.Draw(Vector2.Zero);
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Draw(new Vector2(600, 400 + 55 * i));
            }
        }
    }
}
