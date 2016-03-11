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
        internal Texture2D shooterText;
        internal Texture2D bulletText;
        protected double coolDown = 0;
        internal Shooter()
        {
            bullets.Clear();
            Pos = new Vector2(300, 300);
        }

        internal abstract void Update(GameTime gametime);
        internal void LoadContent(ContentManager Content)
        {
            shooterText = Content.Load<Texture2D>("player1");
            bulletText = Content.Load<Texture2D>("bullet");
        }
        internal Bullet shoot(float Angle)
        {
            double bulletSpeed = 100; // to be decided later
            float velocityX = (float)(Math.Cos(Angle) * bulletSpeed);
            float velocityY = (float)(Math.Sin(Angle) * bulletSpeed);


            return new Bullet(new Vector2(velocityX, velocityY), false, Angle);
        }
        internal bool Win(Runner run)
        {
            foreach (Bullet bull in bullets)
            {
                if (bull.Hit(run))
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
            Vector2 origin = new Vector2(bulletText.Width / 2f, bulletText.Height / 2f);
            foreach (Bullet bull in bullets)
            {
                spritebatch.Draw(bulletText, bull.Pos,
                    null, Color.White, (float)(bull.Angle * 180/Math.PI), Vector2.Zero, 1.0f, SpriteEffects.None, 1.0f);
               // spritebatch.Draw(bulletText, bull.Pos, Color.White);
            }
        }
    }

}
