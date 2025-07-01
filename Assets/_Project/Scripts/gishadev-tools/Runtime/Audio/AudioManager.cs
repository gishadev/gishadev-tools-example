using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;
using Object = UnityEngine.Object;

namespace gishadev.tools.Audio
{
    public class AudioManager : IAudioManager, IInitializable, IDisposable
    {
        [Inject] private AudioMasterSO _audioMasterData;

        public delegate void DelayedDelegate();

        public event Action<AudioData> AudioStarted;

        private static GameObject _audioParent;

        private float _musicVolumePercentage = 1f;
        private float _sfxVolumePercentage = 1f;

        private CancellationTokenSource _delayFuncCts;
        private CancellationTokenSource _cts;

        public AudioMasterSO AudioMasterData => _audioMasterData;

        public void Initialize()
        {
            if (_audioParent != null)
                return;
            Init();
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        public void Dispose()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            _cts?.Cancel();
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
            _audioParent = new GameObject("[Audio Parent]");
            
            _delayFuncCts = new CancellationTokenSource();
            _cts = new CancellationTokenSource();
            _cts.RegisterRaiseCancelOnDestroy(_audioParent);
            
            Object.DontDestroyOnLoad(_audioParent);

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

        // TODO: bugs with fades
        public async UniTask FadeIn(AudioData audioData, CancellationTokenSource fadeCTS)
        {
            audioData.AudioSource.volume = 0f;
            var volume = audioData.AudioSource.volume;
            var linkedCTS = CancellationTokenSource.CreateLinkedTokenSource(_cts.Token, fadeCTS.Token);

            while (!linkedCTS.IsCancellationRequested && audioData.AudioSource.volume * _musicVolumePercentage <
                   audioData.InitialVolume * _musicVolumePercentage)
            {
                volume += Time.deltaTime / AudioMasterData.FadeTransitionTime * _musicVolumePercentage;
                audioData.AudioSource.volume = volume;
                await UniTask.Yield(cancellationToken: linkedCTS.Token).SuppressCancellationThrow();
            }
        }

        public async UniTask FadeOut(AudioData audioData, CancellationTokenSource fadeCTS)
        {
            var volume = audioData.AudioSource.volume;
            var linkedCTS = CancellationTokenSource.CreateLinkedTokenSource(_cts.Token, fadeCTS.Token);

            while (!linkedCTS.IsCancellationRequested &&
                   audioData.AudioSource.volume * _musicVolumePercentage > float.Epsilon)
            {
                volume -= Time.deltaTime / AudioMasterData.FadeTransitionTime * _musicVolumePercentage;
                audioData.AudioSource.volume = volume;
                await UniTask.Yield(cancellationToken: linkedCTS.Token).SuppressCancellationThrow();
            }

            if (linkedCTS.IsCancellationRequested)
                return;

            if (audioData.AudioSource.volume <= float.Epsilon)
            {
                audioData.AudioSource.Stop();
                audioData.AudioSource.volume = audioData.InitialVolume * _musicVolumePercentage;
            }
        }

        public async void DelayFunc(DelayedDelegate delayedDelegate, float delay)
        {
            var linkedCTS = CancellationTokenSource.CreateLinkedTokenSource(_delayFuncCts.Token, _cts.Token);
            await UniTask.WaitForSeconds(delay, cancellationToken: linkedCTS.Token).SuppressCancellationThrow();

            if (!linkedCTS.IsCancellationRequested)
                delayedDelegate();
        }

        public void CancelDelayFunc()
        {
            _delayFuncCts?.Cancel();
            _delayFuncCts = new CancellationTokenSource();
        }

        private T[] GetAudioCollection<T>() where T : AudioData, new()
        {
            return typeof(T) == typeof(MusicData)
                ? AudioMasterData.MusicCollection.Cast<T>().ToArray()
                : AudioMasterData.SFXCollection.Cast<T>().ToArray();
        }

        private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
        }
    }
}