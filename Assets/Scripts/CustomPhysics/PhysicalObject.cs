using FlexusCannon.Additional;
using UnityEngine;

namespace FlexusCannon.PhysicsSystem
{
    public class PhysicalObject : MonoBehaviour, ITickable
    {
        public Vector3 Velocity { get; private set; }

        [Header("Collision")]
        [SerializeField] private LayerMask _includeLayers;
        [SerializeField, Min(0.01f)] private float _collisionRadius = 0.1f;

        [Header("Debug")]
        [SerializeField] private bool _drawGizmos = true;

        private ITickMaster _tickMaster;

        private void OnEnable()
        {
            Velocity = Vector3.zero;
        }

        private void OnDestroy()
        {
            _tickMaster?.RemoveListener(this);
        }

        public void SetTickMaster(ITickMaster tickMaster)
        {
            if (_tickMaster != null) return;

            _tickMaster = tickMaster;
            _tickMaster.AddListener(this);
        }

        public virtual void Tick(float dt)
        {
            if (!gameObject.activeSelf) return;
            if (CheckCollision(dt)) return;

            Velocity += PhysicsSettings.Gravity * dt * Vector3.down;
            Velocity *= 1f / (1f + PhysicsSettings.Drag * dt);

            transform.position += Velocity * dt;
        }

        public void AddImpulse(Vector3 force)
        {
            Velocity += force;
        }

        public void SetVelocity(Vector3 velocity)
        {
            Velocity = velocity;
        }

        protected virtual void OnCollision(RaycastHit hit)
        {

        }

        private bool CheckCollision(float dt)
        {
            if (Velocity.sqrMagnitude < 0.0001f) return false;

            Vector3 moveDir = Velocity.normalized;

            float skin = 0.01f;
            float distance = Velocity.magnitude * dt + skin;

            if (Physics.SphereCast(transform.position, _collisionRadius, moveDir, out RaycastHit sphereHit, distance, _includeLayers))
            {
                transform.position = sphereHit.point + sphereHit.normal * (_collisionRadius + skin);

                RaycastHit finalHit = sphereHit;
                Vector3 rayOrigin = sphereHit.point - moveDir * 0.05f;

                if (Physics.Raycast(rayOrigin, moveDir, out RaycastHit rayHit, 0.1f, _includeLayers))
                {
                    finalHit = rayHit;
                }

                OnCollision(finalHit);
                return true;
            }

            return false;
        }

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            if (!_drawGizmos) return;

            Gizmos.color = Color.cyan;
            Vector3 position = transform.position;
            Gizmos.DrawWireSphere(position, _collisionRadius);

            if (Velocity.sqrMagnitude > 0.001f)
            {
                Vector3 moveDir = Velocity.normalized;
                float distance = Velocity.magnitude * Time.deltaTime;
                Vector3 end = position + moveDir * distance;

                Gizmos.DrawLine(position, end);
                Gizmos.DrawWireSphere(end, _collisionRadius);
            }
        }
#endif
    }
}
