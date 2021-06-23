using System;
using UnityEngine;


namespace testtask.sausage
{
    public interface IUserInput
    {
        event Action<Vector3> OnTouchDown;
        event Action<Vector3> OnTouchMoved;
        event Action<Vector3> OnTouchUp;

        void GetInput();
    }
}

