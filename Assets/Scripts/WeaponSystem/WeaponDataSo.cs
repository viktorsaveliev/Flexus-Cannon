using FlexusCannon.WeaponSystem.ModuleSystem;
using UnityEngine;

namespace FlexusCannon.WeaponSystem
{
    [CreateAssetMenu(fileName = "WeaponData", menuName = "Weapons/WeaponData")]
    public class WeaponDataSo : ScriptableObject
    {
        [field: Header("Base Info")]
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public Weapon Prefab { get; private set; }

        [field: Header("Modules")]
        [field: SerializeReference] public AttackModuleConfig AttackModule { get; private set; }
        [field: Space]
        [field: SerializeReference] public UtilityModuleConfig UtilityModule { get; private set; }
    }
}
