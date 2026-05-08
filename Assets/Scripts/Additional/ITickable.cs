using UnityEngine;

namespace FlexusCannon.Additional
{
    public interface ITickable
    {
        public void Tick(float deltaTime);
    }
}
