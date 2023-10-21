using gishadev.tools.Generative;
using UnityEngine;

namespace gishadev.tools.Test
{
    public class EnumTest : MonoBehaviour
    {
        [SerializeField] private string enumName;
        [SerializeField] private string[] enumEntries;

        [ContextMenu("Generate")]
        private void Generate()
        {
            EnumGenerator.GenerateEnumClass(enumName, enumEntries);
        }
    }
}