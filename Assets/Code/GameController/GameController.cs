using UnityEngine;


namespace gig.fps
{
    public sealed class GameController : MonoBehaviour
    {
        private const string GAME_DATA_PATH = "dataGame";

        private GameData _data;
        private ControllersRepository _repository;

        private void Awake()
        {
            _data = Resources.Load<GameData>(GAME_DATA_PATH);
            _repository = new ControllersRepository();

            new Initializator(_data, _repository);
        }

        private void Update() => _repository.LogicUpdate(Time.deltaTime);
        private void FixedUpdate() => _repository.PhysicsUpdate(Time.deltaTime);
        private void LateUpdate() => _repository.LateUpdate(Time.deltaTime);

        private void OnDestroy() => _repository.CleanUp();
    }
}

