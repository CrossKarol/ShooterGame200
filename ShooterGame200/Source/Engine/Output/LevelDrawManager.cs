#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using System.Threading.Tasks;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
#if WINDOWS_PHONE
using Microsoft.Xna.Framework.Input.Touch;
#endif
using Microsoft.Xna.Framework.Media;
#endregion

namespace ShooterGame200
{
    public class LevelDrawManager
    {
        public bool sortRunning;

        public int nextId;

        public List<DrawSlot> drawables = new List<DrawSlot>();

        public McTimer sortTimer = new McTimer(120);

        public LevelDrawManager()
        {
            sortRunning = false;
            nextId = 1;

        }

        public virtual void Update()
        {
            sortTimer.UpdateTimer();

            if(sortTimer.Test())
            {
                Sort();
                sortTimer.ResetToZero();
            }
        }

        public virtual void Sort()
        {
            if(!sortRunning)
            {
                Task sortTask = new Task(() =>
                {
                    sortRunning = true;

                    DrawSlot tempSlot = null;

                    for(int i=0; i<drawables.Count; i++)
                    {

                        //Resort based on draw layer
                        if(i > 0 && drawables[i].item.drawLayer < drawables[i-1].item.drawLayer)
                        {
                        
                            for(int j=0; j<drawables.Count; j++)
                            {
                                if(drawables[j].item.drawLayer > drawables[i].item.drawLayer)
                                {
                                    tempSlot = drawables[i];
                                    drawables.RemoveAt(i);
                                    drawables.Insert(j, tempSlot);
                                    break;
                                }
                            }
                        }

                        //Resort based on Y pos
                        if(i > 0 && drawables[i].item.drawLayer == drawables[i-1].item.drawLayer && drawables[i].item.SortDrawPos.Y < drawables[i-1].item.SortDrawPos.Y)
                        {
                            for(int j=0;j<drawables.Count;j++)
                            {
                                if(drawables[j].item.SortDrawPos.Y > drawables[i].item.SortDrawPos.Y && drawables[i].item.drawLayer == drawables[j].item.drawLayer)
                                {
                                    tempSlot = drawables[i];
                                    drawables.RemoveAt(i);
                                    drawables.Insert(j, tempSlot);
                                    break;
                                }
                            }
                        }

                    }
                    
                    sortRunning = false;
                });
                sortTask.Start();
            }
            
        }

        public virtual void AddOrUpdateDraws(SceneItem ITEM, bool DRAWABLE)
        {
            if(ITEM.drawLocId == 0 || !SearchForItemById(ITEM.drawLocId))
            {
                bool add = true;
                for(int i=0; i<drawables.Count; i++)
                {
                    if(drawables[i].item == ITEM)
                    {
                        add = false;
                    }
                }

                if(add)
                {
                    InsertItemByPos( ITEM, DRAWABLE);
                }
            }
            else
            {

            }
        }

        public virtual int GetNextID()
        {
            int temp = nextId;
            nextId++;

            return temp;
        }

        public virtual void InsertItemByPos(SceneItem ITEM, bool DRAWABLE)
        {
            ITEM.drawLocId = GetNextID();

            bool added = false;
            for(int i=0; i<drawables.Count; i++)
            {
                //if(drawables[i].item.drawLayer > ITEM.drawLayer || (drawables[i].item.drawLayer == ITEM.drawLayer && drawables[i].item.SortDrawPos.Y >= ITEM.SortDrawPos.Y))
                if(drawables[i].item.SortDrawPos.Y >= ITEM.SortDrawPos.Y || (drawables[i].item.drawLayer > ITEM.drawLayer && drawables[i].item.SortDrawPos.Y == ITEM.SortDrawPos.Y))
                {
                    drawables.Insert(Math.Max(0, i-1), new DrawSlot(ITEM, DRAWABLE));
                    added = true;
                    break;
                }
            }

            if(!added)
            {
                drawables.Add(new DrawSlot(ITEM, DRAWABLE));
            }
        }

        public virtual void Remove(SceneItem ITEM)
        {
            ITEM.drawLocId = 0;

            for(int i=0; i<drawables.Count; i++)
            {
                if(drawables[i].item.drawLocId == ITEM.drawLocId)
                {
                    drawables.RemoveAt(i);
                }
            }
        }

        public virtual bool SearchForItemById(int ID)
        {
            for(int i=0; i<drawables.Count; i++)
            {
                if(drawables[i].id == ID)
                {
                    return true;
                }
            }

            return false;
        }

        /*public virtual void SetAlternateDrawFuncById(int ID, PassObject FUNC)
        {
            for(int i=0;i<drawables.Count;i++)
            {
                if(drawables[i].id == ID)
                {
                    drawables[i].AlternateDrawFunc = FUNC;
                }
            }
        }*/

        public virtual void Draw()
        {
            for(int i=0; i<drawables.Count; i++)
            {
                if(drawables[i].drawing)
                {
                    drawables[i].Draw();
                }
                else
                {

                }
            }
        }
    }
}
