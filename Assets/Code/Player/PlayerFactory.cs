using TMPro;
using UnityEngine;

namespace gig.fps
{
    public sealed class PlayerFactory :
        IFactory<PlayerController>
    {
        private GameData _gameData;

        public PlayerFactory(GameData data)
        {
            _gameData = data;
        }

        public PlayerController Create()
        {
            var startPosition = GameObject.FindGameObjectWithTag(_gameData.TagPlayerStartPosition).transform;
            var mainCanvas = Object.Instantiate(_gameData.GetPrfPlayer, startPosition);

            return new PlayerController();
        }
    }
}

