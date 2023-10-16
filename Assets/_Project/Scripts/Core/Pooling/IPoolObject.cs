using UnityEngine;

namespace gishadev.tools.Core
{
    public interface IPoolObject
    {
        string Name { get; }
        int[] InstanceIds { get; }
        GameObject GetPrefab();
    }
}