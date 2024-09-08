using System;
using System.Collections.Generic;
using Controllers;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class SelectGamePanel : MenuPanel
    {
        [SerializeField] private Button _quizGameButton;
        [SerializeField] private Button _cardsGameButton;
        [SerializeField] private Button _backButton;
        
        public override void Configure(MenuMediator pMenuMediator)
        {
            base.menuMediator = pMenuMediator;
        }

        private void Start()
        {
            _buttons = new List<Button>
            {
                _quizGameButton,
                _cardsGameButton,
                _backButton
            };
            
            _quizGameButton.onClick.AddListener(() =>
            {
                menuMediator.OnQuizGameButtonClicked();
            });
            
            _cardsGameButton.onClick.AddListener(() =>
            {
                menuMediator.OnCardsGameButtonClicked();
            });
            
            _backButton.onClick.AddListener(() =>
            {
                menuMediator.OnBackButtonClicked();
            });
        }
    }
}