using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "Configs/GalleryConfig", fileName = "NewGalleryConfig")]
    public class GalleryConfig : ScriptableObject
    {
        [SerializeField] private string _galleryURL;
        [SerializeField] private int _imagesCount;

        public string GalleryURL => _galleryURL;
        public int ImagesCount => _imagesCount;
    }
}