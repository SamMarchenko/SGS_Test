using Factories;
using StateMachine;

namespace States
{
    public class LoadGalleryState : IState
    {
        private readonly UIFactory _uiFactory;
        private IStateMachine _stateMachine;

        public LoadGalleryState(UIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        public void Init(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            var hud = _uiFactory.CreateHUD();
            _uiFactory.CreateImages(hud.RootImages.transform);
            
            _stateMachine.Enter<SetImagesURLState>();
        }

        public void Exit()
        {
        }
    }
}