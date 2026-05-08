using UnityEngine;

namespace FlexusCannon.WeaponSystem
{
    [RequireComponent(typeof(Weapon))]
    public class WeaponView : MonoBehaviour
    {
        [SerializeField] private Weapon _weapon;
        [SerializeField] private Animator _animator;
        [SerializeField] private ParticleSystem _shootVfx;

        private readonly int ShootAnimHash = Animator.StringToHash("Shoot");

        private void OnValidate()
        {
            if (_weapon == null)
            {
                _weapon = GetComponent<Weapon>();
            }
        }

        private void OnEnable()
        {
            _weapon.OnAttacked += PlayShootAnim;
        }

        private void OnDisable()
        {
            _weapon.OnAttacked -= PlayShootAnim;
        }

        private void PlayShootAnim(IWeapon weapon)
        {
            _animator.SetTrigger(ShootAnimHash);
            _shootVfx.Play();
        }
    }
}
