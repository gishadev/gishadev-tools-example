using gishadev.tools.Core;
using gishadev.tools.Audio;
using gishadev.tools.Pooling;
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
                var enumsGen = (ScriptableObjectEnumsGenerator)target;
                enumsGen.OnCollectionChanged();
            }
        }
    }
    
    [CustomEditor(typeof(PoolDataSO))]
    public class PoolEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Generate Enums"))
            {
                var enumsGen = (ScriptableObjectEnumsGenerator)target;
                enumsGen.OnCollectionChanged();
            }
        }
    }
}
