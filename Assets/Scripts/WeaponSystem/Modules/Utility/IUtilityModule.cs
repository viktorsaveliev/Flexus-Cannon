using UnityEngine;

namespace FlexusCannon.WeaponSystem.ModuleSystem
{
    public interface IUtilityModule
    {
        public bool TryUse(UtilityContext context);
    }
}
