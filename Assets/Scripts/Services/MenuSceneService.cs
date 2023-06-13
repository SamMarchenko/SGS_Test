using System;
using System.Collections.Generic;
using Factories;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Services
{
    public class MenuSceneService : IInitializable, IDisposable
    {
        private readonly List<ICleanable> _cleanables;
        private readonly Button _loadGallerySceneButton;
        private readonly UIFactory _uiFactory;
        private readonly InputService _inputService;
        private readonly ScreenRotationService _screenRotationService;

        public MenuSceneService(List<ICleanable> cleanables,Button loadGallerySceneButton, UIFactory uiFactory,
            InputService inputService, ScreenRotationService screenRotationService)
        {
            _cleanables = cleanables;
            _loadGallerySceneButton = loadGallerySceneButton;
            _uiFactory = uiFactory;
            _inputService = inputService;
            _screenRotationService = screenRotationService;
        }

        public void Initialize()
        {
            _screenRotationService.SetOrientation(ScreenRotationService.Orientation.Portrait);
            
            var hud = _uiFactory.CreateHUD();
            _inputService.Init(hud);
            _loadGallerySceneButton.onClick.AddListener(Load);
        }

        private void Load()
        {
            _loadGallerySceneButton.gameObject.SetActive(false);
            SceneLoadService.SwitchToScene("GalleryScene");
        }

        public void Dispose()
        {
            foreach (var cleanable in _cleanables) 
                cleanable.Clean();
        }
    }
}