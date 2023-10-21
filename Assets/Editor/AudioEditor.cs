using gishadev.tools.Audio;
using UnityEditor;
using UnityEngine;

namespace gishadev.tools.editor
{
    [CustomEditor(typeof(AudioMasterSO))]
    public class AudioEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Generate Enums"))
            {
                AudioMasterSO audioMasterSO = (AudioMasterSO)target;
                audioMasterSO.OnCollectionChanged();
            }
        }
    }
}
