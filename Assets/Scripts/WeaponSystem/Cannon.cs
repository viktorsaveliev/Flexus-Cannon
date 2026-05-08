using FlexusCannon.Additional;
using UnityEngine;

namespace FlexusCannon.WeaponSystem
{
    public class Cannon : Weapon
    {
        [SerializeField] private Transform _launchPoint;
        [SerializeField] private TrajectoryPreview _preview;

        public override bool TryAttack(AttackContext context)
        {
            context.LaunchPoint = _launchPoint;
            context.Direction = _launchPoint.forward;

            return base.TryAttack(context);
        }

        private void Update()
        {
            _preview.Draw(_launchPoint.position, _launchPoint.forward, State.Power);
        }
    }
}
