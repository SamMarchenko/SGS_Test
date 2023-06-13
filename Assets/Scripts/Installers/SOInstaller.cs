using Data;
using UnityEngine;
using Zenject;

namespace Installers
{
    [CreateAssetMenu(menuName = "SOInstallers", fileName = "SOInstaller")]
    public class SOInstaller : ScriptableObjectInstaller<SOInstaller>
    {
        [SerializeField] private GalleryData _galleryData;
        [SerializeField] private ImageViewTextureData _savedTextureData;


        public override void InstallBindings()
        {
            BindGalleryData();
            Container.BindInstance(_savedTextureData);
        }

        private void BindGalleryData() =>
            Container.BindInstance(_galleryData);
    }
}