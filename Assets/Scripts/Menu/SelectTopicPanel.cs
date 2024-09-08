using System.Collections.Generic;
using Controllers;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class SelectTopicPanel : MenuPanel
    {
        [SerializeField] private Button _algebraTopicButton;
        [SerializeField] private Button _plsqlTopicButton;
        [SerializeField] private Button _backButton;
        
        public override void Configure(MenuMediator pMenuMediator)
        {
            base.menuMediator = pMenuMediator;
        }
        
        private void Start()
        {
            _buttons = new List<Button>()
            {
                _algebraTopicButton,
                _plsqlTopicButton,
                _backButton
            };
            
            _algebraTopicButton.onClick.AddListener(() =>
            {
                menuMediator.OnAlgebraTopicButtonClicked();
            });
            
            _plsqlTopicButton.onClick.AddListener(() =>
            {
                menuMediator.OnPlsqlTopicButtonClicked();
            });
            
            _backButton.onClick.AddListener(() =>
            {
                menuMediator.OnBackButtonClicked();
            });
        }
    }
}