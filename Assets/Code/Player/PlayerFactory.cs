using TMPro;
using UnityEngine;

namespace testtask.sausage
{
    public sealed class PlayerFactory :
        IFactory<PlayerController>
    {
        private const string NAME_TRAJECTORY_ROOT = "Trajectory root";

        private GameData _gameData;
        private InputController _inputController;

        public PlayerFactory(GameData data, InputController inputController)
        {
            _gameData = data;
            _inputController = inputController;
        }

        public PlayerController Create()
        {
            var playerData = _gameData.GetDataPlayer;
            var trajectoryData = _gameData.GetDataTrajectory;
            var startPosition = GameObject.FindGameObjectWithTag(_gameData.TagPlayerStartPosition).transform;
            var prefabPlayer = Object.Instantiate(_gameData.GetPrfPlayer, startPosition).transform;
            prefabPlayer = prefabPlayer.GetChild(prefabPlayer.childCount / 2);
            var prefabPoint = _gameData.GetPrfPoint;

            var rootTrajectory = new GameObject(NAME_TRAJECTORY_ROOT).transform;

            return new PlayerController(
                playerData,
                trajectoryData,
                prefabPlayer,
                prefabPoint,
                rootTrajectory,
                _inputController);
        }
    }
}

