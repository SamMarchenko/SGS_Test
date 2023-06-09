using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class LoadImageFromURL : MonoBehaviour
{
    private const string URLPath = "http://data.ikppbb.com/test-task-unity-data/pics/";
    private Coroutine _loadRoutine;
    private Camera _camera;

    private bool _isLoaded;

    public RectTransform uiElement;

    //public int ImageNumber = 1;
    public RawImage Image;
    public Button Button;


    private void Awake()
    {
        Button.onClick.AddListener(Load);
    }

    private void Start()
    {
        _camera = Camera.main;
    }

    // private void Update()
    // {
    //     if (_loadRoutine != null)
    //         return;
    //
    //     if (RectTransformUtility.RectangleContainsScreenPoint(uiElement,
    //             _camera.WorldToScreenPoint(uiElement.position), _camera))
    //     {
    //         Debug.Log($"{gameObject.name} видно");
    //         _loadRoutine = StartCoroutine(LoadImage(URLPath));
    //     }
    // }
    
    
    void Update()
    {
        if (!_isLoaded && IsVisibleOnScreen())
        {
            StartCoroutine(LoadImage(URLPath));
        }
    }

    private bool IsVisibleOnScreen()
    {
        if (Image == null) return false;

        RectTransform rectTransform = Image.rectTransform;
        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);

        foreach (Vector3 corner in corners)
        {
            Vector3 screenPoint = _camera.WorldToViewportPoint(corner);
            if (screenPoint.x >= 0 && screenPoint.x <= 1 && screenPoint.y >= 0 && screenPoint.y <= 1)
            {
                Debug.Log($"{gameObject.name} видно");
                return true;
            }
        }

        return false;
    }

    private void Load()
    {
        // if (_loadRoutine != null)
        //     return;
        // _loadRoutine = StartCoroutine(LoadImage(URLPath));
    }

    private IEnumerator LoadImage(string urlPath)
    {
        int i = Random.Range(1, 67);
        var www = new WWW(URLPath + $"{i}.jpg");

        yield return www;

        if (www.error == null)
        {
            Image.texture = www.texture;
            _isLoaded = true;
           // Debug.Log($"Загружена картинка номер {i}");
        }
        else
        {
            Debug.Log("Error");
        }
    }
}