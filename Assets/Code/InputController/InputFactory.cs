using TMPro;
using UnityEngine;

namespace testtask.sausage
{
    public sealed class InputFactory :
        IFactory<InputController>
    {
        public InputController Create()
        {
            var userInput = new MobileUserInput();

            return new InputController(userInput);
        }
    }
}

