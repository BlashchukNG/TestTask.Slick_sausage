using UnityEngine;


namespace testtask.sausage
{
    public sealed class PlayerMove :
        IPlayerMove
    {
        public void Launch(Vector3 position, PlayerModel model)
        {
            var force = (model.StartTouchPosition - position).sqrMagnitude;
            force *= model.Data.BaseForce;
            force = Mathf.Clamp(force, 0, model.Data.MaxForce);

            var direction = (model.StartTouchPosition - position).normalized;
            model.PlayerRigidbody.AddForce(direction * force, ForceMode.Impulse);
        }
    }
}

