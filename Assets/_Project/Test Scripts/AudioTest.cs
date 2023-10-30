using gishadev.tools.Audio;
using UnityEngine;

namespace gishadev.tools.Test
{
    public class AudioTest : MonoBehaviour
    {
        private void Start()
        {
            AudioManager.I.PlayAudio(MusicAudioEnum.MUSIC_1);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.N))
                AudioManager.I.PlayAudio(MusicAudioEnum.MUSIC_2);

            if (Input.GetMouseButtonDown(0))
                AudioManager.I.PlayAudio(SFXAudioEnum.CLICK);
        }
    }
}