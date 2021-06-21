using System;
using UnityEngine;


namespace gig.fps
{
    public sealed class PlayerView :
        MonoBehaviour
    {
        public event Action<float> OnGetDamage = context => { };


        public void AddDamage(float damage)
        {
            OnGetDamage.Invoke(damage);
        }
    }
}

