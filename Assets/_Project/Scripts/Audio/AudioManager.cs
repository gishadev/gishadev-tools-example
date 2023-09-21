using gishadev.tools.Audio;
using UnityEngine;

namespace gishadev.tools
{
    public enum AudioType
    {
        SFX,
        Music
    }

    public class AudioManager : MonoBehaviour
    {
        public const string AUDIO_MASTER_ASSET = "AudioMasterSO";
        
        public static AudioManager I
        {
            get
            {
                if (_current)
                    return _current;

                _current = new GameObject("AudioManager").AddComponent<AudioManager>();
                DontDestroyOnLoad(_current.gameObject);
                _audioSO = Resources.Load<AudioMasterSO>(AUDIO_MASTER_ASSET);
                return _current;
            }
        }

        private static AudioManager _current;
        private static AudioMasterSO _audioSO;

        public void PlayAudio(int index, AudioType type)
        {
            AudioData[] audioCollection = type == AudioType.Music ? _audioSO.MusicCollection : _audioSO.SFXCollection;
            Debug.Log($"I'm playing: {audioCollection[index].Name} of type {type}");
        }
    }
}