using System;
using UnityEngine;

namespace FlexusCannon.WeaponSystem.ModuleSystem
{
    [Serializable]
    public abstract class AttackModuleConfig
    {
        public abstract IAttackModule CreateRuntime();
    }
}
