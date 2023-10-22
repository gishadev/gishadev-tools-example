using System.Collections.Generic;
using gishadev.tools.Core;
using UnityEditor;
using UnityEngine;

namespace gishadev.tools.editor
{
    public static class EditorDropAreaCreator<T, U> 
        where T : EnumEntryTarget, new()
        where U : class
    {
        public static void Create(ScriptableObjectEnumsGenerator SOEnumsGenerator,
            IEnumerable<T> targetCollection)
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
                            if (draggedObject is U importKeyObject)
                                SOEnumsGenerator.OnDragNDropped<T, U>(importKeyObject, targetCollection);
                        }
                    }

                    break;
            }
        }
    }
}