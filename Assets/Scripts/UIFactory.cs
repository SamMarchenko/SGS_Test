using Data;
using DefaultNamespace.UI;
using UnityEngine;

namespace DefaultNamespace
{
    public class UIFactory
    {
        private readonly HUD _hud;
        private readonly LoadImageFromURL _imagePrefab;
        private readonly GalleryConfig _data;

        public UIFactory(HUD HUD, LoadImageFromURL imagePrefab, GalleryConfig data)
        {
            _hud = HUD;
            _imagePrefab = imagePrefab;
            _data = data;
        }

        public HUD CreateHUD()
        {
            var hud = Object.Instantiate(_hud);
            return hud;
        }

        public void CreateImages(Transform root)
        {
            for (int i = 0; i < _data.ImagesCount; i++)
            {
                var image = Object.Instantiate(_imagePrefab, root);
                var path = _data.GalleryURL + $"{i + 1}.jpg";
                image.Init(path);
            }
        }
    }
}