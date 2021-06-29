namespace testtask.sausage
{
    public sealed class StartMenuControllerFactory :
        IFactory<StartMenuController>
    {
        private GameData _gameData;

        public StartMenuControllerFactory(GameData gameData)
        {
            _gameData = gameData;
        }


        public StartMenuController Create()
        {

        }
    }
}

