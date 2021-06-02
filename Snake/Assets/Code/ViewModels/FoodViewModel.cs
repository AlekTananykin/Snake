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
    class FoodViewModel : IInitialization
    {
        private FoodModel _model;
        private GameObject _view;

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
