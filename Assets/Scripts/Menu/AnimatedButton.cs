using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Menu
{
    public enum AnimationButtonType
    {
        None,
        Scale,
        Slide,
        Move
    }
    public class AnimatedButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Button _button;
        [SerializeField] private Vector3 _originalScale;
        [SerializeField] private RectTransform _rectTransform;
        private Vector3 _originalPosition;
        
        [SerializeField] private float _hoverScale = 1.15f;
        [SerializeField] private float _animationDuration = 0.2f;
        
        [SerializeField] private AnimationButtonType _animationButtonType;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _rectTransform = GetComponent<RectTransform>();
            _originalPosition = _rectTransform.anchoredPosition;
            _originalScale = _button.transform.localScale;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            switch (_animationButtonType)
            {
                case AnimationButtonType.None:
                    break;
                case AnimationButtonType.Scale:
                    _button.transform.DOScale(_originalScale * _hoverScale, _animationDuration);
                    break;
                case AnimationButtonType.Slide:
                    _rectTransform.DOAnchorPosX(_rectTransform.anchoredPosition.x + 10, _animationDuration);
                    break;
                case AnimationButtonType.Move:
                    break;
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            switch (_animationButtonType)
            {
                case AnimationButtonType.None:
                    break;
                case AnimationButtonType.Scale:
                    _button.transform.DOScale(_originalScale, _animationDuration);
                    break;
                case AnimationButtonType.Slide:
                    _rectTransform.DOAnchorPosX(_originalPosition.x, _animationDuration);
                    break;
                case AnimationButtonType.Move:
                    break;
            }
        }
    }
}