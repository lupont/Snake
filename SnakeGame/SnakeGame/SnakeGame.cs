using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

using static SnakeGame.Globals;

namespace SnakeGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class SnakeGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch           _spriteBatch;
        private Texture2D             _backgroundTexture;
        private Snake                 _snake;
        private Apple                 _apple;

        public SnakeGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            _graphics.IsFullScreen = true;
            _graphics.PreferredBackBufferWidth = Width;
            _graphics.PreferredBackBufferHeight = Height;
            _graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            ResetGame();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {

        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            HandleTouch();

            if (gameTime.TotalGameTime.Milliseconds % (60 * 50) == 0)
            {
                _snake.Grow();

                if (_snake.Eats(_apple))
                {
                    ResetApple();
                }
                else
                {
                    _snake.Shrink();
                }
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);
            DrawBackground();
            _snake.Draw(_spriteBatch);
            _apple.Draw(_spriteBatch);
            base.Draw(gameTime);
        }

        private void ResetApple()
        {
            _apple = new Apple(RNG.Next(Columns) * Scale, RNG.Next(Rows) * Scale);
            _apple.SetTexture(GraphicsDevice);
        }

        private void ResetSnake()
        {
            _snake = new Snake(0, 0);
            _snake.SetTexture(GraphicsDevice);
        }

        private void ResetGame()
        {
            ResetApple();
            ResetSnake();
        }

        private void DrawBackground()
        {
            _spriteBatch.Begin();

            _backgroundTexture = new Texture2D(GraphicsDevice, GameArea.Width, GameArea.Height);
            var data = new Color[_backgroundTexture.Width * _backgroundTexture.Height];
            for (int i = 0; i < data.Length; i++)
                data[i] = Color.Black;
            _backgroundTexture.SetData(data);
            _spriteBatch.Draw(_backgroundTexture, GameArea, Color.Black);

            _spriteBatch.End();
        }

        private void HandleTouch()
        {
            var touchCollection = TouchPanel.GetState();
            var previousDirection = _snake.Direction;
            var nextDirection = previousDirection;
            var head = _snake[0];

            foreach (var touchLocation in touchCollection)
            {
                if (touchLocation.State != TouchLocationState.Pressed)
                    continue;

                float x = touchLocation.Position.X;
                float y = touchLocation.Position.Y;
                bool aboveSnake = y < head.Y;
                bool leftOfSnake = x < head.X;

                if (aboveSnake && leftOfSnake)
                {
                    if (previousDirection.X == 0)
                        nextDirection = new Vector2(-1, 0);
                    else
                        nextDirection = new Vector2(0, -1);
                }
                else if (aboveSnake && !leftOfSnake)
                {
                    if (previousDirection.X == 0)
                        nextDirection = new Vector2(1, 0);
                    else
                        nextDirection = new Vector2(0, -1);
                }
                else if (!aboveSnake && leftOfSnake)
                {
                    if (previousDirection.X == 0)
                        nextDirection = new Vector2(-1, 0);
                    else
                        nextDirection = new Vector2(0, 1);
                }
                else if (!aboveSnake && !leftOfSnake)
                {
                    if (previousDirection.X == 0)
                        nextDirection = new Vector2(1, 0);
                    else
                        nextDirection = new Vector2(0, 1);
                }
                _snake.Direction = nextDirection;
                return;
            }
        }
    }
}
