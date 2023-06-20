using System.Collections.Generic;
using Data;
using Services;
using UI;
using UnityEngine;

namespace Factories
{
    public class UIFactory : ICleanable
    {
        private readonly HUD _hudPrefab;
        private readonly CellView _cellPrefab;
        private readonly GalleryScrollView _galleryPrefab;
        private readonly ImageView _imageViewPrefab;
        private readonly GalleryData _data;
        private List<CellView> _imageCells = new List<CellView>();

        public List<CellView> ImageCells => _imageCells;

        public UIFactory(HUD HUDPrefab, CellView cellPrefab, GalleryScrollView galleryPrefab, ImageView imageViewPrefab,
            GalleryData data)
        {
            _hudPrefab = HUDPrefab;
            _cellPrefab = cellPrefab;
            _galleryPrefab = galleryPrefab;
            _imageViewPrefab = imageViewPrefab;
            _data = data;
        }

        public HUD CreateHUD() =>
            Object.Instantiate(_hudPrefab);

        public ImageView CreateImageView(Transform parent) => 
            Object.Instantiate(_imageViewPrefab, parent);

        public GalleryScrollView CreateGallery(Transform parent) =>
            Object.Instantiate(_galleryPrefab, parent);

        public void CreateImages(Transform parent)
        {
            for (int i = 0; i < _data.ImagesCount; i++)
            {
                var cell = Object.Instantiate(_cellPrefab, parent);
                _imageCells.Add(cell);
            }
        }
        
        public void Clean() => 
            _imageCells.Clear();
    }
}