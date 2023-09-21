using System;
using UnityEngine;

namespace gishadev.tools.Audio
{
    [Serializable]
    public abstract class AudioData
    {
        [field: Header("General")]
        [field: SerializeField] public string Name {get; private set;}
        [field: SerializeField] public AudioClip[] AudioClips {get; private set;}

        [field: SerializeField, Range(0f, 1f)] public float Volume {get; private set;}
        [field: SerializeField, Range(0.3f, 3f)] public float Pitch  {get; private set;}
    }
    
    [Serializable]
    public class MusicData : AudioData
    {
        [field: Header("Music")]
        [field: SerializeField] public bool IsLooping {get; private set;}
        [field: SerializeField] public bool IsFade {get; private set;}
    }
    
    [Serializable]
    public class SFXData : AudioData
    {
    }
}