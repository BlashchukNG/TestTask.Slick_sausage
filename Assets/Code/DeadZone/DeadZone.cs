using UnityEngine;


namespace testtask.sausage
{
    public sealed class DeadZone :
        MonoBehaviour,
        IDeadZone
    {
        public event System.Action OnGameOver = () => { };


        private void OnTriggerEnter(Collider other)
        {
            OnGameOver.Invoke();
        }
    }
}

