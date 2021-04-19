using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
public partial class ResourceExporter
{
    static Dictionary<string, string> m_assetSheet = new Dictionary<string, string>();

    static void ExportSheets()
    {
        ClearAssetBundlesName();

        List<string> sheetfiles = new List<string>();
        GetSpriteSheetFilesFromFolder("Assets/SpriteSheet/", "*.png", ref sheetfiles);
        SplitSpriteSheetFile(sheetfiles);
        m_assetSheet.Clear();
        GetAssetsFromFolder("Assets/SpriteSheet/", "*.png", "sheet/", "", ref m_assetSheet);
        ChangeSheetToAlpha(ref m_assetSheet);
        SetAssetBundleNameForSheet(m_assetSheet);
    }

    static void GetSpriteSheetFilesFromFolder(string srcFolder,string searchPattern,ref List<string>sheetfiles)
    {
        if (!Directory.Exists(srcFolder))
            return;
        string[] files = Directory.GetFiles(srcFolder, searchPattern);
        foreach (var oneFile in files)
        {
            if (!File.Exists(oneFile))
                continue;
            sheetfiles.Add(oneFile);
        }
        string[] dirs = Directory.GetDirectories(srcFolder);
        foreach (var oneDir in dirs)
        {
            GetSpriteSheetFilesFromFolder(oneDir, searchPattern, ref sheetfiles);
        }
    }

    static void SplitSpriteSheetFile(List<string> sheetfiles)
    {
        foreach (var path in sheetfiles)
        {
            UnityEngine.Object[] sprites = AssetDatabase.LoadAllAssetsAtPath(Path.ChangeExtension(path, "png"));
            if (sprites.Length > 1)
                continue;
            Texture2D texture = AssetDatabase.LoadAssetAtPath(Path.ChangeExtension(path, "png"), typeof(Texture2D)) as Texture2D;
            TextAsset jsonFile = AssetDatabase.LoadAssetAtPath(Path.ChangeExtension(path, "json"), typeof(TextAsset)) as TextAsset;
            if (jsonFile == null || texture == null)
                continue;
            TexturePackerImporter tpie = new TexturePackerImporter();
            tpie.texFile = texture;
            tpie.frames = JsonUtility.FromJson<Frames>(jsonFile.text);
            tpie.ImportTexture();
        }
    }

    static void SetAssetBundleNameForSheet(Dictionary<string,string> assets)
    {
        TextureImporter teximporter = null;
        AssetImporter importer = null;
        string bundleName;
        foreach (var pair in assets)
        {
            importer = AssetImporter.GetAtPath(pair.Key);
            teximporter = (TextureImporter)importer;
            if (pair.Key.IndexOf("!a.png") < 0 && teximporter.spriteImportMode != SpriteImportMode.Multiple)
                continue;
            bundleName = pair.Value.Replace("!a.", ".");
            importer.SetAssetBundleNameAndVariant(CheckAssetName(bundleName), "");
        }
    }

    static void ChangeSheetToAlpha(ref Dictionary<string,string> assets)
    {
        TextureImporter importer = null;
        TextureImporterPlatformSettings settingPlatfrom;
        foreach (var pair in assets)
        {
            TextureImporterSettings setting = new TextureImporterSettings();
            importer = (TextureImporter)TextureImporter.GetAtPath(pair.Key);
            importer.ReadTextureSettings(setting);
            setting.mipmapEnabled = false;
            setting.readable = false;
            setting.filterMode = FilterMode.Bilinear;
            setting.textureType = TextureImporterType.Sprite;
            setting.alphaSource = TextureImporterAlphaSource.None;
            setting.alphaIsTransparency = false;
            setting.sRGBTexture = false;
            importer.SetTextureSettings(setting);

            settingPlatfrom = importer.GetPlatformTextureSettings("Android");
            if (settingPlatfrom != null)
            {
                settingPlatfrom.maxTextureSize = 2048;
                settingPlatfrom.resizeAlgorithm = TextureResizeAlgorithm.Mitchell;
                settingPlatfrom.overridden = true;
                settingPlatfrom.textureCompression = TextureImporterCompression.Compressed;
                if (pair.Key.IndexOf("!a.png") > 0)
                    settingPlatfrom.format = TextureImporterFormat.ETC_RGB4;
                else
                    settingPlatfrom.format = TextureImporterFormat.ETC_RGB4;
                importer.SetPlatformTextureSettings(settingPlatfrom);
            }
            settingPlatfrom = importer.GetPlatformTextureSettings("iPhone");
            if (settingPlatfrom != null)
            {
                settingPlatfrom.maxTextureSize = 2048;
                settingPlatfrom.resizeAlgorithm = TextureResizeAlgorithm.Mitchell;
                settingPlatfrom.overridden = true;
                settingPlatfrom.textureCompression = TextureImporterCompression.Compressed;
                if (pair.Key.IndexOf("!a.png") > 0)
                    settingPlatfrom.format = TextureImporterFormat.PVRTC_RGB4;
                else
                    settingPlatfrom.format = TextureImporterFormat.PVRTC_RGB4;
                importer.SetPlatformTextureSettings(settingPlatfrom);
            }
            importer.SaveAndReimport();
        }
    }

    [MenuItem("ExportResource/ExportSpriteSheet/Windows")]
    static void ExportSpriteSheetWindow()
    {
        ExportSheets();
        BuildAssetBundles(BuildTarget.StandaloneWindows);
    }

    [MenuItem("ExportResource/ExportSpriteSheet/Android")]
    static void ExportSpriteSheetAndroid()
    {
        ExportSheets();
        BuildAssetBundles(BuildTarget.Android);
    }

    [MenuItem("ExportResource/ExportSpriteSheet/IOS")]
    static void ExportSpriteSheetIOS()
    {
        ExportSheets();
        BuildAssetBundles(BuildTarget.iOS);
    }

    [MenuItem("ExportResource/ExportSpriteSheet/Mac")]
    static void ExportSpriteSheetMac()
    {
        ExportSheets();
        BuildAssetBundles(BuildTarget.StandaloneOSX);
    }
}