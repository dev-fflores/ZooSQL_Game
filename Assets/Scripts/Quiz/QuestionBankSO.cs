using Data;
using UnityEngine;

namespace Quiz
{
    [CreateAssetMenu(fileName = "QuestionBank", menuName = "Quiz/QuestionBank")]
    public class QuestionBankSO : ScriptableObject
    {
        public QuestionSO[] questions;
        public QuestionTopic questionTopic;
        public QuestionDifficulty questionDifficulty;
    }
}