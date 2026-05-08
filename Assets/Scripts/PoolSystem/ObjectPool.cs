using UnityEngine;

namespace FlexusCannon.PoolSystem
{
    public class ObjectPool<T> : Pool<T> where T : Component
    {
        public ObjectPool(T prefab, Transform container, int capacity) : base(prefab, container, capacity)
        {
        }

        protected override T CreateObject()
        {
            T obj = Object.Instantiate(Prefab, Container);

            if (obj is IPoolable poolable)
            {
                poolable.OnCreated();
            }

            return obj;
        }
    }
}