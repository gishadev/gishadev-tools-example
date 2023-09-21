using UnityEngine;

namespace gishadev.tools.Test
{
    public class AudioTest : MonoBehaviour
    {
        private void Awake()
        {
            AudioManager.I.PlayAudio(0, AudioType.Music);
            AudioManager.I.PlayAudio(0, AudioType.SFX);
            AudioManager.I.PlayAudio(1, AudioType.SFX);
        }
    }
}