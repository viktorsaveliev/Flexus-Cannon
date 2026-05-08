using System.Collections.Generic;
using UnityEngine;

namespace FlexusCannon.Additional
{
    public class TickMaster : MonoBehaviour, ITickMaster
    {
        private readonly HashSet<ITickable> _tickables = new();

        private void Update()
        {
            float dt = Time.deltaTime;

            foreach (ITickable tickable in _tickables)
            {
                tickable.Tick(dt);
            }
        }

        public void AddListener(ITickable listener)
        {
            _tickables.Add(listener);
        }

        public void RemoveListener(ITickable listener)
        {
            _tickables.Remove(listener);
        }
    }
}
