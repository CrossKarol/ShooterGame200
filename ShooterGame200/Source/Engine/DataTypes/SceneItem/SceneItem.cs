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
    public class SceneItem : Animated2d
    {

        public SceneItem(string PATH, Vector2 POS, Vector2 DIMS, Vector2 FRAMES, Vector2 SCALE)
            : base(PATH, POS, DIMS * SCALE, FRAMES, Color.White)
        {

        }



    }
}
