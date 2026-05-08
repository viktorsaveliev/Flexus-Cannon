using FlexusCannon.WeaponSystem.ModuleSystem;
using UnityEngine;

namespace FlexusCannon.WeaponSystem.ProjectileSystem
{
    [CreateAssetMenu(fileName = "ProjectileData", menuName = "Weapons/ProjectileData")]
    public class ProjectileDataSo : ScriptableObject
    {
        [field: Header("Base Info")]
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public Projectile Prefab { get; private set; }

        [field: Header("Modules")]
        [field: SerializeField] public ProjectileTrigger OnSpawned { get; private set; }
        [field: SerializeField] public ProjectileTrigger OnCollision { get; private set; }
    }
}
