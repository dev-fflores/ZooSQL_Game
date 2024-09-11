using UnityEngine;

namespace Data
{
    public class PlayerPrefsStoreAdapter : IConfigDataStore
    {
        public void SaveConfigData(ConfigData configData)
        {
            PlayerPrefs.SetInt("currentLevel", configData.currentLevel);
            PlayerPrefs.SetString("currentTopic", configData.currentTopic);
            PlayerPrefs.SetString("currentGameType", configData.currentGameType);
            PlayerPrefs.SetInt("currentDifficulty", configData.currentDifficulty);
            PlayerPrefs.SetInt("isMusicOn", configData.isMusicOn ? 1 : 0);
            PlayerPrefs.SetInt("isSoundOn", configData.isSoundOn ? 1 : 0);
        }

        public ConfigData LoadConfigData()
        {
            ConfigData configData = new ConfigData();
            configData.currentLevel = PlayerPrefs.GetInt("currentLevel", 0);
            configData.currentGameType = PlayerPrefs.GetString("currentGameType", "");
            configData.currentTopic = PlayerPrefs.GetString("currentTopic", "");
            configData.currentDifficulty = PlayerPrefs.GetInt("currentDifficulty", 0);
            configData.isMusicOn = PlayerPrefs.GetInt("isMusicOn", 1) == 1;
            configData.isSoundOn = PlayerPrefs.GetInt("isSoundOn", 1) == 1;
            return configData;
        }
    }
}