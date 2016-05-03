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
    class HumanShooter : Shooter
    {

        internal HumanShooter(ContentManager Content)
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

        internal override void Update(GameTime gametime, Walls walls)
        {
            shooterSprite.Position = this.Pos;
            #region movement
            KeyboardState keyboard = Keyboard.GetState();
            if (keyboard.IsKeyDown(Keys.Right))
            {
                if (Velocity.X < MaxVelocity.X)
                {
                    Velocity.X += 25;
                }
            }
            if (keyboard.IsKeyDown(Keys.Left))
            {
                if (Velocity.X > MinVelocity.X)
                {
                    Velocity.X -= 25;
                }
            }
            if (keyboard.IsKeyDown(Keys.Down))
            {
                if (Velocity.Y < MaxVelocity.Y)
                {
                    Velocity.Y += 25;
                }
            }
            if (keyboard.IsKeyDown(Keys.Up))
            {
                if (Velocity.Y > MinVelocity.Y)
                {
                    Velocity.Y -= 25;
                }
            }
            foreach (Sprite wall in walls.GetWalls)
            {

                if (wall.CollidesWith(this.shooterSprite, true))
                {
                    Velocity = -Velocity;
                }
            }
            Pos += new Vector2((float)(Velocity.X * gametime.ElapsedGameTime.TotalSeconds),
     (float)(Velocity.Y * gametime.ElapsedGameTime.TotalSeconds));
            shooterSprite.Position = this.Pos;
            shooterSprite.transform = Matrix.CreateTranslation(new Vector3(Pos, 0f));

            if (Velocity.X > 0)
            {
                Velocity.X -= (float)(Friction);
            }
            if (Velocity.Y > 0)
            {
                Velocity.Y -= (float)(Friction);
            }
            if (Velocity.X < 0)
            {
                Velocity.X += (float)(Friction);
            }
            if (Velocity.Y < 0)
            {
                Velocity.Y += (float)(Friction);
            }
            #endregion
            #region shoot
            MouseState mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed && coolDown <= 0)
            {
                float Angle = (float)(Math.Atan2(mouseState.Y - this.Pos.Y, mouseState.X - this.Pos.X));
                bullets.Add(shoot(Angle));
                coolDown = 1;
            }
            coolDown -= 1 * gametime.ElapsedGameTime.TotalSeconds;
            #endregion
            #region bulletUpdates
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
            foreach (Sprite Sprite in walls.GetWalls)
            {
                bulletCount = 0;
                foreach (Sprite bullsprite in bulletSprites)
                {
                    if (bullsprite.CollidesWith(Sprite, true))
                    {
                        bullets[bulletCount].Remove = true;
                    }
                    bulletCount++;
                }
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
        internal override void Update(GameTime gametime, Walls walls, Runner run) { }

    }
}
