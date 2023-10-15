using System;
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

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.N))
                AudioManager.I.PlayAudio<MusicData>(1);
        }
    }
}