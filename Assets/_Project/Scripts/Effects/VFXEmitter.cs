using System.Collections.Generic;
using gishadev.tools.Core;
using UnityEngine;

namespace gishadev.tools.Effects
{
    public class VFXEmitter : PoolManager<VFXPoolObject>, IPoolEmitter
    {
        public static VFXEmitter I
        {
            get
            {
                if (_current)
                    return _current;

                _current = new GameObject("[VFXManager]").AddComponent<VFXEmitter>();
                DontDestroyOnLoad(_current.gameObject);

                return _current;
            }
        }
        private static VFXEmitter _current;

        protected override Transform Parent { get; set; }
        protected override List<VFXPoolObject> PoolObjectsCollection => PoolDataSO.VFXPoolObjects;

        protected override void Awake()
        {
            base.Awake();
            Parent = transform;
        }

        public GameObject EmitAt(string effectName, Vector3 position, Quaternion rotation)
        {
            if (!TryInstantiate(effectName, out var obj))
                return null;

            obj.transform.position = position;
            obj.transform.rotation = rotation;

            return obj;
        }
    }
}