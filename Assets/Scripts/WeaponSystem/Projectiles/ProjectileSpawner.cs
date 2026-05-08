using FlexusCannon.Additional;
using FlexusCannon.WeaponSystem;
using FlexusCannon.WeaponSystem.ProjectileSystem;
using System;
using UnityEngine;

namespace FlexusCannon.PoolSystem
{
    public class ProjectileSpawner : MonoBehaviour, IProjectileSpawner
    {
        public event Action<ProjectileFinishContext> OnProjectileDespawned;

        [SerializeField] private ProjectileDataSo _targetProjectile;
        [SerializeField] private Transform _container;
        [SerializeField] private int _capacity;

        private ObjectPool<Projectile> _projectilePool;

        private ITickMaster _tickMaster;
        private IVfxService _vfxService;

        private void OnDestroy()
        {
            foreach (Projectile projectile in _projectilePool.PoolList)
            {
                Despawn(projectile);
            }
        }

        public void Init(ITickMaster tickMaster, IVfxService vfxService)
        {
            _tickMaster = tickMaster;
            _vfxService = vfxService;

            _projectilePool = new(_targetProjectile.Prefab, _container, _capacity);
            _projectilePool.CreatePool();
        }

        public Projectile Spawn(AttackContext context)
        {
            Projectile projectile = _projectilePool.GetInactiveObject();

            projectile.transform.position = context.LaunchPoint.position;

            projectile.Init(_vfxService, _tickMaster);

            projectile.gameObject.SetActive(true);
            projectile.OnFinished += OnFinished;

            return projectile;
        }

        public void OnFinished(ProjectileFinishContext context)
        {
            Projectile projectile = context.Projectile;
            Despawn(projectile);

            OnProjectileDespawned?.Invoke(context);
        }

        private void Despawn(Projectile projectile)
        {
            projectile.gameObject.SetActive(false);
            projectile.OnFinished -= OnFinished;
        }
    }
}
