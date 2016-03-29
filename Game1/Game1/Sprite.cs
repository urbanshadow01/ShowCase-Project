using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Game1
{
    class Sprite
    {
        internal Vector2 Position;
        internal Texture2D Texture;
        private float Alpha = 0;

        internal Sprite(Texture2D texture)
        {
            this.Texture = texture;
        }

        internal bool CollidesWith(Sprite other)
        {
            // Default behavior uses per-pixel collision detection
            return CollidesWith(other, true);
        }

        internal bool CollidesWith(Sprite other, bool calcPerPixel)
        {
            // Get dimensions of texture
            int widthOther = other.Texture.Width;
            int heightOther = other.Texture.Height;
            int widthThis = Texture.Width;
            int heightThis = Texture.Height;

            if (calcPerPixel &&                                // if we need per pixel
                ((Math.Min(widthOther, heightOther) > 100) ||  // at least avoid doing it
                (Math.Min(widthThis, heightThis) > 100)))          // for small sizes
            {
                return Bounds.Intersects(other.Bounds) // If simple intersection fails, don't even bother with per-pixel
                    && PerPixelCollision(this, other);
            }

            return Bounds.Intersects(other.Bounds);
        }

        static bool PerPixelCollision(Sprite a, Sprite b)
        {
            // Get Color data of each Texture
            Color[] bitsA = new Color[a.Texture.Width * a.Texture.Height];
            a.Texture.GetData(bitsA);
            Color[] bitsB = new Color[b.Texture.Width * b.Texture.Height];
            b.Texture.GetData(bitsB);

            // Calculate the intersecting rectangle
            int top = Math.Max(a.Bounds.Top, b.Bounds.Top);
            int bottom = Math.Min(a.Bounds.Bottom, b.Bounds.Bottom);
            int left = Math.Max(a.Bounds.Left, b.Bounds.Left);
            int right = Math.Min(a.Bounds.Right, b.Bounds.Right);

            // For each single pixel in the intersecting rectangle
            for (int y = top; y < bottom; y++)
            {
                for (int x = left; x < right; x++)
                {
                    // Get the color from each texture
                    Color spriteA = bitsA[(x - a.Bounds.X) + (y - a.Bounds.Y) * a.Texture.Width];
                    Color spriteB = bitsB[(x - b.Bounds.X) + (y - b.Bounds.Y) * b.Texture.Width];

                    if (a.Alpha != 0 && b.Alpha != 0) // If both colors are not transparent (the alpha channel is not 0), then there is a collision
                    {
                        return true;
                    }
                }
            }
            // If no collision occurred by now, we're clear.
            return false;
        }

       // private Rectangle bounds = Rectangle.Empty;
        internal virtual Rectangle Bounds
        {
            get
            {
                return new Rectangle(
                    (int)Position.X - Texture.Width,
                    (int)Position.Y - Texture.Height,
                    Texture.Width,
                    Texture.Height);
            }
        }
    }
}
