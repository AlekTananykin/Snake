using Assets.Code.Interfaces;
using Assets.Code.Models;
using Assets.Code.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.ViewModels
{
    sealed class CameraViewModel : IInitialization
    {
        private GameObject _view;
        private CameraModel _model;

        internal CameraViewModel(ViewsFabric viewFabric)
        {
            _view = viewFabric.CreateCamera();
            _model = new CameraModel();
        }

        public void Initialize()
        {
            Camera camera = _view.GetComponent<Camera>();
            camera.transform.forward = Vector3.down;
        }

        public void SetPosition(Vector3 pos)
        {
            _view.transform.position = 
                new Vector3(pos.x, _model.Height, pos.z);
        }

    }
}
