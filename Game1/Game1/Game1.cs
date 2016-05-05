using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    internal enum MenuStates { Main, PlayerAmount, PlayerType, Quit, Credits, GameOver, Playing, Instructions };
    internal class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Runner runner;
        Shooter shooter;
        Menu menu = new Menu();
        Walls walls = new Walls();
        bool runnerAI = false;
        bool shooterAI = false;
        protected Rectangle safeBounds;
        protected const float SafeAreaPortion = 0.001f;

        internal Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 1200;
            graphics.PreferredBackBufferHeight = 800;
            graphics.ApplyChanges();
        }


        protected override void Initialize()
        {
            //bulletText = Content.Load<Texture2D>("bullet");
            Viewport viewport = GraphicsDevice.Viewport;
            safeBounds = new Rectangle(
                (int)(viewport.Width * SafeAreaPortion),
                (int)(viewport.Height * SafeAreaPortion),
                (int)(viewport.Width * (1 - 2 * SafeAreaPortion)),
                (int)(viewport.Height * (1 - 2 * SafeAreaPortion)));
            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            walls.LoadContent(Content);
        }

        protected override void UnloadContent()
        {

        }


        protected override void Update(GameTime gameTime)
        {

            if (menu.State == MenuStates.Playing)
            {
                #region FirstStart
                if(!menu.gameStarted)
                {
                    if (menu.playerAmount == 2)
                    {
                        runner = new HumanRunner(Content);
                        shooter = new HumanShooter(Content);
                    }
                    else if (menu.playerAmount != 2)
                    {
                        if (menu.playerType == 1)
                        {
                            runner = new AIRunner(Content);
                            shooter = new HumanShooter(Content);
                        }
                        else
                        {
                            runner = new HumanRunner(Content);
                            shooter = new AIShooter(Content);
                        }
                    }
                    menu.gameStarted = true;
                }
                #endregion
                #region Restart
                if (Keyboard.GetState().IsKeyDown(Keys.R) && menu.State == MenuStates.GameOver)
                {
                    if (menu.playerAmount == 2)
                    {
                        runner = new HumanRunner(Content);
                        shooter = new HumanShooter(Content);
                    }
                    else
                    {
                        if (menu.playerType == 1)
                        {
                            runner = new AIRunner(Content);
                            shooter = new HumanShooter(Content);
                        }
                        else
                        {
                            runner = new HumanRunner(Content);
                            shooter = new AIShooter(Content);
                        }
                    }
                }
                #endregion
                if (menu.State == MenuStates.Quit || Keyboard.GetState().IsKeyDown(Keys.Escape))
                {
                    Exit();
                }
                #region update
                if (runner != null && shooter != null)
                {
                    if (!runner.Win(shooter) && !shooter.Win(runner))
                    {
                        if (runnerAI)
                        {
                            runner.Update(gameTime, walls, shooter);
                        }
                        else
                        {
                            runner.Update(gameTime, walls);
                        }
                        if (shooterAI)
                        {
                            shooter.Update(gameTime, walls, runner);
                        }
                        else
                        {
                            shooter.Update(gameTime, walls);
                        }
                        //PREVENTS SHOOTER FROM LEAVING RIGHT/LEFT SIDE OF SCREEN
                        shooter.Pos = new Vector2(MathHelper.Clamp(shooter.Pos.X,
                        safeBounds.Left, safeBounds.Right - shooter.shooterText.Width), MathHelper.Clamp(shooter.Pos.Y,
                        safeBounds.Top, safeBounds.Bottom - shooter.shooterText.Height));
                        //PREVENTS RUNNER FROM LEAVING RIGHT/LEFT SIDE OF SCREEN
                        runner.Pos = new Vector2(MathHelper.Clamp(runner.Pos.X,
                        safeBounds.Left, safeBounds.Right - runner.runnerText.Width), MathHelper.Clamp(runner.Pos.Y,
                        safeBounds.Top, safeBounds.Bottom - runner.runnerText.Height));
                        walls.Update(runner, shooter);
                    }
                }
                #endregion
            }
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            if (menu.State == MenuStates.Playing)
            {
                if (shooter != null || runner != null)
                {
                    shooter.Draw(spriteBatch);
                    runner.Draw(spriteBatch);
                    walls.Draw(spriteBatch);
                }
            }
            else
            {
                menu.Draw(spriteBatch);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
