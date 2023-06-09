using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoadImageFromURL : MonoBehaviour
{
    private string _urlPath;
    private Coroutine _loadRoutine;

    private bool _isLoaded;

    public RawImage Image;
    public Button Button;

    public void Init(string path)
    {
        _urlPath = path;
        Button.onClick.AddListener(LoadViewScene);
    }

    private void LoadViewScene()
    {
        if (_isLoaded)
            Debug.Log("Загружаю View сцену");
    }
    
    private void Update()
    {
        if (_loadRoutine != null)
            return;
        Load();
    }

    private void Load() =>
        _loadRoutine = StartCoroutine(LoadImage());

    private IEnumerator LoadImage()
    {
        var www = new WWW(_urlPath);

        yield return www;

        if (www.error == null)
        {
            Image.texture = www.texture;
            _isLoaded = true;
        }
        else
        {
            Debug.Log("Error");
            _loadRoutine = null;
            _isLoaded = false;
        }
    }
}