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

        SpriteFont font;
        Runner runner = new HumanRunner();
        Shooter shooter = new HumanShooter();


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

            shooter.LoadContent(Content);
            runner.LoadContent(Content);
            font = Content.Load<SpriteFont>("myFont");
        }

        protected override void UnloadContent()
        {

        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            if (!runner.Win(shooter) && !shooter.Win(runner))
            {
                runner.Update(gameTime);
                shooter.Update(gameTime);

            }
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            shooter.Draw(spriteBatch);
            runner.Draw(spriteBatch);
            spriteBatch.DrawString(font,"", new Vector2(600, 200), Color.Violet);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
