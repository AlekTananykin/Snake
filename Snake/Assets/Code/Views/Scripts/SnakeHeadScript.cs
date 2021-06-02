using Assets.Code.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHeadScript : MonoBehaviour, ILink
{
    private void OnTriggerEnter(Collider other)
    {
        _onTirggerEnter?.Invoke(other);
    }

    public Action<Collider> _onTirggerEnter;
}
