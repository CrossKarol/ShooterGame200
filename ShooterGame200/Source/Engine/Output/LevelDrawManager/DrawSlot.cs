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
    public class DrawSlot
    {
        public bool drawing;
        public int id;
        public Vector2 offset;
        public SceneItem item;

        public DrawSlot(SceneItem ITEM, bool DRAWING)
        {
            drawing = DRAWING;
            id = ITEM.drawLocId;
            item = ITEM;
            item.DrawManagerDel = new PassObject(UpdateDetails);
        }

        public virtual void UpdateDetails(Object INFO)
        {
            DrawSlotUpdatePackage temp = (DrawSlotUpdatePackage)INFO;
            offset = new Vector2(temp.offset.X, temp.offset.Y);
            drawing = temp.drawing;
        }

        public virtual void Draw()
        {
            if(drawing)
            {

                item.Draw(offset);
                
            }
            else
            {

            }
        }
    }
}
