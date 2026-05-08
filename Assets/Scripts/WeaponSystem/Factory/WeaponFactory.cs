using UnityEngine;

namespace FlexusCannon.WeaponSystem
{
    public class WeaponFactory
    {
        public IWeapon Create(WeaponDataSo weaponData)
        {
            Weapon weapon = Object.Instantiate(weaponData.Prefab);
            weapon.Init();

            return weapon;
        }
    }
}
