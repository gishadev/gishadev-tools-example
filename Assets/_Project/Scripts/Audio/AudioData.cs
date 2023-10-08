using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace gishadev.tools.Audio
{
    [Serializable]
    public abstract class AudioData
    {
        [field: Header("General")]
        [field: SerializeField]
        public string Name { get; private set; }

        [field: SerializeField, Tooltip("Variations of Audio")]
        public AudioClip[] AudioClips { get; private set; }

        [field: SerializeField, Range(0f, 1f)] public float Volume { get; private set; }

        [field: SerializeField, Range(0.3f, 3f)]
        public float Pitch { get; private set; }

        protected AudioSource AudioSource { get; private set; }

        public virtual void InitAudioSource(AudioSource audioSource)
        {
            AudioSource = audioSource;

            AudioSource.clip = AudioClips[0];
            AudioSource.volume = Volume;
            AudioSource.pitch = Pitch;
        }

        public void Play()
        {
            // Randomize clip.
            if (AudioClips.Length > 1)
                AudioSource.clip = AudioClips[Random.Range(0, AudioClips.Length)];

            AudioSource.Play();
        }

        public void Pause() => AudioSource.Pause();
        public void Stop() => AudioSource.Stop();
    }

    [Serializable]
    public class MusicData : AudioData
    {
        [field: Header("Music")]
        [field: SerializeField]
        public bool IsLooping { get; private set; }

        [field: SerializeField] public bool IsFade { get; private set; }

        public override void InitAudioSource(AudioSource audioSource)
        {
            base.InitAudioSource(audioSource);
            AudioSource.loop = IsLooping;
        }
    }

    [Serializable]
    public class SFXData : AudioData
    {
    }
}