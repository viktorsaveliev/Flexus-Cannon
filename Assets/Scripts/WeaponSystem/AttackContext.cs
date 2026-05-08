using UnityEngine;

namespace FlexusCannon.WeaponSystem
{
    public struct AttackContext 
    {
        public IProjectileSpawner ProjectileSpawner;
        public Transform LaunchPoint;
        public Vector3 Direction;
        public WeaponState WeaponState;
    }
}
