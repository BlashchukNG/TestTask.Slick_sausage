namespace gig.fps
{
    public interface IController { }
    public interface ILogicUpdatable { void LogicUpdate(float delta); }
    public interface IPhysicsUpdatable { void PhysicsUpdate(float delta); }
    public interface ILateUpdatable { void LateUpdate(float delta); }
    public interface IFactory<T> { T Create(); }
}

