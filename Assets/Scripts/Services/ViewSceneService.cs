using System;
using System.Collections.Generic;
using Data;
using Factories;
using UnityEngine;
using Zenject;

namespace Services
{
    public class ViewSceneService : IInitializable, IDisposable
    {
        private readonly UIFactory _uiFactory;
        private readonly ImageViewTextureData _textureData;
        private readonly List<ICleanable> _cleanables;
        private readonly TopPanelInputService _topPanelInputService;

        public ViewSceneService(UIFactory uiFactory, ImageViewTextureData textureData, List<ICleanable> cleanables,
            TopPanelInputService topPanelInputService)
        {
            _uiFactory = uiFactory;
            _textureData = textureData;
            _cleanables = cleanables;
            _topPanelInputService = topPanelInputService;
        }

        public void Initialize()
        {
            Screen.orientation = ScreenOrientation.Portrait;
            
            var hud = _uiFactory.CreateHUD();

            _topPanelInputService.Init(hud);
            
            var imageView = _uiFactory.CreateImageView(hud.ContentParent.transform);
            imageView.Init(_textureData.Texture);
        }
        

        public void Dispose()
        {
            foreach (var cleanable in _cleanables)
                cleanable.Clean();
        }
    }
}