using Logic;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GallerySceneInstaller : MonoInstaller
    {
        [SerializeField] private ImageCellView _imageCellPrefab;

        public override void InstallBindings()
        {
            Container.BindInstance(_imageCellPrefab);

            Container.BindInterfacesAndSelfTo<URLService>().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<UIFactory>().AsSingle().NonLazy();
            
            Container.BindInterfacesAndSelfTo<LoadViewSceneState>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<LoadGalleryState>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<SetImagesURLState>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<DownloadAndOpenImagesState>().AsSingle().NonLazy();
            
            Container.BindInterfacesAndSelfTo<MainStateMachine>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GalleryManager>().AsSingle().NonLazy();
        }
    }
}