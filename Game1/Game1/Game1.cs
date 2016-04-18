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
    internal class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        internal Texture2D runnerText;
        SpriteFont font;
        Runner runner;
        Shooter shooter;
        Menu menu = new Menu();
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
            runnerText = Content.Load<Texture2D>("player2");

            font = Content.Load<SpriteFont>("myFont");
        }

        protected override void UnloadContent()
        {

        }


        protected override void Update(GameTime gameTime)
        {
//            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

  //          myBackground.Update(elapsed * 100);


            if (Keyboard.GetState().IsKeyDown(Keys.R))
            {
                runner = new HumanRunner(runnerText);
                shooter = new HumanShooter(Content);
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            if (runner != null || shooter != null)
            {
                if (!runner.Win(shooter) && !shooter.Win(runner))
                {
                    if (runnerAI)
                    {
                        runner.Update(gameTime, shooter);
                    }
                    else
                    {
                        runner.Update(gameTime);
                    }
                    if (shooterAI)
                    {
                        shooter.Update(gameTime, runner);
                    }
                    else
                    {
                        shooter.Update(gameTime);
                    }
                    //PREVENTS SHOOTER FROM LEAVING RIGHT/LEFT SIDE OF SCREEN
                    shooter.Pos = new Vector2(MathHelper.Clamp(shooter.Pos.X,
                    safeBounds.Left, safeBounds.Right - shooter.shooterText.Width), MathHelper.Clamp(shooter.Pos.Y,
                    safeBounds.Top, safeBounds.Bottom - shooter.shooterText.Height));
                    //PREVENTS RUNNER FROM LEAVING RIGHT/LEFT SIDE OF SCREEN
                    runner.Pos = new Vector2(MathHelper.Clamp(runner.Pos.X,
                    safeBounds.Left, safeBounds.Right - runner.runnerText.Width), MathHelper.Clamp(runner.Pos.Y,
                    safeBounds.Top, safeBounds.Bottom - runner.runnerText.Height));
                }
            }
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            if (!menu.GetIsMenu)
            {
                if (shooter != null || runner != null)
                {
                    shooter.Draw(spriteBatch);
                    runner.Draw(spriteBatch);
                } 
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
