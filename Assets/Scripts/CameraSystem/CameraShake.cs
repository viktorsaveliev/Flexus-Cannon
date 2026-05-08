using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

namespace FlexusCannon.CameraSystem
{
    [RequireComponent(typeof(CinemachineBasicMultiChannelPerlin))]
    public class CameraShake : MonoBehaviour
    {
        [SerializeField] private CinemachineBasicMultiChannelPerlin _perlin;
        [SerializeField] private AnimationCurve _fadeCurve = AnimationCurve.EaseInOut(0, 1, 1, 0);

        private float _baseAmplitude;
        private float _baseFrequency;

        private Coroutine _coroutine;

        private void OnValidate()
        {
            if (_perlin == null)
            {
                _perlin = GetComponent<CinemachineBasicMultiChannelPerlin>();
            }
        }

        private void Awake()
        {
            _baseAmplitude = _perlin.AmplitudeGain;
            _baseFrequency = _perlin.FrequencyGain;
        }

        public void Shake(CameraShakeContext context)
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            _coroutine = StartCoroutine(ShakeProcess(context));
        }

        private IEnumerator ShakeProcess(CameraShakeContext context)
        {
            float time = 0f;
            float duration = context.Duration;

            while (time < duration)
            {
                time += Time.deltaTime;

                float t = Mathf.Clamp01(time / duration);
                float fade = _fadeCurve.Evaluate(t);

                _perlin.AmplitudeGain = _baseAmplitude + context.Amplitude * fade;
                _perlin.FrequencyGain = _baseFrequency + context.Frequency * fade;

                yield return null;
            }

            _perlin.AmplitudeGain = _baseAmplitude;
            _perlin.FrequencyGain = _baseFrequency;
        }
    }
}
