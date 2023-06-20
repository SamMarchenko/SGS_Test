using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ImageView : MonoBehaviour
    {
        public RawImage Image;

        public void Init(Texture texture) =>
            Image.texture = texture;
    }
}