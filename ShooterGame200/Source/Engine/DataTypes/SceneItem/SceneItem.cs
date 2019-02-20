#region Includes
using Microsoft.Xna.Framework;
#endregion

namespace ShooterGame200
{
    public class SceneItem : Animated2d
    {

        public int drawLocId, drawLayer;

        public Vector2 sortOffset;
        public PassObject DrawManagerDel;

        public SceneItem(string PATH, Vector2 POS, Vector2 DIMS, Vector2 FRAMES, Vector2 SCALE)
            : base(PATH, POS, DIMS * SCALE, FRAMES, Color.White)
        {
            drawLocId = 0;
            drawLayer = 5;

            sortOffset = new Vector2(0, 0);
        }

    
        public virtual Vector2 SortDrawPos
        {
            get
            {
                return pos + sortOffset;
            }

            set
            {
                pos = value - (sortOffset);
            }
        }

        public virtual void UpdateDraw(Vector2 OFFSET, LevelDrawManager LEVELDRAWMANAGER)
        {
            if(drawLocId == 0 && LEVELDRAWMANAGER != null)
            {
                LEVELDRAWMANAGER.AddOrUpdateDraws(this, true);
            }
            if(DrawManagerDel != null)
            {
                DrawManagerDel(new DrawSlotUpdatePackage(OFFSET, true));
            }
        }
    }
}
