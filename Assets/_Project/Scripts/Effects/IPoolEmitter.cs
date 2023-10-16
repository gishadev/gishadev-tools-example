using UnityEngine;

namespace gishadev.tools.Effects
{
    public interface IPoolEmitter
    {
        GameObject EmitAt(string effectName, Vector3 position, Quaternion rotation);
    }
}