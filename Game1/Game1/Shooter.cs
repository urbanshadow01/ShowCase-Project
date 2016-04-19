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

    abstract class Shooter : Player
    {

        protected List<Bullet> bullets = new List<Bullet>();
        protected List<Sprite> bulletSprites = new List<Sprite>();
        internal Texture2D shooterText;
        internal Texture2D bulletText;
        protected double coolDown = 1;
        internal Sprite shooterSprite;
        internal Shooter()
        {
        }

        internal void LoadContent(ContentManager Content)
        {
            shooterText = Content.Load<Texture2D>("player1");
            bulletText = Content.Load<Texture2D>("bullet");
        }
        internal abstract void Update(GameTime gametime);
        internal abstract void Update(GameTime gametime, Runner run);

        internal Bullet shoot(float Angle)
        {
            double bulletSpeed = 100; // to be decided later
            float velocityX = (float)(Math.Cos(Angle) * bulletSpeed);
            float velocityY = (float)(Math.Sin(Angle) * bulletSpeed);

            bulletSprites.Add(new Sprite(bulletText));
            return new Bullet(new Vector2(velocityX, velocityY), false, Angle, Pos);
        }
        internal bool Win(Runner run)
        {
            foreach (Sprite bull in bulletSprites)
            {
                if (bull.CollidesWith(run.runnerSprite, true))
                {
                    return true;
                }
            }
            return false;
        }
        internal List<Bullet> getBullet()
        {
            return bullets;
        }

        internal void Draw(SpriteBatch spritebatch)
        {

            spritebatch.Draw(shooterText, Pos, Color.White);
            Vector2 origin = new Vector2(bulletText.Bounds.Center.X, bulletText.Bounds.Center.Y);
            foreach (Bullet bull in bullets)
            {
                spritebatch.Draw(bulletText, bull.Pos,
                    null, Color.White, (bull.Angle + (float)(Math.PI * .5f)), origin, 1.0f, SpriteEffects.None, 0f);
                // spritebatch.Draw(bulletText, bull.Pos, Color.White);
            }
        }
    }

}
