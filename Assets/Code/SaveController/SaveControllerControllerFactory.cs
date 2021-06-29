using UnityEngine;

namespace testtask.sausage
{
    public sealed class SaveControllerControllerFactory :
        IFactory<SaveController>
    {
        private GameData _gameData;
        private ISaveLoadUtility saveProvider;

        public SaveControllerControllerFactory(GameData gameData)
        {
            _gameData = gameData;

            switch (Application.platform)
            {
                case RuntimePlatform.WindowsPlayer:
                case RuntimePlatform.WebGLPlayer:
                case RuntimePlatform.WindowsEditor:

                    break;
                case RuntimePlatform.IPhonePlayer:
                case RuntimePlatform.Android:

                    break;
                default:
                    throw new System.InvalidOperationException("Save controller: can not load platform");
            }
        }


        public SaveController Create()
        {

        }


        private 
    }
}

