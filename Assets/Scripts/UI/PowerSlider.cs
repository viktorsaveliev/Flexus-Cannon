using UnityEngine;
using UnityEngine.UI;

namespace FlexusCannon.UiSystem
{
    [RequireComponent(typeof(Slider))]
    public class PowerSlider : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        private void OnValidate()
        {
            if (_slider == null)
            {
                _slider = GetComponent<Slider>();
            }
        }

        public void Init(int minPower, int maxPower)
        {
            _slider.minValue = minPower;
            _slider.maxValue = maxPower;
        }

        public void SetPower(int power)
        {
            if (power < 0) return;
            _slider.value = power;
        }
    }
}
