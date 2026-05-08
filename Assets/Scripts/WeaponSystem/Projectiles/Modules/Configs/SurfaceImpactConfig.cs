using UnityEngine;

namespace FlexusCannon.WeaponSystem.ModuleSystem
{
    public class SurfaceImpactConfig : ProjectileModuleConfig
    {
        [SerializeField, Range(0.1f, 1)] private float _strength = 1;
        [SerializeField, Range(1, 100)] private float _size = 20;

        public override ProjectileModule CreateRuntime()
        {
            return new SurfaceImpactRuntime(_strength, _size);
        }
    }
}
