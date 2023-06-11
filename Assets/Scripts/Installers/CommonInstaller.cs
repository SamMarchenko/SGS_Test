using UI;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class CommonInstaller : MonoInstaller
    {
        [SerializeField] private HUD _hudPrefab;

        public override void InstallBindings()
        {
            BindHUD();
        }

        private void BindHUD() => 
            Container.BindInstance(_hudPrefab);
    }
}