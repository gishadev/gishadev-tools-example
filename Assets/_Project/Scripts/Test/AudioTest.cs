using gishadev.tools.Audio;
using UnityEngine;

namespace gishadev.tools.Test
{
    public class AudioTest : MonoBehaviour
    {
        private void Awake()
        {
            AudioManager.I.PlayAudio(MusicAudio.COOL_MUSIC);
            AudioManager.I.PlayAudio(SFXAudio.SHOOT);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.N))
                AudioManager.I.PlayAudio(MusicAudio.COOL_MUSIC2);

            if (Input.GetMouseButtonDown(0))
                AudioManager.I.PlayAudio(SFXAudio.BEEP);
        }
    }
}