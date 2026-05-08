using UnityEngine;

namespace FlexusCannon.PoolSystem
{
    public interface IVfxService
    {
        public void Play(VfxConfigSo prefab, Vector3 position, Quaternion rotation);
    }
}
