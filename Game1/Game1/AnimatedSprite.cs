using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Game1
{
    class AnimatedSprite
    {
        internal Texture2D Texture { get; set; }
        internal List<Texture2D> Textures { get; set; }
        internal int Rows { get; set; }
        internal int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;

        internal AnimatedSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
        }
        internal AnimatedSprite(List<Texture2D> textures)
        {
            Textures = textures;
        }

        internal void Update()
        {
            currentFrame++;
            if (currentFrame == totalFrames)
                currentFrame = 0;
        }

        internal void Draw(SpriteBatch spriteBatch, Vector2 location, bool list)
        {
            if (!list)
            {
                int width = Texture.Width / Columns;
                int height = Texture.Height / Rows;
                int row = (int)((float)currentFrame / (float)Columns);
                int column = currentFrame % Columns;

                Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
                Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

                spriteBatch.Begin();
                spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
                spriteBatch.End();
            }
            else
            {

            }
        }
    }
}
