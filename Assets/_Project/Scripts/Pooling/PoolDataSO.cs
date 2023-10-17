using System.Collections.Generic;
using UnityEngine;

namespace gishadev.tools.Pooling
{
    [CreateAssetMenu(fileName = "PoolData", menuName = "ScriptableObjects/PoolData")]
    public class PoolDataSO : ScriptableObject
    {
        [field: SerializeField] public List<SFXPoolObject> SFXPoolObjects { get; private set; } = new();
        [field: SerializeField] public List<VFXPoolObject> VFXPoolObjects { get; private set; } = new();
    }
}