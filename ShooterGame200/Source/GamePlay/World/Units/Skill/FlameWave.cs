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
    public class FlameWave : Skill
    {


        public FlameWave(AttackableObject OWNER) : base(OWNER)
        {


        }

        public override void Targeting(Vector2 OFFSET, Player ENEMY)
        {
            if (Globals.mouse.LeftClickRelease())
            {
                targetEffect.done = true;

                GameGlobals.PassProjectile(new FlameWaveProjectile(Globals.mouse.newMousePos - OFFSET, owner, new Vector2(0, 0), 1500));

                done = true;
                active = false;

            }
            else
            {
                targetEffect.pos = Globals.mouse.newMousePos - OFFSET;
            }
        }
    }
}
