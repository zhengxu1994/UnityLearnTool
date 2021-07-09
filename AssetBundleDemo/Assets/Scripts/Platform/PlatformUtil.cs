using System;
using UnityEngine;
using System.IO;
using System.Collections.Generic;

namespace ZFramework
{
    public class PlatformUtil
    {
        #region Android Java 获取persistentDataPath以解决Unity获取路径为空的问题
        private static string[] _persistentDataPaths;

        public static bool IsDirectoryWritable(string path)
        {
            try
            {
                if (!Directory.Exists(path)) return false;
                string file = Path.Combine(path, Path.GetRandomFileName());
                using (FileStream fs = File.Create(file, 1)) { }
                File.Delete(file);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static string GetPersistentDataPath(params string[] components)
        {
            try
            {
                string path = Path.DirectorySeparatorChar + string.Join("" + Path.DirectorySeparatorChar, components);
                if (!Directory.GetParent(path).Exists) return null;
                if (!Directory.Exists(path))
                {
                    Debug.Log("creating directory :" + path);
                    Directory.CreateDirectory(path);
                }
                if(!IsDirectoryWritable(path))
                {
                    Debug.LogWarning("persistent data path not writeable:" + path);
                    return null;
                }
                return path;
            }
            catch(Exception e)
            {
                Debug.LogException(e);
                return null;
            }
        }

        public static string persistenDataPathInternal
        {
#if UNITY_ANDROID
            get {
                if (Application.isEditor || !Application.isPlaying)
                    return Application.persistentDataPath;
                string path = null;
                if (string .IsNullOrEmpty(path))
                {
                    path = GetPersistentDataPath("storage", "emulated", "0", "Android", "data"
                        , Application.identifier, "files");
                }
                if (string.IsNullOrEmpty(path))
                {
                    path = GetPersistentDataPath("data", "data", Application.identifier, "files");
                }
                return path;
            }
#else
            get { return Application.persistentDataPath; }
#endif
        }

        public static string persistentDataPathExternal
        {
#if UNITY_ANDROID
            get
            {
                if (Application.isEditor || !Application.isPlaying) return null;
                string path = null;
                if (string.IsNullOrEmpty(path))
                    path = GetPersistentDataPath("storage", "sdcard0", "Android", "data"
                        , Application.identifier, "files");
                if(string.IsNullOrEmpty(path))
                    path = GetPersistentDataPath("storage", "sdcard1", "Android", "data"
                        , Application.identifier, "files");
                if (string.IsNullOrEmpty(path))
                    path = GetPersistentDataPath("mnt", "sdcard", "Android", "data",
                        Application.identifier, "files");
                return path;
            }
#else
            get { return null; }
#endif
        }

        public static string[] persistentDataPaths
        {
            get
            {
                if(_persistentDataPaths == null)
                {
                    List<string> paths = new List<string>();
                    if (!string.IsNullOrEmpty(persistenDataPathInternal))
                        paths.Add(persistenDataPathInternal);
                    if (!string.IsNullOrEmpty(persistentDataPathExternal))
                        paths.Add(persistentDataPathExternal);
                    if (!string.IsNullOrEmpty(Application.persistentDataPath) &&
                        !paths.Contains(Application.persistentDataPath))
                        paths.Add(Application.persistentDataPath);
                    _persistentDataPaths = paths.ToArray();
                }
                return _persistentDataPaths;
            }
        }

        public static string persistentDataPath
        {
            get {
                return persistentDataPaths.Length > 0 ? persistentDataPaths[0] : null;
            }
        }

        public static string GetPersistentFile(string relativePath)
        {
            if (string.IsNullOrEmpty(relativePath)) return null;
            foreach (string path in persistentDataPaths)
            {
                if (FileExists(path, relativePath)) return Path.Combine(path, relativePath);
            }
            return null;
        }

        public static bool SaveData(string relativePath,byte[] data)
        {
            string path = GetPersistentFile(relativePath);
            if (string.IsNullOrEmpty(path))
                return SaveData(relativePath, data, 0);
            else
            {
                try
                {
                    File.WriteAllBytes(path, data);
                    return true;
                }
                catch (Exception ex)
                {
                    if (File.Exists(path)) File.Delete(path);
                    return SaveData(relativePath, data, 0);
                }
            }
        }

        private static bool SaveData(string relativePath,byte[] data,int pathIndex)
        {
            if(pathIndex < persistentDataPaths.Length)
            {
                string path = Path.Combine(persistentDataPaths[pathIndex], relativePath);
                try
                {
                    string dir = Path.GetDirectoryName(path);
                    if(!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }
                    File.WriteAllBytes(path, data);
                    return true;
                }
                catch(Exception ex)
                {
                    if (File.Exists(path)) File.Delete(path);
                    return SaveData(relativePath, data, pathIndex + 1);
                }
            }
            else
            {
                Debug.LogWarning("could not save data to any persistent data path");
                return false;
            }
        }


        public static bool FileExists(string path,string relativePath)
        {
            return Directory.Exists(path) && File.Exists(Path.Combine(path, relativePath));
        }
#endregion
    }
}

