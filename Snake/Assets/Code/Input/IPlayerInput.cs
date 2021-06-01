using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.PlayerInput
{
    interface IPlayerInput
    {
        bool Left { get; }
        bool Right { get; }
        bool Top { get; }
        bool Bottom { get; }
        bool IsCreateLink { get; }

    }
}
