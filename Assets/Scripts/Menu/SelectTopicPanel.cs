using System.Collections.Generic;
using Controllers;
using Data;
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
            
            _buttons = new List<Selectable>()
            {
                _algebraTopicButton,
                _plsqlTopicButton,
                _backButton
            };
        }
        
        private void Start()
        {
            
            _algebraTopicButton.onClick.AddListener(() =>
            {
                menuMediator.OnTopicButtonClicked(QuestionTopic.Algebra);
            });
            
            _plsqlTopicButton.onClick.AddListener(() =>
            {
                menuMediator.OnTopicButtonClicked(QuestionTopic.PlSql);
            });
            
            _backButton.onClick.AddListener(() =>
            {
                menuMediator.OnBackButtonClicked();
            });
        }
    }
}