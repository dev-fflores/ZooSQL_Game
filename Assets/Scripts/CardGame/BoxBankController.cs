using System;
using UnityEngine;

namespace CardGame
{
    public class BoxBankController : MonoBehaviour
    {
        public BoxElement[] boxElements;
        public GameObject prefabBoxElement;
        
        private void Awake()
        {
            boxElements = GetChildElements();
            UpdateIndexesOfElements();
        }
        
        private BoxElement[] GetChildElements()
        {
            return GetComponentsInChildren<BoxElement>();
        }
        
        private void UpdateIndexesOfElements()
        {
            for (int i = 0; i < boxElements.Length; i++)
            {
                boxElements[i].index = i;
            }
        }
    }
}