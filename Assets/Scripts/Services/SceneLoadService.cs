using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Services
{
    public class SceneLoadService : MonoBehaviour
    {
        private static SceneLoadService s_instance;
        private static bool s_shouldPlayOpenigAnimation = false;
        private static bool s_isFree = true;


        [SerializeField] private Animator _animator;
        [SerializeField] private TMP_Text _loadingPercentageText;
        [SerializeField] private Slider _loadingProgressBar;

        private AsyncOperation _loadingSceneOperation;


        public static void TrySwitchToScene(string sceneName)
        {
            if (!s_isFree)
                return;
            
            s_instance._animator.SetTrigger("sceneClosing");

            s_instance._loadingSceneOperation = SceneManager.LoadSceneAsync(sceneName);
            s_isFree = false;
            s_instance._loadingSceneOperation.allowSceneActivation = false;
        }
        
        public static void TrySwitchToScene(int sceneIndex)
        {
            if (!s_isFree)
                return;
            s_instance._animator.SetTrigger("sceneClosing");

            s_instance._loadingSceneOperation = SceneManager.LoadSceneAsync(sceneIndex);
            s_isFree = false;
            s_instance._loadingSceneOperation.allowSceneActivation = false;
        }

        private void Start()
        {
            s_instance = this;

            if (s_shouldPlayOpenigAnimation)
            {
                _animator.SetTrigger("sceneOpening");
            }
        }

        private void Update()
        {
            if (_loadingSceneOperation != null)
            {
                _loadingPercentageText.text = Mathf.RoundToInt(_loadingSceneOperation.progress * 100) + "%";
                _loadingProgressBar.value = _loadingSceneOperation.progress;
            }
        }

        public void OnAnimationOver()
        {
            s_shouldPlayOpenigAnimation = true;
            _loadingSceneOperation.allowSceneActivation = true;
            s_isFree = true;
        }
    }
}