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