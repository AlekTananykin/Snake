using Assets.Code.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour, IFood
{
    private void OnTriggerEnter(Collider other)
    {
        _onTirggerEnter?.Invoke(other);
    }

    public Action<Collider> _onTirggerEnter;
}
