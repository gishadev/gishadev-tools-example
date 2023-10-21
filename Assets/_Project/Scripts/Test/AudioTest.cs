using gishadev.tools.Audio;
using UnityEngine;

namespace gishadev.tools.Test
{
    public class AudioTest : MonoBehaviour
    {
        private void Awake()
        {
            AudioManager.I.PlayAudio(MusicAudioEnum.COOL_MUSIC);
            AudioManager.I.PlayAudio(SFXAudioEnum.SHOOT);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.N))
                AudioManager.I.PlayAudio(MusicAudioEnum.COOL_MUSIC2);

            if (Input.GetMouseButtonDown(0))
                AudioManager.I.PlayAudio(SFXAudioEnum.BEEP);
        }
    }
}