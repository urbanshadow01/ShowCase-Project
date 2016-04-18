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

        internal AIShooter(Texture2D bullText, Texture2D shootText)
        {
            coolDown = 1;
            bullets.Clear();
            this.Pos = new Vector2(500, 1200);
            bulletText = bulletText;
            shooterText = shootText;
            shooterSprite = new Sprite(shooterText);
            shooterSprite.Position = Pos;
        }

        internal override void Update(GameTime gametime, Runner run)
        {
            shooterSprite.Position = this.Pos;
            if (coolDown <= 0)
            {
                float Angle = (float)(Math.Atan2(run.Pos.Y - Pos.Y, run.Pos.X - Pos.X));
                bullets.Add(shoot(Angle));
                coolDown = 1;
            }
            coolDown -= 1 * gametime.ElapsedGameTime.TotalSeconds;

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
            //Hitbox = new Circle(new Vector2(shooterText.Bounds.Center.X,shooterText.Bounds.Center.Y),shooterText.Width);
        }
        internal override void Update(GameTime gametime)
        {

        }
    }
}
