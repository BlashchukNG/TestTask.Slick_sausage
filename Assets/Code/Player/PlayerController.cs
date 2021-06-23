using UnityEngine;


namespace testtask.sausage
{
    public sealed class PlayerController :
        IController,
        IPhysicsUpdatable
    {
        private const float FORCE_MOD = 4.0f;

        public PlayerModel Model { get; set; }

        private Trajectory _trajectory;
        private IPlayerMove _playerMove;


        public PlayerController(
            PlayerData playerData,
            TrajectoryData trajectoryData,
            Transform prefabPlayer,
            Transform prefabPoint,
            Transform rootTrajectory,
            InputController _inputController)
        {
            Model = new PlayerModel(playerData);
            Model.PlayerTransform = prefabPlayer;
            Model.PlayerRigidbody = prefabPlayer.GetComponent<Rigidbody>();
            _playerMove = new PlayerMove();
            _trajectory = new Trajectory(trajectoryData, prefabPoint, prefabPlayer, rootTrajectory);

            _inputController.UserInput.OnTouchDown += SetStartPosition;
            _inputController.UserInput.OnTouchMoved += Aiming;
            _inputController.UserInput.OnTouchUp += Launch;
        }

        private void SetStartPosition(Vector3 position)
        {
            if (Model.IsGround)
            {
                _trajectory.Activate();
                Model.StartTouchPosition = position;
            }
        }
        private void Aiming(Vector3 position)
        {
            if (Model.IsGround)
            {
                var force = (Model.StartTouchPosition - position).sqrMagnitude;
                force *= Model.Data.BaseForce;
                force = Mathf.Clamp(force, 0, Model.Data.MaxForce) / FORCE_MOD;

                var direction = (Model.StartTouchPosition - position).normalized;

                _trajectory.CalculateTrajectory(direction, force);
            }
        }
        private void Launch(Vector3 position)
        {
            if (Model.IsGround)
            {
                _playerMove.Launch(position, Model);
                _trajectory.Deactivate();
            }
        }
        private void CheckGround()
        {
            var check = Physics.OverlapSphere(Model.PlayerRigidbody.transform.position,
                Model.Data.CheckDistance, Model.Data.GroundLayerMask);
            Model.IsGround = check.Length > 0;
        }


        public void PhysicsUpdate(float delta)
        {
            CheckGround();
        }
    }
}

