using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.Models
{
    class FoodModel
    {
        internal Vector3 GetPosition()
        {
            return new Vector3(
                UnityEngine.Random.value * 10f, 1.0f, UnityEngine.Random.value * 10f);
        }
    }
}
