using UnityEngine;

namespace FlexusCannon.WeaponSystem.ModuleSystem
{
    public interface IProjectileModule
    {
        public void Execute(ProjectileContext context);
    }
}
