using System.Collections.Generic;
using System.Linq;
using gishadev.tools.Core;
using UnityEngine;

namespace gishadev.tools.Pooling
{
    [CreateAssetMenu(fileName = "PoolData", menuName = "ScriptableObjects/PoolData")]
    public class PoolDataSO : ScriptableObjectEnumsGenerator
    {
        [field: SerializeField] public List<SFXPoolObject> SFXPoolObjects { get; private set; } = new();
        [field: SerializeField] public List<VFXPoolObject> VFXPoolObjects { get; private set; } = new();

        private const string SFX_ENUM_NAME = "SoundEffectsEnum";
        private const string VFX_ENUM_NAME = "VisualEffectsEnum";

        // Enum auto generation method.
        public override void OnCollectionChanged()
        {
            InitEnumForCollection(SFXPoolObjects, SFXPoolObjects.Select(x => x.Name), SFX_ENUM_NAME);
            InitEnumForCollection(VFXPoolObjects, VFXPoolObjects.Select(x => x.Name), VFX_ENUM_NAME);
        }
    }
}