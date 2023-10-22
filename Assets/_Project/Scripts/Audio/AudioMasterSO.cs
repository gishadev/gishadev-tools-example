using System;
using System.Collections;
using System.Collections.Generic;
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

        public void OnDragNDropped<T>(AudioClip audioClip, IEnumerable<T> targetCollection) where T : AudioData, new()
        {
            var tempCollection = targetCollection.ToList();
            var newData = InstanceCreator.CreateInstanceWithArgs<T>(audioClip);
            tempCollection.Add(newData);
            
            if (typeof(T) == typeof(SFXData)) 
                SFXCollection = tempCollection.Cast<SFXData>().ToArray();
            if (typeof(T) == typeof(MusicData)) 
                MusicCollection = tempCollection.Cast<MusicData>().ToArray();
        }
    }
}