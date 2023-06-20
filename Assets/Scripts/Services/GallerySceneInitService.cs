using System;
using System.Collections.Generic;
using StateMachine;
using States;
using Zenject;

namespace Services
{
    public class GallerySceneInitService : IInitializable, IDisposable
    {
        private readonly List<ICleanable> _cleanables;
        private MainStateMachine _stateMachine;
        private readonly ScreenRotationService _screenRotationService;

        public GallerySceneInitService(List<ICleanable> cleanables, MainStateMachine stateMachine, ScreenRotationService screenRotationService)
        {
            _cleanables = cleanables;
            _stateMachine = stateMachine;
            _screenRotationService = screenRotationService;
        }

        public void Initialize()
        {
            _screenRotationService.SetOrientation(ScreenRotationService.Orientation.Portrait);
            _stateMachine.Enter<LoadUIState>();
        }

        public void Dispose()
        {
            foreach (var cleanable in _cleanables) 
                cleanable.Clean();
        }
    }
}