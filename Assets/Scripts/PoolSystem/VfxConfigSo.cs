using UnityEngine;

namespace FlexusCannon.PoolSystem
{
    [CreateAssetMenu(fileName = "VfxConfig", menuName = "Configs/VFX")]
    public class VfxConfigSo : ScriptableObject
    {
        [field: SerializeField] public ParticleSystem Prefab { get; private set; }
    }
}
