using UnityEngine;

namespace FlexusCannon.WeaponSystem.ModuleSystem
{
    public class BounceModuleConfig : ProjectileModuleConfig
    {
        [field: SerializeField, Range(0.1f, 1f)] public float EnergyLoss { get; private set; } = 0.6f;

        public override ProjectileModule CreateRuntime()
        {
            return new BounceModuleRuntime(EnergyLoss);
        }
    }
}
