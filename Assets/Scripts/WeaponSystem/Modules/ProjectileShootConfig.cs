using FlexusCannon.WeaponSystem.ProjectileSystem;
using System;
using UnityEngine;

namespace FlexusCannon.WeaponSystem.ModuleSystem
{
    public class ProjectileShootConfig : AttackModuleConfig
    {
        [field: SerializeField, Range(0.1f, 5f)] public float ShootCooldown { get; private set; } = 1f;
        [field: SerializeField] public ProjectileDataSo TargetProjectile { get; private set; }

        public override IAttackModule CreateRuntime()
        {
            return new ProjectileShootRuntime(ShootCooldown);
        }
    }
}
