using System;
using System.Collections.Generic;
using PAC.Scripts.Runtime.ScriptableObjects;
using PAC.Scripts.Runtime.ServiceLocator;
using UnityEngine;

namespace PAC.Scripts.Runtime.Managers.SoundManager
{

    [Serializable]
    public struct GameSound
    {
        public string id;
        public AudioClip clip;
    }

    public class SoundManager : MonoBehaviour, ISoundManager
    {
        private AudioSource _soundEffectSource;
        private AudioSource _musicSource;
        
        [SerializeField] private List<GameSound> gameSounds = new();
        
        private GameConfig _gameConfig;

        private void Awake()
        {
            _soundEffectSource = gameObject.AddComponent<AudioSource>();
            _musicSource = gameObject.AddComponent<AudioSource>();
            _musicSource.loop = true; 
        }

        private void Start()
        {
            _gameConfig = Locator.Instance.Get<GameConfig>();
        }

        public void PlaySound(string id)
        {
            if (!_gameConfig.IsSoundActive)
                return;
            
            var sound = gameSounds.Find(s => s.id == id);
            if (sound.clip != null)
            {
                _soundEffectSource.PlayOneShot(sound.clip);
            }
        }

        public void PlayMusic(string clipName)
        {
            if (!_gameConfig.IsMusicActive)
                return;
            
            var sound = gameSounds.Find(s => s.id == clipName);
            if (sound.clip != null)
            {
                _musicSource.clip = sound.clip;
                _musicSource.Play();
            }
        }

        public void StopMusic()
        {
            _musicSource.Stop();
        }

        public void StopSound()
        {
            _soundEffectSource.Stop();
        }
    }
}
