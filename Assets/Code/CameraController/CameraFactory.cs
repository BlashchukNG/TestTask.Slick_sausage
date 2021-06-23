using TMPro;
using UnityEngine;

namespace testtask.sausage
{
    public sealed class CameraFactory :
        IFactory<CameraController>
    {
        private PlayerController _playerController;


        public CameraFactory(PlayerController playerController)
        {
            _playerController = playerController;
        }


        public CameraController Create()
        {
            var parent = _playerController.Model.PlayerTransform.parent;
            var playerTransform = parent.GetChild(parent.childCount / 2);

            return new CameraController(playerTransform);
        }
    }
}

