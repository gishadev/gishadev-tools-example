using System.Linq;
using gishadev.tools.Core;
using UnityEngine;

namespace gishadev.tools.Audio
{
    [CreateAssetMenu(fileName = "AudioMasterSO", menuName = "ScriptableObjects/AudioMasterSO")]
    public class AudioMasterSO : ScriptableObjectEnumsGenerator
    {
        [field: SerializeField] public float FadeTransitionTime { get; private set; }
        [field: SerializeField] public bool MusicAutoSequencing { get; private set; }
        [field: SerializeField] public MusicData[] MusicCollection { get; private set; }
        [field: SerializeField] public SFXData[] SFXCollection { get; private set; }

        private const string MUSIC_ENUM_NAME = "MusicAudioEnum";
        private const string SFX_ENUM_NAME = "SFXAudioEnum";

        // Enum auto generation method.
        public override void OnCollectionChanged()
        {
            InitEnumForCollection(SFXCollection, SFXCollection.Select(x => x.Name), SFX_ENUM_NAME);
            InitEnumForCollection(MusicCollection, MusicCollection.Select(x => x.Name), MUSIC_ENUM_NAME);
        }
    }
}