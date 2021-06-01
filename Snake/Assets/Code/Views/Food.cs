using Assets.Code.Interfaces;
using Assets.Code.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.Views
{
    class Food : IExecute, IInitialization
    {
        private GameObject _view;
        protected SnakeViewModel _viewModel;

        public Food(SnakeViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void Execute(float deltaTime)
        {
            throw new NotImplementedException();
        }

        public void Initialize()
        {
            _view = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Collider collider = _view.AddComponent<Collider>();
            collider.isTrigger = true;
        }

        public void SetPosition(Vector3 position)
        {
            _view.SetActive(true);
            _view.transform.position = position;
        }

        public void Hide()
        {
            _view.SetActive(false);
        }

        public void Eaten()
        {
            
        }

    }
}
