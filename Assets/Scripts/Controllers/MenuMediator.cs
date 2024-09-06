﻿using System.Collections;
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

        [SerializeField] private MainMenuPanel _mainMenuPanel;
        [SerializeField] private SelectLevelPanel _selectLevelPanel;
        [SerializeField] private MoreLevelPanel _moreLevelPanel;

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
        
        private void DisableButtons()
        {
            _mainMenuPanel._playButton.interactable = false;
            _mainMenuPanel._selectLevelButton.interactable = false;
            _mainMenuPanel._exitButton.interactable = false;
            _selectLevelPanel._backButton.interactable = false;
            _selectLevelPanel._moreLevelButton.interactable = false;
            _moreLevelPanel._backButton.interactable = false;
        }

        private void EnableButtons()
        {
            _mainMenuPanel._playButton.interactable = true;
            _mainMenuPanel._selectLevelButton.interactable = true;
            _mainMenuPanel._exitButton.interactable = true;
            _selectLevelPanel._backButton.interactable = true;
            _selectLevelPanel._moreLevelButton.interactable = true;
            _moreLevelPanel._backButton.interactable = true;
        }

    }
}