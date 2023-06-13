using System;
using System.Collections.Generic;
using Factories;
using Services;
using UnityEngine.UI;
using Zenject;

namespace Services
{
    public class MenuSceneService : IInitializable, IDisposable
    {
        private readonly List<ICleanable> _cleanables;
        private readonly Button _loadGallerySceneButton;
        private readonly UIFactory _uiFactory;
        private readonly TopPanelInputService _topPanelInputService;

        public MenuSceneService(List<ICleanable> cleanables,Button loadGallerySceneButton, UIFactory uiFactory,
            TopPanelInputService topPanelInputService)
        {
            _cleanables = cleanables;
            _loadGallerySceneButton = loadGallerySceneButton;
            _uiFactory = uiFactory;
            _topPanelInputService = topPanelInputService;
        }

        public void Initialize()
        {
            var hud = _uiFactory.CreateHUD();
            _topPanelInputService.Init(hud);
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