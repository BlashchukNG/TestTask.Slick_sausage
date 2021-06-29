using UnityEngine;


namespace testtask.sausage
{
    public sealed class SaveController :
        IController
    {
        public SaveData Save { get; private set; }

        public SaveController(SaveData save)
        {
            Save = save;
        }
    }
}

