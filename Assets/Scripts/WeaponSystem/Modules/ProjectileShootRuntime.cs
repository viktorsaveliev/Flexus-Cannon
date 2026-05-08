using FlexusCannon.WeaponSystem.ProjectileSystem;
using System;
using UnityEngine;

namespace FlexusCannon.WeaponSystem.ModuleSystem
{
    public class ProjectileShootRuntime : ShootModule
    {
        public ProjectileShootRuntime(float cooldown) : base(cooldown)
        {
        }

        protected override void Shoot(AttackContext context)
        {
            Projectile projectile = context.ProjectileSpawner.Spawn(context);
            projectile.AddImpulse(context.Direction * context.WeaponState.Power);

            base.Shoot(context);
        }
    }
}
