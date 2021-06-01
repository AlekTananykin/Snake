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


        void Start()
        {
            try
            {
                _storage = new ControllersStorage();
                _playerInput = new PlayerPcInput();
                InitGame(_storage, _playerInput);

                _storage.Initialize();
            }
            catch (GameException ex)
            {
                Debug.LogError(ex.Message);
                Application.Quit();
            }
        }

        private void InitGame(ControllersStorage storage, IPlayerInput playerInput)
        {
            SnakeViewModel viewModel = new SnakeViewModel(playerInput);

            storage.Add(viewModel);

        }

        void Update()
        {
            _storage.Execute(Time.deltaTime);
        }
       
        public void OnDestroy()
        {
            _storage.Cleanup();
        }

 
    }
}