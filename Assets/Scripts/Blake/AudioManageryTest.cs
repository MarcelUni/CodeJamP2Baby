using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Rendering.PostProcessing;
using Random = UnityEngine.Random;

public class AudioManageryTest : MonoBehaviour
{
    public Sound[] musicSounds, sirenSound, ambienceSounds, TireScreechSounds, sfxSounds, loseSounds;
    public AudioSource musicSource, sirenSource, ambienceSource, TireScreechSource, sfxSource, loseSource;
    
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
                return;
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
        public void PlayLoseSound(string name)
        {
            Sound s = Array.Find(loseSounds, x => x.name == name);
            if (s == null)
            {
                Debug.LogWarning("Sound: " + name + " not found!");
            }
            else
            {
                loseSource.clip = s.clip;
                loseSource.Play();
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
        
        public void MuteSFX()
        {
            if (sfxSource.mute == false)
            {
                sfxSource.mute = true;
            }
            else
            {
                sfxSource.mute = false;
            }
        }
        
        
        public void StopMusic(string name)
        {
            Sound s = Array.Find(musicSounds, x => x.name == name);
            if (musicSource.isPlaying)
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
            
        }
        public void MuteSiren(string name)
        {
            Sound s = Array.Find(sirenSound, x => x.name == name);
            if (!sirenSource.mute)
            {
                sirenSource.mute = true;
            }
            
        }
        
        public void StopSiren(string name)
        {
            Sound s = Array.Find(sirenSound, x => x.name == name);
            if (sirenSource.isPlaying)
            {
                sirenSource.Stop();
            }
            
        }

        /*
        public void ToggleMusic(string name)
        {
            musicSource.mute = !musicSource.mute;
        }
        public void ToggleSFX(string name)
        {
            sfxSource.mute = !sfxSource.mute;
        }
        */
}
