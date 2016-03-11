using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Game1
{
    class AIShooter : Shooter
    {

        internal AIShooter()
        {

        }

        internal override void Update(GameTime gametime)
        {
            double Angle;
            Angle = Math.Atan2(0 - Pos.Y, 0 - Pos.X);



        }
    }
}
