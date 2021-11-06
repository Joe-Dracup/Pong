using Microsoft.Xna.Framework.Graphics;
using System;

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
        private Bar _playerBar;
        private Bar _cpuBar;
        public Ball(Texture2D texture, int xPos, int worldHeight, int worldWidth, Bar playerBar, Bar cpuBar)
        {
            _ballTexture = texture;
            _xPos = xPos;
            _yPos = worldHeight / 2; ;
            _worldHeight = worldHeight;
            _worldWidth = worldWidth;
            _playerBar = playerBar;
            _cpuBar = cpuBar;
        }

        public void Move()
        {
            MoveVertically();
            MoveHorizontally();

            if (IsCollision(_playerBar))
            {
                BounceHorizontal();
                UpdateVerticalMovement(_playerBar);
            }

            if (IsCollision(_cpuBar))
            {
                BounceHorizontal();
                UpdateVerticalMovement(_cpuBar);
            }
        }

        private void MoveHorizontally()
        {
            if (_xPos > _worldWidth || _xPos < 0)
            {
                BounceHorizontal();
            }
            _xPos += _horizontalMovement;
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
            _verticalMovement = _verticalMovement * -1;
        }
        public Texture2D GetTexture()
        {
            return _ballTexture;
        }

        private bool IsCollision(Bar bar)
        {
            return IsXCollision(bar) && IsYCollision(bar);
        }

        private bool IsXCollision(Bar bar)
        {
            return _xPos <= bar.GetXPos() + bar.GetBarWidth() && _xPos >= bar.GetXPos();
        }

        private bool IsYCollision(Bar bar)
        {
            return _yPos <= bar.GetYPos() + bar.GetBarHeight() && _yPos >= bar.GetYPos();
        }

        private void UpdateVerticalMovement(Bar bar)
        {
            var diff = _yPos - bar.YCenterOfBar();
            var off = (diff) / 5;
            _verticalMovement = off;
        }
    }
}
