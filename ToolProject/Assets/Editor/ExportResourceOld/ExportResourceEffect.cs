using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
public partial class ResourceExporter
{
    static Dictionary<string, string> m_assetEffects = new Dictionary<string, string>();
    static int orderNum = 0;

    static void ExportEffect()
    {
        ClearAssetBundlesName();

        m_assetEffects.Clear();

        GetAssetsFromFolder("Assets/Effect/Prefab/", "*.prefab", "prefab/", "eff", ref m_assetEffects);
        SetAssetBundleName(m_assetEffects);
        ChangeAndSetEffectTexture(m_assetEffects, new string[] { ".png", ".tga", ".jpg" }, "texture/eff_");
        SetAssetBundleName(m_assetEffects, new string[] { ".shader" }, "shader/");
        SetAssetBundleName(m_assetEffects, new string[] { ".mat" }, "material/");
    }

    static void ChangeAndSetEffectTexture(Dictionary<string, string> assets, string[] depFormats, string depPath)
    {
        AssetImporter importer = null;
        TextureImporter texImporter = null;
        foreach (var pair in assets)
        {
            string[] dependencies = AssetDatabase.GetDependencies(pair.Key);
            foreach (var sdep in dependencies)
            {
                string dep = sdep.ToLower();
                foreach (var format in depFormats)
                {
                    if (dep.EndsWith(format))
                    {
                        texImporter = (TextureImporter)TextureImporter.GetAtPath(sdep);

                        TextureImporterSettings setting = new TextureImporterSettings();
                        texImporter.ReadTextureSettings(setting);
                        setting.mipmapEnabled = false;
                        setting.readable = false;
                        setting.sRGBTexture = false;
                        setting.filterMode = FilterMode.Bilinear;
                        setting.textureType = TextureImporterType.Sprite;
                        setting.spriteMode = (int)SpriteImportMode.Single;

                        texImporter.SetTextureSettings(setting);
                        texImporter.SaveAndReimport();

                        string newName = string.Format("{0}{1}{2}", depPath, Path.GetFileNameWithoutExtension(sdep), AbExtension);
                        newName = newName.Replace(" ", "");
                        newName = newName.ToLower();

                        texImporter.SetAssetBundleNameAndVariant(CheckAssetName(newName), "");
                    }
                }
            }
            importer = AssetImporter.GetAtPath(pair.Key);
            if (importer == null)
            {
                Debug.LogError("can not find :" + pair.Key);
            }

            importer.SetAssetBundleNameAndVariant(CheckAssetName(pair.Value), "");
        }
    }

    [MenuItem("ExportResource/ExportEffect/Windows")]
    static void ExportEffectWindow()
    {
        ExportEffect();
        BuildAssetBundles(BuildTarget.StandaloneWindows);
    }

    [MenuItem("ExportResource/ExportEffect/Android")]
    static void ExportEffectAndroid()
    {
        ExportEffect();
        BuildAssetBundles(BuildTarget.Android);
    }

    [MenuItem("ExportResource/ExportEffect/IOS")]
    static void ExportEffectIOS()
    {
        ExportEffect();
        BuildAssetBundles(BuildTarget.iOS);
    }

    [MenuItem("ExportResource/ExportEffect/Mac")]
    static void ExportEffectMac()
    {
        ExportEffect();
        BuildAssetBundles(BuildTarget.StandaloneOSX);
    }
}

