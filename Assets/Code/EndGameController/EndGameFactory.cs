using UnityEngine;

namespace testtask.sausage
{
    public sealed class EndGameFactory :
        IFactory<EndGameController>
    {
        private PlayerController _playerController;
        private UIController _uiController;

        public EndGameFactory(UIController uIController, PlayerController playerController)
        {
            _uiController = uIController;
            _playerController = playerController;
        }

        public EndGameController Create()
        {
            var deadZones = Object.FindObjectsOfType<DeadZone>();
            var playerTranform = _playerController.Model.PlayerTransform.parent;

            return new EndGameController(deadZones, playerTranform, _uiController);
        }
    }
}

