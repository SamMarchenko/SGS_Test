using StateMachine;

namespace States
{
    public interface IInitExitableState
    {
        void Init(IStateMachine stateMachine);
   
        void Exit();
    }
}