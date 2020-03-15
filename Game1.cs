using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Texture2D ball;
        private Texture2D pixel;
        private float ballX = 0;
        private float ballY = 0;
        private MouseState MouseInfo;
        //private MouseCursor Cursor;
        private Rectangle ball1Rectangle = new Rectangle(new Point(210, 670), new Point(30, 30));
        private Block[,] blockArray = new Block[8, 8];
        
        //this is a test
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferHeight = 700,
                PreferredBackBufferWidth = 450
            };
            Content.RootDirectory = "Content";

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            IsMouseVisible = true;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            ball = Content.Load<Texture2D>("red_ball");
            pixel = Content.Load<Texture2D>("single_pixel");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            MouseInfo = Mouse.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (MouseInfo.LeftButton == ButtonState.Pressed)
            {
                ballX = Convert.ToSingle((MouseInfo.X - 225) / (Math.Sqrt((Math.Pow(MouseInfo.X - 225, 2)) + (Math.Pow(700 - MouseInfo.Y, 2)))));

                ballY = Convert.ToSingle((700 - MouseInfo.Y) / (Math.Sqrt((Math.Pow(MouseInfo.X - 225, 2)) + (Math.Pow(700 - MouseInfo.Y, 2)))));
            }

            ball1Rectangle.Offset(new Vector2(ballX, -ballY)*20);
            ball1Rectangle.X = MouseInfo.X-15;
            ball1Rectangle.Y = MouseInfo.Y-15;
            
               
            
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            spriteBatch.Begin();

            spriteBatch.Draw(pixel, new Vector2(MouseInfo.X, MouseInfo.Y), Color.White);
            spriteBatch.Draw(ball, ball1Rectangle, Color.White);
            

            spriteBatch.End();

            base.Draw(gameTime);
        }
        
    }
    public class Block
    {
        private int x;
        private int y;

        public Block(int xValue, int yValue)
        {
            x = xValue;
            y = yValue;
        }
    }
}
