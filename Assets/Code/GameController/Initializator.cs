namespace gig.fps
{
    public sealed class Initializator
    {
        public Initializator(GameData _data, ControllersRepository _repository)
        {
            var uiController = new UIControllerFactory(_data).Create();
            var playerController = new PlayerFactory(_data).Create();

            _repository.Add(uiController);
            _repository.Add(playerController);
        }
    }
}

