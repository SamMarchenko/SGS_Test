namespace States
{
    public interface IPayLoadedState<TPayLoad> : IInitExitableState
    {
        void Enter(TPayLoad payLoad);
    }
}