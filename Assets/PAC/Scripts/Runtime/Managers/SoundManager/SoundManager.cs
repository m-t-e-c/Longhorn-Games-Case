using System;
using System.Collections.Generic;
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

        private void Awake()
        {
            _soundEffectSource = gameObject.AddComponent<AudioSource>();
            _musicSource = gameObject.AddComponent<AudioSource>();
            _musicSource.loop = true; 
        }

        public void PlaySound(string id)
        {
            var sound = gameSounds.Find(s => s.id == id);
            if (sound.clip != null)
            {
                _soundEffectSource.PlayOneShot(sound.clip);
            }
        }

        public void PlayMusic(string clipName)
        {
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
