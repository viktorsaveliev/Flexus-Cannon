using FlexusCannon.WeaponSystem.ProjectileSystem;
using UnityEngine;

namespace FlexusCannon.WeaponSystem.ModuleSystem
{
    public class TakeDamageModuleConfig : ProjectileModuleConfig
    {
        [field: SerializeField, Range(1, 10)] public int Health { get; private set; } = 2;
        [field: SerializeReference] public ProjectileModuleConfig OnDeath { get; private set; }

        public override ProjectileModule CreateRuntime()
        {
            IProjectileModule onDeathModule = OnDeath.CreateRuntime();
            return new TakeDamageRuntime(onDeathModule, Health);
        }
    }
}
