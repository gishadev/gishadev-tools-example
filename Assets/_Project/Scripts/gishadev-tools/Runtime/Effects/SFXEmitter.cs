using System.Collections.Generic;
using System.Linq;
using Gisha.Effects.Audio;
using gishadev.tools.Pooling;
using UnityEngine;

namespace gishadev.tools.Effects
{
    public class SFXEmitter : PoolManager<SFXPoolObject>, ISFXEmitter
    {
        protected override Transform Parent { get; set; }
        protected override List<SFXPoolObject> PoolObjectsCollection => PoolDataSO.SFXPoolObjects.ToList();

        public override void Initialize()
        {
            Parent = new GameObject("[SFXEmitter]").transform;
            base.Initialize();
        }

        public GameObject EmitAt(int index, Vector3 position, Quaternion rotation)
        {
            if (!TryInstantiate(index, out var obj))
                return null;

            obj.transform.position = position;
            obj.transform.rotation = rotation;
            obj.AddComponent<DisableSFXOnComplete>();

            return obj;
        }

        public GameObject EmitAt(SoundEffectsEnum enumEntry, Vector3 position, Quaternion rotation) =>
            EmitAt((int) enumEntry, position, rotation);
    }
}