using UnityEngine;

namespace gishadev.tools.Audio
{
    public class MusicPlayer : AudioPlayer<MusicData>
    {
        private readonly AudioManager _audioManager;

        public MusicPlayer(AudioManager audioManager)
        {
            _audioManager = audioManager;
        }

        public override void Play(MusicData data)
        {
            // Randomize clip.
            if (data.AudioClips.Length > 1)
                data.AudioSource.clip = data.AudioClips[Random.Range(0, data.AudioClips.Length)];

            if (data.IsFade)
                _audioManager.FadeIn(data);
            data.AudioSource.Play();
        }

        public override void Pause(MusicData data)
        {
            data.AudioSource.Pause();
        }

        public override void Stop(MusicData data)
        {
            data.AudioSource.Stop();
        }
    }
}