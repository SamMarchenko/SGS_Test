﻿using System.Collections.Generic;

namespace Logic
{
    public class SetImagesURLState : IState
    {
        private readonly URLService _urlService;
        private readonly UIFactory _uiFactory;
        private IStateMachine _stateMachine;

        public SetImagesURLState(URLService urlService, UIFactory uiFactory)
        {
            _urlService = urlService;
            _uiFactory = uiFactory;
        }
        public void Init(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            var urls = _urlService.SetURl(_uiFactory.ImageCells);
            _stateMachine.Enter<DownloadAndOpenImagesState, Dictionary<ImageCellView, string>>(urls);
        }

        public void Exit()
        {
        }
    }
}