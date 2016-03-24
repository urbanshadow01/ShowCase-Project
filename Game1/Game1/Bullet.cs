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
    class Bullet
    {
        protected Vector2 Velocity;
        internal Vector2 Pos = new Vector2(300, 300);
        internal bool Remove { get; set; }
        internal Circle Hitbox { get; set; }
        internal float Angle;
       // internal Texture2D bulletText { get; set; }
        internal Bullet(Vector2 Velocity1, bool remov, float Angle1)
        {
            Velocity = Velocity1;
            Remove = remov;
            this.Angle = Angle1;
        }

        internal void Update(GameTime gametime, Texture2D bulletText)
        {
            Pos += new Vector2((float)(Velocity.X * gametime.ElapsedGameTime.TotalSeconds),
                (float)(Velocity.Y * gametime.ElapsedGameTime.TotalSeconds));//Changes pos of bullet based on velocity
            this.Hitbox = new Circle(new Vector2(bulletText.Bounds.Center.X, bulletText.Bounds.Center.Y), 5);
            if (Pos.X < -200 || Pos.X > 600) //300 = max window X
            {
                Remove = true;
            }
            if (Pos.Y < 0)
            {
                Remove = true;
            }
            //Hit();
        }
        internal bool Hit(Runner run)
        {

            if (this.Hitbox.Intersects(run.Hitbox))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
