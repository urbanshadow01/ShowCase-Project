﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Game1
{
    class Menu
    {
        private MouseState oldState;
        private bool OnMenu = false;
        internal bool GetIsMenu { get { return OnMenu; } }
        internal bool SetIsMenu { set { OnMenu = value; } }
        internal void LoadContent(ContentManager Content)
        {

        }

        internal void Update(GameTime gameTime, int menuOption)
        {
            if (OnMenu)
            {
                MouseState mouse = Mouse.GetState();
            }
        }

        internal void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
