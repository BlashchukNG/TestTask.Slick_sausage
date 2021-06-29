using UnityEngine;


namespace testtask.sausage
{
    public sealed class StartMenuController :
        IController
    {
        public IStartMenuView View { get; private set; }

        public StartMenuController(IStartMenuView view)
        {
            View = view;
        }
    }
}

