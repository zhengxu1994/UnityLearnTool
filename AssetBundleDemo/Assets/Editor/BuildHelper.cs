using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace ZFramework
{
    public static class BuildHelper
    {
        private const string relativeDirPrefix = "../Release";
        public static string BuildFolder = "../Release/{0}/StreamingAssets";
        public static string ABAssetFolder = "Assets/Bundles";
        static string assetsDir =  "Assets/Bundles";
        //[MenuItem("Tools/web资源服务器")]
        //public static void OpenFileServer()
        //{
        //    //ProcessHelper.Run("dotnet", "FileServer.dll", "../FileServer/");
        //}

        [MenuItem("Tools/SetABName")]
        static void AutoBuildAll()
        {
            //清除所有的AssetBundleName
            ClearAssetBundlesName();
            //设置指定路径下所有需要打包的assetbundlename
            SetAssetBundlesName(assetsDir);
        }

        /// <summary>
        /// 清除所有的AssetBundleName，由于打包方法会将所有设置过AssetBundleName的资源打包，所以自动打包前需要清理
        /// </summary>
        static void ClearAssetBundlesName()
        {
            //获取所有的AssetBundle名称
            string[] abNames = AssetDatabase.GetAllAssetBundleNames();

            //强制删除所有AssetBundle名称
            for (int i = 0; i < abNames.Length; i++)
            {
                AssetDatabase.RemoveAssetBundleName(abNames[i], true);
            }
        }

        /// <summary>
        /// 设置所有在指定路径下的AssetBundleName
        /// </summary>
        static void SetAssetBundlesName(string _assetsPath)
        {
            //先获取指定路径下的所有Asset，包括子文件夹下的资源
            DirectoryInfo dir = new DirectoryInfo(_assetsPath);
            FileSystemInfo[] files = dir.GetFileSystemInfos(); //GetFileSystemInfos方法可以获取到指定目录下的所有文件以及子文件夹

            for (int i = 0; i < files.Length; i++)
            {
                if (files[i] is DirectoryInfo)  //如果是文件夹则递归处理
                {
                    SetAssetBundlesName(files[i].FullName);
                }
                else if (!files[i].Name.EndsWith(".meta") && !files[i].Name.EndsWith(".DS_Store")) //如果是文件的话，则设置AssetBundleName，并排除掉.meta文件
                {
                    SetABName(files[i].FullName);     //逐个设置AssetBundleName
                }
            }

        }

        /// <summary>
        /// 设置单个AssetBundle的Name
        /// </summary>
        /// <param name="filePath"></param>
        static void SetABName(string assetPath)
        {
            string importerPath = "Assets" + assetPath.Substring(Application.dataPath.Length);  //这个路径必须是以Assets开始的路径
            AssetImporter assetImporter = AssetImporter.GetAtPath(importerPath);  //得到Asset
            string tempName = assetPath.Substring(assetPath.LastIndexOf(@"/") + 1);
            string assetName = tempName.Remove(tempName.LastIndexOf(".")); //获取asset的文件名称
            assetImporter.assetBundleName = string.Format("{0}{1}", assetName, ".unity3d") ;    //最终设置assetBundleName
        }

        public static void Build(PlatformType type,BuildAssetBundleOptions buildAssetBundleOptions,
            BuildOptions buildOptions,bool isBuildExe,bool isContainAB,bool clearFolder)
        {
            BuildTarget buildTarget = BuildTarget.StandaloneWindows;
            string exeName = "ZFramework";
            switch (type)
            {
                case PlatformType.PC:
                    buildTarget = BuildTarget.StandaloneWindows64;
                    exeName += ".exe";
                    break;
                case PlatformType.Android:
                    buildTarget = BuildTarget.Android;
                    exeName += ".apk";
                    break;
                case PlatformType.IOS:
                    buildTarget = BuildTarget.iOS;
                    break;
                case PlatformType.MacOS:
                    buildTarget = BuildTarget.StandaloneOSX;
                    break;
            }

            string fold = string.Format(BuildFolder, type);
            if(clearFolder && Directory.Exists(fold))
            {
                Directory.Delete(fold, true);
                Directory.CreateDirectory(fold);
            }
            else
                Directory.CreateDirectory(fold);
            Debug.Log("开始资源打包");
            BuildPipeline.BuildAssetBundles(fold, buildAssetBundleOptions, buildTarget);
            Debug.Log("打包资源完成");

            if(isContainAB)
            {
                FileHelper.CleanDirectory("Assets/StreamingAssets/");
                FileHelper.CopyDirectory(fold, "Assets/StreamingAssets");
            }

            if(isBuildExe)
            {
                AssetDatabase.Refresh();
                string[] levels = { "Assets/Scenes/Init.unity"};
                Debug.Log("开始exe打包");
                BuildPipeline.BuildPlayer(levels, $"{relativeDirPrefix}/{exeName}", buildTarget, buildOptions);
                Debug.Log("完成exe打包");
            }
        }
    }
}
