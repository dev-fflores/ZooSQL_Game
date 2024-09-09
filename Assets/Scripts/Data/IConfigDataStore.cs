using UnityEngine;

namespace Data
{
    public interface IConfigDataStore
    {
        void SaveConfigData(ConfigData configData);
        ConfigData LoadConfigData();
    }
}