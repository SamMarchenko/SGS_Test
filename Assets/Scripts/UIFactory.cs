using System.Collections.Generic;
using Data;
using UI;
using UnityEngine;

public class UIFactory
{
    private readonly HUD _hudPrefab;
    private readonly ImageCellView _imageCellPrefab;
    private readonly GalleryData _data;
    private List<ImageCellView> _imageCells = new List<ImageCellView>();

    public List<ImageCellView> ImageCells => _imageCells;

    public UIFactory(HUD HUDPrefab, ImageCellView imageCellPrefab, GalleryData data)
    {
        _hudPrefab = HUDPrefab;
        _imageCellPrefab = imageCellPrefab;
        _data = data;
    }

    public HUD CreateHUD() => 
        Object.Instantiate(_hudPrefab);

    public void CreateImages(Transform root)
    {
        for (int i = 0; i < _data.ImagesCount; i++)
        {
            var image = Object.Instantiate(_imageCellPrefab, root);
            _imageCells.Add(image);
            // var path = _data.GalleryURL + $"{i + 1}.jpg";
            // image.Init(path);
        }
    }
}