using System;
using UnityEngine;

namespace FlexusCannon.WeaponSystem.ModuleSystem
{
    public interface IPowerModule : IUtilityModule
    {
        public int MinPower { get; }
        public int MaxPower { get; }

        public event Action<float> OnPowerChanged;
    }
}
