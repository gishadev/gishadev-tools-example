using gishadev.tools.Audio;
using UnityEngine;
using Zenject;

namespace gishadev.tools.Test
{
    public class AudioTest : MonoBehaviour
    {
        [Inject] private IAudioManager _audioManager;
        
        private void Start()
        {
            _audioManager.PlayAudio(MusicAudioEnum.MUSIC_1);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.N))
                _audioManager.PlayAudio(MusicAudioEnum.MUSIC_2);

            if (Input.GetMouseButtonDown(0))
                _audioManager.PlayAudio(SFXAudioEnum.CLICK);
        }
    }
}