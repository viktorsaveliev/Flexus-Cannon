using System;
using UnityEngine;

namespace FlexusCannon.WeaponSystem.ModuleSystem
{
    public class ChangePowerConfig : UtilityModuleConfig
    {
        [field: SerializeField, Range(1, 20)] public int MinPower { get; private set; } = 5;
        [field: SerializeField, Range(21, 100)] public int MaxPower { get; private set; } = 50;
        [field: SerializeField, Range(0.5f, 10)] public float ChangeSpeed { get; private set; } = 1f;

        public override IUtilityModule CreateRuntime()
        {
            return new ChangePowerRuntime(MinPower, MaxPower, ChangeSpeed);
        }
    }
}
