using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.PlayerInput
{
    sealed class PlayerPcInput : IPlayerInput
    {
        public bool Left => Input.GetKey(KeyCode.A);
        public bool Right => Input.GetKey(KeyCode.D);
        public bool Top => Input.GetKey(KeyCode.W);
        public bool Bottom => Input.GetKey(KeyCode.S);
        public bool IsCreateLink => Input.GetKeyDown(KeyCode.L);
    }
}
