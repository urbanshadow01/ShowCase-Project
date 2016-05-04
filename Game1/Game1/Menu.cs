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
    class Menu
    {
        internal MenuStates State = MenuStates.Playing;
        SpriteFont font;
        List<Vector2> Location = new List<Vector2>();
        List<Rectangle> MenuHitbox = new List<Rectangle>();
        float Width = 1200;
        float Height = 800;
        internal void LoadContent(ContentManager Content)
        {
            font = Content.Load<SpriteFont>("NewSpriteFont");
        }

        internal void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();
            if (State == MenuStates.Main)
            {
                if (Location.Count == 0)
                {
                    Location.Add(new Vector2(Width / 2, 100));
                    Location.Add(new Vector2(Width / 2, 300));
                    Location.Add(new Vector2(Width / 2, 500));
                    Location.Add(new Vector2(Width / 2, 700));
                }
                if (MenuHitbox.Count == 0)
                {
                    MenuHitbox.Add(new Rectangle((int)Location[0].X, (int)Location[0].Y, (int)font.MeasureString("Play").X + 5, (int)font.MeasureString("Play").Y + 5));
                    MenuHitbox.Add(new Rectangle((int)Location[1].X, (int)Location[1].Y, (int)font.MeasureString("Instructions").X + 5, (int)font.MeasureString("Instructions").Y + 5));
                    MenuHitbox.Add(new Rectangle((int)Location[2].X, (int)Location[2].Y, (int)font.MeasureString("Credits").X + 5, (int)font.MeasureString("Credits").Y + 5));
                    MenuHitbox.Add(new Rectangle((int)Location[3].X, (int)Location[3].Y, (int)font.MeasureString("Quit").X + 5, (int)font.MeasureString("Quit").Y + 5));
                }
            }
        }

        internal void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
