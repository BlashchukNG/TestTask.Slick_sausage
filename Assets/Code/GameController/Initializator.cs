namespace testtask.sausage
{
    public sealed class Initializator
    {
        public Initializator(GameData _data, ControllersRepository _repository)
        {
            var inputController = new InputFactory().Create();
            var playerController = new PlayerFactory(_data, inputController).Create();
            var uiController = new UIControllerFactory(_data).Create();
            var cameraController = new CameraFactory(playerController).Create();
            var endGameController = new EndGameFactory(uiController, playerController).Create();

            _repository.Add(inputController);
            _repository.Add(uiController);
            _repository.Add(playerController);
            _repository.Add(cameraController);
            _repository.Add(endGameController);
        }
    }
}

