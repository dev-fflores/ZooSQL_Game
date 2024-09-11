using UnityEngine;

namespace Data
{
    [System.Serializable]
    public enum GameType
    {
        None,
        CardsGame,
        QuizGame
    }
    [System.Serializable]
    public enum GameDifficulty
    {
        None,
        Easy,
        Medium,
        Hard
    }
    
    [System.Serializable]
    public enum GameTopic
    {
        None,
        PlSql,
        Algebra
    }
    
    [System.Serializable]
    public class ConfigData 
    {
        public int currentLevel;
        public string currentGameType;
        public string currentTopic;
        public int currentDifficulty;
        public bool isMusicOn;
        public bool isSoundOn;
    }
}