using System.Collections.Generic;
using System.Linq;
using gishadev.tools.Generative;
using UnityEngine;

namespace gishadev.tools.Core
{
    public abstract class ScriptableObjectEnumsGenerator : ScriptableObject
    {
        public abstract void OnCollectionChanged();

        public abstract void OnDragNDropped<T, U>(U importKeyObject, IEnumerable<T> targetCollection)
            where T : EnumEntryTarget, new()
            where U : class;

        protected void InitEnumForCollection(IEnumerable<EnumEntryTarget> collection,
            IEnumerable<string> enumEntriesNames,
            string enumName)
        {
            var list = collection.ToList();

            string[] entries = new string[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                entries[i] = enumEntriesNames.ToArray()[i];
                list[i].SetEnumIndex(i);
            }

            EnumGenerator.GenerateEnumClass(enumName, entries);
        }
    }
}