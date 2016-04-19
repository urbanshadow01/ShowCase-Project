using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Game1
{
    class AIRunner : Runner
    {

        internal AIRunner(ContentManager Content)
        {
            Pos = new Vector2(100, 100);
            Velocity = new Vector2(0, 0);
            base.LoadContent(Content);
            runnerSprite = new Sprite(runnerText);
        }
        internal override void Update(GameTime gametime) { }
        internal override void Update(GameTime gametime, Shooter shooter)
        {
            #region movement
            float Angle = (float)(Math.Atan2(shooter.Pos.Y - Pos.Y, shooter.Pos.X - Pos.X));
            float Speed = 100; 
            float velocityX = (float)(Math.Cos(Angle) * Speed);
            float velocityY = (float)(Math.Sin(Angle) * Speed);
            Velocity = new Vector2(velocityX, velocityY);
            #region dodging
            foreach (Bullet bull in shooter.getBullet())
            {
                if (bull.Pos.Y + 20 <= Pos.Y)
                {
                    continue;
                }
                if((bull.Pos.X - Pos.X) <= 100)
                {
                    if (bull.GetVelocity.X >= 0)
                    {
                        Velocity.X -= 100;
                        continue;
                    }
                    if (bull.GetVelocity.X <= 0)
                    {
                        Velocity.X += 100;
                        continue;
                    }                   
                }
            }
            #endregion
            Pos += new Vector2((float)(Velocity.X * gametime.ElapsedGameTime.TotalSeconds),
                 (float)(Velocity.Y * gametime.ElapsedGameTime.TotalSeconds));
            runnerSprite.Position = Pos;
            runnerSprite.transform = Matrix.CreateTranslation(new Vector3(Pos, 0f));
            #endregion
            // Hitbox = new Circle(new Vector2(runnerText.Bounds.Center.X, runnerText.Bounds.Center.Y), runnerText.Width);
            #region friction
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
            #endregion
        }
    }
}
