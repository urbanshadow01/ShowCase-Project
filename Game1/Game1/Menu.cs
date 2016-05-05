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
        internal MenuStates State = MenuStates.Main;
        SpriteFont font;
        List<Vector2> Location = new List<Vector2>();
        List<Rectangle> MenuHitbox = new List<Rectangle>();
        float Width = 1200;
        internal int playerAmount;
        internal int playerType;
        Color colorPlay = Color.Gray;
        Color colorInstructions = Color.Gray;
        Color colorQuit = Color.Gray;
        Color colorCredits = Color.Gray;
        Color colorReturn = Color.Gray;
        Color colorOpt1 = Color.Gray;
        Color colorOpt2 = Color.Gray;
        internal bool gameStarted = false;
        internal void LoadContent(ContentManager Content)
        {
            font = Content.Load<SpriteFont>("NewSpriteFont");
        }

        internal void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();
            #region Main
            if (State == MenuStates.Main)
            {
                gameStarted = false;
                if (Location.Count == 0 ||  Location == null)
                {
                    Location.Add(new Vector2(Width / 2, 100));
                    Location.Add(new Vector2(Width / 2, 300));
                    Location.Add(new Vector2(Width / 2, 500));
                    Location.Add(new Vector2(Width / 2, 700));
                }
                if (MenuHitbox.Count <= 0 || MenuHitbox == null)
                {
                    MenuHitbox.Add(new Rectangle((int)Location[0].X, (int)Location[0].Y, (int)font.MeasureString("Play").X + 5, (int)font.MeasureString("Play").Y + 5));
                    MenuHitbox.Add(new Rectangle((int)Location[1].X, (int)Location[1].Y, (int)font.MeasureString("Instructions").X + 5, (int)font.MeasureString("Instructions").Y + 5));
                    MenuHitbox.Add(new Rectangle((int)Location[2].X, (int)Location[2].Y, (int)font.MeasureString("Credits").X + 5, (int)font.MeasureString("Credits").Y + 5));
                    MenuHitbox.Add(new Rectangle((int)Location[3].X, (int)Location[3].Y, (int)font.MeasureString("Quit").X + 5, (int)font.MeasureString("Quit").Y + 5));
                }
                #region playBtn
                if (MenuHitbox[0].Contains(mouse.X, mouse.Y))
                {
                    colorPlay = Color.Black;
                    colorInstructions = Color.Gray;
                    colorQuit = Color.Gray;
                    colorCredits = Color.Gray;
                    if (mouse.LeftButton == ButtonState.Pressed)
                    {
                        State = MenuStates.PlayerAmount;
                        Location.Clear();
                        MenuHitbox.Clear();
                    }
                }
                #endregion
                #region instructBtn
                if (MenuHitbox[1].Contains(mouse.X, mouse.Y))
                {
                    colorInstructions = Color.Black;
                    colorPlay = Color.Gray;
                    colorQuit = Color.Gray;
                    colorCredits = Color.Gray;
                    if (mouse.LeftButton == ButtonState.Pressed)
                    {
                        State = MenuStates.Instructions;
                        Location.Clear();
                        MenuHitbox.Clear();
                    }
                }
                #endregion
                #region Credit
                if (MenuHitbox[2].Contains(mouse.X, mouse.Y))
                {
                    colorInstructions = Color.Gray;
                    colorPlay = Color.Gray;
                    colorQuit = Color.Gray;
                    colorCredits = Color.Black;
                    if (mouse.LeftButton == ButtonState.Pressed)
                    {
                        State = MenuStates.Credits;
                        Location.Clear();
                        MenuHitbox.Clear();
                    }
                }
                #endregion
                #region Quit
                if (MenuHitbox[3].Contains(mouse.X, mouse.Y))
                {
                    colorInstructions = Color.Gray;
                    colorPlay = Color.Gray;
                    colorQuit = Color.Black;
                    colorCredits = Color.Gray;
                    if (mouse.LeftButton == ButtonState.Pressed)
                    {
                        State = MenuStates.Quit;
                        Location.Clear();
                        MenuHitbox.Clear();
                    }
                }
                #endregion
            }
            #endregion
            #region instructions
            if (State == MenuStates.Instructions)
            {
                gameStarted = false;
                if (Location.Count == 0 || Location == null)
                {
                    Location.Add(new Vector2(0, 800));

                }
                if (MenuHitbox.Count == 0 || MenuHitbox == null)
                {
                    MenuHitbox.Add(new Rectangle((int)Location[0].X, (int)Location[0].Y, (int)font.MeasureString("Go Back").X + 5, (int)font.MeasureString("Go Back").Y + 5));
                }
                if (MenuHitbox[0].Contains(mouse.X, mouse.Y))
                {
                    colorReturn = Color.Black;
                    if (mouse.LeftButton == ButtonState.Pressed)
                    {
                        State = MenuStates.Main;
                        Location.Clear();
                        MenuHitbox.Clear();
                    }
                }
            }
            #endregion
            #region Credits
            if (State == MenuStates.Credits)
            {
                gameStarted = false;
                if (Location.Count == 0 || Location == null)
                {
                    Location.Add(new Vector2(0, 800));

                }
                if (MenuHitbox.Count == 0 || MenuHitbox == null)
                {
                    MenuHitbox.Add(new Rectangle((int)Location[0].X, (int)Location[0].Y, (int)font.MeasureString("Go Back").X + 5, (int)font.MeasureString("Go Back").Y + 5));
                }
                if (MenuHitbox[0].Contains(mouse.X, mouse.Y))
                {
                    colorReturn = Color.Black;
                    if (mouse.LeftButton == ButtonState.Pressed)
                    {
                        State = MenuStates.Main;
                        Location.Clear();
                        MenuHitbox.Clear();
                    }
                }
            }
            #endregion
            #region PlayerAmountSelection
            if (State == MenuStates.PlayerAmount)
            {
                gameStarted = false;
                if (Location.Count == 0 || Location == null)
                {
                    Location.Add(new Vector2(Width / 2, 300));
                    Location.Add(new Vector2(Width / 2, 500));

                }
                if (MenuHitbox.Count == 0 || MenuHitbox == null)
                {
                    MenuHitbox.Add(new Rectangle((int)Location[0].X, (int)Location[0].Y, (int)font.MeasureString("1 Player").X + 5, (int)font.MeasureString("1 Player").Y + 5));
                    MenuHitbox.Add(new Rectangle((int)Location[1].X, (int)Location[1].Y, (int)font.MeasureString("2 Players").X + 5, (int)font.MeasureString("2 Players").Y + 5));
                }
                if (MenuHitbox[0].Contains(mouse.X, mouse.Y))
                {
                    colorOpt1 = Color.Black;
                    colorOpt2 = Color.Gray;
                    if (mouse.LeftButton == ButtonState.Pressed)
                    {
                        State = MenuStates.PlayerType;
                        playerAmount = 1;
                        Location.Clear();
                        MenuHitbox.Clear();
                    }
                }
                if (MenuHitbox[1].Contains(mouse.X, mouse.Y))
                {
                    colorOpt1 = Color.Gray;
                    colorOpt2 = Color.Black;
                    if (mouse.LeftButton == ButtonState.Pressed)
                    {
                        playerType = 0;
                        playerAmount = 2;
                        State = MenuStates.Playing;
                        Location.Clear();
                        MenuHitbox.Clear();
                    }
                }
            }
            #endregion
            #region PlayerType
            if (State == MenuStates.PlayerType)
            {
                gameStarted = false;
                if (Location.Count == 0 || Location == null)
                {
                    Location.Add(new Vector2(Width / 2, 300));
                    Location.Add(new Vector2(Width / 2, 500));
                }
                if (MenuHitbox.Count == 0 || MenuHitbox == null)
                {
                    MenuHitbox.Add(new Rectangle((int)Location[0].X, (int)Location[0].Y, (int)font.MeasureString("Shooter").X + 5, (int)font.MeasureString("Shooter").Y + 5));
                    MenuHitbox.Add(new Rectangle((int)Location[1].X, (int)Location[1].Y, (int)font.MeasureString("Runner").X + 5, (int)font.MeasureString("Runner").Y + 5));
                }
                if (MenuHitbox[0].Contains(mouse.X, mouse.Y))
                {
                    colorOpt1 = Color.Black;
                    colorOpt2 = Color.Gray;
                    if (mouse.LeftButton == ButtonState.Pressed)
                    {
                        State = MenuStates.Playing;
                        playerType = 1;
                        Location.Clear();
                        MenuHitbox.Clear();
                    }
                }
                if (MenuHitbox[1].Contains(mouse.X, mouse.Y))
                {
                    colorOpt1 = Color.Gray;
                    colorOpt2 = Color.Black;
                    if (mouse.LeftButton == ButtonState.Pressed)
                    {
                        State = MenuStates.Playing;
                        playerType = 2;
                        Location.Clear();
                        MenuHitbox.Clear();
                    }
                }
            }
            #endregion
        }


        internal void Draw(SpriteBatch spriteBatch)
        {
            #region mainDraw
            if (State == MenuStates.Main && !(Location.Count <= 0))
            {
                spriteBatch.DrawString(font, "Play", Location[0], colorPlay);
                spriteBatch.DrawString(font, "Instructions", Location[1], colorInstructions);
                spriteBatch.DrawString(font, "Credits", Location[2], colorCredits);
                spriteBatch.DrawString(font, "Quit", Location[3], colorQuit);
            }
            #endregion
            #region instructions
            if (State == MenuStates.Instructions && !(Location.Count <= 0))
            {
                spriteBatch.DrawString(font, "Runner: Moves faster than the Shooter ", new Vector2(Width / 2, 0), Color.White);
                spriteBatch.DrawString(font, "Use WASD to move", new Vector2(Width / 2, 100), Color.White);
                spriteBatch.DrawString(font, "Shooter: Moves slower than the Runner ", new Vector2(Width / 2, 300), Color.White);
                spriteBatch.DrawString(font, "But, can fire projectiles ", new Vector2(Width / 2, 300), Color.White);
                spriteBatch.DrawString(font, "Use Arrow keys to move", new Vector2(Width / 2, 100), Color.White);
                spriteBatch.DrawString(font, "Return", Location[0], colorReturn);
            }
            #endregion
            #region Credits
            if (State == MenuStates.Credits && !(Location.Count <= 0))
            {
                spriteBatch.DrawString(font, "Return", Location[0], colorReturn);
            }
            #endregion
            #region PlayerAmount
            if (State == MenuStates.PlayerAmount && !(Location.Count <= 0))
            {
                spriteBatch.DrawString(font, "1 Player", Location[0], colorOpt1);
                spriteBatch.DrawString(font, "2 Players", Location[1], colorOpt2);
            }
            #endregion
            #region PlayerType
            if (State == MenuStates.PlayerType && !(Location.Count <= 0))
            {
                spriteBatch.DrawString(font, "Shooter", Location[0], colorOpt1);
                spriteBatch.DrawString(font, "Runner", Location[1], colorOpt2);

            }
            #endregion
        }
    }
}
