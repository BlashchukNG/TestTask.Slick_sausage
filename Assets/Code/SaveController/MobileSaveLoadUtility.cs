using System.IO;
using UnityEngine;


namespace testtask.sausage
{
    public sealed class MobileSaveLoadUtility :
        ISaveLoadUtility
    {
        private readonly string path;

        public MobileSaveLoadUtility()
        {
            path = Application.persistentDataPath + $"/Save.save.gig";
        }

        public SaveData Load()
        {
            if(Path.E)
        }

        public void Save(SaveData save)
        {
            throw new System.NotImplementedException();
        }
    }
}

