using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public class DownloadAndOpenImagesState : IPayLoadedState<Dictionary<ImageCellView, string>>
    {
        private IStateMachine _stateMachine;
        

        public void Init(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter(Dictionary<ImageCellView, string> payLoad)
        {
            foreach (var CellURLPair in payLoad)
            {
                var cell = CellURLPair.Key;
                var url = CellURLPair.Value;
                
                cell.LoadImage(url);
                
                AddCallback(cell);
            }
        }

        private void AddCallback(ImageCellView cell)
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
    }
}