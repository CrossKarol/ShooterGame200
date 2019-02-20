#region Includes
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
#endregion

namespace ShooterGame200
{
    public class TileBkg2d : Basic2D
    {

        public Vector2 bkgDims;

        public TileBkg2d(string PATH, Vector2 POS, Vector2 DIMS, Vector2 BKGDIMS) : base(PATH, POS, new Vector2((float)Math.Floor(DIMS.X), (float)Math.Floor(DIMS.Y)))
        {
            bkgDims = new Vector2((float)Math.Floor(BKGDIMS.X), (float)Math.Floor(BKGDIMS.Y));
    
        }

        public override void Draw(Vector2 OFFSET)
        {
            float numX = (float)Math.Ceiling(bkgDims.X / dims.X);
            float numY = (float)Math.Ceiling(bkgDims.Y / dims.Y);

            for (int i=0; i < numX; i++)
            {
                for (int j = 0; j < numY; j++)
                {
                    if (i < numX-1 && j < numY-1)
                    {
                        base.Draw(OFFSET + new Vector2(dims.X / 2 + dims.X * i, dims.Y / 2 + dims.Y * j));
                    }
                    else
                    {
                        float xLeft = Math.Min(dims.X, (bkgDims.X - (i * dims.X)));
                        float yLeft = Math.Min(dims.Y, (bkgDims.Y - (j * dims.Y)));
                        float xPercentLeft = Math.Min(1, xLeft / dims.X);
                        float yPercentLeft = Math.Min(1, yLeft / dims.Y);

                        Globals.spriteBatch.Draw(myModel, new Rectangle((int)(pos.X + OFFSET.X + dims.X * i), (int)(pos.Y + OFFSET.Y + dims.Y * j), (int)Math.Ceiling(dims.X * xPercentLeft), (int)Math.Ceiling(dims.Y * yPercentLeft)), new Rectangle(0, 0, (int)(xPercentLeft * myModel.Bounds.Width), (int)(yPercentLeft * myModel.Bounds.Height)), Color.White, rot, new Vector2(0, 0), new SpriteEffects(), 0);
                    }
                }
            }
        }
    }
}
