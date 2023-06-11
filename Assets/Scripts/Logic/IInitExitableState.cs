namespace Logic
{
    public interface IInitExitableState
    {
        void Init(IStateMachine stateMachine);
   
        void Exit();
    }
}