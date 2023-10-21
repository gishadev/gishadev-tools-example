using System.Linq;
using gishadev.tools.Generative;
using UnityEngine;

namespace gishadev.tools.Audio
{
    [CreateAssetMenu(fileName = "AudioMasterSO", menuName = "ScriptableObjects/AudioMasterSO")]
    public class AudioMasterSO : ScriptableObject
    {
        [field: SerializeField] public float FadeTransitionTime { get; private set; }
        [field: SerializeField] public bool MusicAutoSequencing { get; private set; }
        [field: SerializeField] public MusicData[] MusicCollection { get; private set; }
        [field: SerializeField] public SFXData[] SFXCollection { get; private set; }

        private const string MUSIC_ENUM_NAME = "MusicAudio";
        private const string SFX_ENUM_NAME = "SFXAudio";

        // Enum auto generation method.
        public void OnCollectionChanged()
        {
            InitEnumForCollection(SFXCollection, SFX_ENUM_NAME);
            InitEnumForCollection(MusicCollection, MUSIC_ENUM_NAME);
        }

        private void InitEnumForCollection(AudioData[] collection, string enumName)
        {
            string[] entries = new string[collection.Length];
            for (int i = 0; i < collection.Length; i++)
            {
                entries[i] = collection[i].Name;
                collection[i].SetEnumIndex(i);
            }

            EnumGenerator.GenerateEnumClass(enumName, entries);
        }
    }
}