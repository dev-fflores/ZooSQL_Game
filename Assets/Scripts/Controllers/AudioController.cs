using System;
using System.Linq;
using Extras;
using UnityEngine;
using UnityEngine.Serialization;

namespace Controllers
{
    [System.Serializable]
    public struct AudioClipInfo
    {
        public string name;
        public AudioClip clip;
    }
    public class AudioController : Singleton<AudioController>
    {
        public AudioSource musicAudioSource;
        public AudioSource sfxAudioSource;
        
        public AudioClipInfo[] musicAudioClipInfoArray;
        public AudioClipInfo[] sfxAudioClipInfoArray;
        

        private void Start()
        {
            musicAudioSource.playOnAwake = false;
            sfxAudioSource.playOnAwake = false;
        }
        
        public void PlayMusic(string clipName)
        {
            musicAudioSource.clip = GetAudioClipByName(clipName, musicAudioClipInfoArray);
            musicAudioSource.Play();
        }
        
        public void PlaySFX(string clipName)
        {
            sfxAudioSource.PlayOneShot(GetAudioClipByName(clipName, sfxAudioClipInfoArray));
        }
        
        public void StopMusic()
        {
            musicAudioSource.Stop();
        }
        
        public void StopSFX()
        {
            sfxAudioSource.Stop();
        }

        private AudioClip GetAudioClipByName(string clipName, AudioClipInfo[] audioClipInfoArray)
        {
            return (from clipInfo in audioClipInfoArray where clipInfo.name == clipName select clipInfo.clip).FirstOrDefault();
        }
    }
}