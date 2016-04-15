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
        internal Texture2D shooterText;
        internal Texture2D bulletText;
        internal Texture2D runnerText;
        SpriteFont font;
        Runner runner;
        Shooter shooter;
        Menu menu = new Menu();
        bool runnerAI = true;
        bool shooterAI = false;

        internal Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            //bulletText = Content.Load<Texture2D>("bullet");

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
            if (Keyboard.GetState().IsKeyDown(Keys.R))
            {
                runner = new AIRunner(runnerText);
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
