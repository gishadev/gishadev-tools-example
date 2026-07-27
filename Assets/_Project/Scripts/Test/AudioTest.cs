using gishadev.tools.Audio;
using UnityEngine;
using VContainer;

namespace gishadev.tools.Test
{
    public class AudioTest : MonoBehaviour
    {
        [Inject] private IAudioManager _audioManager;
        
        private void Start()
        {
            _audioManager.PlayMusic(MusicAudioEnum.MUSIC_1);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                _audioManager.PlayMusic(MusicAudioEnum.MUSIC_2);
            }

            if (Input.GetMouseButtonDown(0))
                _audioManager.PlaySFX(SFXAudioEnum.CLICK);
        }
    }
}