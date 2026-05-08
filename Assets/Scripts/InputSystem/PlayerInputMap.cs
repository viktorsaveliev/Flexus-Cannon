using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FlexusCannon.GameInputSystem
{
    public class PlayerInputMap : InputMap
    {
        public event Action OnAttack;

        public Vector2 Look { get; private set; }
        public float Scroll { get; private set; }

        public override void Enter()
        {
            base.Enter();

            InputActions.Player.Attack.performed += OnAttackClicked;

            SetActive(true);
        }

        public override void Exit()
        {
            base.Exit();

            SetActive(false);

            InputActions.Player.Attack.performed -= OnAttackClicked;
        }

        public override void Tick()
        {
            Look = InputActions.Player.Look.ReadValue<Vector2>();
            Scroll = InputActions.Player.ChangePower.ReadValue<float>();
        }

        protected override void SetActive(bool isActive)
        {
            if (isActive)
            {
                InputActions.Player.Enable();
            }
            else
            {
                InputActions.Player.Disable();
            }
        }

        private void OnAttackClicked(InputAction.CallbackContext context)
        {
            OnAttack?.Invoke();
        }
    }
}
