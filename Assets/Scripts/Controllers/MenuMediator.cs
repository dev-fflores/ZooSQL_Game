using System.Collections;
using DG.Tweening;
using System.Collections.Generic;
using Data;
using Menu;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Controllers
{
    public class MenuMediator : MonoBehaviour
    {
        private Stack<MenuPanel> _panelStack = new Stack<MenuPanel>();
        
        private ConfigData _configData;
        
        [Header("Menu Panels")]
        [SerializeField] private MenuPanel _mainMenuPanel;
        [SerializeField] private MenuPanel _optionsMenuPanel;
        [SerializeField] private MenuPanel _selectGamePanel;
        [SerializeField] private MenuPanel _selectTopicPanel;
        [SerializeField] private MenuPanel _selectDifficultyPanel;
        [SerializeField] private MenuPanel _moreLevelPanel;

        private void Awake()
        {
            
        }

        private void Start()
        {
            DOTween.Init();
            
            _configData = DataManager.Instance.LoadConfigData();
            
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
            _configData.currentGameType = GameType.QuizGame.ToString();
            Debug.Log($"currentGameType: {_configData.currentGameType}");
        }

        public void OnCardsGameButtonClicked()
        {
            ShowPanel(_selectTopicPanel);
            _configData.currentGameType = GameType.CardsGame.ToString();
            Debug.Log($"currentGameType: {_configData.currentGameType}");
        }
        
        public void OnBackButtonClicked()
        {
            BackPanel();
        }
        
        public void OnMoreLevelButtonClicked()
        {
            ShowPanel(_moreLevelPanel);
        }
        
        public void OnTopicButtonClicked(GameTopic gameTopic)
        {
            switch (gameTopic)
            {
                case GameTopic.Algebra:
                    _configData.currentTopic = GameTopic.Algebra.ToString();
                    break;
                case GameTopic.PlSql:
                    _configData.currentTopic = GameTopic.PlSql.ToString();
                    break;
                default:
                    _configData.currentTopic = GameTopic.None.ToString();
                    break;
            }
            Debug.Log($"currentTopic: {_configData.currentTopic}");
            ShowPanel(_selectDifficultyPanel);
        }
        
        public void OnDifficultyButtonClicked(GameDifficulty gameDifficulty)
        {
            switch (gameDifficulty)
            {
                case GameDifficulty.Easy:
                    _configData.currentDifficulty = (int)GameDifficulty.Easy;
                    break;
                case GameDifficulty.Medium:
                    _configData.currentDifficulty = (int)GameDifficulty.Medium;
                    break;
                case GameDifficulty.Hard:
                    _configData.currentDifficulty = (int)GameDifficulty.Hard;
                    break;
                default:
                    _configData.currentDifficulty = (int)GameDifficulty.None;
                    break;
            }
            _selectDifficultyPanel.Hide();
            DataManager.Instance.SaveConfigData(_configData);
            Debug.Log($"currentDifficulty: {_configData.currentDifficulty}");
            
            StartCoroutine(LoadSceneAfter("IntroScene", _selectDifficultyPanel.AnimationOutDuration));
        }
        
        private IEnumerator LoadSceneAfter(string sceneName, float seconds)
        {
            yield return new WaitForSeconds(seconds);
            DOTween.KillAll();
            SceneManager.LoadScene(sceneName);
        }

        // public void OnEasyButtonClicked()
        // {
        //     _configData.currentDifficulty = (int)GameDifficulty.Easy;
        //     DataManager.Instance.SaveConfigData(_configData);
        //     Debug.Log($"currentDifficulty: {_configData.currentDifficulty}");
        //     SceneManager.LoadScene("IntroScene");
        // }
        //
        // public void OnMediumButtonClicked()
        // {
        //     _configData.currentDifficulty = (int)GameDifficulty.Medium;
        //     DataManager.Instance.SaveConfigData(_configData);
        //     Debug.Log($"currentDifficulty: {_configData.currentDifficulty}");
        //     Debug.Log(_configData);
        //     SceneManager.LoadScene("IntroScene");
        // }
        //
        // public void OnHardButtonClicked()
        // {
        //     _configData.currentDifficulty = (int)GameDifficulty.Hard;
        //     DataManager.Instance.SaveConfigData(_configData);
        //     Debug.Log($"currentDifficulty: {_configData.currentDifficulty}");
        //     SceneManager.LoadScene("IntroScene");
        // }

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
