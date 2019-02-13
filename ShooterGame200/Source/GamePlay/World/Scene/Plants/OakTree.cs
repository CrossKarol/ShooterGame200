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
    public class OakTree : SceneItem
    {

        public OakTree(Vector2 POS, Vector2 SCALE)
            : base("2D\\UI\\Scene\\OakTree", POS, new Vector2(100, 100) * SCALE, new Vector2(1, 1), SCALE)
        {


        }

    }
}
