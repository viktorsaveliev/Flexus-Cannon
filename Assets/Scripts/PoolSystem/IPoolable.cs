using UnityEngine;

namespace FlexusCannon.PoolSystem
{
    public interface IPoolable
    {
        public void OnCreated();
        public void OnSpawned();
        public void OnDespawned();
    }
}
