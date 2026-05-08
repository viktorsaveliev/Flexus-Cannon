using System.Collections.Generic;
using UnityEngine;

namespace FlexusCannon.PoolSystem
{
    public abstract class Pool<T> where T : Component
    {
        public IReadOnlyList<T> PoolList => _pool;

        protected readonly T Prefab;
        protected readonly Transform Container;

        private readonly int _capacity;
        private readonly List<T> _pool;

        public Pool(T prefab, Transform container, int capacity)
        {
            Prefab = prefab;
            Container = container;

            _capacity = capacity;
            _pool = new(capacity);
        }

        public void CreatePool()
        {
            int created = 0;

            while (created < _capacity)
            {
                T obj = CreateObject();
                _pool.Add(obj);
                obj.gameObject.SetActive(false);

                created++;
            }
        }

        public T GetInactiveObject()
        {
            T freeObj = null;

            foreach (T pool in _pool)
            {
                if (pool.gameObject.activeSelf) continue;
                freeObj = pool;
                break;
            }

            if (freeObj == null)
            {
                freeObj = CreateObject();
                _pool.Add(freeObj);
            }

            return freeObj;
        }

        protected abstract T CreateObject();
    }
}