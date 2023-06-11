using Factories;
using Services;
using StateMachine;
using States;
using UI;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GallerySceneInstaller : MonoInstaller
    {
        [SerializeField] private CellView cellPrefab;

        public override void InstallBindings()
        {
            Container.BindInstance(cellPrefab);

            Container.BindInterfacesAndSelfTo<URLService>().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<UIFactory>().AsSingle().NonLazy();
            
            Container.BindInterfacesAndSelfTo<LoadViewSceneState>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<LoadGalleryState>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<SetImagesURLState>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<DownloadAndOpenImagesState>().AsSingle().NonLazy();
            
            Container.BindInterfacesAndSelfTo<MainStateMachine>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GallerySceneInitService>().AsSingle().NonLazy();
        }
    }
}