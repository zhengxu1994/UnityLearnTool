using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text.RegularExpressions;

public partial class ResourceExporter
{
    [MenuItem("地图操作/1.地图素材统一化")]
    static void ResourceCityWarMap()
    {
        m_assetSprite.Clear();
        GetAssetsFromFolder("Assets/MapRes/", "*png", "", "", ref m_assetSprite);
        GetAssetsFromFolder("Assets/MapRes/", "*jpg", "", "", ref m_assetSprite);
        ChangeSpriteTypeToSprite();
    }
}
public partial class CityWarMapEditor
{
    [MenuItem("地图操作/2.地图自动排序")]
    static void SortCityWarMap()
    {
        var tileSize = 1024;
        var allGos = Resources.FindObjectsOfTypeAll(typeof(GameObject));
        var previousSelection = Selection.objects;
        Selection.objects = allGos;
        var selectTransforms = Selection.GetTransforms(SelectionMode.Editable | SelectionMode.ExcludePrefab);
        Selection.objects = selectTransforms;

        int row = 0;
        int col = 0;
        int maxROW = 0;
        Transform mapRoot = null;
        foreach (var trans in selectTransforms)
        {
            if (trans.name.Equals("Directional Light"))
            {
                GameObject.DestroyImmediate(trans.gameObject);
                continue;
            }
            if (trans.name.Equals("Main Camera"))
            {
                Camera mainCamera = Camera.main;
                mainCamera.orthographic = true;
                mainCamera.clearFlags = CameraClearFlags.SolidColor;
                mainCamera.orthographicSize = 320f;
                mainCamera.farClipPlane = 1000;
                mainCamera.transform.localPosition = new Vector3(568f, 320f, -500);
                mainCamera.transform.localRotation = new Quaternion(0, 0, 0, 0);
                mainCamera.cullingMask = 1 << 0;
                mainCamera.cullingMask |=1 << 4;
                continue;
            }
            if (trans.name.Equals("map"))
            {
                mapRoot = trans;
                continue;
            }
            if (trans.name.Equals("water"))
            {
                trans.localPosition = new Vector3(trans.localPosition.x, trans.localPosition.y, 1);
                continue;
            }
            Match mat = Regex.Match(trans.name, @"^citywar_\d._r(\d)_c(\d)");
            if (mat.Groups.Count >= 3)
            {
                row = int.Parse(mat.Groups[1].ToString());
                col = int.Parse(mat.Groups[2].ToString());

                if (row > maxROW)
                    maxROW = row;
                trans.localPosition = new Vector3(col * tileSize, row * tileSize, 0);
            }
            else
            {
                mat = Regex.Match(trans.name, @"^battle_\d._r(\d)_c(\d)");
                if (mat.Groups.Count >= 3)
                {
                    row = int.Parse(mat.Groups[1].ToString());
                    col = int.Parse(mat.Groups[2].ToString());
                    if (row > maxROW)
                        maxROW = row;
                    trans.localPosition = new Vector3(col * tileSize, row * tileSize, 0);
                }
            }
            EditorUtility.SetDirty(trans);
        }
        if (mapRoot == null)
        {
            mapRoot = new GameObject("map").transform;
        }

        mapRoot.localScale = Vector3.one;
        mapRoot.localRotation = Quaternion.identity;
        mapRoot.localPosition = new Vector3(0, 0, 1);

        UnityEditor.SceneManagement.EditorSceneManager.SaveOpenScenes();
    }
}

public partial class ResourceExporter
{
    static Dictionary<string, string> m_assetMapData = new Dictionary<string, string>();

    static void ExportMap()
    {
        ClearAssetBundlesName();
        m_assetMapData.Clear();
        GetAssetsFromFolder("Assets/Map/", "*.unity", "map/", "", ref m_assetScenes);
        SetAssetBundleName(m_assetScenes);
        SetAssetBundleName(m_assetScenes, new string[] { ".png", ".tga", "jpg" }, "texture/map_");
        SetAssetBundleName(m_assetScenes, new string[] { ".mat" }, "material/map_");
        SetAssetBundleName(m_assetScenes, new string[] { ".shader" }, "shader/");

        m_assetMapData.Clear();
        GetAssetsFromFolder("Assets/Map/", "*.bytes", "map/", "bin", ref m_assetMapData);
        SetAssetBundleName(m_assetMapData);
    }

    [MenuItem("ExportResource/ExportMap/Windows")]
    static void ExportMapWindows()
    {
        ExportMap();
        BuildAssetBundles(BuildTarget.StandaloneWindows);
    }

    [MenuItem("ExportResource/ExportMap/Android")]
    static void ExportMapAndroid()
    {
        ExportMap();
        BuildAssetBundles(BuildTarget.Android);
    }

    [MenuItem("ExportResource/ExportMap/IOS")]
    static void ExportMapIOS()
    {
        ExportMap();
        BuildAssetBundles(BuildTarget.iOS);
    }

    [MenuItem("ExportResource/ExportMap/Mac")]
    static void ExportMapMac()
    {
        ExportMap();
        BuildAssetBundles(BuildTarget.StandaloneOSX);
    }
}
