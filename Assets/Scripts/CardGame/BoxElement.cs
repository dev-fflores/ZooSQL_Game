using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CardGame
{
    // [RequireComponent(typeof(ContentSizeFitter))]
    [RequireComponent(typeof(RectTransform))]
    public class BoxElement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private Image _image;
        public Transform parentToReturnTo = null;
        public int index;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log($"On Begin Drag");
            parentToReturnTo = transform.parent;
            transform.SetParent(transform.root);
            transform.SetAsLastSibling();
            _image.raycastTarget = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            Debug.Log($"On Drag");
            transform.position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Debug.Log($"On End Drag");
            transform.SetParent(parentToReturnTo);
            transform.SetSiblingIndex(index);
            _image.raycastTarget = true;
        }
    }
}
