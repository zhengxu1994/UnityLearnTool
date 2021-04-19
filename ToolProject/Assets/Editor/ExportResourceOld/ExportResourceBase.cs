using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;
using LitJson;
using System;

public partial class ResourceExporter
{
    static readonly string AbExtension = ".bundle";

    static void WriteDependenceConfig(Dictionary<string, List<string>> dict)
    {
        if (dict.Count < 0)
            return;
        //json 格式 资源名:[依赖资源名数组]
        string fileName = Application.dataPath + "/Config/dependency.json";
        Directory.CreateDirectory(Path.GetDirectoryName(fileName));

        JsonWriter writer = new JsonWriter();
        JsonWriter prettyer = new JsonWriter();
        prettyer.PrettyPrint = true;

        writer.WriteObjectStart();
        prettyer.WriteObjectStart();

        foreach (var pair in dict)
        {
            writer.WritePropertyName(pair.Key.Replace(AbExtension, ""));
            writer.WriteArrayStart();

            prettyer.WritePropertyName(pair.Key.Replace(AbExtension, ""));
            prettyer.WriteArrayStart();

            foreach (var s in pair.Value)
            {
                writer.Write(s.Replace(AbExtension, ""));
                prettyer.Write(s.Replace(AbExtension, ""));
            }
            writer.WriteArrayEnd();
            prettyer.WriteArrayEnd();
        }

        writer.WriteObjectEnd();
        prettyer.WriteObjectEnd();

        //json 写入
        StreamWriter sw = File.CreateText(fileName);
        sw.Write(writer.ToString());
        sw.Close();
        sw.Dispose();

        sw = File.CreateText(Application.dataPath + "/../../dist/depinfo.json");
        sw.Write(writer.ToString());
        sw.Close();
        sw.Dispose();

        AssetImporter importer = AssetImporter.GetAtPath("Assets/Config/dependency.json");
        if (importer != null)
            importer.SetAssetBundleNameAndVariant(CheckAssetName(string.Format("config/dependency{0}", AbExtension)), "");
    }
    /// <summary>
    /// dependency ==> <资源名,List<依赖资源名>>
    /// </summary>
    /// <param name="target">Target.</param>
    /// <param name="dict">Dict.</param>
    static void LoadOldDependency(Dictionary<string, List<string>> dict)
    {
        string dataPath = Application.dataPath + "/../../dist/depinfo.json";
        string jsonstr = "";
        if(File.Exists(dataPath))
        {
            StreamReader sr = File.OpenText(dataPath);
            jsonstr = sr.ReadToEnd();
            sr.Close();
            sr.Dispose();
        }

        if (string.IsNullOrEmpty(jsonstr)) return;
   
        JsonData depArr;
        JsonData jsonData = JsonMapper.ToObject(jsonstr);
        foreach (var key in jsonData.Keys)
        {
            if (!dict.ContainsKey(key))
                dict[key] = new List<string>();
            depArr = jsonData[key];
            for (int i = 0; i < depArr.Count; i++)
                dict[key].Add(depArr[i].ToString());
        }
    }

    static string CheckAssetName(string oldname)
    {
        string newname = oldname.ToLower();
        newname = newname.Replace("-", "_");
        newname = newname.Replace(" ", "_");
        return newname;
    }

    static void SaveDependency(string outputPath,BuildAssetBundleOptions options,BuildTarget target)
    {
        string dir = GetBundleSaveDir(target);

        string depfile = dir.TrimEnd('/');
        depfile = depfile.Substring(depfile.LastIndexOf("/") + 1);

        Dictionary<string, List<string>> dependencies = new Dictionary<string, List<string>>();

        LoadOldDependency(dependencies);

        //描述文件
        string path = dir + depfile;
        AssetBundle ab = AssetBundle.LoadFromFile(path);
        AssetBundleManifest manifest = (AssetBundleManifest)ab.LoadAsset("AssetBundleManifest");
        ab.Unload(false);

        //更新依赖config数据
        foreach (var asset in manifest.GetAllAssetBundles())
        {
            List<string> list = new List<string>();
            string[] deps = manifest.GetDirectDependencies(asset);
            foreach (var dep in deps)
                list.Add(dep);
            string resname = asset.Replace(AbExtension, "");
            if (deps.Length > 0)
                dependencies[resname] = list;
            else if (dependencies.ContainsKey(resname))
                dependencies.Remove(resname);
        }
        //资源配置信息
        WriteDependenceConfig(dependencies);

        BuildPipeline.BuildAssetBundles(outputPath, options, target);
    }

    /// <summary>
    /// 不同平台的路径
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    static string GetPlatformPath(BuildTarget target) {
        string platformPath = string.Empty;
        switch (target)
        {
            case BuildTarget.Android:
                platformPath = "dist/android";
                break;
            case BuildTarget.iOS:
                platformPath = "dist/ios";
                break;
            case BuildTarget.StandaloneOSX:
                platformPath = "dist/mac";
                break;
            default:
                platformPath = "dist/pc";
                break;
        }
        return platformPath;
    }



    public static string GetBundleSaveDir(BuildTarget target)
    {
        string path = string.Format("{0}/../../{1}/", Application.dataPath, GetPlatformPath(target));

        return path; 
    }

    static void BuildAssetBundles(BuildTarget target,BuildAssetBundleOptions options = BuildAssetBundleOptions.DeterministicAssetBundle | BuildAssetBundleOptions.ChunkBasedCompression)
    {
        string dir = GetBundleSaveDir(target);
        Directory.CreateDirectory(Path.GetDirectoryName(dir));

        BuildPipeline.BuildAssetBundles(dir, options, target);

        SaveDependency(dir, options, target);

        ClearAssetBundlesName();
    }

    static void SetAssetBundleName(Dictionary<string, string> assets,string assignName = "")
    {
        AssetImporter importer = null;
        foreach (var pair in assets)
        {
            importer = AssetImporter.GetAtPath(pair.Key);
            if (!string.IsNullOrEmpty(assignName))
                importer.SetAssetBundleNameAndVariant(CheckAssetName(assignName + AbExtension), "");
            else
                importer.SetAssetBundleNameAndVariant(CheckAssetName(pair.Value), "");
        }
    }

    static void ClearAssetBundlesName()
    {
        int length = AssetDatabase.GetAllAssetBundleNames().Length;
        string[] oldAssetBundleNames = new string[length];
        for (int i = 0; i < oldAssetBundleNames.Length; i++)
        {
            oldAssetBundleNames[i] = AssetDatabase.GetAllAssetBundleNames()[i];
        }
        for (int i = 0; i < oldAssetBundleNames.Length; i++)
        {
            AssetDatabase.RemoveAssetBundleName(oldAssetBundleNames[i], true);
        }
    }

    static void SetAssetBundleName(Dictionary<string,string> assets,string[] depFormats,string depPath,string assignName="")
    {
        AssetImporter importer = null;
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
                        importer = AssetImporter.GetAtPath(sdep);
                        string newName;
                        if (!string.IsNullOrEmpty(assignName))
                            newName = string.Format("{0}{1}{2}", depPath, assignName, AbExtension);
                        else
                           newName = string.Format("{0}{1}{2}", depPath, Path.GetFileNameWithoutExtension(sdep),AbExtension);

                        importer.SetAssetBundleNameAndVariant(CheckAssetName(newName), "");
                    }
                }
            }

            importer = AssetImporter.GetAtPath(pair.Key);
            if (importer == null)
                Debug.LogError("can not find:" + pair.Key);
            importer.SetAssetBundleNameAndVariant(CheckAssetName(pair.Value), "");
        }
    }

    static void GetAssetsFromFolder(string srcFolder, string searchPattern, string dstFolder, string prefix, ref Dictionary<string, string> assets)
    {
        GetAssetsFromFolder(srcFolder, searchPattern, dstFolder, prefix, AbExtension, ref assets);
    }

    static void GetAssetsFromFolder(string srcFolder, string searchPattern, string dstFolder, string prefix, string suffix, ref Dictionary<string, string> assets)
    {
        string searchFolder = StandardlizePath(srcFolder);
        if (!Directory.Exists(searchFolder))
            return;
        string[] files = Directory.GetFiles(searchFolder, searchPattern);
        foreach (var oneFile in files)
        {
            string srcFile = StandardlizePath(oneFile);
            if (!File.Exists(srcFile))
                continue;
            string dstFile;
            if (string.IsNullOrEmpty(prefix))
                dstFile = Path.Combine(dstFolder, string.Format("{0}{1}", Path.GetFileNameWithoutExtension(srcFile), suffix));
            else
                dstFile = Path.Combine(dstFolder, string.Format("{0}_{1}{2}", prefix, Path.GetFileNameWithoutExtension(srcFile), suffix));

            dstFile = StandardlizePath(dstFile);
            assets[srcFile] = dstFile;
        }

        string[] dirs = Directory.GetDirectories(searchFolder);
        foreach (var oneDir in dirs)
            GetAssetsFromFolder(oneDir, searchPattern, dstFolder, prefix, suffix, ref assets);

    }

    static string StandardlizePath(string path)
    {
        string pathReplace = path.Replace(@"\", @"/");
        return pathReplace.ToLower();
    }

    static string StandardlizePath(UnityEngine.Object obj)
    {
        return StandardlizePath(AssetDatabase.GetAssetPath(obj));
    }

    static void DeleteFileFromFolder(string path)
    {
        if (Directory.Exists(path))
        {
            string[] files = Directory.GetFiles(path);
            foreach (var file in files)
                File.Delete(file);
            files = Directory.GetDirectories(path);
            foreach (var file in files)
                Directory.Delete(file,true);
        }
    }

    static void ExportAllWindows()
    {
        DeleteFileFromFolder(string.Format("{0}{1}", GetBundleSaveDir(BuildTarget.StandaloneWindows64), "config"));
        DeleteFileFromFolder(string.Format("{0}{1}", GetBundleSaveDir(BuildTarget.StandaloneWindows64), "data"));
        DeleteFileFromFolder(string.Format("{0}{1}", GetBundleSaveDir(BuildTarget.StandaloneWindows64), "font"));
        DeleteFileFromFolder(string.Format("{0}{1}", GetBundleSaveDir(BuildTarget.StandaloneWindows64), "ui"));
       
        if (Application.platform == RuntimePlatform.WindowsEditor)
            RunBat("build_win.bat", "1", "HotFixProject/");
        ExportDataWindows();
        ExportFontWindows();
        ExportGuiWindows();
        ExportConfigWindows();
        Debug.Log("资源导出window完毕");
        CopyAllWindowsToRes();
    }


    static void ExportAllMac()
    {
        DeleteFileFromFolder(string.Format("{0}{1}", GetBundleSaveDir(BuildTarget.StandaloneOSX), "config"));
        DeleteFileFromFolder(string.Format("{0}{1}", GetBundleSaveDir(BuildTarget.StandaloneOSX), "data"));
        DeleteFileFromFolder(string.Format("{0}{1}", GetBundleSaveDir(BuildTarget.StandaloneOSX), "font"));
        DeleteFileFromFolder(string.Format("{0}{1}", GetBundleSaveDir(BuildTarget.StandaloneOSX), "ui"));

        if (Application.platform == RuntimePlatform.WindowsEditor)
            RunBat("build_win.bat", "1", "HotFixProject/");
        ExportDataMac();
        ExportFontMac();
        ExportGuiMac();
        ExportConfigMac();
        Debug.Log("资源导出mac完毕");
        CopyAllMacToRes();
    }

    static void ExportAllAndroid()
    {
        DeleteFileFromFolder(string.Format("{0}{1}", GetBundleSaveDir(BuildTarget.Android), "config"));
        DeleteFileFromFolder(string.Format("{0}{1}", GetBundleSaveDir(BuildTarget.Android), "data"));
        DeleteFileFromFolder(string.Format("{0}{1}", GetBundleSaveDir(BuildTarget.Android), "font"));
        DeleteFileFromFolder(string.Format("{0}{1}", GetBundleSaveDir(BuildTarget.Android), "ui"));

        if (Application.platform == RuntimePlatform.WindowsEditor)
            RunBat("build_win.bat", "1", "HotFixProject/");
        ExportDataAndroid();
        ExportFontAndriod();
        ExportGuiAndroid();
        ExportConfigAndroid();
        Debug.Log("资源导出mac完毕");
        CopyAllAndriodToRes();
    }

    static void ExportAllIOS()
    {
        DeleteFileFromFolder(string.Format("{0}{1}", GetBundleSaveDir(BuildTarget.iOS), "config"));
        DeleteFileFromFolder(string.Format("{0}{1}", GetBundleSaveDir(BuildTarget.iOS), "data"));
        DeleteFileFromFolder(string.Format("{0}{1}", GetBundleSaveDir(BuildTarget.iOS), "font"));
        DeleteFileFromFolder(string.Format("{0}{1}", GetBundleSaveDir(BuildTarget.iOS), "ui"));

        if (Application.platform == RuntimePlatform.WindowsEditor)
            RunBat("build_win.bat", "1", "HotFixProject/");
        ExportDataIOS();
        ExportFontIOS();
        ExportGuiIOS();
        ExportConfigIOS();
        Debug.Log("资源导出mac完毕");
        CopyAllIOSToRes();
    }

    static bool redundancy = true;

    static void CopyAllBundleToRes(string copyPath,string key ="")
    {
        string resPath = Application.streamingAssetsPath;
        string encryptStr = "UnityFSUnityFSUnityFSUnityFSUnityFSUnityFS";
        if (key != null && key.Length == 35)
            encryptStr = key;
        if (!Directory.Exists(resPath))
            encryptStr = key;
        else
            DeleteFileFromFolder(resPath);

        if(Directory.Exists(resPath))
        {
            string[] directors = Directory.GetDirectories(copyPath);
            string[] files;
            string dname;
            string fname;
            string targetfile;
            byte[] encryptKey = System.Text.Encoding.UTF8.GetBytes(encryptStr);
            foreach (var director in directors)
            {
                dname = StandardlizePath(Path.GetFileName(director));
                if (!Directory.Exists(string.Format("{0}/{1}", resPath, dname)))
                    Directory.CreateDirectory(string.Format("{0}/{1}", resPath, dname));
                files = Directory.GetFiles(StandardlizePath(director));
                foreach (var file in files)
                {
                    fname = StandardlizePath(Path.GetFileName(file));
                    if (file.EndsWith(".bundle"))
                    {
                        targetfile = string.Format("{0}/{1}/{2}", resPath, dname, fname);
                        if (redundancy)
                        {
                            using (FileStream fileStream = File.OpenRead(file))
                            {
                                if (fileStream != null && fileStream.Length > 0)
                                {
                                    byte[] byteData = new byte[fileStream.Length];
                                    fileStream.Read(byteData, 0, (int)fileStream.Length);
                                    byte[] newData = new byte[fileStream.Length + encryptKey.Length];
                                    Array.Copy(encryptKey, newData, encryptKey.Length);
                                    Array.Copy(byteData, 0, newData, encryptKey.Length, byteData.Length);
                                    if (File.Exists(targetfile))
                                        File.Delete(targetfile);
                                    using (FileStream tempfs = File.Create(targetfile))
                                    {
                                        tempfs.Write(newData, 0, newData.Length);
                                    }
                                }
                            }
                        }
                        else
                            File.Copy(StandardlizePath(file), targetfile);
                    }
                }
            }
        }
        CopyAllSoundToRes();
    }


    static void CopyAllSoundToRes()
    {
        var files = Directory.GetFiles(Application.dataPath + "/../../wwiseProject/GeneratedSoundBanks/Windows");
        string fname;
        string targetfile;
        string resPath = Application.streamingAssetsPath;
        string dname = "sound";
        if (!Directory.Exists(string.Format("{0}/{1}", resPath, dname)))
            Directory.CreateDirectory(string.Format("{0}/{1}", resPath, dname));
        foreach (var file in files)
        {
            fname = Path.GetFileName(file);
            if (fname.EndsWith(",bnk"))
            {
                targetfile = string.Format("{0}/{1}/{2}", resPath, dname, fname);
                File.Copy(file, targetfile);
            }
        }
    }


    static void CopyAllPlatToRes(string plat,string key ="")
    {
        string copyPath = string.Format("{0}/../../dist/{1}", Application.dataPath, plat);
        CopyAllBundleToRes(copyPath, key);
    }

    static void CopyAllWindowsToRes()    {
        string copyPath = string.Format("{0}/../../dist/pc", Application.dataPath);
        CopyAllBundleToRes(copyPath);
    }

    static void CopyAllMacToRes()
    {
        string copyPath = string.Format("{0}/../../dist/mac", Application.dataPath);
        CopyAllBundleToRes(copyPath);
    }

    static void CopyAllAndriodToRes()
    {
        string copyPath = string.Format("{0}/../../dist/android", Application.dataPath);
        CopyAllBundleToRes(copyPath);
    }

    static void CopyAllIOSToRes()
    {
        string copyPath = string.Format("{0}/../../dist/ios", Application.dataPath);
        CopyAllBundleToRes(copyPath);
    }
    
}