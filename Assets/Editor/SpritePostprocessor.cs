using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpritePostprocessor : AssetPostprocessor
{
    void OnPostprocessTexture()
    {
        if (assetPath.Contains("Sprite"))
        {
            TextureImporter textureImporter = (TextureImporter) assetImporter;
            textureImporter.textureType = TextureImporterType.Sprite;
            textureImporter.textureCompression = TextureImporterCompression.Uncompressed;
        }
    }
	
}
