using Klak.Hap;
using UnityEngine;

namespace Dkvfx
{
    [ExecuteInEditMode]
    public sealed class Converter : MonoBehaviour
    {
        #region Editable attributes

        [SerializeField] HapPlayer _source = null;
        [SerializeField] Metadata _metadata = null;

        [SerializeField] RenderTexture _positionMap = null;
        [SerializeField] RenderTexture _colorMap = null;

        [SerializeField, HideInInspector] Shader _shader = null;

        #endregion

        #region Private members

        Material _material;
        RenderBuffer[] _mrt = new RenderBuffer[2];

        #endregion

        #region MonoBehaviour implementation

        void OnDestroy()
        {
            if (_material != null)
            {
                if (Application.isPlaying)
                    Destroy(_material);
                else
                    DestroyImmediate(_material);
            }
        }

        void Update()
        {
            // All the properties should be set.
            if (_source == null || _metadata == null ||
                _positionMap == null || _colorMap == null) return;

            // Lazy initialization
            if (_material == null)
            {
                _material = new Material(_shader);
                _material.hideFlags = HideFlags.DontSave;
            }

            // Multiple render target
            _mrt[0] = _positionMap.colorBuffer;
            _mrt[1] = _colorMap.colorBuffer;
            Graphics.SetRenderTarget(_mrt, _positionMap.depthBuffer);

            // Shader attributes
            _metadata.Apply(_material);
            _material.mainTexture = _source.texture;
            _material.SetPass(0);

            // Invoke the shader
            Graphics.DrawProceduralNow(MeshTopology.Triangles, 3, 1);

            // Render target deactivation
            Graphics.SetRenderTarget(null);
        }

        #endregion
    }
}
