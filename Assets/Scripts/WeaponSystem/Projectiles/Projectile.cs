using FlexusCannon.Additional;
using FlexusCannon.PhysicsSystem;
using FlexusCannon.PoolSystem;
using FlexusCannon.WeaponSystem.ModuleSystem;
using System;
using UnityEngine;

namespace FlexusCannon.WeaponSystem.ProjectileSystem
{
    public class Projectile : PhysicalObject
    {
        public event Action<ProjectileFinishContext> OnFinished;

        [field: SerializeField] public ProjectileDataSo Data { get; private set; }

        private ProjectileTriggerRuntime _onSpawned;
        private ProjectileTriggerRuntime _onCollision;

        private IVfxService _vfxService;

        public void Init(IVfxService vfxService, ITickMaster tickMaster)
        {
            SetTickMaster(tickMaster);

            _vfxService = vfxService;

            _onSpawned = Data.OnSpawned.CreateRuntime();
            _onCollision = Data.OnCollision.CreateRuntime();

            ProjectileContext context = new()
            {
                Projectile = this,
                VfxService = vfxService,
            };

            _onSpawned.Execute(context);
        }

        public void Finish(ProjectileFinishContext context)
        {
            OnFinished?.Invoke(context);
        }

        protected override void OnCollision(RaycastHit hit)
        {
            base.OnCollision(hit);

            ProjectileContext context = new()
            {
                Projectile = this,
                Hit = hit,
                VfxService = _vfxService
            };

            _onCollision.Execute(context);
        }
    }
}
