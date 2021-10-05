using Microsoft.Xna.Framework.Graphics;

namespace Pong
{
    public class Bar
    {
        private readonly Texture2D _barTexture;

        private readonly int _worldHeight;

        private int _yPos;
        private int _xPos;

        public const int Height = 80;
        public const int Width = 10;

        private const int _movementLength = 8;

        public Bar(Texture2D barTexture, int worldHeight, int xPos)
        {
            _barTexture = barTexture;
            _worldHeight = worldHeight;
            _xPos = xPos;
            _yPos = worldHeight / 2 - Height / 2;
        }

        public int GetXPos() { return _xPos; }
        public int GetYPos() { return _yPos; }
        public void MoveUp()
        {
            if(_yPos > 0)
            {
                _yPos -= _movementLength;
            }
        }

        public void MoveDown()
        {
            if (_yPos < _worldHeight - Height)
            {
                _yPos += _movementLength;
            }
        }

        public Texture2D GetTexture()
        {
            return _barTexture;
        }

        public int YCenterOfBar()
        {
            return _yPos + Height / 2;
        }
    }
}
