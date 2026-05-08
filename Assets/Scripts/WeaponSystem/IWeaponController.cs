using UnityEngine;

namespace FlexusCannon.WeaponSystem
{
    public interface IWeaponController
    {
        public IWeapon CurrentWeapon { get; }

        public void Equip(WeaponDataSo data);
        public void Unequip();

        public bool TryAttack(AttackContext context);
        public bool TryUtility(UtilityContext context);
    }
}
