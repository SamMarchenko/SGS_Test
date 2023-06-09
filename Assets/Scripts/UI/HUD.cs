using UnityEngine;

namespace DefaultNamespace.UI
{
    public class HUD : MonoBehaviour
    {
        [SerializeField] private GameObject _rootImages;

        public GameObject RootImages => _rootImages;

    }
}