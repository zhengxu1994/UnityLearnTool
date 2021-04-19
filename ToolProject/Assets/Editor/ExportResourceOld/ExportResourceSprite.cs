using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public partial class ResourceExporter
{
    static Dictionary<string, string> m_assetSprite = new Dictionary<string, string>();

    static void ExportSprite()
    {
        ClearAssetBundlesName();

        m_assetSprite.Clear();
        GetAssetsFromFolder("Assets/Sprite/", "*.png", "sprite/", "", ref m_assetSprite);

        ChangeSpriteTypeToSprite();
        SetAssetBundleName(m_assetSprite);
    }

    static void ChangeSpriteTypeToSprite()
    {
        TextureImporter importer = null;
        foreach (var pair in m_assetSprite)
        {
            importer = (TextureImporter)TextureImporter.GetAtPath(pair.Key);

            TextureImporterSettings settings = new TextureImporterSettings();
            importer.ReadTextureSettings(settings);

            settings.mipmapEnabled = false;
            settings.readable = false;
            settings.wrapMode = TextureWrapMode.Clamp;
            settings.filterMode = FilterMode.Bilinear;
            settings.textureType = TextureImporterType.Sprite;
            settings.spriteMode = (int)SpriteImportMode.Single;
            settings.spritePixelsPerUnit = 1.0f;
            settings.spriteAlignment = (int)SpriteAlignment.Custom;
            settings.spritePivot = Vector2.zero;
            settings.sRGBTexture = false;
            importer.SetTextureSettings(settings);
            importer.SaveAndReimport();
        }
    }
    [MenuItem("ExportResource/ExportSprite/Windows")]
    static void ExportSpriteWindow()
    {
        ExportEffect();
        BuildAssetBundles(BuildTarget.StandaloneWindows);
    }

    [MenuItem("ExportResource/ExportSprite/Android")]
    static void ExportSpriteAndroid()
    {
        ExportEffect();
        BuildAssetBundles(BuildTarget.Android);
    }

    [MenuItem("ExportResource/ExportSprite/IOS")]
    static void ExportSpriteIOS()
    {
        ExportEffect();
        BuildAssetBundles(BuildTarget.iOS);
    }

    [MenuItem("ExportResource/ExportSprite/Mac")]
    static void ExportSpriteMac()
    {
        ExportEffect();
        BuildAssetBundles(BuildTarget.StandaloneOSX);
    }
}