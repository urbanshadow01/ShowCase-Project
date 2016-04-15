using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Game1
{
    class HumanRunner : Runner
    {

        internal HumanRunner(Texture2D runnerText)
        {
            Pos = new Vector2(100, 100);
            Velocity = new Vector2(0, 0);
            this.runnerText = runnerText;
            runnerSprite = new Sprite(runnerText);
        }

        internal override void Update(GameTime gametime)
        {
            KeyboardState keyboard = Keyboard.GetState();
            if (keyboard.IsKeyDown(Keys.D) || keyboard.IsKeyDown(Keys.Right))
            {
                if (Velocity.X < MaxVelocity.X)
                {
                    Velocity.X += 50;
                }
            }
            if (keyboard.IsKeyDown(Keys.A) || keyboard.IsKeyDown(Keys.Left))
            {
                if (Velocity.X > MinVelocity.X)
                {
                    Velocity.X -= 50;
                }
            }
            if (keyboard.IsKeyDown(Keys.S) || keyboard.IsKeyDown(Keys.Down))
            {
                if (Velocity.Y < MaxVelocity.Y)
                {
                    Velocity.Y += 50;
                }
            }
            if (keyboard.IsKeyDown(Keys.W) || keyboard.IsKeyDown(Keys.Up))
            {
                if (Velocity.Y > MinVelocity.Y)
                {
                    Velocity.Y -= 50;
                }
            }


            Pos += new Vector2((float)(Velocity.X * gametime.ElapsedGameTime.TotalSeconds),
                 (float)(Velocity.Y * gametime.ElapsedGameTime.TotalSeconds));
            runnerSprite.Position = Pos;
            runnerSprite.transform = Matrix.CreateTranslation(new Vector3(Pos, 0f));
            // Hitbox = new Circle(new Vector2(runnerText.Bounds.Center.X, runnerText.Bounds.Center.Y), runnerText.Width);
            if (Velocity.X > 0)
            {
                Velocity.X -= (float)(Friction * gametime.ElapsedGameTime.TotalSeconds);
            }
            if (Velocity.Y > 0)
            {
                Velocity.Y -= (float)(Friction * gametime.ElapsedGameTime.TotalSeconds);
            }
            if (Velocity.X < 0)
            {
                Velocity.X += (float)(Friction * gametime.ElapsedGameTime.TotalSeconds);
            }
            if (Velocity.Y < 0)
            {
                Velocity.Y += (float)(Friction * gametime.ElapsedGameTime.TotalSeconds);
            }
        }
        internal override void Update(GameTime gametime, Shooter shooter) { }

    }
}
