using System;
using UnityEngine;

namespace FlexusCannon.WeaponSystem.ModuleSystem
{
    [Serializable]
    public abstract class ProjectileModuleConfig
    {
        public abstract ProjectileModule CreateRuntime();
    }
}
