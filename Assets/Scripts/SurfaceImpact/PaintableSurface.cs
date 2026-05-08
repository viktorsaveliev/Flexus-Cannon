using UnityEngine;

namespace FlexusCannon.SurfaceImpactSystem
{
    public class PaintableSurface : MonoBehaviour
    {
        [SerializeField] private Renderer _renderer;
        [SerializeField] private Material _drawShader;
        [SerializeField, Range(0.1f, 2f)] private float _sizeMultiplizer = 1;

        private RenderTexture _splatMap;
        private Material _currentMaterial;
        private Material _drawMaterial;

        private readonly int SplatMap = Shader.PropertyToID("_SplatMap");
        private readonly int Coordinate = Shader.PropertyToID("_Coordinates");
        private readonly int Strength = Shader.PropertyToID("_Strength");
        private readonly int Size = Shader.PropertyToID("_Size");

        private void Awake()
        {
            _drawMaterial = Instantiate(_drawShader);

            var renderer = GetComponent<MeshRenderer>();

            _currentMaterial = Instantiate(renderer.sharedMaterial);
            renderer.material = _currentMaterial;

            _splatMap = new RenderTexture(1024, 1024, 0, RenderTextureFormat.ARGBFloat);
            _splatMap.wrapMode = TextureWrapMode.Clamp;
            _splatMap.Create();

            _currentMaterial.SetTexture(SplatMap, _splatMap);
        }

        public void Paint(RaycastHit hit, float strength, float size)
        {
            float uvScale = transform.lossyScale.magnitude;

            float adjustedSize = size / uvScale;

            _drawMaterial.SetVector(Coordinate, hit.textureCoord);
            _drawMaterial.SetFloat(Strength, strength);
            _drawMaterial.SetFloat(Size, adjustedSize * _sizeMultiplizer);

            RenderTexture temp = RenderTexture.GetTemporary(_splatMap.width, _splatMap.height);

            Graphics.Blit(_splatMap, temp);
            Graphics.Blit(temp, _splatMap, _drawMaterial);

            RenderTexture.ReleaseTemporary(temp);
        }
    }
}
