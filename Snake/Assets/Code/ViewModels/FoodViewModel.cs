using Assets.Code.Interfaces;
using Assets.Code.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.ViewModels
{
<<<<<<< HEAD
    class FoodViewModel : IInitialization
=======
    class FoodViewModel : IInitialization, ICleanup
>>>>>>> f8bc5d74e33dee40e11c2410899bcee682774704
    {
        private FoodModel _model;
        private GameObject _view;

<<<<<<< HEAD
=======
        public void Cleanup()
        {
        }

>>>>>>> f8bc5d74e33dee40e11c2410899bcee682774704
        public void Initialize()
        {
            _model = new FoodModel();

            _view = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Collider collider = _view.GetComponent<Collider>();
            collider.isTrigger = false;

            Rigidbody rigidBody = _view.AddComponent<Rigidbody>();
            rigidBody.isKinematic = true;

            FoodScript food = _view.AddComponent<FoodScript>();
            food._onTirggerEnter += CollisionOccured;

            _view.transform.position = _model.GetPosition();
        }

        public void CollisionOccured(Collider obj) 
        {
            _view.transform.position = _model.GetPosition();
        }
    }
}
