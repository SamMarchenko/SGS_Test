using System;
using Data;
using DefaultNamespace;
using DefaultNamespace.UI;
using UnityEngine;

namespace Logic
{
    public class GalleryManager : MonoBehaviour
    {
        [SerializeField] private GalleryConfig _data;
        [SerializeField] private HUD _hudPrefab;
        [SerializeField] private LoadImageFromURL _imagePrefab;


        private void Start()
        {
            var uiFactory = new UIFactory(_hudPrefab, _imagePrefab, _data);

            var hud = uiFactory.CreateHUD();
            uiFactory.CreateImages(hud.RootImages.transform);
        }
    }
}