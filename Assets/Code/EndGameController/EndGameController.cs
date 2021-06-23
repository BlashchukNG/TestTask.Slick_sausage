using UnityEngine;


namespace testtask.sausage
{
    public sealed class EndGameController :
        IController
    {
        private Transform _playerTransform;
        private UIController _uiController;

        public EndGameController(DeadZone[] deadZones, Transform playerController, UIController uiController)
        {
            _playerTransform = playerController;
            _uiController = uiController;

            foreach (var zone in deadZones)
            {
                zone.OnGameOver += EndGame;
            }
        }


        private void EndGame()
        {
            _playerTransform.gameObject.SetActive(false);
            _uiController.EndGame();
        }
    }
}

