using Services;
using StateMachine;
using States;
using Zenject;

namespace Installers
{
    public class GallerySceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<URLService>().AsSingle().NonLazy();
            BindStates();
            Container.BindInterfacesAndSelfTo<MainStateMachine>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GallerySceneInitService>().AsSingle().NonLazy();
        }

        private void BindStates()
        {
            Container.BindInterfacesAndSelfTo<LoadViewSceneState>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<LoadUIState>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<SetImagesURLState>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<DownloadAndOpenImagesState>().AsSingle().NonLazy();
        }
    }
}