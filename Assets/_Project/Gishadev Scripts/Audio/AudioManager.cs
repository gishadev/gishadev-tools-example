using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace gishadev.tools.Audio
{
    public class AudioManager : IAudioManager, IInitializable, IDisposable
    {
        [Inject] private AudioMasterSO _audioMasterData;

        public delegate void DelayedDelegate();

        public event Action<AudioData> AudioStarted;

        private GameObject _audioParent;

        private float _musicVolumePercentage = 1f;
        private float _sfxVolumePercentage = 1f;

        private CancellationTokenSource _delayFuncCTS;

        public AudioMasterSO AudioMasterData => _audioMasterData;

        public void Initialize()
        {
            Init();
        }

        public void Dispose()
        {
        }

        public void SetSFXVolume(float volumePercent)
        {
            var sfxData = GetAudioCollection<SFXData>();

            foreach (var sfx in sfxData)
                sfx.AudioSource.volume = volumePercent * sfx.InitialVolume;

            _sfxVolumePercentage = volumePercent;
        }

        public void SetMusicVolume(float volumePercent)
        {
            var musicData = GetAudioCollection<MusicData>();

            foreach (var music in musicData)
                music.AudioSource.volume = volumePercent * music.InitialVolume;

            _musicVolumePercentage = volumePercent;
        }

        public void PlayAudio<T>(int index) where T : AudioData, new()
        {
            var audioCollection = GetAudioCollection<T>();

            if (index < 0 || index > audioCollection.Length - 1)
            {
                Debug.LogError("There is no sfx with index " + index);
                return;
            }

            var data = audioCollection.ToArray()[index];

            data.Play();

            AudioStarted?.Invoke(data);

            Debug.Log($"I'm playing: {data.Name} of type {typeof(T)}");
        }

        public void PlayAudio(MusicAudioEnum enumEntry) => PlayAudio<MusicData>((int)enumEntry);
        public void PlayAudio(SFXAudioEnum enumEntry) => PlayAudio<SFXData>((int)enumEntry);

        #region Initialization

        private void Init()
        {
            _delayFuncCTS = new CancellationTokenSource();
            _audioParent = new GameObject("[Audio Parent]");
            InitCollection(AudioMasterData.SFXCollection);
            InitCollection(AudioMasterData.MusicCollection);
        }

        private void InitCollection<T>(IEnumerable<T> collection) where T : AudioData, new()
        {
            // Init audio player.
            BaseAudioPlayer audioPlayer =
                typeof(T) == typeof(MusicData) ? new MusicPlayer(this) : new SFXPlayer(this);

            foreach (var audio in collection)
            {
                var child = new GameObject(audio.Name);
                child.transform.SetParent(_audioParent.transform);

                var audioSource = child.AddComponent<AudioSource>();
                audio.InitAudioSource(audioSource);
                audio.InitAudioPlayer(audioPlayer);
            }
        }

        #endregion

        public async void FadeIn(AudioData audioData)
        {
            audioData.AudioSource.volume = 0f;
            var volume = audioData.AudioSource.volume;

            while (audioData.AudioSource.volume * _musicVolumePercentage <
                   audioData.InitialVolume * _musicVolumePercentage)
            {
                volume += Time.deltaTime / AudioMasterData.FadeTransitionTime * _musicVolumePercentage;
                audioData.AudioSource.volume = volume;
                await UniTask.Yield();
            }
        }

        public async void FadeOut(AudioData audioData)
        {
            var volume = audioData.AudioSource.volume;

            while (audioData.AudioSource.volume * _musicVolumePercentage > 0)
            {
                volume -= Time.deltaTime / AudioMasterData.FadeTransitionTime * _musicVolumePercentage;
                audioData.AudioSource.volume = volume;
                await UniTask.Yield();
            }

            if (audioData.AudioSource.volume == 0)
            {
                audioData.AudioSource.Stop();
                audioData.AudioSource.volume = audioData.InitialVolume * _musicVolumePercentage;
            }
        }

        public async void DelayFunc(DelayedDelegate delayedDelegate, float delay)
        {
            await UniTask.WaitForSeconds(delay, cancellationToken: _delayFuncCTS.Token);
            if (!_delayFuncCTS.IsCancellationRequested)
                delayedDelegate();
        }

        public void CancelDelayFunc()
        {
            _delayFuncCTS.Cancel();
            _delayFuncCTS = new CancellationTokenSource();
        }

        private T[] GetAudioCollection<T>() where T : AudioData, new()
        {
            return typeof(T) == typeof(MusicData)
                ? AudioMasterData.MusicCollection.Cast<T>().ToArray()
                : AudioMasterData.SFXCollection.Cast<T>().ToArray();
        }
    }
}