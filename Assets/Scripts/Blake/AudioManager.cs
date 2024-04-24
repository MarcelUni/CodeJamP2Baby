using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Rendering.PostProcessing;

public class AudioManager : MonoBehaviour
{
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;
    
        public static AudioManager instance;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            
        }

    
        public void PlayMusic(string name)
        {
            Sound s = Array.Find(musicSounds, x => x.name == name);
            if (s == null)
            {
                Debug.LogWarning("Sound: " + name + " not found!");
            }
            else
            {
                musicSource.clip = s.clip;
                musicSource.Play();
            }
            
        }
        public void PlaySFX(string name)
        {
            Sound s = Array.Find(sfxSounds, x => x.name == name);
            if (s == null)
            {
                Debug.LogWarning("Sound: " + name + " not found!");
            }
            else
            {
                sfxSource.PlayOneShot(s.clip);
                sfxSource.Play();
            }
            
        }
        public void MuteMusic(string name)
        {
            Sound s = Array.Find(musicSounds, x => x.name == name);
            if (musicSource.mute == false)
            {
                musicSource.mute = true;
            }
            else
            {
                musicSource.mute = false;
            }
        }

        public void ToggleMusic(string name)
        {
            musicSource.mute = !musicSource.mute;
        }
        public void ToggleSFX(string name)
        {
            sfxSource.mute = !sfxSource.mute;
        }
}
