using System.Collections;
using DG.Tweening;
using System.Collections.Generic;
using Menu;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Controllers
{
    public class MenuMediator : MonoBehaviour
    {
        public static MenuMediator Instance { get; private set; }
        private Stack<MenuPanel> _panelStack = new Stack<MenuPanel>();
        

        [SerializeField] private MenuPanel _mainMenuPanel;
        [SerializeField] private MenuPanel _optionsMenuPanel;
        [SerializeField] private MenuPanel _selectGamePanel;
        [SerializeField] private MenuPanel _selectTopicPanel;
        [SerializeField] private MenuPanel _selectDifficultyPanel;
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
            _optionsMenuPanel.Hide();
            _selectGamePanel.Hide();
            _selectTopicPanel.Hide();
            _selectDifficultyPanel.Hide();
            _moreLevelPanel.Hide();
            
            
            _mainMenuPanel.Configure(this);
            _optionsMenuPanel.Configure(this);
            _selectGamePanel.Configure(this);
            _selectTopicPanel.Configure(this);
            _selectDifficultyPanel.Configure(this);
            _moreLevelPanel.Configure(this);
        }

        public void OnPlayButtonClicked()
        {
            Debug.Log("A jugar!");
            ShowPanel(_selectGamePanel);
            
        }

        public void OnSelectLevelClicked()
        {
            ShowPanel(_optionsMenuPanel);
            Debug.Log("Selecciona nivel!");
        }

        public void OnExitButtonClicked()
        {
            Debug.Log("Salió!");
        }
        
        public void OnQuizGameButtonClicked()
        {
            ShowPanel(_selectTopicPanel);
        }

        public void OnCardsGameButtonClicked()
        {
            ShowPanel(_selectTopicPanel);
        }
        
        public void OnBackButtonClicked()
        {
            BackPanel();
        }
        
        public void OnMoreLevelButtonClicked()
        {
            ShowPanel(_moreLevelPanel);
        }
        

        public void OnAlgebraTopicButtonClicked()
        {
            ShowPanel(_selectDifficultyPanel);
        }

        public void OnPlsqlTopicButtonClicked()
        {
            ShowPanel(_selectDifficultyPanel);
        }

        public void OnEasyButtonClicked()
        {
            SceneManager.LoadScene("IntroScene");
        }

        public void OnMediumButtonClicked()
        {
            SceneManager.LoadScene("IntroScene");
        }

        public void OnHardButtonClicked()
        {
            SceneManager.LoadScene("IntroScene");
        }

        #region ShowAndHidePanels

        public void ShowPanel(MenuPanel menuPanel)
        {
            if (_panelStack.Count > 0)
            {
                _panelStack.Peek().Hide();
            }
            
            StartCoroutine(ShowPanelCoroutine(menuPanel));
        }
        
        private IEnumerator ShowPanelCoroutine(MenuPanel menuPanel)
        {
            DisableButtons();
            yield return new WaitForSeconds(_panelStack.Count > 0 ? _panelStack.Peek().AnimationOutDuration : 0);
            _panelStack.Push(menuPanel);
            menuPanel.Show();
            EnableButtons();
        }

        public void BackPanel()
        {
            if (_panelStack.Count <= 0) return;
        
            StartCoroutine(BackPanelCoroutine());
        }
        
        private IEnumerator BackPanelCoroutine()
        {
            DisableButtons();
            var currentPanel = _panelStack.Pop();
            currentPanel.Hide();
            yield return new WaitForSeconds(currentPanel.AnimationOutDuration);
            if (_panelStack.Count > 0)
            {
                _panelStack.Peek().Show();
            }
            EnableButtons();
        }

        #endregion

        #region EnableAndDisableButtons
        private void DisableButtons()
        {
            foreach (var menuPanel in _panelStack)
            {
                foreach (var button in menuPanel.Buttons)
                {
                    button.interactable = false;
                }
            }
        }

        private void EnableButtons()
        {
            foreach (var menuPanel in _panelStack)
            {
                foreach (var button in menuPanel.Buttons)
                {
                    button.interactable = true;
                }
            }
        }

        #endregion
    }
}
