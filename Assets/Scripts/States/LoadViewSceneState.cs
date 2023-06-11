using StateMachine;
using UnityEngine;

namespace States
{
    public class LoadViewSceneState : IPayLoadedState<Texture>
    {
        private IStateMachine _stateMachine;

        public void Init(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter(Texture payLoad)
        {
            Debug.Log("Загружаю сцену вьюхи картинки");
        }

        public void Exit()
        {
            
        }
    }
}