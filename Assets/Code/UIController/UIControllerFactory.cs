using TMPro;
using UnityEngine;

namespace gig.fps
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

            gameVersion.GetChild(0).GetComponent<TMP_Text>().text = _gameData.CurrentGameVersion;

            return new UIController(mainCanvas);
        }
    }
}

