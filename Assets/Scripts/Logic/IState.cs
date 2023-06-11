namespace Logic
{
    public interface IState : IInitExitableState
    {
        void Enter();
    }
}