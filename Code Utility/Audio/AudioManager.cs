using System.Collections.Generic;
using Dino.Utility.Audio;
using Dino.UtilityTools.Singleton;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using AudioType = Dino.Utility.Audio.AudioType;

namespace Dino.Utility.Audio
{

    /// <summary>
    /// Last update 14/03/2025 Dino
    /// A class that allows you to manage audio.
    /// </summary>
    public class AudioManager : Singleton<AudioManager>
    {
        #region serialized fields

            [Header("Audio Manager Data")] 
            [SerializeField]
            private AudioManagerData _audioManagerData;

            [HideInInspector]
            [Header("Audio Test")]
            public string _soundNameTest;
            #endregion

            #region private fields
            
            private GameObject _soundsContainer;
            private List<AudioSource> _audioSources = new List<AudioSource>();
            
            private List<AudioData> _sfxAudioData = new List<AudioData>();
            private List<AudioData> _musicAudioData = new List<AudioData>();
            
            #endregion

            public AudioManagerData AudioManagerData
            {
                get => _audioManagerData;
                set => _audioManagerData = value;
            }
            
            // public bool IsInitialized { get; private set; }
            // public UnityEvent OnFinishedInitialize { get; } = new UnityEvent();

            #region unity methods
            
            private void Awake()
            {
                Initialize();
            }
        
            
            #endregion

            #region private methods
            
            
            private AudioSource FindAudioSource(AudioClip clip)
            {
                return _audioSources.Find(x => x.clip == clip);
            }
            private void Initialize()
            {
                _soundsContainer = new GameObject("SoundsContainer");
                _audioSources = new List<AudioSource>();
                _soundsContainer.transform.SetParent(transform);
                PrepareLists();
                // IsInitialized = true;
                // OnFinishedInitialize?.Invoke();
            }

        
            private void  PrepareLists()
            {
                _sfxAudioData = _audioManagerData.audioData.FindAll(x => x.audioType == AudioType.SFX);
                _musicAudioData = _audioManagerData.audioData.FindAll(x => x.audioType == AudioType.Music);
            }

            #endregion

            
            #region public methdos
            public void PlaySound(string soundName)
            {
                AudioData audioData = _audioManagerData.audioData.Find(x => x.name == soundName);
                if (audioData == null)
                {
                    Debug.LogWarning("Sound: " + soundName + " not found!");
                    return;
                }
                
                AudioSource audioSource = FindAudioSource(audioData.clip);
                
                if (audioSource == null)
                {
                    GameObject go = new GameObject("AS : " + audioData.name);
                    audioSource =  go.AddComponent<AudioSource>();
                    audioSource.transform.SetParent(_soundsContainer.transform);
                    audioSource.clip = audioData.clip;
                    audioSource.loop = audioData.loop;
                    audioSource.volume = audioData.volume;
                    audioSource.pitch = audioData.pitch;
                    audioSource.Play();
                    _audioSources.Add(audioSource);
                }
                else
                {
                    audioSource.Play();
                }
            }
            
            public void StopSound(string soundName)
            {
                AudioData audioData = _audioManagerData.audioData.Find(x => x.name == soundName);
                if (audioData == null)
                {
                    Debug.LogWarning("Sound: " + soundName + " not found!");
                    return;
                }
                AudioSource audioSource = FindAudioSource(audioData.clip);
                if (audioSource != null)
                {
                    audioSource.Stop();
                }
            }

            #endregion

            
    }
}

namespace Dino.Utility.Audio
{
    public enum AudioType
    {
        Music,
        SFX,
        Ambience
    }
}