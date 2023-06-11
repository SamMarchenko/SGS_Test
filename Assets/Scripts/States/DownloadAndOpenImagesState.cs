using System.Collections.Generic;
using StateMachine;
using UI;
using UnityEngine;

namespace States
{
    public class DownloadAndOpenImagesState : IPayLoadedState<Dictionary<CellView, string>>, IUpdatableState
    {
        private IStateMachine _stateMachine;
        private Dictionary<CellView, string> _cellsUrls;


        public void Init(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter(Dictionary<CellView, string> payLoad)
        {
            _cellsUrls = payLoad;
            Debug.Log("Вошел в DownloadAndOpenImagesState");
            foreach (var CellURLPair in _cellsUrls)
                AddCallback(CellURLPair.Key);
        }

        private void AddCallback(CellView cell)
        {
            cell.AddCallBack(() =>
            {
                if (cell.IsLoaded)
                    _stateMachine.Enter<LoadViewSceneState, Texture>(cell.Image.texture);
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

            //Debug.Log($"Camera minY ={cameraMinY}; CellY = {cellY}");

            //todo: костыль
            if (cellY == cell.instanceY)
                return false;

            return cameraMinY <=
                   cellY;
        }
    }
}