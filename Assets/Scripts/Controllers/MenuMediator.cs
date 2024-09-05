using DG.Tweening;
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
        [SerializeField] private MenuPanel _moreLevelPanel;

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
            DOTween.Init();
            
            _panelStack.Push(_mainMenuPanel);
            
            _mainMenuPanel.Show();
            _selectLevelPanel.Hide();
            
            _mainMenuPanel.Configure(this);
            _selectLevelPanel.Configure(this);
            _moreLevelPanel.Configure(this);
        }

        public void OnPlayButtonClicked()
        {
            Debug.Log("A jugar!");
            
            
        }

        public void OnSelectLevelClicked()
        {
            ShowPanel(_selectLevelPanel);
            Debug.Log("Selecciona nivel!");
        }

        public void OnExitButtonClicked()
        {
            Debug.Log("Salió!");
        }

        public void OnBackButtonClicked()
        {
            BackPanel();
        }
        
        public void OnMoreLevelButtonClicked()
        {
            ShowPanel(_moreLevelPanel);
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