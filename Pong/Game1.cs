using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Bar _playerBar;
        private Bar _cpuBar;
        private Ball _ball;

        private int _height;
        private int _width;
        private const int _barToEdgePadding = 40;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _height = _graphics.PreferredBackBufferHeight;
            _width = _graphics.PreferredBackBufferWidth;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //Textures
            var barTexture = Content.Load<Texture2D>("PongBar");
            var ballTexture = Content.Load<Texture2D>("PongBall");

            _ball = new Ball(ballTexture, _width / 2, _height, _width);

            _playerBar = new Bar(barTexture, _height, _width - _barToEdgePadding);
            _cpuBar = new Bar(barTexture, _height, _barToEdgePadding);
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

            _ball.Move();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.Draw(_playerBar.GetTexture(), new Rectangle(_playerBar.GetXPos(), _playerBar.GetYPos(), Bar.Width, Bar.Height), Color.White);
            _spriteBatch.Draw(_cpuBar.GetTexture(), new Rectangle(_cpuBar.GetXPos(), _cpuBar.GetYPos(), Bar.Width, Bar.Height), Color.White);
            _spriteBatch.Draw(_ball.GetTexture(), new Rectangle(_ball.GetXPos(), _ball.GetYPos(), 10, 10), Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
