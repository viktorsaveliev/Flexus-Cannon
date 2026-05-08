using FlexusCannon.WeaponSystem;
using FlexusCannon.WeaponSystem.ProjectileSystem;
using UnityEngine;

namespace FlexusCannon.CameraSystem
{
    public class CameraShakePresenter : MonoBehaviour
    {
        [SerializeField] private CameraShake _cameraShake;

        [SerializeField] private CameraShakeContext _explodeSettings;
        [SerializeField] private CameraShakeContext _shootSettings;

        private WeaponController _weaponController;
        private IProjectileSpawner _projectileSpawner;

        private void OnDestroy()
        {
            if (_weaponController != null)
            {
                _weaponController.OnWeaponEquipped -= OnWeaponEquipped;
                _weaponController.OnWeaponUnequipped -= OnWeaponUnequipped;

                if (_weaponController.CurrentWeapon != null)
                {
                    _weaponController.CurrentWeapon.OnAttacked -= OnWeaponShoot;
                }
            }

            _projectileSpawner.OnProjectileDespawned -= OnProjectileDespawned;
        }

        public void Init(WeaponController weaponController, IProjectileSpawner projectileSpawner)
        {
            _weaponController = weaponController;
            _projectileSpawner = projectileSpawner;

            _weaponController.OnWeaponEquipped += OnWeaponEquipped;
            _weaponController.OnWeaponUnequipped += OnWeaponUnequipped;

            _projectileSpawner.OnProjectileDespawned += OnProjectileDespawned;

            if (_weaponController.CurrentWeapon != null)
            {
                _weaponController.CurrentWeapon.OnAttacked += OnWeaponShoot;
            }
        }

        private void OnWeaponEquipped(IWeapon weapon)
        {
            weapon.OnAttacked += OnWeaponShoot;
        }

        private void OnWeaponUnequipped(IWeapon weapon)
        {
            weapon.OnAttacked -= OnWeaponShoot;
        }

        private void OnWeaponShoot(IWeapon weapon)
        {
            _cameraShake.Shake(_shootSettings);
        }

        private void OnProjectileDespawned(ProjectileFinishContext context)
        {
            if (context.Explode)
            {
                _cameraShake.Shake(_explodeSettings);
            }
        }
    }
}
