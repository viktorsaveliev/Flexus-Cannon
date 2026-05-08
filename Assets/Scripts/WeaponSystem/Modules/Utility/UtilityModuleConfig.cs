using System;
using UnityEngine;

namespace FlexusCannon.WeaponSystem.ModuleSystem
{
    [Serializable]
    public abstract class UtilityModuleConfig
    {
        public abstract IUtilityModule CreateRuntime();
    }
}
