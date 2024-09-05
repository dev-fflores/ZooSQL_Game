
using Controllers;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class MoreLevelPanel : MenuPanel
    {
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
        }
    }
}