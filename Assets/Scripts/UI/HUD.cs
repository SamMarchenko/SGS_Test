using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HUD : MonoBehaviour
    {
        [SerializeField] private Button _exitButton;
        [SerializeField] private Transform _contentParent;
        public Button ExitButton => _exitButton;
        public Transform ContentParent => _contentParent;
    }
}