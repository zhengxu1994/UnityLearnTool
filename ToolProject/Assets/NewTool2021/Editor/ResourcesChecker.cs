using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ZFrameWork
{
    public class CheckInfo
    {
        public string name;

        public string resPath;

        public int vertexCount;

        public int facetsCount;

        public Dictionary<string, int> useTextureSizes = new Dictionary<string, int>();

        //....
    }
    public static class ResourcesChecker
    {
        public static string resPath = Application.dataPath + "/ResPath/Prefab";

        public static Color LogColor = Color.black;

        public static Color WarningColor = Color.yellow;

        public static Color ErrorColor = Color.red;

        public static int vertexMax = 300;

        public static int facetsMax = 1500;

        public static int textureMaxSize = 2048;

        public static List<CheckInfo> checkInfos;

        [MenuItem("ResCheck/CheckAll")]
        public static void CheckAll()
        {
            if (Directory.Exists(resPath))
            {
                string[] files = Directory.GetFiles(resPath);
                if (files == null || files.Length <= 0)
                {
                    Debug.LogError("assets is null");
                    return;
                }
                checkInfos = new List<CheckInfo>();
                for (int i = 0; i < files.Length; i++)
                {
                    string fileStr = files[i];
                    if (File.Exists(fileStr))
                    {
                        if(fileStr.EndsWith(".prefab"))
                        {
                            //prefab
                            fileStr = fileStr.Replace(@"\", "/");
                            fileStr = fileStr.Substring(fileStr.IndexOf("Assets"));
                            Object prefab = AssetDatabase.LoadAssetAtPath<Object>(fileStr);
                            if(prefab != null)
                            {
                                GameObject obj = prefab as GameObject;
                                var v = CheckRes(obj);
                                Debug.Log(v);   
                            }
                        }
                    }
                }
            }
            else
            {
                Debug.LogError("respath is null");
            }
        }

        public static void ExportToExcelData()
        {

        }

        //检测顶点数 面片数
        public static CheckInfo CheckRes(GameObject prefab)
        {
            Component[] filters;
            filters = prefab.GetComponentsInChildren<MeshFilter>();
            CheckInfo v = new CheckInfo();
            foreach (MeshFilter mesh in filters)
            {
                v.facetsCount += mesh.sharedMesh.triangles.Length / 3;
                v.vertexCount+= mesh.sharedMesh.vertexCount;
            }
            Component[] renderers;
            renderers = prefab.GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer render in renderers)
            {
                Material[] mats = render.materials;
                for (int i = 0; i < mats.Length; i++)
                {
                    
                }
            }
            return v;
        }
       
      
    }
}
