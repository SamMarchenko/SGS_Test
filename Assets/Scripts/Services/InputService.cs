using UI;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Services
{
    public class InputService : ICleanable, ITickable
    {
        private HUD _hud;

        public void Init(HUD hud)
        {
            _hud = hud;
            _hud.ExitButton.onClick.AddListener(ExitCurrentScene);
        }

        public void Tick()
        {
#if UNITY_ANDROID
            if (Input.GetKey(KeyCode.Escape)) 
                ExitCurrentScene();
#endif
        }

        public void Clean()
        {
            _hud.ExitButton.onClick.RemoveAllListeners();
        }

        private void ExitCurrentScene()
        {
         
            var activeScene = SceneManager.GetActiveScene().buildIndex;

            if (activeScene > 0)
                SceneLoadService.SwitchToScene(activeScene - 1);
            else
            {
#if UNITY_EDITOR

                EditorApplication.isPaused = true;
                
#elif UNITY_ANDROID
                Application.Quit();
                
#endif
            }
        }
    }
}