using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Rendering.PostProcessing;
using Random = UnityEngine.Random;

public class AudioManageryTest : MonoBehaviour
{
    public Sound[] musicSounds, sirenSound, ambienceSounds, TireScreechSounds, sfxSounds;
    public AudioSource musicSource, sirenSource, ambienceSource, TireScreechSource, sfxSource;
    
        public static AudioManageryTest instance;

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
        
        public void PlaySiren(string name)
        {
            Sound s = Array.Find(sirenSound, x => x.name == name);
            if (s == null)
            {
                Debug.LogWarning("Sound: " + name + " not found!");
            }
            else
            {
                sirenSource.clip = s.clip;
                sirenSource.Play();
            }
            
        }
        
        public void PlayAmbience(string name)
        {
            Sound s = Array.Find(ambienceSounds, x => x.name == name);
            if (s == null)
            {
                Debug.LogWarning("Sound: " + name + " not found!");
            }
            else
            {
                ambienceSource.clip = s.clip;
                ambienceSource.Play();
            }
            
        }
        public void PlayTireScreech(string name)
        {
            //int rand = Random.Range(0, TireScreechSounds.Length);
            
            //Sound s = Array.FindIndex(rand, x => x.index == index);
            
            
            Sound s = Array.Find<Sound>(TireScreechSounds, x => x.name == name);
            if (s == null)
            {
                Debug.LogWarning("Sound: " + name + " not found!");
            }
            //Sound s = TireScreechSounds[1];
            else
            {
                TireScreechSource.clip = s.clip;
                TireScreechSource.Play();
            }
            

            


        }
        /*{
            Sound s = Array.Find(TireScreechSounds, x => x.name == name);
            if (s == null)
            {
                Debug.LogWarning("Sound: " + name + " not found!");
            }
            else
            {
                TireScreechSource.PlayOneShot(s.clip);
                TireScreechSource.Play();
            }
            
        }*/
        
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
        public void StopMusic(string name)
        {
            Sound s = Array.Find(musicSounds, x => x.name == name);
            if (musicSource.isPlaying == false)
            {
                musicSource.Stop();
            }
            
        }
        
        public void StopAmbience(string name)
        {
            Sound s = Array.Find(ambienceSounds, x => x.name == name);
            if (ambienceSource.isPlaying == false)
            {
                ambienceSource.Stop();
            }
            
        }
        
        
        
        public void UnmuteSiren(string name)
        {
            Sound s = Array.Find(sirenSound, x => x.name == name);
            if (sirenSource.mute)
            {
                sirenSource.mute = false;
            }
            else
            {
                sirenSource.mute = true;
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
