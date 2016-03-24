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
    abstract class Runner : Player
    {
        protected Vector2 Velocity;
        protected Vector2 MaxVelocity = new Vector2(200, 200);
        protected Vector2 MinVelocity = new Vector2(-200, -200);
        protected int Friction = 10;
        internal Texture2D runnerText;
        internal Sprite runnerSprite;
        
        internal Runner()
        {
            runnerSprite = new Sprite(runnerText);
        }
        internal abstract void Update(GameTime gametime);
        internal void LoadContent(ContentManager Content)
        {
            runnerText = Content.Load<Texture2D>("player2");
        }
        internal void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(runnerText, Pos, Color.White);
        }
        internal bool Win(Shooter shooter)
        {
            if (Hitbox.Intersects(shooter.Hitbox))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
