using System;
using System.Collections.Generic;
using StateMachine;
using States;
using UnityEngine;
using Zenject;

namespace Services
{
    public class GallerySceneInitService : IInitializable, IDisposable
    {
        private readonly List<ICleanable> _cleanables;
        private MainStateMachine _stateMachine;
        
        public GallerySceneInitService(List<ICleanable> cleanables, MainStateMachine stateMachine)
        {
            _cleanables = cleanables;
            _stateMachine = stateMachine;
        }
        
        public void Initialize()
        {
            Screen.orientation = ScreenOrientation.Portrait;
            _stateMachine.Enter<LoadUIState>();
        }

        public void Dispose()
        {
            foreach (var cleanable in _cleanables)
            {
                cleanable.Clean();
            }
        }
    }
}