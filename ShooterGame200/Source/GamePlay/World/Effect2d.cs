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
    public class Effect2d : Animated2d
    {

        public bool done, noTimer;

        public McTimer timer;


        public Effect2d(string PATH, Vector2 POS, Vector2 DIMS, Vector2 FRAMES, int MSEC)
            : base(PATH, POS, DIMS, FRAMES, Color.White)
        {
            done = false;
            noTimer = false;
            timer = new McTimer(MSEC);
        }

        public override void Update(Vector2 OFFSET)
        {
            timer.UpdateTimer();
            if (timer.Test() && !noTimer)
            {
                done = true;
            }

            base.Update(OFFSET);
        }


        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
