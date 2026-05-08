using FlexusCannon.Additional;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace FlexusCannon.GameInputSystem
{
    public class InputRouter : ITickable, IDisposable
    {
        public InputMap CurrentMap { get; private set; }

        private readonly HashSet<InputMap> _inputMaps = new();

        private PlayerInputActions _inputActions;
        private ITickMaster _tickMaster;

        public void Tick(float deltaTime)
        {
            CurrentMap?.Tick();
        }

        public void Dispose()
        {
            foreach (InputMap inputMap in _inputMaps)
            {
                inputMap.Exit();
            }

            _tickMaster.RemoveListener(this);
        }

        public void Init(ITickMaster tickMaster)
        {
            _tickMaster = tickMaster;

            _inputActions = new PlayerInputActions();
            _inputMaps.Add(new PlayerInputMap());

            foreach (InputMap inputMap in _inputMaps)
            {
                inputMap.Init(_inputActions);
            }

            _tickMaster.AddListener(this);
        }

        public void SetPlayerMap()
        {
            PlayerInputMap inputMap = GetInputMap<PlayerInputMap>();
            SetActiveMap(inputMap);
        }

        public T GetInputMap<T>() where T : InputMap
        {
            foreach (InputMap inputMap in _inputMaps)
            {
                if (inputMap is T correctInputMap)
                {
                    return correctInputMap;
                }
            }

            return null;
        }

        private void SetActiveMap<T>(T inputMap) where T : InputMap
        {
            CurrentMap?.Exit();
            CurrentMap = inputMap;
            CurrentMap.Enter();
        }
    }
}
