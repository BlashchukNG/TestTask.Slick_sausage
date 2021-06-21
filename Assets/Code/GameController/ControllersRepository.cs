using System.Collections.Generic;


namespace gig.fps
{
    public sealed class ControllersRepository :
        ILogicUpdatable,
        IPhysicsUpdatable,
        ILateUpdatable
    {
        private readonly List<ILogicUpdatable> _logicUpdatables;
        private readonly List<IPhysicsUpdatable> _physicsUpdatables;
        private readonly List<ILateUpdatable> _lateUpdatables;


        public ControllersRepository()
        {
            _logicUpdatables = new List<ILogicUpdatable>();
            _physicsUpdatables = new List<IPhysicsUpdatable>();
            _lateUpdatables = new List<ILateUpdatable>();
        }


        public void Add(IController controller)
        {
            if (controller is ILogicUpdatable logicUpdatable) _logicUpdatables.Add(logicUpdatable);
            if (controller is IPhysicsUpdatable physicsUpdatable) _physicsUpdatables.Add(physicsUpdatable);
            if (controller is ILateUpdatable lateUpdatable) _lateUpdatables.Add(lateUpdatable);
        }
        public void Remove(IController controller)
        {
            if (controller is ILogicUpdatable logicUpdatable) _logicUpdatables.Remove(logicUpdatable);
            if (controller is IPhysicsUpdatable physicsUpdatable) _physicsUpdatables.Remove(physicsUpdatable);
            if (controller is ILateUpdatable lateUpdatable) _lateUpdatables.Remove(lateUpdatable);
        }
        public void CleanUp()
        {
            _logicUpdatables.Clear();
            _physicsUpdatables.Clear();
            _lateUpdatables.Clear();
        }

        public void LogicUpdate(float delta)
        {
            foreach (var updatable in _logicUpdatables)
            {
                updatable.LogicUpdate(delta);
            }
        }

        public void PhysicsUpdate(float delta)
        {
            foreach (var updatable in _physicsUpdatables)
            {
                updatable.PhysicsUpdate(delta);
            }
        }

        public void LateUpdate(float delta)
        {
            foreach (var updatable in _lateUpdatables)
            {
                updatable.LateUpdate(delta);
            }
        }
    }
}

