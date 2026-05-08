using System;
using UnityEngine;

namespace FlexusCannon.WeaponSystem
{
    public interface IWeaponEvents
    {
        public event Action<IWeapon> OnWeaponEquipped;
        public event Action<IWeapon> OnWeaponUnequipped;
    }
}
