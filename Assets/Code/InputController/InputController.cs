namespace testtask.sausage
{
    public sealed class InputController :
        IController,
        ILogicUpdatable
    {
        public IUserInput UserInput { get; private set; }

        public InputController(IUserInput userInput)
        {
            UserInput = userInput;
        }


        public void LogicUpdate(float delta)
        {
            UserInput.GetInput();
        }
    }
}

