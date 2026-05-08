using FlexusCannon.SurfaceImpactSystem;
using UnityEngine;

namespace FlexusCannon.WeaponSystem.ModuleSystem
{
    public class SurfaceImpactRuntime : ProjectileModule
    {
        private readonly float _strength;
        private readonly float _size;

        public SurfaceImpactRuntime(float strength, float size)
        {
            _strength = strength;
            _size = size;
        }

        public override void Execute(ProjectileContext context)
        {
            if (context.Hit.collider == null) return;

            RaycastHit hit = context.Hit;
            
            if (hit.collider.TryGetComponent(out PaintableSurface surface))
            {
                surface.Paint(hit, _strength, _size);
            }
        }
    }
}
