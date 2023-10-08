using gishadev.tools.Audio;
using UnityEngine;

namespace gishadev.tools.Test
{
    public class AudioTest : MonoBehaviour
    {
        private void Awake()
        {
            AudioManager.I.PlayAudio<MusicData>(0);
            AudioManager.I.PlayAudio<SFXData>("shoot");
        }
    }
}