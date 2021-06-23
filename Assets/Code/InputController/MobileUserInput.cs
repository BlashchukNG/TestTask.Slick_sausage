using System;
using UnityEngine;


namespace testtask.sausage
{
    public sealed class MobileUserInput :
        IUserInput
    {
        public event Action<Vector3> OnTouchDown = context => { };
        public event Action<Vector3> OnTouchMoved = context => { };
        public event Action<Vector3> OnTouchUp = context => { };

        public void GetInput()
        {
            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        OnTouchDown.Invoke(touch.position);
                        break;
                    case TouchPhase.Moved:
                        OnTouchMoved.Invoke(touch.position);
                        break;
                    case TouchPhase.Ended:
                        OnTouchUp.Invoke(touch.position);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

