using System;
using UnityEngine;

namespace FlexusCannon.GameInputSystem
{
    [Serializable]
    public abstract class InputMap
    {

        protected PlayerInputActions InputActions;

        public virtual void Init(PlayerInputActions inputActions)
        {
            InputActions = inputActions;
        }

        public virtual void Enter()
        {
            SetActive(true);
        }

        public virtual void Exit()
        {
            SetActive(false);
        }

        public abstract void Tick();

        protected abstract void SetActive(bool isActive);

        public void SetCursorState(bool newState)
        {
            Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
        }
    }
}
