using UnityEngine;
using Depthkit;

namespace Dkvfx
{
    public sealed class Metadata : ScriptableObject
    {
        public Depthkit_Metadata depthkitMetadata;

        public void Apply(Material material)
        {
            if (depthkitMetadata == null) return;
            if (depthkitMetadata.perspectives == null) return;
            if (depthkitMetadata.perspectives.Length == 0) return;

            var pers = depthkitMetadata.perspectives[0];

            material.SetVector("_Crop", pers.crop);
            material.SetVector("_ImageDimensions", pers.depthImageSize);
            material.SetVector("_FocalLength", pers.depthFocalLength);
            material.SetVector("_PrincipalPoint", pers.depthPrincipalPoint);
            material.SetFloat("_NearClip", pers.nearClip);
            material.SetFloat("_FarClip", pers.farClip);
            material.SetMatrix("_Extrinsics", pers.extrinsics);
        }
    }
}
