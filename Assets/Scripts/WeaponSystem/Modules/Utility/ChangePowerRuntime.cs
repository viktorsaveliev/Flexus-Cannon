using System;
using UnityEngine;

namespace FlexusCannon.WeaponSystem.ModuleSystem
{
    public class ChangePowerRuntime : IPowerModule
    {
        public event Action<float> OnPowerChanged;

        public int MinPower { get; private set; }
        public int MaxPower { get; private set; }

        private readonly float _changeSpeed;

        public ChangePowerRuntime(int minPower, int maxPower, float changeSpeed)
        {
            MinPower = minPower;
            MaxPower = maxPower;

            _changeSpeed = changeSpeed;
        }

        public bool TryUse(UtilityContext context)
        {
            if (context.ScrollAxis != 0)
            {
                ChangePower(context);
                return true;
            }

            return false;
        }

        private void ChangePower(UtilityContext context)
        {
            if (Mathf.Approximately(context.ScrollAxis, 0f)) return;

            WeaponState state = context.WeaponState;

            state.Power += context.ScrollAxis * _changeSpeed;
            state.Power = Mathf.Clamp(state.Power, MinPower, MaxPower);

            OnPowerChanged?.Invoke(state.Power);
        }
    }
}
