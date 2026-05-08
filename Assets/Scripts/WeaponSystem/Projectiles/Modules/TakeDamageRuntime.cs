using UnityEngine;

namespace FlexusCannon.WeaponSystem.ModuleSystem
{
    public class TakeDamageRuntime : ProjectileModule
    {
        private readonly IProjectileModule _deathModule;
        private int _currentHealth;

        public TakeDamageRuntime(IProjectileModule deathBehaviour, int health)
        {
            _currentHealth = health;
            _deathModule = deathBehaviour;
        }

        public override void Execute(ProjectileContext context)
        {
            _currentHealth--;

            if (_currentHealth <= 0 && _deathModule != null)
            {
                _deathModule.Execute(context);
            }
        }
    }
}
