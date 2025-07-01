using System;

namespace gishadev.tools.Audio
{
    public interface IAudioManager
    {
        event Action<AudioData> AudioStarted;
        void SetSFXVolume(float volumePercent);
        void SetMusicVolume(float volumePercent);
        void PlayAudio<T>(int index) where T : AudioData, new();
        void PlayAudio(MusicAudioEnum enumEntry);
        void PlayAudio(SFXAudioEnum enumEntry);
    }
}