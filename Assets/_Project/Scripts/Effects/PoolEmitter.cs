using gishadev.tools.Core;
using UnityEngine;

namespace gishadev.tools.Effects
{
    public class PoolEmitter : PoolManager<SFXPoolObject>, IPoolEmitter
    {
        public static PoolEmitter I
        {
            get
            {
                if (_current)
                    return _current;

                _current = new GameObject("[SFXManager]").AddComponent<PoolEmitter>();
                DontDestroyOnLoad(_current.gameObject);

                return _current;
            }
        }
        private static PoolEmitter _current;

        protected override Transform Parent { get; set; }

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