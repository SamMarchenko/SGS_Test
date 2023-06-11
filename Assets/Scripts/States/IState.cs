namespace States
{
    public interface IState : IInitExitableState
    {
        void Enter();
    }
}