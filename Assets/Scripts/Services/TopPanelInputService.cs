using UI;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace Services
{
    public class TopPanelInputService : ICleanable
    {
        private HUD _hud;

        public void Init(HUD hud)
        {
            _hud = hud;
            _hud.ExitButton.onClick.AddListener(ExitCurrentScene);
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
                
#else

                Application.Quit();
                
#endif
            }
        }
    }
}