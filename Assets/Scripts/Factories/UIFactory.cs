using System.Collections.Generic;
using Data;
using UI;
using UnityEngine;

namespace Factories
{
    public class UIFactory
    {
        private readonly HUD _hudPrefab;
        private readonly CellView _cellPrefab;
        private readonly GalleryData _data;
        private List<CellView> _imageCells = new List<CellView>();

        public List<CellView> ImageCells => _imageCells;

        public UIFactory(HUD HUDPrefab, CellView cellPrefab, GalleryData data)
        {
            _hudPrefab = HUDPrefab;
            _cellPrefab = cellPrefab;
            _data = data;
        }

        public HUD CreateHUD() => 
            Object.Instantiate(_hudPrefab);

        public void CreateImages(Transform root)
        {
            for (int i = 0; i < _data.ImagesCount; i++)
            {
                var cell = Object.Instantiate(_cellPrefab, root);
                _imageCells.Add(cell);
                cell.instanceY = Camera.main.ScreenToWorldPoint(cell.RectTransform.position).y;
            }
        }
    }
}