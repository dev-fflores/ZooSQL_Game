﻿using System;
using System.Collections;
using System.Collections.Generic;
using Controllers;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Menu
{
    public enum DirectionIn
    {
        Left,
        Right,
        Up,
        Down
    }
    
    public enum DirectionOut
    {
        Left,
        Right,
        Up,
        Down
    }
    
    public enum AnimationInType
    {
        None,
        FadeIn,
        SlideIn,
        ScaleIn,
    }

    public enum AnimationOutType
    {
        None,
        FadeOut,
        SlideOut,
        ScaleOut,
    }
    
    public abstract class MenuPanel : MonoBehaviour
    {
        protected MenuMediator menuMediator;
        
        protected List<Selectable> _buttons = new List<Selectable>();
        public List<Selectable> Buttons => _buttons;
        public float AnimationOutDuration => _animationOutDuration;
        
        [SerializeField] protected CanvasGroup _canvasGroup;
        [SerializeField] protected AnimationInType _animationInType;
        [SerializeField] protected AnimationOutType _animationOutType;
        [SerializeField] protected float _animationInDuration;
        [SerializeField] protected float _animationOutDuration;
        [SerializeField] protected DirectionIn directionIn;
        [SerializeField] protected DirectionOut directionOut;

        protected RectTransform rectTransform;
        public virtual void Configure(MenuMediator pMenuMediator)
        {
            this.menuMediator = pMenuMediator;
        }

        private void Awake()
        {
            // _buttons = new List<Button>(GetComponentsInChildren<Button>());
            // _buttons.ForEach(button =>
            // {
            //     button.onClick.AddListener(() =>
            //     {
            //         menuMediator.OnButtonClicked(button);
            //     });
            // });
            
        }

        public virtual void Show()
        {
            switch (_animationInType)
            {
                case AnimationInType.None:
                    break;
                case AnimationInType.FadeIn:
                    _canvasGroup.alpha = 0;
                    _canvasGroup.DOFade(1, _animationInDuration);
                    break;
                case AnimationInType.SlideIn:
                    rectTransform = GetComponent<RectTransform>();
                    switch (directionIn)
                    {
                        case DirectionIn.Left:
                            rectTransform.anchoredPosition = new Vector2(-Screen.width, 0);
                            rectTransform.DOAnchorPosX(0, _animationInDuration);
                            break;
                        case DirectionIn.Right:
                            rectTransform.anchoredPosition = new Vector2(Screen.width, 0);
                            rectTransform.DOAnchorPosX(0, _animationInDuration);
                            break;
                        case DirectionIn.Up:
                            rectTransform.anchoredPosition = new Vector2(0, Screen.height);
                            rectTransform.DOAnchorPosY(0, _animationInDuration);
                            break;
                        case DirectionIn.Down:
                            rectTransform.anchoredPosition = new Vector2(0, -Screen.height);
                            rectTransform.DOAnchorPosY(0, _animationInDuration);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    break;
                case AnimationInType.ScaleIn:
                    transform.localScale = Vector3.zero;
                    transform.DOScale(Vector3.one, _animationInDuration);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            switch (_animationOutType)
            {
                case AnimationOutType.None:
                    break;
                case AnimationOutType.FadeOut:
                    _canvasGroup.DOFade(0, _animationOutDuration);
                    break;
                case AnimationOutType.SlideOut:
                    rectTransform = GetComponent<RectTransform>();
                    switch (directionOut)
                    {
                        case DirectionOut.Left:
                            rectTransform.DOAnchorPosX(-Screen.width, _animationOutDuration);
                            break;
                        case DirectionOut.Right:
                            rectTransform.DOAnchorPosX(Screen.width, _animationOutDuration);
                            break;
                        case DirectionOut.Up:
                            rectTransform.DOAnchorPosY(Screen.height, _animationOutDuration);
                            break;
                        case DirectionOut.Down:
                            rectTransform.DOAnchorPosY(-Screen.height, _animationOutDuration);
                            break;
                    }
                    break;
                case AnimationOutType.ScaleOut:
                    transform.DOScale(Vector3.zero, _animationOutDuration);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
                
            }

            if (gameObject.activeSelf)
            {
                StartCoroutine(WaitingForAnimation());
            }
        }
        
        private IEnumerator WaitingForAnimation()
        {
            yield return new WaitForSeconds(_animationOutDuration);
            gameObject.SetActive(false);
        }
    }
}