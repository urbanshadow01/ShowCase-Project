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
        internal List<Sprite> GetWalls { get { return WallSprites; } }
        private Vector2 Pos = Vector2.Zero;
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
        internal void Update(Runner runner, Shooter shooter)
        {
            if (WallSprites.Count == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    Pos.Y = random.Next(50, 500);
                    Pos.X = random.Next(100, 700);
                    int texture = random.Next(0, 2);
                    WallSprites.Add(new Sprite(Textures[texture]));
                    WallSprites[i].Position = Pos;
                    WallSprites[i].transform = Matrix.CreateTranslation(new Vector3(Pos, 0f));
                }
            }

            /*List<Bullet> bullets = shooter.getBullet();
            
            foreach (Sprite Sprite in WallSprites)
            {
                int count = 0;
                foreach (Sprite bullsprite in shooter.getBulletSprite())
                {
                    if (bullsprite.CollidesWith(Sprite,true))
                    {
                        bullets[count].Remove = true;
                    }
                    count++;
                }
                if(runner.runnerSprite.CollidesWith(Sprite,true))
                {
                    runner.SetVelocity = Vector2.Zero;
                } 
            }*/

        }
        internal bool OnRight(Sprite sprite)
        {
            foreach (Sprite wall in WallSprites)
            {
                if (sprite.Bounds.Right <= wall.Bounds.Left && sprite.CollidesWith(wall,true))
                {
                    return true;
                }
            }
            return false;
        }
        internal bool OnLeft(Sprite sprite)
        {
            foreach (Sprite wall in WallSprites)
            {
                if (sprite.Bounds.Left >= wall.Bounds.Right && sprite.CollidesWith(wall, true))
                {
                    return true;
                }
            }
            return false;
        }
        internal bool OnTop(Sprite sprite)
        {
            foreach (Sprite wall in WallSprites)
            {
                if (sprite.Bounds.Bottom <= wall.Bounds.Top && sprite.CollidesWith(wall, true))
                {
                    return true;
                }
            }
            return false;
        }
        internal bool OnBottom(Sprite sprite)
        {
            foreach (Sprite wall in WallSprites)
            {
                if (sprite.Bounds.Top >= wall.Bounds.Bottom && sprite.CollidesWith(wall,true))
                {
                    return true;
                }
            }
            return false;
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
