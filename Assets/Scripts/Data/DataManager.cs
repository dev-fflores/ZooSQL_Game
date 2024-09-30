using System;
using Extras;
using UnityEngine;

namespace Data
{
    public class DataManager : Singleton<DataManager>
    {
        private IConfigDataStore _configDataStore;

        private void Awake()
        {
            _configDataStore = new PlayerPrefsStoreAdapter();
        }
        
        public void SaveConfigData(ConfigData configData)
        {
            _configDataStore.SaveConfigData(configData);
        }
        
        public ConfigData LoadConfigData()
        {
            return _configDataStore.LoadConfigData();
        }
        
    }
}