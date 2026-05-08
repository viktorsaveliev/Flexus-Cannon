using FlexusCannon.PoolSystem;
using UnityEngine;

namespace FlexusCannon.WeaponSystem.ModuleSystem
{
    public class ExplodeModuleConfig : ProjectileModuleConfig
    {
        [field: SerializeField] public VfxConfigSo Vfx { get; private set; }

        public override ProjectileModule CreateRuntime()
        {
            return new ExplodeModuleRuntime(Vfx);
        }
    }
}
