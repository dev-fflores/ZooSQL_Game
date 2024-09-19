using System;
using System.Collections.Generic;
using Quiz;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public class QuizController : MonoBehaviour
    {
        public List<QuestionSO> questionsToShow;
        private int _currentQuestionIndex;
        
        [Header("UI Elements")]
        public Image questionImage;
        public TextMeshProUGUI questionTMP;
        public List<Button> answerButtons;

        private void Awake()
        {
            _currentQuestionIndex = 0;
            questionTMP = GameObject.FindGameObjectWithTag("Question").GetComponent<TextMeshProUGUI>();
        }
    }
}