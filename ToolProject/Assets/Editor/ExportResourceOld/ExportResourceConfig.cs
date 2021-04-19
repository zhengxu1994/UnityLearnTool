using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

public partial class ResourceExporter
{
    public static System.Diagnostics.Process CreateShellExprocess(string cmd, string args, string workingDir = "")
    {
        var pStartInfo = new System.Diagnostics.ProcessStartInfo(cmd);
        pStartInfo.Arguments = args;
        pStartInfo.CreateNoWindow = false;
        pStartInfo.UseShellExecute = true;
        pStartInfo.RedirectStandardError = false;
        pStartInfo.RedirectStandardInput = false;
        pStartInfo.RedirectStandardOutput = false;
        if (!string.IsNullOrEmpty(workingDir))
            pStartInfo.WorkingDirectory = workingDir;
        return System.Diagnostics.Process.Start(pStartInfo);
    }

    public static void RunBat(string batfile, string args, string workingDir = "")
    {
        var p = CreateShellExprocess(batfile, args, workingDir);
        p.WaitForExit();
        p.Close();
    }

    static Dictionary<string, string> m_assestXML = new Dictionary<string, string>();
    static Dictionary<string, string> m_assetConfig = new Dictionary<string, string>();

    static readonly string configDxportPath = "config/";

    static byte[] encrypt(byte[] data, byte[] key)
    {
        if (data == null || data.Length == 0 || key == null || key.Length == 0)
            return data;
        for (int i = 0; i < data.Length; i++)
        {
            //数据与密钥异或，再与循环变量的第8位异或（增加复杂度）
            data[i] = (byte)(data[i] ^ key[i % key.Length] ^ (i & 0xFF));
        }
        return data;
    }


    static void EncryptStaticData()
    {
        string staticdata = "Assets/Config/staticdata.bytes";
        string game_config = "Assets/Config/game_config.bytes";
        if (File.Exists(game_config))
        {
            if (File.Exists(staticdata))
                File.Delete(staticdata);
            FileStream fileStream = File.OpenRead(game_config);
            if (fileStream != null && fileStream.Length > 0)
            {
                byte[] byteData = new byte[fileStream.Length];
                fileStream.Read(byteData, 0, (int)fileStream.Length);
                fileStream.Close();
                byte[] encryptKey = System.Text.Encoding.UTF8.GetBytes("easyencrypt");
                byteData = encrypt(byteData, encryptKey);
                File.WriteAllBytes(staticdata, byteData);
                File.Delete(game_config);
            }
        }
    }

    static void CopyCodeFromDist(string plat, BuildTarget target)
    {
        if (Application.platform == RuntimePlatform.WindowsEditor)
            RunBat("build_win.bat", "1", "HotFixProject/");
        ClearAssetBundlesName();
        m_assetConfig.Clear();

        EncryptStaticData();

        GetAssetsFromFolder("Assets/Config/", "staticdata.bytes", configDxportPath, "", ref m_assetConfig);
        SetAssetBundleName(m_assetConfig);
        BuildAssetBundles(target);

        string copyFile = string.Format("{0}/../../dist/{1}/config/staticdata.bundle", Application.dataPath, plat);
        string resPath = Application.streamingAssetsPath + "/res";

        if (!Directory.Exists(resPath))
            Directory.CreateDirectory(resPath);
        if (!Directory.Exists(string.Format("{0}/{1}", resPath, "config")))
            Directory.CreateDirectory(string.Format("{0}/{1}", resPath, "config"));

        string toPath = string.Format("{0}/{1}/{2}", resPath, "config", "staticdata.bundle");
        if (File.Exists(toPath))
            File.Delete(toPath);
        File.Copy(StandardlizePath(copyFile), toPath);
    }

    [MenuItem("ExportResource/脚本编译拷贝/Windows")]
    static void CopyCodeFromWindows()
    {
        CopyCodeFromDist("pc", BuildTarget.StandaloneLinux64);
        Debug.Log("拷贝windows配置完毕");
    }

    [MenuItem("ExportResource/脚本编译拷贝/Mac")]
    static void CopyCodeFromMac()
    {
        CopyCodeFromDist("mac", BuildTarget.StandaloneOSX);
        Debug.Log("拷贝Mac配置完毕");
    }

    [MenuItem("ExportResource/脚本编译拷贝/Android")]
    static void CopyCodeFromAndroid()
    {
        CopyCodeFromDist("android", BuildTarget.Android);
        Debug.Log("拷贝android配置完毕");
    }

    [MenuItem("ExportResource/脚本编译拷贝/IOS")]
    static void CopyCodeFromIOS()
    {
        CopyCodeFromDist("ios", BuildTarget.iOS);
        Debug.Log("拷贝ios配置完毕");
    }

    static void ExportConfig()
    {
        ClearAssetBundlesName();

        m_assestXML.Clear();
        GetAssetsFromFolder("Assets/Config/", "*xml", "", "", ref m_assestXML);

        string[] keys = new string[m_assestXML.Keys.Count];
        m_assestXML.Keys.CopyTo(keys, 0);
        Regex re = new Regex("_");

        foreach (var key in keys)
        {
            if (re.Matches(m_assestXML[key]).Count > 1)
            {
                m_assestXML[key] = configDxportPath + m_assestXML[key].Substring(m_assestXML[key].IndexOf('_') + 1);
            }
            else
                m_assestXML[key] = configDxportPath + m_assestXML[key];
        }

        SetAssetBundleName(m_assestXML);

        m_assetConfig.Clear();
        EncryptStaticData();

        GetAssetsFromFolder("Assets/Config/", "*.bytes", configDxportPath, "", ref m_assetConfig);
        SetAssetBundleNameForConfig(m_assetConfig);

        SetAssetBundleNameForWwise();
    }

    static void SetAssetBundleNameForWwise()
    {
        AssetImporter importer = AssetImporter.GetAtPath("Assets/Wwise/ScriptableObjects/AkWwiseInitializationSetting.asset");
        if (importer != null)
            importer.SetAssetBundleNameAndVariant(CheckAssetName("config/AkWwiseInitializationSettings" + AbExtension), "");
    }

    static void SetAssetBundleNameForConfig(Dictionary<string,string> assets)
    {
        AssetImporter importer = null;
        foreach (var pair in assets)
        {
            importer = AssetImporter.GetAtPath(pair.Key);
            if (pair.Value.IndexOf("formation_") > 0)
            {
                importer.SetAssetBundleNameAndVariant(CheckAssetName("config/formation" + AbExtension), "");
            }
            else
                importer.SetAssetBundleNameAndVariant(CheckAssetName(pair.Value), "");
        }
    }

    [MenuItem("ExportResource/ExportConfig/Windows")]
    static void ExportConfigWindows()
    {
        DeleteFileFromFolder(string.Format("{0}/{1}", GetBundleSaveDir(BuildTarget.StandaloneLinux64), configDxportPath));
        ExportConfig();
        BuildAssetBundles(BuildTarget.StandaloneWindows64);
    }

    [MenuItem("ExportResource/ExportConfig/Mac")]
    static void ExportConfigMac()
    {
        DeleteFileFromFolder(string.Format("{0}/{1}", GetBundleSaveDir(BuildTarget.StandaloneOSX), configDxportPath));
        ExportConfig();
        BuildAssetBundles(BuildTarget.StandaloneOSX);
    }

    [MenuItem("ExportResource/ExportConfig/Android")]
    static void ExportConfigAndroid()
    {
        DeleteFileFromFolder(string.Format("{0}/{1}", GetBundleSaveDir(BuildTarget.Android), configDxportPath));
        ExportConfig();
        BuildAssetBundles(BuildTarget.Android);
    }

    [MenuItem("ExportResource/ExportConfig/IOS")]
    static void ExportConfigIOS()
    {
        DeleteFileFromFolder(string.Format("{0}/{1}", GetBundleSaveDir(BuildTarget.iOS), configDxportPath));
        ExportConfig();
        BuildAssetBundles(BuildTarget.iOS);
    }
}



