﻿using Factories;
using Services;
using StateMachine;
using UI;

namespace States
{
    public class LoadUIState : IState
    {
        private readonly UIFactory _uiFactory;
        private IStateMachine _stateMachine;
        private HUD _hud;
        private GalleryScrollView _gallery;
        private TopPanelInputService _topPanelInputService;

        public LoadUIState(UIFactory uiFactory, TopPanelInputService topPanelInputService)
        {
            _uiFactory = uiFactory;
            _topPanelInputService = topPanelInputService;
        }

        public void Init(IStateMachine stateMachine) => 
            _stateMachine = stateMachine;

        public void Enter() =>
            InitUI();

        private void InitUI()
        {
            _hud = _uiFactory.CreateHUD();

            _topPanelInputService.Init(_hud);
            
            _gallery = _uiFactory.CreateGallery(_hud.ContentParent.transform);
            Subscribe();

            _uiFactory.CreateImages(_gallery.CellsParent.transform);
        }

        private void Subscribe() =>
            _gallery.OnGridFilled += OnGridFilled;

        private void OnGridFilled() =>
            _stateMachine.Enter<SetImagesURLState>();

        public void Exit() => 
            Unsubscribe();

        private void Unsubscribe() => 
            _gallery.OnGridFilled -= OnGridFilled;
    }
}