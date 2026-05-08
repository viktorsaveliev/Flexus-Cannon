using FlexusCannon.WeaponSystem.ModuleSystem;
using System;
using UnityEngine;

namespace FlexusCannon.WeaponSystem
{
    public interface IWeapon
    {
        public event Action<IWeapon> OnAttacked;
        public event Action<IWeapon> OnUtilityUsed;

        public WeaponDataSo Data { get; }
        public WeaponState State { get; }

        public IAttackModule AttackModule { get; }
        public IUtilityModule UtilityModule { get; }

        public void OnEquipped();
        public void OnUnequipped();

        public bool TryAttack(AttackContext context);
        public bool TryUseUtility(UtilityContext context);
    }
}
