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
    class HumanRunner : Runner
    {

        internal HumanRunner(ContentManager Content)
        {
            Pos = new Vector2(100, 100);
            Velocity = new Vector2(0, 0);
            base.LoadContent(Content);
            runnerSprite = new Sprite(runnerText);
        }

        internal override void Update(GameTime gametime)
        {
            #region movement
            KeyboardState keyboard = Keyboard.GetState();
            if (keyboard.IsKeyDown(Keys.D))
            {
                if (Velocity.X < MaxVelocity.X)
                {
                    Velocity.X += 50;
                }
            }
            if (keyboard.IsKeyDown(Keys.A))
            {
                if (Velocity.X > MinVelocity.X)
                {
                    Velocity.X -= 50;
                }
            }
            if (keyboard.IsKeyDown(Keys.S))
            {
                if (Velocity.Y < MaxVelocity.Y)
                {
                    Velocity.Y += 50;
                }
            }
            if (keyboard.IsKeyDown(Keys.W))
            {
                if (Velocity.Y > MinVelocity.Y)
                {
                    Velocity.Y -= 50;
                }
            }


            Pos += new Vector2((float)(Velocity.X * gametime.ElapsedGameTime.TotalSeconds),
                 (float)(Velocity.Y * gametime.ElapsedGameTime.TotalSeconds));
            #endregion
            runnerSprite.Position = this.Pos;
            runnerSprite.transform = Matrix.CreateTranslation(new Vector3(Pos, 0f));
            // Hitbox = new Circle(new Vector2(runnerText.Bounds.Center.X, runnerText.Bounds.Center.Y), runnerText.Width);
            #region friction
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
        }
        internal override void Update(GameTime gametime, Shooter shooter) { }

    }
}
