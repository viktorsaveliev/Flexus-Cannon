using FlexusCannon.PhysicsSystem;
using UnityEngine;

namespace FlexusCannon.Additional
{
    [RequireComponent(typeof(LineRenderer))]
    public class TrajectoryPreview : MonoBehaviour
    {
        [SerializeField] private LineRenderer _line;

        [Header("Simulation")]
        [SerializeField] private int _maxSteps = 100;
        [SerializeField] private float _stepTime = 0.02f;

        [Header("Collision")]
        [SerializeField] private LayerMask _layers;
        [SerializeField] private float _radius = 0.1f;

        private void OnValidate()
        {
            if (_line == null)
            {
                _line = GetComponent<LineRenderer>();
            }
        }

        public void Draw(Vector3 startPosition, Vector3 direction, float power)
        {
            Vector3 position = startPosition;
            Vector3 velocity = direction * power;

            _line.positionCount = _maxSteps;

            for (int i = 0; i < _maxSteps; i++)
            {
                _line.SetPosition(i, position);

                Vector3 moveDir = velocity.normalized;
                float distance = velocity.magnitude * _stepTime;

                if (Physics.SphereCast(position, _radius, moveDir, out RaycastHit hit, distance, _layers))
                {
                    _line.positionCount = i + 1;
                    _line.SetPosition(i, hit.point);

                    return;
                }

                velocity += PhysicsSettings.Gravity * _stepTime * Vector3.down;
                velocity *= 1f / (1f + PhysicsSettings.Drag * _stepTime);

                position += velocity * _stepTime;
            }
        }
    }
}
