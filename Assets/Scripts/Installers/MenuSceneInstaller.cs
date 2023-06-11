using Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Installers
{
    public class MenuSceneInstaller : MonoInstaller
    {
        [SerializeField] private Button _loadGallerySceneBtn;
        public override void InstallBindings()
        {
            Container.BindInstance(_loadGallerySceneBtn);
            Container.BindInterfacesAndSelfTo<MenuSceneService>().AsSingle().NonLazy();
        }
    }
}