
using Controllers;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class MainMenuPanel : MenuPanel
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _selectLevelButton;
        [SerializeField] private Button _exitButton;
        public override void Configure(MenuMediator pMenuMediator)
        {
            base.menuMediator = pMenuMediator;
        }

        private void Awake()
        {
            _playButton.onClick.AddListener(() =>
            {
                menuMediator.OnPlayButtonPressed();
            });
            _selectLevelButton.onClick.AddListener(() =>
            {
                menuMediator.OnSelectLevelPressed();
            });
            _exitButton.onClick.AddListener(() =>
            {
                menuMediator.OnExitButtonPressed();
            });
        }

        public override void Show()
        {
            throw new System.NotImplementedException();
        }

        public override void Hide()
        {
            
        }
    }
}