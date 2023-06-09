using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
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
        var request = UnityWebRequestTexture.GetTexture(_urlPath);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Image.texture = DownloadHandlerTexture.GetContent(request);
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