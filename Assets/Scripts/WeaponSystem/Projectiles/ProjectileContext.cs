using FlexusCannon.PoolSystem;
using FlexusCannon.WeaponSystem.ProjectileSystem;
using UnityEngine;

namespace FlexusCannon.WeaponSystem.ModuleSystem
{
    public struct ProjectileContext
    {
        public Projectile Projectile;
        public RaycastHit Hit;

        public IVfxService VfxService;
    }
}
