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
    class AIShooter : Shooter
    {

        internal AIShooter(ContentManager Content)
        {
            coolDown = 1;
            bullets.Clear();
            this.Pos = new Vector2(500, 1200);
            base.LoadContent(Content);
            shooterSprite = new Sprite(shooterText);
            shooterSprite.Position = Pos;
            MaxVelocity = new Vector2(100, 100);
            MinVelocity = new Vector2(-100, -100);
            Friction = 2.5f;
        }

        internal override void Update(GameTime gametime, Runner run)
        {
            shooterSprite.Position = this.Pos;
            #region shoot
            if (coolDown <= 0)
            {
                float Angle = (float)(Math.Atan2(run.Pos.Y - Pos.Y, run.Pos.X - Pos.X));
                bullets.Add(shoot(Angle));
                coolDown = 1;
            }
            coolDown -= 1 * gametime.ElapsedGameTime.TotalSeconds;
            #endregion
            #region bulletUpdate
            int bulletCount = 0;
            foreach (Bullet bullet in bullets)
            {
                bullet.Update(gametime, bulletText);
                bulletSprites[bulletCount].Position = bullet.Pos;
                bulletSprites[bulletCount].transform =
                    Matrix.CreateTranslation(new Vector3(-(new Vector2(bulletText.Width / 2, bulletText.Height / 2)), 0f)) *
                    Matrix.CreateRotationZ(bullet.Angle + (float)Math.PI * .5f) *
                    Matrix.CreateTranslation(new Vector3(bullet.Pos, 0f));

                bulletCount++;
            }

            for (int i = bullets.Count - 1; i >= 0; i--)
            {
                Bullet bullet = bullets.ElementAt(i);
                if (bullet.Remove)
                {
                    bulletSprites.RemoveAt(i);
                    bullets.RemoveAt(i);
                }
            }
            #endregion
            //Hitbox = new Circle(new Vector2(shooterText.Bounds.Center.X,shooterText.Bounds.Center.Y),shooterText.Width);
        }
        internal override void Update(GameTime gametime)
        {

        }
    }
}
