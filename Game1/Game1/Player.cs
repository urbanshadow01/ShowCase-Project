﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Game1
{
    abstract class Player
    {
        internal Vector2 Pos { get; set; }
        internal Vector2 GetVelocity { get { return Velocity; } }
        internal Vector2 SetVelocity { set { Velocity = value; } }
        protected Vector2 Velocity;
        protected Vector2 MaxVelocity = new Vector2(200, 200);
        protected Vector2 MinVelocity = new Vector2(-200, -200);
        protected float Friction = 5;
        internal Player()
        {

        }







    }
}
