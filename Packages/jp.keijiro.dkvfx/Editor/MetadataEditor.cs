using Depthkit;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Dkvfx
{
    static class MetadataEditor
    {
        [MenuItem("Assets/Depthkit/Convert Metadata")]
        static void ConvertMetadata()
        {
            var sources = Selection.GetFiltered<TextAsset>(SelectionMode.Assets);
            var assets = new List<Metadata>();

            foreach (var source in sources)
            {
                var path = AssetDatabase.GetAssetPath(source);
                path = Path.Combine(
                    Path.GetDirectoryName(path),
                    Path.GetFileNameWithoutExtension(path) + ".asset"
                );

                var asset = ScriptableObject.CreateInstance<Metadata>();
                asset.depthkitMetadata = Depthkit_Metadata.CreateFromJSON(source.text);

                AssetDatabase.CreateAsset(asset, path);
                AssetDatabase.SaveAssets();

                assets.Add(asset);
            }

            EditorUtility.FocusProjectWindow();
            Selection.objects = assets.ToArray();
        }

        [MenuItem("Assets/Depthkit/Convert Metadata", true)]
        static bool ValidateConvertMetadata()
        {
            return Selection.GetFiltered<TextAsset>(SelectionMode.Assets).Length > 0;
        }
    }
}
