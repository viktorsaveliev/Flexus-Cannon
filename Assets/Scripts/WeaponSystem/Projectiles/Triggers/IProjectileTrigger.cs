using FlexusCannon.WeaponSystem.ModuleSystem;
using UnityEngine;

namespace FlexusCannon.WeaponSystem.ProjectileSystem
{
    public interface IProjectileTrigger
    {
        public void Execute(ProjectileContext context);
    }
}
