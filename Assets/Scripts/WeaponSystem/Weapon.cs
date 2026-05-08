using FlexusCannon.WeaponSystem.ModuleSystem;
using System;
using UnityEngine;

namespace FlexusCannon.WeaponSystem
{
    public abstract class Weapon : MonoBehaviour, IWeapon
    {
        public event Action<IWeapon> OnAttacked;
        public event Action<IWeapon> OnUtilityUsed;

        [field: SerializeField] public WeaponDataSo Data { get; private set; }

        public WeaponState State { get; private set; }

        public IAttackModule AttackModule { get; private set; }
        public IUtilityModule UtilityModule { get; private set; }

        public void Init()
        {
            if (Data.AttackModule != null)
            {
                AttackModule = Data.AttackModule.CreateRuntime();
            }
            else
            {
                Debug.LogError($"{Data.Name} AttackModule = null");
            }

            if (Data.UtilityModule != null)
            {
                UtilityModule = Data.UtilityModule.CreateRuntime();
            }
            else
            {
                Debug.LogError($"{Data.Name} UtilityModule = null");
            }

            State = new();
        }

        public virtual bool TryAttack(AttackContext context)
        {
            context.WeaponState = State;

            bool success = AttackModule?.TryAttack(context) ?? false;

            if (success)
            {
                OnAttacked?.Invoke(this);
            }

            return success;
        }

        public virtual bool TryUseUtility(UtilityContext context)
        {
            context.WeaponState = State;

            bool success = UtilityModule?.TryUse(context) ?? false;

            if (success)
            {
                OnUtilityUsed?.Invoke(this);
            }

            return success;
        }

        public virtual void OnEquipped() { }

        public virtual void OnUnequipped() { }
    }
}
