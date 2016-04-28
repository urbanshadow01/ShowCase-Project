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

        internal override void Update(GameTime gametime, Walls walls)
        {
            #region movement
            KeyboardState keyboard = Keyboard.GetState();
            foreach(Sprite wall in walls.GetWalls)
            {
                if (runnerSprite.CollidesWith(wall, true))
                {
                    Velocity = Vector2.Zero;
                } 
            }
            if (keyboard.IsKeyDown(Keys.D) && !walls.OnRight(runnerSprite))
            {
                if (Velocity.X < MaxVelocity.X)
                {
                    Velocity.X += 50;
                }
            }
            if (keyboard.IsKeyDown(Keys.A) && !walls.OnLeft(runnerSprite))
            {
                if (Velocity.X > MinVelocity.X)
                {
                    Velocity.X -= 50;
                }
            }
            if (keyboard.IsKeyDown(Keys.S) && !walls.OnTop(runnerSprite))
            {
                if (Velocity.Y < MaxVelocity.Y)
                {
                    Velocity.Y += 50;
                }
            }
            if (keyboard.IsKeyDown(Keys.W) && !walls.OnBottom(runnerSprite))
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
        internal override void Update(GameTime gametime, Walls walls, Shooter shooter) { }

    }
}
