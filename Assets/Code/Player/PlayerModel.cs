using UnityEngine;


namespace testtask.sausage
{
    public sealed class PlayerModel
    {
        public PlayerData Data { get; private set; }
        public Transform PlayerTransform { get; set; }
        public Rigidbody PlayerRigidbody { get; set; }
        public Vector3 StartTouchPosition { get; set; }
        public float CurrentForce { get; set; }
        public bool IsGround { get; set; }


        public PlayerModel(PlayerData data)
        {
            Data = data;
        }

    }
}