﻿/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class Collision
    {

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
            int widthMe = Texture.Width;
            int heightMe = Texture.Height;

            if (calcPerPixel &&                                // if we need per pixel
                ((Math.Min(widthOther, heightOther) > 100) ||  // at least avoid doing it
                (Math.Min(widthMe, heightMe) > 100)))          // for small sizes (nobody will notice :P)
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
            int x1 = Math.Max(a.Bounds.X, b.Bounds.X);
            int x2 = Math.Min(a.Bounds.X + a.Bounds.Width, b.Bounds.X + b.Bounds.Width);

            int y1 = Math.Max(a.Bounds.Y, b.Bounds.Y);
            int y2 = Math.Min(a.Bounds.Y + a.Bounds.Height, b.Bounds.Y + b.Bounds.Height);

            // For each single pixel in the intersecting rectangle
            for (int y = y1; y < y2; ++y)
            {
                for (int x = x1; x < x2; ++x)
                {
                    // Get the color from each texture
                    Color a = bitsA[(x - a.Bounds.X) + (y - a.Bounds.Y) * a.Texture.Width];
                    Color b = bitsB[(x - b.Bounds.X) + (y - b.Bounds.Y) * b.Texture.Width];

                    if (a.A != 0 && b.A != 0) // If both colors are not transparent (the alpha channel is not 0), then there is a collision
                    {
                        return true;
                    }
                }
            }
            // If no collision occurred by now, we're clear.
            return false;
        }

        private Rectangle bounds = Rectangle.Empty;
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
*/