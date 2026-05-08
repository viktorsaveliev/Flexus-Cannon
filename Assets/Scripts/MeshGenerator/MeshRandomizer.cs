using UnityEngine;

namespace FlexusCannon.MeshGenerator
{
    [RequireComponent(typeof(MeshFilter))]
    public class MeshRandomizer : MonoBehaviour
    {
        [SerializeField] private MeshFilter _filter;

        private readonly RandomMeshGenerator _generator = new();
        private const float _meshNoise = 0.3f;

        private Mesh _baseMesh;

        private void OnValidate()
        {
            if (_filter == null)
            {
                _filter = GetComponent<MeshFilter>();
            }
        }

        private void Awake()
        {
            _baseMesh = _filter.mesh;
        }

        private void OnEnable()
        {
            Mesh randomMesh = _generator.Generate(_baseMesh, _meshNoise);
            _filter.mesh = randomMesh;
        }
    }
}
