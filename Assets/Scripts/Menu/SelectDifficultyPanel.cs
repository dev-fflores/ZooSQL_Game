﻿using System.Collections.Generic;
using Controllers;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class SelectDifficultyPanel : MenuPanel
    {
        [SerializeField] private Button _easyButton;
        [SerializeField] private Button _mediumButton;
        [SerializeField] private Button _hardButton;
        [SerializeField] private Button _backButton;
        
        public override void Configure(MenuMediator pMenuMediator)
        {
            base.menuMediator = pMenuMediator;
        }
        
        private void Start()
        {
            _buttons = new List<Button>()
            {
                _easyButton,
                _mediumButton,
                _hardButton,
                _backButton
            };
            
            _easyButton.onClick.AddListener(() =>
            {
                menuMediator.OnEasyButtonClicked();
            });
            
            _mediumButton.onClick.AddListener(() =>
            {
                menuMediator.OnMediumButtonClicked();
            });
            
            _hardButton.onClick.AddListener(() =>
            {
                menuMediator.OnHardButtonClicked();
            });
            
            _backButton.onClick.AddListener(() =>
            {
                menuMediator.OnBackButtonClicked();
            });
        }
    }
}