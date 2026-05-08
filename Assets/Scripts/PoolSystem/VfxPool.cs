using System;
using System.Collections.Generic;
using UnityEngine;

namespace FlexusCannon.PoolSystem
{
    public class VfxPool : MonoBehaviour, IVfxService
    {
        [SerializeField] private Transform _container;
        [SerializeField] private VfxSettings[] _vfxs;

        private readonly Dictionary<VfxConfigSo, ObjectPool<ParticleSystem>> _pools = new();

        public void Init()
        {
            foreach (VfxSettings vfxSettings in _vfxs)
            {
                ObjectPool<ParticleSystem> pool = new(vfxSettings.Vfx.Prefab, _container, vfxSettings.Capacity);
                pool.CreatePool();
                
                _pools.Add(vfxSettings.Vfx, pool);
            }
        }

        public void Play(VfxConfigSo prefab, Vector3 position, Quaternion rotation)
        {
            ParticleSystem particles = GetVfx(prefab);

            particles.transform.SetPositionAndRotation(position, rotation);
            particles.gameObject.SetActive(true);

            particles.Play();
        }

        private ParticleSystem GetVfx(VfxConfigSo vfxConfigSo) => _pools[vfxConfigSo].GetInactiveObject();
    }

    [Serializable]
    public class VfxSettings
    {
        public VfxConfigSo Vfx;
        [Range(1, 50)] public int Capacity = 1;
    }
}
