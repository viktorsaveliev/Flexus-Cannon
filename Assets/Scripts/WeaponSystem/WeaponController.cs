using System;
using UnityEngine;

namespace FlexusCannon.WeaponSystem
{
    public class WeaponController : IWeaponController, IWeaponEvents
    {
        public event Action<IWeapon> OnWeaponEquipped;
        public event Action<IWeapon> OnWeaponUnequipped;

        public IWeapon CurrentWeapon { get; private set; }

        private readonly WeaponFactory _factory;

        public WeaponController(WeaponFactory factory)
        {
            _factory = factory;
        }

        public void Equip(IWeapon weapon)
        {
            Unequip();

            CurrentWeapon = weapon;
            CurrentWeapon.OnEquipped();

            OnWeaponEquipped?.Invoke(CurrentWeapon);
        }

        public void Equip(WeaponDataSo weaponData)
        {
            if (weaponData == null)
            {
                Debug.LogError("Target WeaponData is null");
                return;
            }

            Unequip();

            IWeapon weapon = _factory.Create(weaponData);
            Equip(weapon);
        }

        public void Unequip()
        {
            if (CurrentWeapon == null) return;

            CurrentWeapon.OnUnequipped();

            OnWeaponUnequipped?.Invoke(CurrentWeapon);

            CurrentWeapon = null;
        }

        public bool TryAttack(AttackContext context)
        {
            return CurrentWeapon?.TryAttack(context) ?? false;
        }

        public bool TryUtility(UtilityContext context)
        {
            return CurrentWeapon?.TryUseUtility(context) ?? false;
        }
    }
}
