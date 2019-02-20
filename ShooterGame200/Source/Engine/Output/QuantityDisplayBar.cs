#region Includes
using Microsoft.Xna.Framework;
#endregion


namespace ShooterGame200
{
    public class QuantityDisplayBar
    {
        public int boarder;

        public Basic2D bar, barBKG;

        public Color color;

        public QuantityDisplayBar(Vector2 DIMS, int BOARDER, Color COLOR)
        {
            boarder = BOARDER;
            color = COLOR;

            bar = new Basic2D("2D\\Misc\\bar", new Vector2(0, 0), new Vector2(DIMS.X - boarder * 2, DIMS.Y - boarder * 2));
            barBKG = new Basic2D("2D\\Misc\\barBkg", new Vector2(0, 0), new Vector2(DIMS.X, DIMS.Y));
        }

        public virtual void Update(float CURRENT, float MAX)
        {
            bar.dims = new Vector2(CURRENT/MAX*(barBKG.dims.X-boarder*2), bar.dims.Y);
        }

        public virtual void Draw(Vector2 OFFSET)
        {
            Globals.normalEffect.Parameters["xSize"].SetValue(1.0f);
            Globals.normalEffect.Parameters["ySize"].SetValue(1.0f);
            Globals.normalEffect.Parameters["xDraw"].SetValue(1.0f);
            Globals.normalEffect.Parameters["yDraw"].SetValue(1.0f);
            Globals.normalEffect.Parameters["filterColor"].SetValue(Color.Black.ToVector4());
            Globals.normalEffect.CurrentTechnique.Passes[0].Apply();


            barBKG.Draw(OFFSET, new Vector2(0, 0), Color.Black);

            Globals.normalEffect.Parameters["filterColor"].SetValue(color.ToVector4());
            Globals.normalEffect.CurrentTechnique.Passes[0].Apply();

            bar.Draw(OFFSET + new Vector2(boarder, boarder), new Vector2(0, 0), color);
        }
    }
}
