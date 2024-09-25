using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace SpinWheel
{
    public class AnswerPoint : MonoBehaviour
    {
        public bool isCorrect;
        public SpriteRenderer iconSpr;

        private void Awake()
        {
            iconSpr = GetComponent<SpriteRenderer>();
        }
    }
}
