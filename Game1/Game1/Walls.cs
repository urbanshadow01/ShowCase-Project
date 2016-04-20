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
    class Walls
    {

        private List<Texture2D> Textures = new List<Texture2D>();
        private List<Sprite> WallSprites = new List<Sprite>();
        Random random = new Random();
        internal Walls()
        {

        }

        internal void LoadContent(ContentManager Content)
        {
            Textures.Add(Content.Load<Texture2D>("wallTest"));
            Textures.Add(Content.Load<Texture2D>("wallTest2"));
        }
        // ScrollingBackground.Update
        internal void Update(Runner run, Shooter shoot)
        {
            if (WallSprites.Count == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    int posY = random.Next(10, 500);
                    int posX = random.Next(10, 500);
                    int texture = random.Next(0, 2);
                    WallSprites.Add(new Sprite(Textures[texture]));
                    WallSprites[i].Position = new Vector2(posX, posY);
                }
            }
            List<Bullet> bullets = shoot.getBullet();
            int count = bullets.Count;
            foreach (Sprite sprite in WallSprites)
            {
                foreach (Sprite bullsprite in shoot.getBulletSprite())
                {
                    if (bullsprite.CollidesWith(sprite))
                    {
                        bullets[count].Remove = true;
                    }
                    count++;
                }
                if (run.runnerSprite.CollidesWith(sprite))
                {

                }
            }

        }
        internal void Draw(SpriteBatch spritebatch)
        {
            foreach (Sprite wall in WallSprites)
            {
                spritebatch.Draw(wall.Texture, wall.Position, Color.White);
            }
        }
    }
}
