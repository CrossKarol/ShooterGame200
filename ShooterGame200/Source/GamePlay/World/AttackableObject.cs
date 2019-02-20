#region Includes
using Microsoft.Xna.Framework;
#endregion


namespace ShooterGame200
{
    public class AttackableObject : Animated2d
    {
        public bool dead;

        public float speed;
        public float hitDist;
        public float health;
        public float healthMax;

        public int killValue;
        public int ownerId;
        public AttackableObject(string PATH, Vector2 POS, Vector2 DIMS, Vector2 FRAMES, int OWNERID) 
            : base(PATH, POS, DIMS, FRAMES, Color.White)
        {
            ownerId = OWNERID;
            dead = false;
            speed = 2.0f;
            health = 1;
            healthMax = health;
            killValue = 1;
            hitDist = 35.0f;
        }

        public virtual void GetHit(AttackableObject ATTACKER, float DAMAGE)
        {
            health -= DAMAGE;
            if (health <= 0)
            {

                dead = true;

                GameGlobals.PassGold(new PlayerValuePacket(ATTACKER.ownerId, killValue));
            }
        }
        public virtual void Update(Vector2 OFFSET, Player ENEMY, SquareGrid GRID)
        {

            base.Update(OFFSET);
        }



   

        public override void Draw(Vector2 OFFSET)
        {
            Globals.normalEffect.Parameters["xSize"].SetValue((float)myModel.Bounds.Width);
            Globals.normalEffect.Parameters["ySize"].SetValue((float)myModel.Bounds.Height);
            Globals.normalEffect.Parameters["xDraw"].SetValue((float)((int)dims.X));
            Globals.normalEffect.Parameters["yDraw"].SetValue((float)((int)dims.Y));
            Globals.normalEffect.Parameters["filterColor"].SetValue(Color.White.ToVector4());
            Globals.normalEffect.CurrentTechnique.Passes[0].Apply();

            base.Draw(OFFSET);
        }

    }
}
