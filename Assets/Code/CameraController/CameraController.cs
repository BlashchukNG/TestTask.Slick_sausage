using UnityEngine;


namespace testtask.sausage
{
    public sealed class CameraController :
        IController,
        ILateUpdatable
    {
        private Transform _playerTransform;
        private Transform _cameraTransform;
        private Vector3 _offset;

        public CameraController(Transform playerTransform)
        {
            _playerTransform = playerTransform;
            _cameraTransform = Camera.allCameras[0].transform;
            _offset = _cameraTransform.position - _playerTransform.transform.position;
        }

        public void LateUpdate(float delta)
        {
            _cameraTransform.position = _playerTransform.position + _offset;
        }
    }
}

