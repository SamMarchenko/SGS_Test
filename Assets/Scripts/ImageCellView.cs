using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ImageCellView : MonoBehaviour
{
    private string _urlPath;
    private Coroutine _loadRoutine;

    private bool _isLoaded;

    public RawImage Image;
    public Button Button;
    
    public bool IsLoaded => _isLoaded;

    public void LoadImage(string path) =>
        _loadRoutine = StartCoroutine(Load(path));

    private IEnumerator Load(string path)
    {
        var request = UnityWebRequestTexture.GetTexture(path);

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

    public void AddCallBack(UnityAction action)
    {
        Button.onClick.AddListener(action);
    }
}