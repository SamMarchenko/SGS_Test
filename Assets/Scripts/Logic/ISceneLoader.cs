using Logic;
using UnityEngine.UI;

namespace Logic
{
    public interface ISceneLoader
    {
        public void Load(string URL, int imagesCount);
        public void Load(RawImage image);
    }
}

public class SceneLoader : ISceneLoader
{
    public void Load(string URL, int imagesCount)
    {
        
    }

    public void Load(RawImage image)
    {
        
    }
}