using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Game1
{
    class HumanShooter : Shooter
    {

        internal HumanShooter()
        {

        }

        internal override void Update(GameTime gametime)
        {
            MouseState mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed && coolDown <= 0)
            {
                float Angle = (float)(Math.Atan2(mouseState.Y - Pos.Y, mouseState.X - Pos.X));
                bullets.Add(shoot(Angle));
                coolDown = 1;
            }
            coolDown -= 1 * gametime.ElapsedGameTime.TotalSeconds;
            int bulletCount = 0;
            foreach (Bullet bullet in bullets)
            {
                bullet.Update(gametime, bulletText);
                bulletSprites.
            }
            foreach (Sprite sprite in bulletSprites)
            {
                sprite.Position = Vector2.Zero;
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



    }
}
