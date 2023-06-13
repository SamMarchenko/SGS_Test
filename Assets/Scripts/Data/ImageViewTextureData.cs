using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "SavedTextureData", fileName = "ViewData")]
    public class ImageViewTextureData : ScriptableObject
    {
        public Texture Texture;
    }
}