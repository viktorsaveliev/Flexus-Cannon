using FlexusCannon.WeaponSystem.ModuleSystem;
using System;
using UnityEngine;

namespace FlexusCannon.WeaponSystem.ProjectileSystem
{
    [Serializable]
    public class ProjectileTrigger
    {
        [SerializeField]
        private ProjectileModuleEntry[] _modulesData;

        public ProjectileTriggerRuntime CreateRuntime()
        {
            IProjectileModule[] modules = new IProjectileModule[_modulesData.Length];

            for (int i = 0; i < modules.Length; i++)
            {
                modules[i] = _modulesData[i].Config.CreateRuntime();
            }

            return new ProjectileTriggerRuntime(modules);
        }
    }

    [Serializable]
    public class ProjectileModuleEntry // Sometimes a [SerializeReference] combined with an array isn't saved in the inspector, so I use an intermediate class
    {
        [field: SerializeReference] public ProjectileModuleConfig Config { get; private set; }
    }
}
