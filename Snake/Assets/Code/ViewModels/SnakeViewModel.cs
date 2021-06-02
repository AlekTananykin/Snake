using Assets.Code.Interfaces;
using Assets.Code.Models;
using Assets.Code.PlayerInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.ViewModels
{
    class SnakeViewModel : IExecute, IInitialization
    {
        private List<GameObject> _tail = new List<GameObject>();
        private GameObject _head;

        private float _linkSize;

        private SnakeModel _model;

        internal SnakeViewModel(IPlayerInput input)
        {
            _linkSize = 1;
            _model = new SnakeModel(input);
        }

        public void Execute(float deltaTime)
        {
            if (_model.IsCreateLink())
                _tail.Add(CreateLink(_head.transform.position));

            Vector3 headPrevPosition = _head.transform.position;
            _head.transform.position = _model.GetHeadPosition(headPrevPosition, deltaTime);
            Position(_head.transform.position);

            Vector3 neckPosition = _tail.Last().transform.position;
            if (Vector3.Distance(neckPosition, _head.transform.position) < _linkSize)
                return;

            for (int i = 0; i < _tail.Count - 1; ++i)
            {
                _tail[i].transform.position = _model.GetLinkPosition(
                    _tail[i].transform.position,
                    _tail[i + 1].transform.position, deltaTime);
            }
            
            _tail.Last().transform.position = _model.GetLinkPosition(
                _tail.Last().transform.position,
                headPrevPosition, deltaTime);
        }

        public void Initialize()
        {
            _head = CreateLink(new Vector3(10, 1, 3));
            SnakeHeadScript headScript = _head.AddComponent<SnakeHeadScript>();
            headScript._onTirggerEnter += CollisionOccured;

            GameObject link = CreateLink(new Vector3(10, 1, 2));
            _tail.Add(link);
        }

        private void CollisionOccured(Collider obj)
        {
            if (obj.gameObject.TryGetComponent(out IFood food))
            {
                _tail.Add(CreateLink(_head.transform.position));
                FoodEaten?.Invoke();
            }
            else
            {
                Dead?.Invoke();
                Debug.Log("GameOver");
            }
        }

        GameObject CreateLink(Vector3 position)
        {
            GameObject view = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            Collider collider = view.GetComponent<Collider>();
            collider.isTrigger = true;

            Rigidbody rigidBody = view.AddComponent<Rigidbody>();
            rigidBody.isKinematic = true;

            view.transform.position = position;
            return view;
        }


        internal Vector3 GetPosition()
        {
            return _head.transform.position;
        }


        internal Action<Vector3> Position;
        internal Action FoodEaten;
        internal Action Dead;
    }
}
