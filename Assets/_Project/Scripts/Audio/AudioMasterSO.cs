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
    }
}