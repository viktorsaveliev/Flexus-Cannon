using System;
using UnityEngine;

namespace FlexusCannon.WeaponSystem.ModuleSystem
{
    [Serializable]
    public abstract class ProjectileModule : IProjectileModule
    {
        public abstract void Execute(ProjectileContext context);
    }
}
