using Microsoft.Xna.Framework.Graphics;

namespace Pong
{
    public class Ball
    {
        private readonly Texture2D _ballTexture;

        private readonly int _worldHeight;
        private readonly int _worldWidth;

        private int _xPos;
        private int _yPos;

        private int _verticalMovement = 0;
        private int _horizontalMovement = 5;
        public Ball(Texture2D texture, int xPos, int worldHeight, int worldWidth)
        {
            _ballTexture = texture;
            _xPos = xPos;
            _yPos = worldHeight / 2; ;
            _worldHeight = worldHeight;
            _worldWidth = worldWidth;
        }

        private void MoveHorizontally()
        {
            if(_xPos > _worldWidth || _xPos < 0)
            {
                BounceHorizontal();
            }
            _xPos += _horizontalMovement;
        }

        public void Move()
        {
            MoveVertically();
            MoveHorizontally();
        }

        private void MoveVertically()
        {
            if (_yPos > _worldHeight || _yPos < 0)
            {
                BounceVertical();
            }
            _yPos += _verticalMovement;
        }

        public int GetXPos()
        {
            return _xPos;
        }
        public int GetYPos()
        {
            return _yPos;
        }

        private void BounceHorizontal()
        {
            _horizontalMovement = _horizontalMovement * -1;
        }

        private void BounceVertical()
        {
            _horizontalMovement = _verticalMovement * -1;
        }
        public Texture2D GetTexture()
        {
            return _ballTexture;
        }
    }
}
