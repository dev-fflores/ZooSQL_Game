using System.Collections;
using System.Collections.Generic;
using Cartoon;
using Data;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Controllers
{
    public class StoryBoardController : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private List<CartoonPage> _cartoonPages;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private int _currentPageIndex;
        [SerializeField] private CartoonPage _currentPage;
        
        [SerializeField] private ConfigData _configData;
        
        private void Start()
        {
            _configData = DataManager.Instance.LoadConfigData();
            InitializeCartoons();
            _currentPageIndex = 0;
            _currentPage = _cartoonPages[_currentPageIndex];
        }

        private void InitializeCartoons()
        {
            foreach (var cartoonPage in _cartoonPages)
            {
                cartoonPage.gameObject.SetActive(false);
            }
            _cartoonPages[0].gameObject.SetActive(true);
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            var currentPage = GetCurrentCartoonPage();
            
            if (currentPage.IsDialogueFinished)
            {
                _cartoonPages[_currentPageIndex].gameObject.SetActive(false);
                _currentPageIndex++;

                if (_currentPageIndex >= _cartoonPages.Count)
                {
                    Debug.Log("All dialogues are finished");
                    // TODO: Add a method to finish the story
                    // Ir a la siguiente escena
                    var gameType = _configData.currentGameType;

                    if (gameType == GameType.CardsGame.ToString())
                    {
                        SceneManager.LoadScene("CardsGameScene");
                    }else if (gameType == GameType.QuizGame.ToString())
                    {
                        SceneManager.LoadScene("QuizGameScene");
                    }
                }
                else
                {
                    _cartoonPages[_currentPageIndex].gameObject.SetActive(true);
                }
            }
            currentPage.WritePartialDialogue();
        }
        
        public CartoonPage GetCurrentCartoonPage()
        {
            return _cartoonPages[_currentPageIndex];
        }
    }

}