using System;
using UnityEngine;

namespace CardGame
{
    public class BoxBankController : MonoBehaviour
    {
        public BoxElement[] boxElements;
        
        private void Awake()
        {
            boxElements = GetComponentsInChildren<BoxElement>();
        }
    }
}