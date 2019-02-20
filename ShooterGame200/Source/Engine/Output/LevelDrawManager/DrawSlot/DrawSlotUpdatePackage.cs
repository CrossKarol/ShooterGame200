#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
#if WINDOWS_PHONE
using Microsoft.Xna.Framework.Input.Touch;
#endif
using Microsoft.Xna.Framework.Media;
#endregion

namespace ShooterGame200
{
    public class DrawSlotUpdatePackage
    {
        public Vector2 offset;
        public bool drawing;

        public DrawSlotUpdatePackage(Vector2 OFFSET, bool DRAWING)
        {
            drawing = DRAWING;
            offset = OFFSET;
        }
    }
}
