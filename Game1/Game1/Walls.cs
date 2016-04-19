using System;
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
    class Walls
    {

        private List<Texture2D> Textures = new List<Texture2D>();
        private List<Sprite> WallSprites = new List<Sprite>();
        internal Walls()
        {

        }

        internal void LoadContent(ContentManager Content)
        {

        }
        // ScrollingBackground.Update
        internal void Update()
        {
            foreach(Sprite sprite in WallSprites)
            {

            }
        }

    }
}
