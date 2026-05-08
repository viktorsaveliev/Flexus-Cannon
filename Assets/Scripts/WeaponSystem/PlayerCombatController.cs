using FlexusCannon.Additional;
using FlexusCannon.GameInputSystem;
using System;
using UnityEngine;

namespace FlexusCannon.WeaponSystem
{
    public class PlayerCombatController : IDisposable, ITickable
    {
        private readonly PlayerInputMap _input;
        private readonly IWeaponController _weapons;
        private readonly IProjectileSpawner _projectileSpawner;
        private readonly ITickMaster _tickMaster;

        public PlayerCombatController(
            PlayerInputMap input, 
            IWeaponController weapons, 
            IProjectileSpawner projectileSpawner,
            ITickMaster tickMaster)
        {
            _input = input;
            _weapons = weapons;
            _projectileSpawner = projectileSpawner;
            _tickMaster = tickMaster;
        }

        public void Init()
        {
            _input.OnAttack += HandleShoot;
            _tickMaster.AddListener(this);
        }

        public void Dispose()
        {
            _input.OnAttack -= HandleShoot;
            _tickMaster.RemoveListener(this);
        }

        public void Tick(float deltaTime)
        {
            float scroll = _input.Scroll;

            if (Mathf.Abs(scroll) > 0.01f)
            {
                _weapons.TryUtility(new UtilityContext
                {
                    ScrollAxis = scroll
                });
            }
        }

        private void HandleShoot()
        {
            _weapons.TryAttack(new AttackContext
            {
                ProjectileSpawner = _projectileSpawner
            });
        }
    }
}
