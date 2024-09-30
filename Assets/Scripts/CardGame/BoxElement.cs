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
        private BoxBankController _boxBankController;
        public GameObject prefabBoxElement;
        private Image _image;
        private TextMeshProUGUI _textBoxElement;
        public Transform parentToReturnTo = null;
        public int index;

        private void Awake()
        {
            _image = GetComponent<Image>();
            _textBoxElement = GetComponentInChildren<TextMeshProUGUI>();
            _boxBankController = transform.parent.GetComponent<BoxBankController>();
        }

        private void Start()
        {
            prefabBoxElement = _boxBankController.prefabBoxElement;
            _textBoxElement.raycastTarget = false;
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
            Debug.Log($" eventData.gameObject.name: {eventData.pointerEnter.transform.parent.gameObject.name}");
            transform.SetParent(parentToReturnTo);
            
            transform.SetSiblingIndex(index);
            _image.raycastTarget = true;
        }
    }
}
