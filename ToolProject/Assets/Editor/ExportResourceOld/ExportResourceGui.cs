using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;

public partial class ResourceExporter
{
    static Dictionary<string, string> m_assetGui = new Dictionary<string, string>();
    static Dictionary<string, string> m_assetAudio = new Dictionary<string, string>();

    static List<string> m_assetSpine = new List<string>();
    static readonly string guiDxportPath = "ui/";
    static readonly string fontDxportPath = "font/";

    static void ExportFont()
    {
        ClearAssetBundlesName();
        m_assetGui.Clear();
        GetAssetsFromFolder("Assets/Font/", "*.ttf", "font/", "", ref m_assetGui);
        GetAssetsFromFolder("Assets/Font/", "*.asset", "font/", "", ref m_assetGui);
        SetAssetBundleNameForGui(m_assetGui);
    }

    static void ExportGui()
    {
        ClearAssetBundlesName();

        m_assetGui.Clear();
        m_assetAudio.Clear();
        GetAssetsFromFolder("Assets/Gui/", "*png", "ui/", "", ref m_assetGui);

        ChangeGuiToAlpha(ref m_assetGui);
        SetAssetBundleNameForGui(m_assetGui);
        m_assetGui.Clear();

        GetAssetsFromFolder("Assets/Gui/", "*.bytes", "ui/", "", ref m_assetGui);
        GetAssetsFromFolder("Assets/Spine/", "*.bytes", "ui/", "", ref m_assetGui);

        SetAssetBundleName(m_assetGui, "ui/uidata");

        GetAssetsFromFolder("Assets/Gui/", "*.mp3", "ui/", "", ref m_assetAudio);
        GetAssetsFromFolder("Assets/Gui/", "*.wav", "ui/", "", ref m_assetAudio);
        GetAssetsFromFolder("Assets/Gui/", "*.ogg", "ui/", "", ref m_assetAudio);
        ChangeAudioType();
        SetAssetBundleName(m_assetAudio, "ui/audio");

        ExportGuiSpine("Assets/Spine/", "spine");
    }

    static void ChangeAudioType()
    {
        AudioImporter importer = null;
        foreach (var pair in m_assetAudio)
        {
            importer = (AudioImporter)AudioImporter.GetAtPath(pair.Key);
            importer.forceToMono = true;

            AudioImporterSampleSettings setting = importer.defaultSampleSettings;
            if (pair.Key.Contains("music"))
            {
                setting.loadType = UnityEngine.AudioClipLoadType.CompressedInMemory;
                setting.compressionFormat = UnityEngine.AudioCompressionFormat.PCM;
            }
            else
            {
                setting.loadType = UnityEngine.AudioClipLoadType.DecompressOnLoad;
                setting.compressionFormat = UnityEngine.AudioCompressionFormat.ADPCM;
            }
            importer.defaultSampleSettings = setting;
            importer.SaveAndReimport();
        }
    }

    static void ExportGuiSpine(string srcFolder, string dstFolder)
    {
        m_assetSpine.Clear();
        string[] files = Directory.GetFiles(srcFolder, "*.json");
        foreach (var oneFile in files)
        {
            string srcFile = StandardlizePath(oneFile);
            if (!File.Exists(srcFile))
                continue;
            m_assetSpine.Add(srcFile);
        }
        foreach (var spine in m_assetSpine)
        {
            string newName = spine.Substring(spine.LastIndexOf("/") + 1);
            newName = newName.Replace(".json", "");

            SetOneAssetBundleName(srcFolder, newName + ".json", dstFolder, newName);
            SetOneAssetBundleName(srcFolder, newName + ".atlas.txt", dstFolder, newName);

            SetOneAssetBundleName(srcFolder, newName + ".png", dstFolder, newName, true);
            SetOneAssetBundleName(srcFolder, newName + "2.png", dstFolder, newName, true);
            SetOneAssetBundleName(srcFolder, newName + "3.png", dstFolder, newName, true);
            SetOneAssetBundleName(srcFolder, newName + "4.png", dstFolder, newName, true);
            SetOneAssetBundleName(srcFolder, newName + "5.png", dstFolder, newName, true);

            SetOneAssetBundleName(srcFolder, newName + "_Material.mat", dstFolder, newName);
            SetOneAssetBundleName(srcFolder, newName + "_Material2.mat", dstFolder, newName);
            SetOneAssetBundleName(srcFolder, newName + "_Material3.mat", dstFolder, newName);
            SetOneAssetBundleName(srcFolder, newName + "_Material4.mat", dstFolder, newName);
            SetOneAssetBundleName(srcFolder, newName + "_Material5.mat", dstFolder, newName);

            SetOneAssetBundleName(srcFolder, newName + "_" + "Atlas.asset", dstFolder, newName);
            SetOneAssetBundleName(srcFolder, newName + "_" + "SkeletonData.asset", dstFolder, newName);
        }
    }


    static void SetOneAssetBundleName(string srcFolder,string searchPattern,string dstFolder,string newName,bool isTexture =false)
    {
        AssetImporter importer = null;
        TextureImporter texImporter = null;
        TextureImporterPlatformSettings settingPlatfrom;

        string[] files = Directory.GetFiles(srcFolder, searchPattern);
        foreach (var oneFile in files)
        {
            string srcFile = StandardlizePath(oneFile);
            if (!File.Exists(srcFile))
                continue;

            string dstFile;
            dstFile = Path.Combine(dstFolder, Path.GetFileNameWithoutExtension(newName));
            dstFile = StandardlizePath(dstFile);

            if (isTexture)
            {
                texImporter = (TextureImporter)TextureImporter.GetAtPath(srcFile);
                TextureImporterSettings setting = new TextureImporterSettings();
                texImporter.ReadTextureSettings(setting);
                setting.mipmapEnabled = false;
                setting.readable = false;
                setting.filterMode = UnityEngine.FilterMode.Bilinear;
                setting.textureType = TextureImporterType.Default;
                setting.textureShape = TextureImporterShape.Texture2D;
                setting.alphaSource = TextureImporterAlphaSource.FromInput;

                texImporter.SetTextureSettings(setting);

                settingPlatfrom = texImporter.GetPlatformTextureSettings("Android");
                if (settingPlatfrom != null)
                {
                    settingPlatfrom.maxTextureSize = 2048;
                    settingPlatfrom.resizeAlgorithm = TextureResizeAlgorithm.Mitchell;
                    settingPlatfrom.overridden = true;

                    settingPlatfrom.format = TextureImporterFormat.ARGB32;
                    texImporter.SetPlatformTextureSettings(settingPlatfrom);
                }

                settingPlatfrom = texImporter.GetPlatformTextureSettings("iPhone");
                if (settingPlatfrom != null)
                {
                    settingPlatfrom.maxTextureSize = 2048;
                    settingPlatfrom.resizeAlgorithm = TextureResizeAlgorithm.Mitchell;
                    settingPlatfrom.overridden = true;

                    settingPlatfrom.format = TextureImporterFormat.ARGB32;
                    texImporter.SetPlatformTextureSettings(settingPlatfrom);
                }
                texImporter.SaveAndReimport();
            }
            else
                importer = AssetImporter.GetAtPath(srcFile);

            if (isTexture)
                texImporter.SetAssetBundleNameAndVariant(CheckAssetName(dstFile + AbExtension), "");
            else
                importer.SetAssetBundleNameAndVariant(CheckAssetName(dstFile + AbExtension), "");
        }
    }

    static void ChangeGuiToAlpha(ref Dictionary<string, string> assets)
    {
        TextureImporter importer = null;
        TextureImporterPlatformSettings settingPlatfrom;
        foreach (var pair in assets)
        {
            importer = (TextureImporter)TextureImporter.GetAtPath(pair.Key);
            TextureImporterSettings setting = new TextureImporterSettings();
            importer.ReadTextureSettings(setting);
            setting.mipmapEnabled = false;
            setting.readable = false;
            setting.filterMode = UnityEngine.FilterMode.Bilinear;
            setting.textureType = TextureImporterType.Default;
            setting.textureShape = TextureImporterShape.Texture2D;
            setting.alphaSource = TextureImporterAlphaSource.FromInput;
            setting.alphaIsTransparency = true;
            importer.SetTextureSettings(setting);

            settingPlatfrom = importer.GetPlatformTextureSettings("Android");
            if (settingPlatfrom != null)
            {
                settingPlatfrom.maxTextureSize = 2048;
                settingPlatfrom.resizeAlgorithm = TextureResizeAlgorithm.Mitchell;
                settingPlatfrom.overridden = true;

                settingPlatfrom.format = TextureImporterFormat.ARGB32;
                importer.SetPlatformTextureSettings(settingPlatfrom);
            }

            settingPlatfrom = importer.GetPlatformTextureSettings("iPhone");
            if (settingPlatfrom != null)
            {
                settingPlatfrom.maxTextureSize = 2048;
                settingPlatfrom.resizeAlgorithm = TextureResizeAlgorithm.Mitchell;
                settingPlatfrom.overridden = true;

                settingPlatfrom.format = TextureImporterFormat.ARGB32;
                importer.SetPlatformTextureSettings(settingPlatfrom);
            }

            importer.SaveAndReimport();
        }
    }


    static void ChangeToAlpha()
    {
        m_assetGui.Clear();
        GetAssetsFromFolder("Assets/Gui/", "*.png", "ui/", "", ref m_assetGui);
        
    }

    [MenuItem("ExportResource/ExportGui/Windows")]
    static void ExportGuiWindows()
    {
        DeleteFileFromFolder(string.Format("{0}{1}", GetBundleSaveDir(BuildTarget.StandaloneLinux64), guiDxportPath));
        ExportGui();
        BuildAssetBundles(BuildTarget.StandaloneLinux64);
    }

    [MenuItem("ExportResource/ExportGui/Mac")]
    static void ExportGuiMac()
    {
        DeleteFileFromFolder(string.Format("{0}{1}", GetBundleSaveDir(BuildTarget.StandaloneOSX), guiDxportPath));
        ExportGui();
        BuildAssetBundles(BuildTarget.StandaloneOSX);
    }

    [MenuItem("ExportResource/ExportGui/Android")]
    static void ExportGuiAndroid()
    {
        DeleteFileFromFolder(string.Format("{0}{1}", GetBundleSaveDir(BuildTarget.Android), guiDxportPath));
        ExportGui();
        BuildAssetBundles(BuildTarget.Android);
    }

    [MenuItem("ExportResource/ExportGui/IOS")]
    static void ExportGuiIOS()
    {
        DeleteFileFromFolder(string.Format("{0}{1}", GetBundleSaveDir(BuildTarget.iOS), guiDxportPath));
        ExportGui();
        BuildAssetBundles(BuildTarget.iOS);
    }

    [MenuItem("ExportResource/ExportFont/Windows")]
    static void ExportFontWindows()
    {
        DeleteFileFromFolder(string.Format("{0}{1}", GetBundleSaveDir(BuildTarget.StandaloneWindows64), guiDxportPath));
        ExportFont();
        BuildAssetBundles(BuildTarget.StandaloneWindows64);
    }

    [MenuItem("ExportResource/ExportFont/Mac")]
    static void ExportFontMac()
    {
        DeleteFileFromFolder(string.Format("{0}{1}", GetBundleSaveDir(BuildTarget.StandaloneOSX), guiDxportPath));
        ExportFont();
        BuildAssetBundles(BuildTarget.StandaloneOSX);
    }

    [MenuItem("ExportResource/ExportFont/Android")]
    static void ExportFontAndriod()
    {
        DeleteFileFromFolder(string.Format("{0}{1}", GetBundleSaveDir(BuildTarget.Android), guiDxportPath));
        ExportFont();
        BuildAssetBundles(BuildTarget.Android);
    }

    [MenuItem("ExportResource/ExportFont/IOS")]
    static void ExportFontIOS()
    {
        DeleteFileFromFolder(string.Format("{0}{1}", GetBundleSaveDir(BuildTarget.iOS), guiDxportPath));
        ExportFont();
        BuildAssetBundles(BuildTarget.iOS);
    }

    static void ChangeImageTypeToGui(ref Dictionary<string, string> assets)
    {
        TextureImporter importer = null;
        foreach (var pair in assets)
        {
            importer = (TextureImporter)TextureImporter.GetAtPath(pair.Key);

            //设置图片格式 
            TextureImporterSettings setting = new TextureImporterSettings();

            setting.mipmapEnabled = false;
            setting.readable = false;
            setting.sRGBTexture = false;
            setting.filterMode = UnityEngine.FilterMode.Bilinear;
            setting.textureType = TextureImporterType.Default;
            setting.textureShape = TextureImporterShape.Texture2D;
            setting.alphaSource = TextureImporterAlphaSource.FromInput;
            setting.alphaIsTransparency = true;
            importer.SetTextureSettings(setting);

            importer.SaveAndReimport();
        }
    }

    static void SetAssetBundleNameForGui(Dictionary<string,string> assets)
    {
        AssetImporter importer = null;
        string newName;
        foreach (var pair in assets)
        {
            importer = AssetImporter.GetAtPath(pair.Key);
            newName = pair.Value;
            newName = newName.Replace("!a.bundle", ".bundle");
            importer.SetAssetBundleNameAndVariant(CheckAssetName(newName), "");
        }
    }
}
