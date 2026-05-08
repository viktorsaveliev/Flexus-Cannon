using FlexusCannon.PhysicsSystem;
using System;
using UnityEngine;

namespace FlexusCannon.WeaponSystem.ModuleSystem
{
    [Serializable]
    public class BounceModuleRuntime : ProjectileModule
    {
        private readonly float _energyLoss;

        public BounceModuleRuntime(float energyLoss)
        {
            _energyLoss = energyLoss;
        }

        public override void Execute(ProjectileContext context)
        {
            PhysicalObject physical = context.Projectile;

            Vector3 incoming = physical.Velocity;

            float speed = incoming.magnitude;

            Vector3 reflected = Vector3.Reflect(
                incoming.normalized,
                context.Hit.normal
            );

            physical.SetVelocity(_energyLoss * speed * reflected);
        }
    }
}
