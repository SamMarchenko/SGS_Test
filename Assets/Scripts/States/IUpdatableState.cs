namespace States
{
    public interface IUpdatableState : IInitExitableState
    {
        void Update();
    }
}