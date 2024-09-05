using System;
using Controllers;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class SelectLevelPanel : MenuPanel
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
                menuMediator.BackPanel();
            });
        }

        public override void Show()
        {
            throw new System.NotImplementedException();
        }

        public override void Hide()
        {
            throw new System.NotImplementedException();
        }
    }
}