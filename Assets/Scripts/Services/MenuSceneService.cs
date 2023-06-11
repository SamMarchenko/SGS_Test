using UnityEngine.UI;
using Zenject;

namespace Services
{
    public class MenuSceneService : IInitializable
    {
        private readonly Button _loadGallerySceneButton;

        public MenuSceneService(Button loadGallerySceneButton)
        {
            _loadGallerySceneButton = loadGallerySceneButton;
        }

        public void Initialize() => 
            _loadGallerySceneButton.onClick.AddListener(Load);

        private void Load() =>
            SceneLoadService.SwitchToScene("GalleryScene");
    }
}