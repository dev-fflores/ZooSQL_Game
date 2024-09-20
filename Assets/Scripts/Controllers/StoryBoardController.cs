using System.Collections;
using System.Collections.Generic;
using Cartoon;
using Data;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Menu;
using UnityEngine.Serialization;

namespace Controllers
{
    public class StoryBoardController : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private List<CartoonPage> _cartoonPages;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private int _currentPageIndex;
        [SerializeField] private CartoonPage _currentPage;
        
        [SerializeField] private AnimationInType _animationInType;
        [SerializeField] private AnimationOutType _animationOutType;
        [SerializeField] private float _animationDuration;
        private bool _isInTransition;
        
        [SerializeField] private ConfigData _configData;
        
        private void Start()
        {
            DOTween.Init();
            _isInTransition = true;
            _configData = DataManager.Instance.LoadConfigData();
            SetupCartoonPages();
            _currentPageIndex = 0;
            _currentPage = _cartoonPages[_currentPageIndex];
            
            _canvasGroup.alpha = 0;
            var sequence = DOTween.Sequence();
            sequence.Append(_canvasGroup.DOFade(1, _animationDuration)).AppendCallback(() =>
            {
                _isInTransition = false;
                Debug.Log("IsInTransition: " + _isInTransition);
            });
            sequence.Play();
        }

        private void SetupCartoonPages()
        {
            foreach (var cartoonPage in _cartoonPages)
            {
                cartoonPage.gameObject.SetActive(false);
            }
            _cartoonPages[0].gameObject.SetActive(true);
        }
        
        private IEnumerator CanvasFadeIn()
        {
            _isInTransition = true;
            _canvasGroup.alpha = 0;
            // DisableInteractableButtons();
            _canvasGroup.DOFade(1, _animationDuration);
            yield return new WaitForSeconds(_animationDuration);
            _isInTransition = false;
            // EnableInteractableButtons();
        }
        
        private IEnumerator CanvasFadeOut()
        {
            _isInTransition = true;
            _canvasGroup.alpha = 1;
            // DisableInteractableButtons();
            _canvasGroup.DOFade(0, _animationDuration);
            yield return new WaitForSeconds(_animationDuration);
            _isInTransition = false;
        }
        
        private void DisableInteractableButtons()
        {
            foreach (var cartoonPage in _cartoonPages)
            {
                cartoonPage.GetComponent<CanvasGroup>().interactable = false;
                cartoonPage.GetComponent<CanvasGroup>().blocksRaycasts = false;
            }
        }
        
        private void EnableInteractableButtons()
        {
            foreach (var cartoonPage in _cartoonPages)
            {
                cartoonPage.GetComponent<CanvasGroup>().interactable = true;
                cartoonPage.GetComponent<CanvasGroup>().blocksRaycasts = true;
            }
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            if (_isInTransition)
            {
                return;
            }
            
            var currentPage = GetCurrentCartoonPage();

            if (!currentPage.IsPartialDialogueFinished && !currentPage.IsDialogueFinished)
            {
                currentPage.CompleteWritePartialDialogue();
                return;
            }
            
            if (currentPage.IsDialogueFinished)
            {
                _isInTransition = true;
                
                var sequence = DOTween.Sequence();
                sequence.Append(_canvasGroup.DOFade(0, _animationDuration)).AppendCallback(() =>
                {
                    _cartoonPages[_currentPageIndex].gameObject.SetActive(false);
                    _currentPageIndex++;
                    if (_currentPageIndex >= _cartoonPages.Count)
                    {
                        DOTween.KillAll();
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
                });

                // _isInTransition = true;
                sequence.AppendCallback(() =>
                {
                    _canvasGroup.alpha = 0;
                    _cartoonPages[_currentPageIndex].gameObject.SetActive(true);
                });
                sequence.Append(_canvasGroup.DOFade(1, _animationDuration)).AppendCallback(() =>
                {
                    _isInTransition = false;
                });
                sequence.Play();
            }
            currentPage.WritePartialDialogueWithAnimation();
        }
        
        public CartoonPage GetCurrentCartoonPage()
        {
            return _cartoonPages[_currentPageIndex];
        }
    }

}