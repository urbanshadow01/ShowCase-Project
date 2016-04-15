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
        internal Vector2 GetVelocity { get { return Velocity; } }
        protected Vector2 Velocity;
        protected Vector2 MaxVelocity = new Vector2(200, 200);
        protected Vector2 MinVelocity = new Vector2(-200, -200);
        protected int Friction = 10;
        internal Texture2D runnerText;
        internal Sprite runnerSprite;

        internal Runner()
        {

        }
        internal abstract void Update(GameTime gametime);
        internal abstract void Update(GameTime gametime, Shooter shooter);
        internal void Draw(SpriteBatch spritebatch)
        {
            if (runnerText != null)
            {
                spritebatch.Draw(runnerText, Pos, Color.White);
            }
        }
        internal bool Win(Shooter shooter)
        {
            if (runnerSprite.CollidesWith(shooter.shooterSprite, false))
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
