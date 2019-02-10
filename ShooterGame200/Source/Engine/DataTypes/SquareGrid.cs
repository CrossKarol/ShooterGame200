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
    public class SquareGrid
    {

        public bool showGrid;

        public Vector2 slotDims, gridDims, physicalStartPos, totalPhysicalDims, currentHoverSlot;

        public Basic2D gridImg;



        public List<List<GridLocation>> slots = new List<List<GridLocation>>();


        public SquareGrid(Vector2 SLOTDIMS, Vector2 STARTPOS, Vector2 TOTALDIMS)
        {
            showGrid = false;

            slotDims = SLOTDIMS;

            physicalStartPos = new Vector2((int)STARTPOS.X, (int)STARTPOS.Y);
            totalPhysicalDims = new Vector2((int)TOTALDIMS.X, (int)TOTALDIMS.Y);

            currentHoverSlot = new Vector2(-1, -1);

            SetBaseGrid();
            
            gridImg = new Basic2D("2d\\Misc\\shade", slotDims/2, new Vector2(slotDims.X-2, slotDims.Y-2));
        }

        public virtual void Update(Vector2 OFFSET)
        {
            currentHoverSlot = GetSlotFromPixel(new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y), -OFFSET);
        }

        public virtual Vector2 GetPosFromLoc(Vector2 LOC)
        {
            return physicalStartPos + new Vector2((int)LOC.X * slotDims.X, (int)LOC.Y * slotDims.Y);
        }

        public virtual GridLocation GetSlotFromLocation(Vector2 LOC)
        {
            if(LOC.X >= 0 && LOC.Y >= 0 && LOC.X < slots.Count && LOC.Y < slots[(int)LOC.X].Count)
            {
                return slots[(int)LOC.X][(int)LOC.Y];
            }

            return null;
        }

        public virtual Vector2 GetSlotFromPixel(Vector2 PIXEL, Vector2 OFFSET)
        {
            Vector2 adjustedPos = PIXEL - physicalStartPos + OFFSET;

            Vector2 tempVec = new Vector2(Math.Min(Math.Max(0, (int)(adjustedPos.X/slotDims.X)), slots.Count-1), Math.Min(Math.Max(0, (int)(adjustedPos.Y/slotDims.Y)), slots[0].Count-1));

            return tempVec;
        }

        public virtual void SetBaseGrid()
        {
            gridDims = new Vector2((int)(totalPhysicalDims.X/slotDims.X), (int)(totalPhysicalDims.Y/slotDims.Y));

            slots.Clear();
            for(int i=0; i<gridDims.X; i++)
            {
                slots.Add(new List<GridLocation>());

                for(int j=0; j<gridDims.Y; j++)
                {
                    slots[i].Add(new GridLocation(1, false));
                }
            }
        }


        public virtual void DrawGrid(Vector2 OFFSET)
        {
            if(showGrid)
            {
                //Vector2 topLeft = GetSlotFromPixel((new Vector2(0, 0)) / Globals.zoom  - OFFSET, Vector2.Zero);
                //Vector2 botRight = GetSlotFromPixel((new Vector2(Globals.screenWidth, Globals.screenHeight)) / Globals.zoom  - OFFSET, Vector2.Zero);
                Vector2 topLeft = GetSlotFromPixel(new Vector2(0, 0), Vector2.Zero);
                Vector2 botRight = GetSlotFromPixel(new Vector2(Globals.screenWidth, Globals.screenHeight), Vector2.Zero);

                Globals.normalEffect.Parameters["filterColor"].SetValue(Color.White.ToVector4());
                Globals.normalEffect.CurrentTechnique.Passes[0].Apply();

                for(int j=(int)topLeft.X;j<=botRight.X && j<slots.Count;j++)
                {
                    for(int k=(int)topLeft.Y;k<=botRight.Y && k<slots[0].Count;k++)
                    {
                        if(currentHoverSlot.X == j && currentHoverSlot.Y == k)
                        {
                            Globals.normalEffect.Parameters["filterColor"].SetValue(Color.Red.ToVector4());
                            Globals.normalEffect.CurrentTechnique.Passes[0].Apply();

                        }
                        else if(slots[j][k].filled)
                        {
                            Globals.normalEffect.Parameters["filterColor"].SetValue(Color.DarkGray.ToVector4());
                            Globals.normalEffect.CurrentTechnique.Passes[0].Apply();
                        }
                        else
                        {
                            Globals.normalEffect.Parameters["filterColor"].SetValue(Color.White.ToVector4());
                            Globals.normalEffect.CurrentTechnique.Passes[0].Apply();
                        }

                        gridImg.Draw(OFFSET + physicalStartPos + new Vector2(j * slotDims.X, k * slotDims.Y));
                    }
                }
            }
        }
    }
}
