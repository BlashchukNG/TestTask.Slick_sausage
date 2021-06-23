using TMPro;
using UnityEngine;

namespace testtask.sausage
{
    public sealed class UIControllerFactory :
        IFactory<UIController>
    {
        private GameData _gameData;

        public UIControllerFactory(GameData data)
        {
            _gameData = data;
        }

        public UIController Create()
        {
            var mainCanvas = Object.Instantiate(_gameData.GetPrfMainCanvas);
            var gameVersion = Object.Instantiate(_gameData.GetPrfGameVersion, mainCanvas);
            var endGame = Object.Instantiate(_gameData.GetPrfEndGame, mainCanvas);

            gameVersion.GetChild(0).GetComponent<TMP_Text>().text = _gameData.CurrentGameVersion;

            return new UIController(mainCanvas, endGame);
        }
    }
}

