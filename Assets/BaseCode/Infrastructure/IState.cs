namespace BaseCode.Infrastructure
{
    public interface IExitableState
    {
        void Exit();
    }

    public interface IState : IExitableState
    {
        void Enter();
    }

    public interface ILoadedState<TData> : IExitableState
    {
        void Enter(TData data);
    }
}