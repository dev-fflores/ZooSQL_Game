using System.Collections.Generic;
using DG.Tweening;
using Controllers;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class OptionsMenuPanel : MenuPanel
    {
        [SerializeField] private Toggle _musicToggle; 
        [SerializeField] private Toggle _soundToggle; 
        [SerializeField] private Button _backButton; 
        public override void Configure(MenuMediator pMenuMediator)
        {
            base.menuMediator = pMenuMediator;
            
            _buttons = new List<Selectable>
            {
                _musicToggle,
                _soundToggle,
                _backButton
            };
        }

        private void Awake()
        {
            
            _backButton.onClick.AddListener(() =>
            {
                menuMediator.OnBackButtonClicked();
            });
            _musicToggle.onValueChanged.AddListener((value) =>
            {
                menuMediator.OnMusicToggleChanged(value);
            });
            _soundToggle.onValueChanged.AddListener((value) =>
            {
                menuMediator.OnSoundToggleChanged(value);
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