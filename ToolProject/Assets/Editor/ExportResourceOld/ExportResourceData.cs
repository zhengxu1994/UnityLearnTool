using System.Collections.Generic;
using UnityEditor;

public partial class ResourceExporter
{
    static Dictionary<string, string> m_assetData = new Dictionary<string, string>();
    static readonly string dataDxportPath = "data/";

    static void ExportData()
    {
        ClearAssetBundlesName();

        m_assetData.Clear();
        GetAssetsFromFolder("Assets/ConfigData/", "*.json", dataDxportPath, "", ref m_assetData);

        SetAssetBundleNameForData(m_assetData);
    }

    static readonly HashSet<string> aloneData = new HashSet<string>() { };

    static void SetAssetBundleNameForData(Dictionary<string,string> assets)
    {
        HashSet<string> alones = new HashSet<string>();
        foreach (var file in aloneData)
        {
            alones.Add(StandardlizePath(file));
        }

        string name;
        AssetImporter importer = null;

        foreach (var pair in assets)
        {
            importer = AssetImporter.GetAtPath(pair.Key);
            name = pair.Key.Substring(pair.Key.LastIndexOf('/') + 1);
            if (name.IndexOf("config_") > 0)
            {
                if (name.IndexOf("config_hero") >= 0)
                    importer.SetAssetBundleNameAndVariant(CheckAssetName("data/config_herodatas" + AbExtension), "");
                else if (!alones.Contains(name))
                    importer.SetAssetBundleNameAndVariant(CheckAssetName("data/config_datas" + AbExtension), "");
                else
                    importer.SetAssetBundleNameAndVariant(CheckAssetName(pair.Value), "");
            }
            else
                importer.SetAssetBundleNameAndVariant(CheckAssetName(pair.Value), "");
        }
    }

    [MenuItem("ExportResource/ExportData/Windows")]
    static void ExportDataWindows()
    {
        DeleteFileFromFolder(string.Format("{0}/{1}", GetBundleSaveDir(BuildTarget.StandaloneWindows64), dataDxportPath));
        ExportData();
        BuildAssetBundles(BuildTarget.StandaloneWindows64);
    }

    [MenuItem("ExportResource/ExportData/Mac")]
    static void ExportDataMac()
    {
        DeleteFileFromFolder(string.Format("{0}/{1}", GetBundleSaveDir(BuildTarget.StandaloneOSX), dataDxportPath));
        ExportData();
        BuildAssetBundles(BuildTarget.StandaloneOSX);
    }

    [MenuItem("ExportResource/ExportData/Android")]
    static void ExportDataAndroid()
    {
        DeleteFileFromFolder(string.Format("{0}/{1}", GetBundleSaveDir(BuildTarget.Android), dataDxportPath));
        ExportData();
        BuildAssetBundles(BuildTarget.Android);
    }

    [MenuItem("ExportResource/ExportData/IOS")]
    static void ExportDataIOS()
    {
        DeleteFileFromFolder(string.Format("{0}/{1}", GetBundleSaveDir(BuildTarget.iOS), dataDxportPath));
        ExportData();
        BuildAssetBundles(BuildTarget.iOS);
    }
}
