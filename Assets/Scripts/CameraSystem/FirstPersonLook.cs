using FlexusCannon.Additional;
using FlexusCannon.GameInputSystem;
using UnityEngine;

namespace FlexusCannon.FPSController
{
    public class FirstPersonLook : MonoBehaviour, ITickable
    {
        [Header("Look")]
        [SerializeField] private float _sensitivity = 120f;
        [SerializeField] private float _smoothing = 10f;

        [Header("Pitch Object")]
        [SerializeField] private Transform _pitchTarget;
        [SerializeField] private float _minPitch = -70f;
        [SerializeField] private float _maxPitch = 70f;

        private float _yRotation;
        private float _pitchRotation;

        private Vector2 _currentMouseDelta;

        private PlayerInputMap _playerInputMap;
        private ITickMaster _master;

        private void OnDestroy()
        {
            _master.RemoveListener(this);
        }

        public void Construct(InputRouter input, ITickMaster tickMaster)
        {
            _playerInputMap = input.GetInputMap<PlayerInputMap>();
            _master = tickMaster;

            _master.AddListener(this);
        }

        public void Tick(float dt)
        {
            Vector2 targetDelta = _playerInputMap.Look;

            _currentMouseDelta = Vector2.Lerp(_currentMouseDelta, targetDelta, _smoothing * Time.deltaTime);

            RotateYaw();
            RotatePitch();
        }

        private void RotateYaw()
        {
            float mouseX = _currentMouseDelta.x * _sensitivity * Time.deltaTime;

            _yRotation += mouseX;

            transform.localRotation = Quaternion.Euler(0f, _yRotation, 0f);
        }

        private void RotatePitch()
        {
            if (_pitchTarget == null) return;

            float mouseY = _currentMouseDelta.y * _sensitivity * Time.deltaTime;

            _pitchRotation -= mouseY;
            _pitchRotation = Mathf.Clamp(_pitchRotation, _minPitch, _maxPitch);

            _pitchTarget.localRotation = Quaternion.Euler(_pitchRotation, 0f, 0f);
        }
    }
}
