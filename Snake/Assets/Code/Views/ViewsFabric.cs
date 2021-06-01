using Assets.Code.Exceptions;
using Assets.Code.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.Views
{
    internal class ViewsFabric
    {
        private GameObject _camera;
        internal GameObject CreateCamera()
        {
            if (null == _camera)
            {
                GameObject cameraPrefab = 
                    (GameObject)Resources.Load("Prefabs/Main Camera");
                if (null == cameraPrefab)
                {
                    throw new GameException(
                        "CreateCamera: Camera prefab is not found. ");
                }
                _camera = GameObject.Instantiate(cameraPrefab);
            }
            return _camera;
        }

    }
}
