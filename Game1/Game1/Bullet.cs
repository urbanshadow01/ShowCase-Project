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
        internal Vector2 GetVelocity { get { return Velocity; } }
        internal Vector2 Pos = new Vector2(500, 1200);
        internal bool Remove { get; set; }
        internal BoundingSphere Hitbox { get; set; }
        internal float Angle;
        // internal Texture2D bulletText { get; set; }
        internal Bullet(Vector2 Velocity1, bool remov, float Angle1,Vector2 Pos)
        {
            Velocity = Velocity1;
            Remove = remov;
            this.Angle = Angle1;
            this.Pos = Pos;
        }

        internal void Update(GameTime gametime, Texture2D bulletText)
        {
            Pos += new Vector2((float)(Velocity.X * gametime.ElapsedGameTime.TotalSeconds),
                (float)(Velocity.Y * gametime.ElapsedGameTime.TotalSeconds));//Changes pos of bullet based on velocity.

            if (Pos.X < -200 || Pos.X > 600) //300 = max window X
            {
                Remove = true;
            }
            if (Pos.Y < 0)
            {
                Remove = true;
            }
        }


    }
}
