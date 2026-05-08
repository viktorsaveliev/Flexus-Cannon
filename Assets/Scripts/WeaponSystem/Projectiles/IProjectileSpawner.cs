using FlexusCannon.WeaponSystem.ProjectileSystem;
using System;

namespace FlexusCannon.WeaponSystem
{
    public interface IProjectileSpawner
    {
        public event Action<ProjectileFinishContext> OnProjectileDespawned;

        public Projectile Spawn(AttackContext context);
    }
}
