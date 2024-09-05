using DG.Tweening;
using Controllers;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class SelectLevelPanel : MenuPanel
    {
        [SerializeField] private Button _moreLevelButton; 
        [SerializeField] private Button _backButton; 
        public override void Configure(MenuMediator pMenuMediator)
        {
            base.menuMediator = pMenuMediator;
        }

        private void Awake()
        {
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