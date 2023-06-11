using Zenject;

namespace Logic
{
    public class GalleryManager : IInitializable
    {
        private MainStateMachine _stateMachine;
        
        public GalleryManager(MainStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        public void Initialize() => 
            _stateMachine.Enter<LoadGalleryState>();
    }
}