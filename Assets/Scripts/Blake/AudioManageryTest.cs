using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Rendering.PostProcessing;
using Random = UnityEngine.Random;

public class AudioManageryTest : MonoBehaviour
{
    // Here we are creating an array of Sound objects for each type of sound we want to play.
    public Sound[] musicSounds, sirenSound, ambienceSounds, TireScreechSounds, sfxSounds, loseSounds;
    // Here we are creating an AudioSource object for each type of sound we want to play.
    public AudioSource musicSource, sirenSource, ambienceSource, TireScreechSource, sfxSource, loseSource;
    
        // This is a singleton pattern.
        // It is used to ensure that only one instance of the AudioManageryTest object is created.
        public static AudioManageryTest instance;

       
       
        // On Awake, we check if an instance of the AudioManageryTest object exists.
        void Awake()
        {
            // If it does not, we set the instance to this object and call DontDestroyOnLoad so the object persists between scenes.
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            // If an instance already exists, we destroy this object.
            else
            {
                Destroy(gameObject);
            }
        }
        
        // Here we are creating a method to play music.
        // When the method is called, it takes a string parameter called name.
        public void PlayMusic(string name)
        {
            // Here the Array.Find method is used to find the Sound object with the name that matches the name parameter.
            Sound s = Array.Find(musicSounds, x => x.name == name);
            
            // If the Sound object is not found, a warning is logged.
            if (s == null)
            {
                Debug.LogWarning("Sound: " + name + " not found!");
                return;
            }
            // If the Sound object is found,
            // the musicSource clip is set to the clip of the Sound object and the music is played.
            else
            {
                musicSource.clip = s.clip;
                musicSource.Play();
            }
        }
        
        // The subsequent methods are similar to the PlayMusic method.
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
            Sound s = Array.Find<Sound>(TireScreechSounds, x => x.name == name);
            if (s == null)
            {
                Debug.LogWarning("Sound: " + name + " not found!");
            }
            else
            {
                TireScreechSource.clip = s.clip;
                TireScreechSource.Play();
            }
        }
    
        
        // The PlaySFX method is slightly different.
        // It uses the PlayOneShot method to play the sound.
        // This is because the sound is a one-shot sound effect.
        // The sound is played once and then stops.
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
        
        // The MuteSFX method is used to mute the sound effects.
        public void MuteSFX()
        {
            // If the sound effects are not muted, they are muted.
            if (sfxSource.mute == false)
            {
                sfxSource.mute = true;
            }
            // If the sound effects are muted, they are unmuted.
            else
            {
                sfxSource.mute = false;
            }
        }
        
        // The StopMusic method is used to stop the music.
        public void StopMusic(string name)
        {
            // The Array.Find method is used to find the Sound object with the name that matches the name parameter.
            Sound s = Array.Find(musicSounds, x => x.name == name);
            // If the music is playing, it is stopped.
            if (musicSource.isPlaying)
            {
                musicSource.Stop();
            }
            
        }
        
        /// The methods UnmuteSiren and MuteSiren are used to mute and unmute the siren sound.
        /// As the siren SFX should only play when the player is in a certain state
        /// it is important to be able to mute and unmute the siren sound throughout the game.
        public void UnmuteSiren(string name)
        {
            // The Array.Find method is used to find the Sound object with the name that matches the name parameter.
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
        // StopSiren is used to stop the siren sound.
        // Preventing it from being played when it is not needed.
        public void StopSiren(string name)
        {
            Sound s = Array.Find(sirenSound, x => x.name == name);
            if (sirenSource.isPlaying)
            {
                sirenSource.Stop();
            }
        }
}
