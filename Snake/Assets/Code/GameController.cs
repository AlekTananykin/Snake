using Assets.Code.Exceptions;

using Assets.Code.PlayerInput;
using Assets.Code.ViewModels;
using Assets.Code.Views;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Controllers
{
    public sealed class GameController : MonoBehaviour
    {
        private ControllersStorage _storage;
        private IPlayerInput _playerInput;
        private ViewsFabric _viewsFabric;

        private SnakeViewModel _snake;
        private CameraViewModel _camera;

        void Start()
        {
            try
            {
                _storage = new ControllersStorage();
                _playerInput = new PlayerPcInput();
                _viewsFabric = new ViewsFabric();

                InitGame(_storage, _playerInput, _viewsFabric);

                _storage.Initialize();
            }
            catch (GameException ex)
            {
                Debug.LogError(ex.Message);
                Application.Quit();
            }
        }

        private void InitGame(ControllersStorage storage, 
            IPlayerInput playerInput, ViewsFabric viewFabric)
        {
            _snake = new SnakeViewModel(playerInput);
            storage.Add(_snake);

            _camera = new CameraViewModel(viewFabric);
           //_camera.SetPosition(_snake.GetPosition());
            storage.Add(_camera);

            FoodViewModel food = new FoodViewModel();
            storage.Add(food);

            _snake.Position += _camera.SetPosition;
        }

        void Update()
        {
            _storage.Execute(Time.deltaTime);
        }
       
        public void OnDestroy()
        {
            _storage.Cleanup();
            _snake.Position -= _camera.SetPosition;
        }

 
    }
}