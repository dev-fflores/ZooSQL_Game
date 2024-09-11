using System.Collections.Generic;
using DG.Tweening;
using Controllers;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class MainMenuPanel : MenuPanel
    {
        [SerializeField] public Button _playButton;
        [SerializeField] public Button _selectLevelButton;
        [SerializeField] public Button _exitButton;
        public override void Configure(MenuMediator pMenuMediator)
        {
            base.menuMediator = pMenuMediator;
        }

        private void Awake()
        {
            // Agregar los botones, que se van a declarando, en la lista _buttons
            _buttons = new List<Selectable>
            {
                _playButton,
                _selectLevelButton,
                _exitButton
            };
            
            _playButton.onClick.AddListener(() =>
            {
                menuMediator.OnPlayButtonClicked();
            });
            _selectLevelButton.onClick.AddListener(() =>
            {
                menuMediator.OnSelectLevelClicked();
            });
            _exitButton.onClick.AddListener(() =>
            {
                menuMediator.OnExitButtonClicked();
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