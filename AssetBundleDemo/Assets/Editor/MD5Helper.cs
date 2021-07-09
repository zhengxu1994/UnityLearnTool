using System;
using System.Text;
using UnityEngine;
using System.IO;
using UnityEditor;
using System.Linq;
using System.Security.Cryptography;
using System.Collections.Generic;

public class MD5Helper
{
    public static string assetPath = "Assets/Bundles";
    public static string exportVersionPath = "../Release/update.txt";

    /// <summary>
    /// 创建版本信息 保存到streamingasssets下
    /// </summary>
    public static void BuildVersion()
    {
        Caching.ClearCache();

        CreateUpdateTxt();
        AssetDatabase.Refresh();
    }


    private static void CreateUpdateTxt()
    {
        List<string> files = new List<string>();
        FileHelper.GetAllFiles(files,assetPath);
        StringBuilder sb = new StringBuilder();
        foreach (var filePath in files)
        {
            if (filePath.EndsWith(".meta")) continue;
            string md5 = BuildFileMD5(filePath);
            string tempName = filePath.Substring(filePath.LastIndexOf(@"/") + 1);
            string fileName = tempName.Remove(tempName.LastIndexOf("."));
            sb.AppendLine(string.Format("{0}:{1}", fileName, md5));
        }

        string updatePath = Path.Combine(Application.streamingAssetsPath, "Version/update.txt");
        WriteTXT(updatePath, sb.ToString());
    }

    public static string BuildFileMD5(string filePath)
    {
        string fileMD5 = string.Empty;
        try
        {
            using(FileStream fs = File.OpenRead(filePath))
            {
                MD5 md5 = MD5.Create();
                byte[] fileMd5Bytes = md5.ComputeHash(fs);
                fileMD5 = System.BitConverter.ToString(fileMd5Bytes).Replace("_", "").ToLower();
            }
        }
        catch(Exception e)
        {
            Debug.LogError(e);
        }
        return fileMD5;
    }

    private static void WriteTXT(string path, string content)
    {
        string directory = Path.GetDirectoryName(path);
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        if (File.Exists(path))
        {
            File.Delete(path);
        }

        using (FileStream fs = File.Create(path))
        {
            StreamWriter sw = new StreamWriter(fs, Encoding.ASCII);
            try
            {
                sw.Write(content);

                sw.Close();
                fs.Close();
                fs.Dispose();

                if (File.Exists(exportVersionPath))
                    File.Delete(exportVersionPath);
                File.Copy(path, exportVersionPath);
            }
            catch (IOException e)
            {
                Debug.Log(e.Message);
            }
        }
    }

}
