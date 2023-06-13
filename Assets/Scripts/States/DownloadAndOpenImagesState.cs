using System.Collections.Generic;
using Data;
using StateMachine;
using UI;
using UnityEngine;

namespace States
{
    public class DownloadAndOpenImagesState : IPayLoadedState<Dictionary<CellView, string>>, IUpdatableState
    {
        private readonly ImageViewTextureData _textureData;
        private IStateMachine _stateMachine;
        private Dictionary<CellView, string> _cellsUrls;

        public DownloadAndOpenImagesState(ImageViewTextureData textureData)
        {
            _textureData = textureData;
        }

        public void Init(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter(Dictionary<CellView, string> payLoad)
        {
            _cellsUrls = payLoad;
            foreach (var CellURLPair in _cellsUrls)
                AddCallback(CellURLPair.Key);
        }

        private void AddCallback(CellView cell)
        {
            cell.AddCallBack(() =>
            {
                if (cell.IsLoaded)
                {
                    _textureData.Texture = cell.Image.texture;
                    _stateMachine.Enter<LoadViewSceneState>();
                }
            });
        }


        public void Exit()
        {
        }

        public void Update()
        {
            foreach (var cell in _cellsUrls.Keys)
            {
                if (CheckCellVisible(cell) && cell.LoadRoutine == null)
                {
                    cell.LoadImage(_cellsUrls[cell]);
                }
            }
        }

        private bool CheckCellVisible(CellView cell)
        {
            var cameraMinY = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane)).y;

            var cellY = Camera.main.ScreenToWorldPoint(cell.RectTransform.position).y;
            
            return cameraMinY <=
                   cellY;
        }
    }
}