using FlexusCannon.PoolSystem;
using FlexusCannon.WeaponSystem.ProjectileSystem;
using System;
using UnityEngine;

namespace FlexusCannon.WeaponSystem.ModuleSystem
{
    [Serializable]
    public class ExplodeModuleRuntime : ProjectileModule
    {
        private readonly VfxConfigSo _particlePrefab;

        public ExplodeModuleRuntime(VfxConfigSo particleSystem)
        {
            _particlePrefab = particleSystem;
        }

        public override void Execute(ProjectileContext context)
        {
            Transform transform = context.Projectile.transform;

            context.VfxService.Play(_particlePrefab, transform.position, transform.rotation);

            ProjectileFinishContext finishContext = new()
            {
                Projectile = context.Projectile,
                Explode = true
            };

            context.Projectile.Finish(finishContext);
        }
    }
}
