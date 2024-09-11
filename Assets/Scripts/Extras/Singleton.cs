﻿using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Extras
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();
                    if (_instance == null)
                    {
                        GameObject obj = new GameObject();
                        obj.name = typeof(T).Name;
                        _instance = obj.AddComponent<T>();
                        DontDestroyOnLoad(_instance);
                    }
                }

                return _instance;
            }
        }
    }
}