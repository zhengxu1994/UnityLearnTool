using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public partial class ResourceExporter
{
    static Dictionary<string, string> cur_assetTextures = new Dictionary<string, string>();
    [MenuItem("地图操作/剪裁图片")]
    static void CutTexutures()
    {
        string path = Application.dataPath + "/MapResNew";
        DirectoryInfo info = new DirectoryInfo(path);
        FileInfo[] files = info.GetFiles();
        foreach (var file in files)
        {
            if (file.FullName.EndsWith(".meta"))
                continue;
            Texture2D obj =(Texture2D) AssetDatabase.LoadAssetAtPath(string.Format("Assets/MapResNew/{0}",file.Name), typeof(Texture2D));
            if (obj.width > 1024 || obj.height > 1024)
            {
                var colors = obj.GetPixels(0, 0, 1024, 1024);
                var tex = new Texture2D(1024, 1024);
                tex.SetPixels(0,0,1024,1024,colors);
                tex.Apply();
                byte[] btr = tex.EncodeToPNG();
                string name = file.Name.Split('.')[0];
                File.WriteAllBytes(Application.dataPath + "/MapRes/" + name + "1.png", btr);

                var colors2 = obj.GetPixels(1024, 0, obj.width-1024, obj.height);
                var tex2 = new Texture2D(obj.width-1024, 1024);
                tex2.SetPixels(0, 0, obj.width - 1024, 1024, colors2);
                tex2.Apply();
                byte[] btr2 = tex2.EncodeToPNG();
                File.WriteAllBytes(Application.dataPath + "/MapRes/" + name +"2.png" , btr2);
            }
        }
    }

}
