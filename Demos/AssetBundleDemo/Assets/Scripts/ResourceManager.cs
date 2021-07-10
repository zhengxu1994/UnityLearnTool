//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System.IO;
//using System.Text;
//using System;
//using UnityEngine.Networking;

//namespace ZFramework
//{
//    public class ResourceManager
//    {

//        public static ResourceManager Inst { get; } = new ResourceManager();
//        //流程
//        //通过本地md5文件于服务器md5进行比较，筛选出需要更新的ab包
//        //将需要更新的ab包下载到对应路径下（pc streamingassets 或者自定义，移动平台为持久化路径）
//        //资源包加载逻辑
//        //load 依赖文件 异步 同步加载方法 资源缓存 资源卸载（使用引用计数）
//        public string path = "";

//        public string serverMD5Path
//        {
//            get {
//#if UNITY_EDITOR
//                return "../Release/update.txt";// 测试使用
//#else
//#endif
//            }
//        }
//        public string localMD5Path
//        { get {
//#if UNITY_EDITOR
//                return "Assets/StreamingAssets/Version/update.txt";// 测试使用
//#else
//#endif
//            }
//        }

//        public List<string> GetNeedUpdateABNames(out List<string> needRemoveList)
//        {
//            var list = new List<string>();
//            var serverMD5List = new Dictionary<string,string>();
//            var localMD5List = new Dictionary<string,string>();
//            using(FileStream fs = File.OpenRead(serverMD5Path))
//            {
//                StreamReader sr = new StreamReader(fs,Encoding.Default);
//                fs.Seek(0, SeekOrigin.Begin);
//                string content = sr.ReadLine();
//                while (content != null && content.Contains(":"))
//                {
//                    string[] strs = content.Split(':');
//                    string key = strs[0];
//                    string value = strs[1];
//                    serverMD5List.Add(key, value);
//                    content = sr.ReadLine();
//                }
//                fs.Close();
//                sr.Close();
//            }

//            using (FileStream fs = File.OpenRead(localMD5Path))
//            {
//                StreamReader sr = new StreamReader(fs, Encoding.Default);
//                fs.Seek(0, SeekOrigin.Begin);
//                string content = sr.ReadLine();
//                while (content != null && content.Contains(":"))
//                {
//                    string[] strs = content.Split(':');
//                    string key = strs[0];
//                    string value = strs[1];
//                    localMD5List.Add(key, value);
//                    content = sr.ReadLine();
//                }
//                fs.Close();
//                sr.Close();
//            }

//            needRemoveList = new List<string>();
//            //比较
//            foreach (var item in serverMD5List)
//            {
//                if (localMD5List.ContainsKey(item.Key) && localMD5List[item.Key] == item.Value)
//                    continue;
//                list.Add(item.Key);
//            }
//            //移除
//            foreach (var item in localMD5List)
//            {
//                if (!serverMD5List.ContainsKey(item.Key))
//                    needRemoveList.Add(item.Key);
//            }
//            return list;
//        }

////        /// <summary>  
////        /// 下载并保存资源到本地  
////        /// </summary>  
////        /// <param name="url"></param>  
////        /// <param name="name"></param>  
////        /// <returns></returns>  
////        public static IEnumerator DownloadAndSave(string url, string name, Action<bool, string> Finish = null)
////        {
////            var quest = UnityWebRequest.Get(url);
////            quest.timeout = 30;
////            yield return quest.SendWebRequest();
////            bool success = false;
////            if(quest.result != UnityWebRequest.Result.Success)
////            {
////                Debug.LogError("DownLoad Error:" + quest.error);
////                success = false;
////            }
////            else
////            {
////                byte[] bytes = quest.downloadHandler.data;
////                if(bytes.Length > 0)
////                {
////                    SaveAssets(
////#if UNITY_EDITOR
////                        Application.streamingAssetsPath
////#else
////                            Application.persistentDataPath,
////#endif
////                        , name, bytes);
////                }
////                success = true;
////            }
////            Finish?.Invoke(success, name);
////        }

//        /// <summary>  
//        /// 保存资源到本地  
//        /// </summary>  
//        /// <param name="path"></param>  
//        /// <param name="name"></param>  
//        /// <param name="info"></param>  
//        /// <param name="length"></param>  
//        public static bool SaveAssets(string path, string name, byte[] bytes)
//        {
//            Stream sw;
//            FileInfo t = new FileInfo(path + "//" + name);
//            if (!t.Exists)
//            {
//                try
//                {
//                    sw = t.Create();
//                    sw.Write(bytes, 0, bytes.Length);
//                    sw.Close();
//                    sw.Dispose();
//                    return true;
//                }
//                catch
//                {
//                    return false;
//                }
//            }
//            else
//            {
//                return true;
//            }
//        }

//        public string GetPlatformBundlePath()
//        {
//#if UNITY_EDITOR_OSX
//            return "../Release/MacOS/StreamingAssets";
//#else
//#endif
//        }

//        public IEnumerator LoadDependencies(string path)
//        {
//            //读取所有依赖信息的ab ，从ab中读取所有依赖数据
//            AssetBundle ab = AssetBundle.LoadFromFile(path);
//            AssetBundleCreateRequest request = AssetBundle.LoadFromFileAsync(path);
//            yield return request;

//            UnityWebRequest request1 = UnityWebRequestAssetBundle.GetAssetBundle(path);
//            yield return request1.SendWebRequest();

//            AssetBundleRequest q1 = request.assetBundle.LoadAssetAsync("lobby");
//            yield return q1;

//            var obj = request.assetBundle.LoadAsset("lobby");

//            var names = ab.GetAllAssetNames();
            
//            AssetBundleManifest manifest = ab.LoadAsset<AssetBundleManifest>("assetbundlemanifest");

//        }

//    }
//}
