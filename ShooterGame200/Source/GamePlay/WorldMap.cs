#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
#endregion

namespace ShooterGame200
{
    public class WorldMap
    {

        public List<Button2d> levels = new List<Button2d>();

        PassObject ChangeGameState;

        public Basic2D bkg;
        public WorldMap(PassObject CHANGEGAMESTATE)
        {
            ChangeGameState = CHANGEGAMESTATE;

            bkg = new Basic2D("2D\\UI\\Backgrounds\\WordMapBackground", new Vector2(Globals.screenWidth / 2, Globals.screenHeight / 2), new Vector2(Globals.screenWidth, Globals.screenHeight));


            LoadData();
        }

        public virtual void Update()
        {
            for(int i=0; i <levels.Count; i++)
            {
                levels[i].Update(Vector2.Zero);
            }
        }

   
        public virtual void LoadData()
        {
            XDocument xml = XDocument.Load("XML\\Levels.xml");

            List<XElement> levelList = (from t in xml.Descendants("Level")
                                            select t).ToList<XElement>();

            for(int i=0; i<levelList.Count; i++)
            {
                levels.Add(new Button2d("2D\\Misc\\SimpleBtn", new Vector2(Convert.ToInt32(levelList[i].Element("Pos").Element("x").Value, Globals.culture), Convert.ToInt32(levelList[i].Element("Pos").Element("y").Value, Globals.culture)), new Vector2(150, 40), "Fonts\\Arial16", levelList[i].Element("name").Value, LevelClicked, levelList[i].Attribute("id").Value));
            }
        }
        public virtual void LevelClicked(object INFO)
        {
            ChangeGameState(INFO);
        }



        public virtual void Draw()
        {
            bkg.Draw(Vector2.Zero);

            for (int i = 0; i < levels.Count; i++)
            {
                levels[i].Draw(Vector2.Zero);
            }
        }
    }
}
