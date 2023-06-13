using System.Collections;
using Assets.SimpleSpinner;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace UI
{
    public class CellView : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private SimpleSpinner _spinner;

        private Coroutine _loadRoutine;

        private bool _isLoaded;

        public RawImage Image;
        public Button Button;

        public bool IsLoaded => _isLoaded;
        public RectTransform RectTransform => _rectTransform;
        public Coroutine LoadRoutine => _loadRoutine;

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
                ChangeImageAlfa();
                _spinner.gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("Error");
                _loadRoutine = null;
                _isLoaded = false;
            }
        }

        private void ChangeImageAlfa()
        {
            var color = Image.color;
            color.a = 1;
            Image.color = color;
        }

        public void AddCallBack(UnityAction action) =>
            Button.onClick.AddListener(action);
    }
}