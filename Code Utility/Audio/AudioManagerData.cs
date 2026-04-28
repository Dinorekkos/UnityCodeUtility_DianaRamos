using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Dino.Utility.Audio
{ 
    [CreateAssetMenu(fileName = "AudioManagerData", menuName = "DINO/Audio/AudioManagerData", order = 0)]
    public class AudioManagerData : ScriptableObject
    {
        [SerializeField] private AudioMixerGroup _sfxAudioMixerGroup;
        [SerializeField] private string _sfxVolumeParameterName = "SFXVolume";
        [SerializeField] private AudioMixerGroup _musicAudioMixerGroup;
        [SerializeField] private string _musicVolumeParameterName = "MusicVolume";
        [SerializeField] private AudioMixerGroup _ambienceAudioMixerGroup;
        [SerializeField] private string _ambienceVolumeParameterName = "AmbienceVolume";
        
        
        public AudioMixerGroup SfxAudioMixerGroup
        {
            get => _sfxAudioMixerGroup;
        }

        public AudioMixerGroup MusicAudioMixerGroup
        {
            get => _musicAudioMixerGroup;
        }
        
        public AudioMixerGroup AmbienceAudioMixerGroup
        {
            get => _ambienceAudioMixerGroup;
        }
        
        
        public string SfxVolumeParameterName
        {
            get => _sfxVolumeParameterName;
        }
        
        public string MusicVolumeParameterName
        {
            get => _musicVolumeParameterName;
        }
        
        public string AmbienceVolumeParameterName
        {
            get => _ambienceVolumeParameterName;
        }
        
        public List<AudioData> audioData = new List<AudioData>();
        
        public AudioData GetAudioData(string name)
        {
            return audioData.Find(x => x.name == name);
        }
        
        
    }
    
    
    [Serializable]
    public class AudioData
    {
        public string name;
        public AudioClip clip;
        public bool loop = false;
        public float volume = 1f;
        public float pitch = 1f;
        public AudioType audioType;
    }
}