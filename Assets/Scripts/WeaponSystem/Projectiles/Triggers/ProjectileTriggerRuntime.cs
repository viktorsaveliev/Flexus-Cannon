using UnityEngine;

namespace FlexusCannon.WeaponSystem.ModuleSystem
{
    public class ProjectileTriggerRuntime
    {
        private readonly IProjectileModule[] _modules;

        public ProjectileTriggerRuntime(IProjectileModule[] modules)
        {
            _modules = modules;
        }

        public void Execute(ProjectileContext context)
        {
            foreach (IProjectileModule module in _modules)
            {
                module.Execute(context);
            }
        }
    }
}
