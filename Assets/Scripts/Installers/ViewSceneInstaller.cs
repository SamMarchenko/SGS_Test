using Services;
using Zenject;

namespace Installers
{
    public class ViewSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ViewSceneService>().AsSingle().NonLazy();
        }
    }
}