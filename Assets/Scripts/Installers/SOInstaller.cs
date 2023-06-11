using Data;
using UnityEngine;
using Zenject;

namespace Installers
{
    [CreateAssetMenu(menuName = "SOInstallers", fileName = "SOInstaller")]
    public class SOInstaller : ScriptableObjectInstaller<SOInstaller>
    {
        [SerializeField] private GalleryData _galleryData;
       

        public override void InstallBindings()
        {
            BindGalleryData();
           
        }

        private void BindGalleryData() => 
            Container.BindInstance(_galleryData);
    }
}