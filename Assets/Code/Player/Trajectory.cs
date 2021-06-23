using UnityEngine;


namespace testtask.sausage
{
    public sealed class Trajectory
    {
        private TrajectoryData _data;
        private Transform[] _trajectoryPoints;
        private Transform _playerTransform;
        private Transform _rootTrajectory;
        private bool _isAiming;

        public Trajectory(TrajectoryData data, Transform prfPoint, Transform playerTransform, Transform root)
        {
            _data = data;
            _rootTrajectory = root;
            _playerTransform = playerTransform;

            Create(prfPoint);
            Deactivate();
        }


        private void Create(Transform prfPoint)
        {
            _trajectoryPoints = new Transform[_data.PointsLenght];

            for (int i = 0; i < _data.PointsLenght; i++)
            {
                _trajectoryPoints[i] = Object.Instantiate(prfPoint, _rootTrajectory);
            }
        }

        private Vector3 CalculatePointPosition(Vector3 direction, float force, float distance)
        {
            var position = _playerTransform.position + (direction * force * distance) +
                (Physics.gravity * (distance * distance) * 0.5f);
            return position;
        }

        public void CalculateTrajectory(Vector3 direction, float force)
        {
            if (_isAiming)
                for (int i = 0; i < _trajectoryPoints.Length; i++)
                {
                    _trajectoryPoints[i].transform.position = CalculatePointPosition(direction, force, i * _data.DistanceBtwPoints);
                }
        }
        public void Activate()
        {
            _rootTrajectory.gameObject.SetActive(true);
            _isAiming = true;
        }
        public void Deactivate()
        {
            _rootTrajectory.gameObject.SetActive(false);
            _isAiming = false;
        }
    }
}

