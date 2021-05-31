using Assets.Code.Exceptions;
using Assets.Code.Models;
using Assets.Code.PlayerInput;
using Assets.Code.SaveLoad;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Controllers
{
    public sealed class GameController : MonoBehaviour
    {
        private ControllersStorage _storage;

        private IPlayerInput _playerInput;

        private uint _piratesCount = 1200;

        void Start()
        {
            try
            {

                _playerInput = new PlayerPcInput();
                new InitGame(_controllersStorage, gameModel,
                    _playerInput, _savedGamesPath);

                _controllersStorage.Initialize();
            }
            catch (GameException ex)
            {
                Debug.LogError(ex.Message);
                Application.Quit();
            }
        }

        void Update()
        {
            _controllersStorage.Execute(Time.deltaTime);
        }
        private void LateUpdate()
        {
            _controllersStorage.LateExecute(Time.deltaTime);
        }

        public void OnDestroy()
        {
            _controllersStorage.Cleanup();
        }

 
    }
}