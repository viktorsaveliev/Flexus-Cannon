using FlexusCannon.WeaponSystem;
using FlexusCannon.WeaponSystem.ModuleSystem;
using TMPro;
using UnityEngine;

namespace FlexusCannon.UiSystem
{
    public class PowerPanelController : MonoBehaviour
    {
        [SerializeField] private PowerSlider _slider;
        [SerializeField] private TMP_Text _valueText;

        private IWeaponEvents _events;
        private IPowerModule _currentPowerModule;

        private void OnDestroy()
        {
            _events.OnWeaponEquipped -= OnWeaponEquipped;
            _events.OnWeaponUnequipped -= OnWeaponUnequipped;

            if (_currentPowerModule != null)
            {
                _currentPowerModule.OnPowerChanged -= UpdatePowerInfo;
                _currentPowerModule = null;
            }
        }

        public void Init(IWeaponEvents events)
        {
            _events = events;

            _events.OnWeaponEquipped += OnWeaponEquipped;
            _events.OnWeaponUnequipped += OnWeaponUnequipped;
        }

        private void OnWeaponEquipped(IWeapon weapon)
        {
            if (weapon.UtilityModule is IPowerModule powerModule)
            {
                _currentPowerModule = powerModule;
                powerModule.OnPowerChanged += UpdatePowerInfo;

                float power = weapon.State.Power;
                UpdatePowerInfo(power);

                _slider.Init(powerModule.MinPower, powerModule.MaxPower);
            }
        }

        private void OnWeaponUnequipped(IWeapon weapon)
        {
            if (weapon.UtilityModule is IPowerModule powerModule)
            {
                powerModule.OnPowerChanged -= UpdatePowerInfo;
                _currentPowerModule = null;
            }
        }

        private void UpdatePowerInfo(float power)
        {
            _slider.SetPower((int)power);
            _valueText.text = $"{power}";
        }
    }
}
