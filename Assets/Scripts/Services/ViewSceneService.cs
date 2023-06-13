using System;
using System.Collections.Generic;
using Data;
using Factories;
using Zenject;

namespace Services
{
    public class ViewSceneService : IInitializable, IDisposable
    {
        private readonly UIFactory _uiFactory;
        private readonly ImageViewTextureData _textureData;
        private readonly List<ICleanable> _cleanables;
        private readonly InputService _inputService;
        private readonly ScreenRotationService _screenRotationService;

        public ViewSceneService(UIFactory uiFactory, ImageViewTextureData textureData, List<ICleanable> cleanables,
            InputService inputService, ScreenRotationService screenRotationService)
        {
            _uiFactory = uiFactory;
            _textureData = textureData;
            _cleanables = cleanables;
            _inputService = inputService;
            _screenRotationService = screenRotationService;
        }

        public void Initialize()
        {
            _screenRotationService.SetOrientation(ScreenRotationService.Orientation.Any);

            var hud = _uiFactory.CreateHUD();

            _inputService.Init(hud);

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