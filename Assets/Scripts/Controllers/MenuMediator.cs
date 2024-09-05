using System;
using System.Collections.Generic;
using Menu;
using UnityEngine;

namespace Controllers
{
    public class MenuMediator : MonoBehaviour
    {
        public static MenuMediator Instance { get; private set; }
        private Stack<MenuPanel> _panelStack = new Stack<MenuPanel>();

        [SerializeField] private MenuPanel _mainMenuPanel;
        [SerializeField] private MenuPanel _selectLevelPanel;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            _mainMenuPanel.Configure(this);
            _selectLevelPanel.Configure(this);
        }

        public void OnPlayButtonPressed()
        {
            Debug.Log("A jugar!");
            
            
        }

        public void OnSelectLevelPressed()
        {
            Debug.Log("Selecciona nivel!");
            
            ShowPanel(_selectLevelPanel);
        }

        public void OnExitButtonPressed()
        {
            Debug.Log("Salió!");
        }

        public void ShowPanel(MenuPanel menuPanel)
        {
            if (_panelStack.Count > 0)
            {
                _panelStack.Peek().Hide();
            }
            
            _panelStack.Push(menuPanel);
            menuPanel.Show();
        }

        public void BackPanel()
        {
            if (_panelStack.Count <= 0) return;
            
            _panelStack.Pop().Hide();
            if (_panelStack.Count > 0)
            {
                _panelStack.Peek().Show();
            }
        }
    }
}