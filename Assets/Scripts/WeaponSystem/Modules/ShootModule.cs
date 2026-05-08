using System;
using UnityEngine;

namespace FlexusCannon.WeaponSystem.ModuleSystem
{
    public abstract class ShootModule : IAttackModule
    {
        public float ShootCooldown { get; private set; }

        private float _currentCooldown;

        public ShootModule(float cooldown)
        {
            ShootCooldown = cooldown;
        }

        public virtual bool TryAttack(AttackContext context)
        {
            if (!CanShoot())
            {
                return false;
            }

            Shoot(context);

            return true;
        }

        protected virtual void Shoot(AttackContext context)
        {
            _currentCooldown = Time.time + ShootCooldown;
        }

        protected virtual bool CanShoot()
        {
            if (_currentCooldown > Time.time)
            {
                return false;
            }

            return true;
        }

    }
}
