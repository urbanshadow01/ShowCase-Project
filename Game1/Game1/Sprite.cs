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
        internal Matrix transform { get; set; }
        internal Sprite(Texture2D texture)
        {
            this.Texture = texture;
        }

        internal bool CollidesWith(Sprite other, bool transformed)
        {
            // Default behavior uses per-pixel collision detection

            if (!transformed)
            {
                return CollidesWith(other);
            }
            else
            {
                if (this.TransBounds(this.Bounds, transform).Intersects(other.TransBounds(other.Bounds, transform)))
                {
                    return transCollidesPixels(transform, this, other);
                } else
                {
                    return false;
                }
            }
        }

        internal bool CollidesWith(Sprite other)
        {
            // Get dimensions of texture
            int widthOther = other.Texture.Width;
            int heightOther = other.Texture.Height;
            int widthThis = Texture.Width;
            int heightThis = Texture.Height;

            if (((Math.Min(widthOther, heightOther) > 100) || (Math.Min(widthThis, heightThis) > 100)))
            {
                return Bounds.Intersects(other.Bounds) // If simple intersection fails, don't even bother with per-pixel
                    && PerPixelCollision(this, other);
            }

            return Bounds.Intersects(other.Bounds);
        }

        #region perPixelNonTransformed
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
        #endregion
        #region transPixelCheck
        public static bool transCollidesPixels(
                           Matrix transformA, Sprite a,
                           Sprite b)
        {
            // Calculate a matrix which transforms from A's local space into
            // world space and then into B's local space
            Matrix transformB = b.transform;
            Matrix transformAToB = transformA * Matrix.Invert(transformB);
            int heightA = a.Texture.Height;
            int widthA = a.Texture.Width;
            int heightB = b.Texture.Height;
            int widthB = b.Texture.Width;
            Color[] bitsA = new Color[a.Texture.Width * a.Texture.Height];
            a.Texture.GetData(bitsA);
            Color[] bitsB = new Color[b.Texture.Width * b.Texture.Height];
            b.Texture.GetData(bitsB);
            // When a point moves in A's local space, it moves in B's local space with a
            // fixed direction and distance proportional to the movement in A.
            // This algorithm steps through A one pixel at a time along A's X and Y axes
            // Calculate the analogous steps in B:
            Vector2 stepX = Vector2.TransformNormal(Vector2.UnitX, transformAToB);
            Vector2 stepY = Vector2.TransformNormal(Vector2.UnitY, transformAToB);

            // Calculate the top left corner of A in B's local space
            // This variable will be reused to keep track of the start of each row
            Vector2 yPosInB = Vector2.Transform(Vector2.Zero, transformAToB);

            // For each row of pixels in A
            for (int yA = 0; yA < heightA; yA++)
            {
                // Start at the beginning of the row
                Vector2 posInB = yPosInB;

                // For each pixel in this row
                for (int xA = 0; xA < widthA; xA++)
                {
                    // Round to the nearest pixel
                    int xB = (int)Math.Round(posInB.X);
                    int yB = (int)Math.Round(posInB.Y);

                    // If the pixel lies within the bounds of B
                    if (0 <= xB && xB < widthB &&
                        0 <= yB && yB < heightB)
                    {
                        // Get the colors of the overlapping pixels
                        Color colorA = bitsA[xA + yA * widthA];
                        Color colorB = bitsB[xB + yB * widthB];

                        // If both pixels are not completely transparent,
                        if (colorA.A != 0 && colorB.A != 0)
                        {
                            // then an intersection has been found
                            return true;
                        }
                    }

                    // Move to the next pixel in the row
                    posInB += stepX;
                }

                // Move to the next row
                yPosInB += stepY;
            }

            // No intersection found
            return false;
        }
        #endregion
        // private Rectangle bounds = Rectangle.Empty;
        internal Rectangle Bounds
        {
            get
            {
                return new Rectangle(
                    (int)Position.X,
                    (int)Position.Y,
                    Texture.Width,
                    Texture.Height);
            }
        }
        #region TransBounds
        internal Rectangle TransBounds(Rectangle rectangle, Matrix transform)
        {
            // Get all four corners in local space
            Vector2 leftTop = new Vector2(rectangle.Left, rectangle.Top);
            Vector2 rightTop = new Vector2(rectangle.Right, rectangle.Top);
            Vector2 leftBottom = new Vector2(rectangle.Left, rectangle.Bottom);
            Vector2 rightBottom = new Vector2(rectangle.Right, rectangle.Bottom);

            // Transform all four corners into work space
            Vector2.Transform(ref leftTop, ref transform, out leftTop);
            Vector2.Transform(ref rightTop, ref transform, out rightTop);
            Vector2.Transform(ref leftBottom, ref transform, out leftBottom);
            Vector2.Transform(ref rightBottom, ref transform, out rightBottom);

            // Find the minimum and maximum extents of the rectangle in world space
            Vector2 min = Vector2.Min(Vector2.Min(leftTop, rightTop),
                                      Vector2.Min(leftBottom, rightBottom));
            Vector2 max = Vector2.Max(Vector2.Max(leftTop, rightTop),
                                      Vector2.Max(leftBottom, rightBottom));

            // Return that as a rectangle
            return new Rectangle((int)min.X, (int)min.Y,
                                 (int)(max.X - min.X), (int)(max.Y - min.Y));
        }
        #endregion
    }
}
