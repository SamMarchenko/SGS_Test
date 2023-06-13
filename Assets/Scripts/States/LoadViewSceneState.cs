using Services;
using StateMachine;

namespace States
{
    public class LoadViewSceneState : IState
    {
        private IStateMachine _stateMachine;

        public void Init(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter() => 
            SceneLoadService.TrySwitchToScene("ViewScene");


        public void Exit()
        {
        }
    }
}