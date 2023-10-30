using System;
using Cinemachine;
using gishadev.tools.Audio;
using UnityEngine;

namespace gishadev.tools.Test
{
    [RequireComponent(typeof(CinemachineImpulseSource))]
    public class ImpulseTest : MonoBehaviour
    {
        [SerializeField] private float hfThreshold = 0.8f;
        [SerializeField] private int sampleBufferSize = 512;

        [SerializeField] private float effectMultiplier = 25f;
        [SerializeField] private AnimationCurve frequencyMultiplierCurve;


        private CinemachineImpulseSource _impulseSource;
        private AudioSource _audioSource;

        private void Awake()
        {
            _impulseSource = GetComponent<CinemachineImpulseSource>();
        }

        private void OnEnable()
        {
            AudioManager.I.AudioStarted += OnAudioStarted;
        }

        private void OnDisable()
        {
            AudioManager.I.AudioStarted -= OnAudioStarted;
        }

        private void Update()
        {
            if (_audioSource == null)
                return;

            float[] spectrumData = new float[sampleBufferSize];
            _audioSource.GetSpectrumData(spectrumData, 0, FFTWindow.Hamming);

            // Check high-frequency content (adjust the frequency range as needed).
            if (IsHighFrequencyActive(spectrumData))
            {
                float frequencyMultiplier = GetFrequencyMultiplier(spectrumData);
                _impulseSource.GenerateImpulse(frequencyMultiplier * effectMultiplier);
            }
        }

        private void OnAudioStarted(AudioData audioData)
        {
            if (audioData is not MusicData musicData)
                return;

            _audioSource = musicData.AudioSource;
        }

        private bool IsHighFrequencyActive(float[] spectrumData)
        {
            // Calculate the average spectrum value for high frequencies.
            float highFrequencyValue = 0f;
            int numSamples = spectrumData.Length;

            for (int i = numSamples / 2; i < numSamples; i++)
                highFrequencyValue += spectrumData[i];

            highFrequencyValue /= numSamples / 2;

            // Compare the high-frequency value to a threshold.
            return highFrequencyValue > hfThreshold;
        }

        private float GetFrequencyMultiplier(float[] spectrumData)
        {
            int numSamples = spectrumData.Length;
            int highFrequencyStart = numSamples / 2;

            // Calculate the average amplitude of the high-frequency range.
            float highFrequencyAmplitude = 0f;
            for (int i = highFrequencyStart; i < numSamples; i++)
            {
                highFrequencyAmplitude += spectrumData[i];
            }

            highFrequencyAmplitude /= numSamples / 2;

            // Use the frequencyMultiplierCurve to map amplitude to a multiplier.
            return frequencyMultiplierCurve.Evaluate(highFrequencyAmplitude);
        }
    }
}