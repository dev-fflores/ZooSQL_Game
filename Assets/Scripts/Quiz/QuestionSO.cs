using Data;
using UnityEngine;

namespace Quiz
{
    [System.Serializable]
    public struct Answer
    {
        [TextArea(3, 10)]
        public string answerText;
        public bool isCorrect;
    }
    [CreateAssetMenu(fileName = "Question", menuName = "Quiz/Question")]
    public class QuestionSO : ScriptableObject
    {
        public Sprite questionImage;
        [TextArea(3, 10)]
        public string questionText;
        public Answer[] answers;
        public QuestionTopic questionTopic;
        public QuestionDifficulty questionDifficulty;
        public QuestionType questionType;
    }
}
