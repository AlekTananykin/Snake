using Assets.Code.PlayerInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.Models
{
    internal sealed class SnakeModel
    {
        private IPlayerInput _input;
        private float _snakeSpeed = 1f;

        internal SnakeModel(IPlayerInput input)
        {
            _input = input;
        }

        internal Vector3 GetHeadPosition(Vector3 position, float deltaTime)
        {
            float speedX = 0;
            float speedZ = 0;
            if (_input.Left)
            {
                speedX = -_snakeSpeed;
            }
            else if (_input.Right)
            {
                speedX = _snakeSpeed;
            }

            if (_input.Top)
            {
                speedZ = _snakeSpeed;
            }
            else if (_input.Bottom)
            {
                speedZ = -_snakeSpeed;
            }

            Vector3 speed = new Vector3(speedX, 0, speedZ);
            return position + 
                deltaTime * Vector3.ClampMagnitude(speed, _snakeSpeed);
        }

        internal Vector3 GetLinkPosition(Vector3 position, Vector3 nextPosition, float deltaTime)
        {
            Vector3 speed = nextPosition - position;
            return position +
                deltaTime * Vector3.ClampMagnitude(speed, _snakeSpeed);
        }

        internal bool IsCreateLink()
        {
            return _input.IsCreateLink;
        }
    }
}
