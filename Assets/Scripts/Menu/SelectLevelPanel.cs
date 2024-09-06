﻿using System.Collections.Generic;
using DG.Tweening;
using Controllers;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class SelectLevelPanel : MenuPanel
    {
        [SerializeField] public Button _moreLevelButton; 
        [SerializeField] public Button _backButton; 
        public override void Configure(MenuMediator pMenuMediator)
        {
            base.menuMediator = pMenuMediator;
        }

        private void Awake()
        {
            _buttons = new List<Button>
            {
                _moreLevelButton,
                _backButton
            };
            
            _backButton.onClick.AddListener(() =>
            {
                menuMediator.OnBackButtonClicked();
            });
            _moreLevelButton.onClick.AddListener(() =>
            {
                menuMediator.OnMoreLevelButtonClicked();
            });
        }

        public override void Show()
        {
            base.Show();
        }

        public override void Hide()
        {
            base.Hide();
        }
    }
}