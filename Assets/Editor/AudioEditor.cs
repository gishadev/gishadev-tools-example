using System.Collections;
using System.Collections.Generic;
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
        private AudioMasterSO _audioMaster;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            _audioMaster = (AudioMasterSO) target;
            EditorGUILayout.Space();
            DropAreaGUI(_audioMaster.MusicCollection);
            EditorGUILayout.Space();
            DropAreaGUI(_audioMaster.SFXCollection);

            if (GUILayout.Button("Generate Enums"))
            {
                var enumsGen = (ScriptableObjectEnumsGenerator) target;
                enumsGen.OnCollectionChanged();
            }
        }

        private void DropAreaGUI<T>(IEnumerable<T> targetCollection) where T : AudioData, new()
        {
            Event evt = Event.current;
            Rect dropArea = GUILayoutUtility.GetRect(0.0f, 50.0f, GUILayout.ExpandWidth(true));
            GUI.Box(dropArea, $"DRAG & DROP FOR {targetCollection.GetType().Name}");

            switch (evt.type)
            {
                case EventType.DragUpdated:
                case EventType.DragPerform:
                    if (!dropArea.Contains(evt.mousePosition))
                        return;

                    DragAndDrop.visualMode = DragAndDropVisualMode.Copy;

                    if (evt.type == EventType.DragPerform)
                    {
                        DragAndDrop.AcceptDrag();

                        foreach (Object draggedObject in DragAndDrop.objectReferences)
                        {
                            if (draggedObject is AudioClip audioClip)
                                _audioMaster.OnDragNDropped(audioClip, targetCollection);
                        }
                    }

                    break;
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
                var enumsGen = (ScriptableObjectEnumsGenerator) target;
                enumsGen.OnCollectionChanged();
            }
        }
    }
}