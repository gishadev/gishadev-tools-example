using System.Collections.Generic;
using Gisha.Effects.Audio;
using gishadev.tools.Core;
using UnityEngine;

namespace gishadev.tools.Effects
{
    public class SFXEmitter : PoolManager<SFXPoolObject>, IPoolEmitter
    {
        public static SFXEmitter I
        {
            get
            {
                if (_current)
                    return _current;

                _current = new GameObject("[SFXManager]").AddComponent<SFXEmitter>();
                DontDestroyOnLoad(_current.gameObject);

                return _current;
            }
        }
        private static SFXEmitter _current;

        protected override Transform Parent { get; set; }
        protected override List<SFXPoolObject> PoolObjectsCollection => PoolDataSO.SFXPoolObjects;

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
            obj.AddComponent<DisableSFXOnComplete>();

            return obj;
        }
    }
}