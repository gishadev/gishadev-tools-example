using UnityEngine;

namespace gishadev.tools.Effects
{
    public interface IOtherEmitter
    {
        GameObject EmitAt(int index, Vector3 position, Quaternion rotation);
        GameObject EmitAt(OtherPoolEnum enumEntry, Vector3 position, Quaternion rotation);
        GameObject GetPrefab(OtherPoolEnum enumEntry);
    }
}