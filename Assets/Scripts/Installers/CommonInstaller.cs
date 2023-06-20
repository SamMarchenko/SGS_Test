using Factories;
using Services;
using UI;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class CommonInstaller : MonoInstaller
    {
        [SerializeField] private HUD _hudPrefab;
        [SerializeField] private GalleryScrollView _galleryPrefab;
        [SerializeField] private CellView _cellViewPrefab;
        [SerializeField] private ImageView _imageViewPrefab;

        public override void InstallBindings()
        {
            BindHUD();
            BindUIElements();
            Container.BindInterfacesAndSelfTo<UIFactory>().AsSingle().NonLazy();
            BindServices();
        }

        private void BindServices()
        {
            Container.BindInterfacesAndSelfTo<InputService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ScreenRotationService>().AsSingle().NonLazy();
        }

        private void BindUIElements()
        {
            Container.BindInstance(_galleryPrefab);
            Container.BindInstance(_cellViewPrefab);
            Container.BindInstance(_imageViewPrefab);
        }

        private void BindHUD() => 
            Container.BindInstance(_hudPrefab);
    }
}