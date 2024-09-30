using System;
using System.Collections;
using System.Collections.Generic;
using Quiz;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public class QuizController : MonoBehaviour
    {
        [Header("Question Banks")]
        [SerializeField] private List<QuestionBankSO> _algebraQuestions;
        public Dictionary<int, QuestionBankSO> _algebraQuestionsDictionary;
        
        [Header("Questions Components")]
        public QuestionSO[] questionsToShow;
        [SerializeField] private int _currentQuestionIndex;
        private int _currentQuestionBankIndex;
        
        [Header("UI Elements")]
        public Image questionImage;
        public TextMeshProUGUI questionTMP;
        public TextMeshProUGUI[] answerTMPs;
        
        public Button[] answerButtons;
        
        public PointBarController pointBarController;

        private void Awake()
        {
            _currentQuestionIndex = 0;
            _currentQuestionBankIndex = 0;
            pointBarController = FindObjectOfType<PointBarController>();
            GetComponentsFromUI();
        }

        private void Start()
        {
            questionsToShow = GetQuestionFromBank(_algebraQuestions[_currentQuestionBankIndex]);

            LoadQuestionInUI(questionsToShow[_currentQuestionIndex]);
        }
        
        private void GetComponentsFromUI()
        {
            questionImage = GameObject.FindGameObjectWithTag("QuestionImage").GetComponent<Image>();
            questionTMP = GameObject.FindGameObjectWithTag("Question").GetComponent<TextMeshProUGUI>();
            answerButtons = Array.ConvertAll(GameObject.FindGameObjectsWithTag("AnswerButton"), item => item.GetComponent<Button>());
            // Invert answerButtons array
            Array.Reverse(answerButtons);
            answerTMPs = new TextMeshProUGUI[answerButtons.Length];
            for (int i = 0; i < answerButtons.Length; i++)
            {
                answerTMPs[i] = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            }
        }
        
        public void LoadQuestionInUI(QuestionSO question)
        {
            questionTMP.text = question.questionText;
            questionImage.sprite = question.questionImage;
            for (int i = 0; i < question.answers.Length; i++)
            {
                answerTMPs[i].text = question.answers[i].answerText;
            }
        }
        
        public QuestionSO[] GetQuestionFromBank(QuestionBankSO questionBank)
        {
            return questionBank.questions;
        }

        private void OnAnswerButtonClicked(Button button)
        {
            var answer = button.GetComponentInChildren<TextMeshProUGUI>().text;
            var isCorrect = Array.Find(questionsToShow[_currentQuestionIndex].answers, a => a.answerText == answer).isCorrect;

            Debug.Log(isCorrect ? "Correct" : "Incorrect");

            _currentQuestionIndex++;
            pointBarController.AddPoint(isCorrect);
            Debug.Log($"_currentQuestionIndex: {_currentQuestionIndex}");
            if (_currentQuestionIndex >= questionsToShow.Length)
            {
                _currentQuestionBankIndex++;
                questionsToShow = GetQuestionFromBank(_algebraQuestions[_currentQuestionBankIndex]);
                _currentQuestionIndex = 0;
                StartCoroutine(LoadNextBankQuestion());
                return;
            }
            LoadQuestionInUI(questionsToShow[_currentQuestionIndex]);
        }
            else
        
        private IEnumerator LoadNextBankQuestion()
        {
            yield return new WaitForSeconds(pointBarController.pointScaleDuration);
            pointBarController.ResetPointsBar();
            LoadQuestionInUI(questionsToShow[_currentQuestionIndex]);
        }

        #region Listeners
        private void OnEnable()
        {
            foreach (var button in answerButtons)
            {
                button.onClick.AddListener(() => OnAnswerButtonClicked(button));
            }
        }
        
        private void OnDisable()
        {
            foreach (var button in answerButtons)
            {
                button.onClick.RemoveAllListeners();
            }
        }
        #endregion

    }
}
