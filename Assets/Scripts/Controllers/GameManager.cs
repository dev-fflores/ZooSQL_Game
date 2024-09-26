using System;
using Extras;
using UnityEngine;

namespace Controllers
{
    public class GameManager : Singleton<GameManager>
    {
        [Header("Answer Sprites")]
        public Sprite correctAnswerSprite;
        public Sprite incorrectAnswerSprite;
        
        public bool[] questionsAnswered;

        private void Start()
        {
            questionsAnswered = new bool[10];
        }
    }
}
