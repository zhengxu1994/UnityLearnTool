using System;
using System.Collections.Generic;
using UnityEditor;
public partial class ResourceExporter
{
    static Dictionary<string, string> m_assetScenes = new Dictionary<string, string>();

    static void ExportScene()
    {
        ClearAssetBundlesName();

        m_assetScenes.Clear();
        GetAssetsFromFolder("Assets/Scenes/", "*unity", "scene/", "s", ref m_assetScenes);
        SetAssetBundleName(m_assetScenes);
        SetAssetBundleName(m_assetScenes, new string[] { ".png", ".tga", ".jpg" }, "texture/t_");
        SetAssetBundleName(m_assetScenes, new string[] { ".mat" }, "material/mat_");
        SetAssetBundleName(m_assetScenes, new string[] { ".shader" }, "shader/");
    }
    [MenuItem("ExportResource/ExportScene/Windows")]
    static void ExportSceneWindows()
    {
        ExportScene();
        BuildAssetBundles(BuildTarget.StandaloneWindows);
    }

    [MenuItem("ExportResource/ExportScene/Mac")]
    static void ExportSceneMac()
    {
        ExportScene();
        BuildAssetBundles(BuildTarget.StandaloneOSX);
    }

    [MenuItem("ExportResource/ExportScene/Android")]
    static void ExportSceneAndroid()
    {
        ExportScene();
        BuildAssetBundles(BuildTarget.Android);
    }
}
