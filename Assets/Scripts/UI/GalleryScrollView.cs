using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GalleryScrollView : MonoBehaviour
    {
        [SerializeField] private GameObject _cellsParent;
        [SerializeField] private GridLayoutGroup _gridLayoutGroup;
        private bool _gridFilled;

        public Action OnGridFilled;

        public GameObject CellsParent => _cellsParent;

        private void Update()
        {
            if (_gridFilled)
            {
                return;
            }
            if (_gridLayoutGroup.isActiveAndEnabled)
            {
                OnGridFilled?.Invoke();
                _gridFilled = true;
            }
            
        }
    }
}