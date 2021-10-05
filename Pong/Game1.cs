using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D ballTexture;
        Vector2 ballPosition;
        float ballSpeed;
        private const int _barToEdgePadding = 40;

        private Bar _playerBar;
        private Bar _cpuBar;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            ballPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
            ballSpeed = 100f;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            ballTexture = Content.Load<Texture2D>("ball");
            var barTexture = Content.Load<Texture2D>("PongBar");

            _playerBar = new Bar(barTexture, _graphics.PreferredBackBufferHeight, _graphics.PreferredBackBufferWidth - _barToEdgePadding);
            _cpuBar = new Bar(barTexture, _graphics.PreferredBackBufferHeight, _barToEdgePadding);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Up))
            {
                _playerBar.MoveUp();
            }

            if (kstate.IsKeyDown(Keys.Down))
            {
                _playerBar.MoveDown();
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(
                ballTexture,
                ballPosition,
                null,
                Color.White,
                0f,
                new Vector2(ballTexture.Width / 2, ballTexture.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f
            );

            _spriteBatch.Draw(_playerBar.GetTexture(), new Rectangle(_playerBar.GetXPos(), _playerBar.GetYPos(), Bar.Width, Bar.Height), Color.White);
            _spriteBatch.Draw(_cpuBar.GetTexture(), new Rectangle(_cpuBar.GetXPos(), _cpuBar.GetYPos(), Bar.Width, Bar.Height), Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
