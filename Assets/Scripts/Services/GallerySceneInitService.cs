using StateMachine;
using States;
using Zenject;

namespace Services
{
    public class GallerySceneInitService : IInitializable
    {
        private MainStateMachine _stateMachine;
        
        public GallerySceneInitService(MainStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        public void Initialize() => 
            _stateMachine.Enter<LoadGalleryState>();
    }
}