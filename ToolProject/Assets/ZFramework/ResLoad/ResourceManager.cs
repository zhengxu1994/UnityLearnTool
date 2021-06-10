﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using ZFramework.Platform;

namespace ZFramework.ResLoad
{
    using Object = UnityEngine.Object;
    public class ResourceManager : Singleton<ResourceManager>
    {
        public class AssetNode
        {
            public AssetBundle ab { get; set; }

            /// <summary>
            /// 引用计数 当引用计数为0是 代表需要移除
            /// </summary>
            public int count { get; set; }

            public AssetNode(AssetBundle ab,int count)
            {
                this.ab = ab;
                this.count = count;
            }
        }

        private readonly string mDependencyPath = "config/dependency";

        /// <summary>
        /// 缓存资源
        /// </summary>
        private readonly Dictionary<string, AssetNode> mCacheAssets = new Dictionary<string, AssetNode>();

        /// <summary>
        /// 依赖资源
        /// </summary>
        private readonly Dictionary<string, HashSet<string>> mDependencies = new Dictionary<string, HashSet<string>>();

        /// <summary>
        /// FGUI资源
        /// </summary>
        private readonly Dictionary<string, HashSet<string>> mPackageAssets = new Dictionary<string, HashSet<string>>();

        public string ABExtension { get; set; } = ".bundle";

        /// <summary>
        /// 正在加载的ab资源
        /// </summary>
        private readonly Dictionary<string, Action<AssetBundle>> mLoadingAssets = new Dictionary<string, Action<AssetBundle>>();

        public void Init()
        {
            LoadDependencyConfig(mDependencyPath);
        }
        /// <summary>
        /// 加载依赖信息
        /// </summary>
        /// <param name="file"></param>
        private void LoadDependencyConfig(string file)
        {
            file = file.ToLower();
            TextAsset textAsset = LoadAssetFromBundleFile(file, typeof(TextAsset)) as TextAsset;
            if(textAsset  == null)
            {
                LogTool.LogError("dependency is null");
                return;
            }

            LitJson.JsonData depArr;
            //tojson
            LitJson.JsonData jsonData = LitJson.JsonMapper.ToObject(textAsset.text);
            foreach (var key in jsonData.Keys)
            {
                if (!mDependencies.ContainsKey(key))
                    mDependencies.Add(key, new HashSet<string>());
                depArr = jsonData[key];
                //保存依赖数据
                for (int i = 0; i < depArr.Count; i++)
                {
                    mPackageAssets[key].Add(depArr[i].ToString());
                }
            }
        }

        /// <summary>
        /// 获取某个ab包的所有依赖资源包
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public HashSet<string> GetDependency(string file)
        {
            if (mDependencies.ContainsKey(file))
                return mDependencies[file];
            return null;
        }

        ///// <summary>
        ///// 异步加载资源
        ///// </summary>
        ///// <param name="ab"></param>
        ///// <param name="type"></param>
        ///// <param name="assetName"></param>
        ///// <returns></returns>
        //async Task<Object> LoadAssetsFromBundleAsync(AssetBundle ab,Type type = null,string assetName = null)
        //{
        //    Object obj = null;
        //    if(ab != null)
        //    {
        //        if(!string.IsNullOrEmpty(assetName))
        //        {
        //            //判断资源内是否存在找的对象
        //            var names = ab.GetAllAssetNames();
        //            for (int i = 0; i < names.Length; i++)
        //            {
        //                //存在
        //                if(names[i].IndexOf(assetName.ToLower()) != -1)
        //                {
        //                    if(type != null)
        //                    {
        //                        AssetBundleRequest request = ab.LoadAssetAsync(names[i], type);
        //                        await request;
        //                        obj = request.asset;
        //                    }
        //                    else
        //                    {
        //                        AssetBundleRequest request = ab.LoadAssetAsync(names[i]);
        //                        await request;
        //                        obj = request.asset;
        //                    }
        //                    break;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            //默认加载第一个同类型资源
        //            Object[] objs;
        //            if(type != null)
        //            {
        //                AssetBundleRequest request = ab.LoadAllAssetsAsync(type);
        //                yield return request;
        //                objs = request.allAssets;
        //            }
        //            else
        //            {
        //                AssetBundleRequest request = ab.LoadAllAssetsAsync();
        //                yield return request;
        //                objs = request.allAssets;
        //            }

        //            if (objs.Length > 0)
        //                obj = objs[0];
        //        }
        //    }

        //     return obj;
        //}

        /// <summary>
        /// 从bundle中加载资源对象
        /// </summary>
        /// <param name="file"></param>
        /// <param name="type"></param>
        /// <param name="unload">加载完对象后是否卸载bundle包</param>
        /// <param name="assetName"></param>
        /// <returns></returns>
        public Object LoadAssetFromBundleFile(string file,Type type = null,bool unload= true,string assetName = null)
        {
            file = file.ToLower();
            AssetBundle ab = LoadBundleFromFile(file);
            if(ab == null)
            {
                LogTool.LogError("load bundle failed:{0}!", file);
                return null;
            }

            Object obj = LoadAssetFromBundle(ab,type,assetName);

            if (unload)
                UnLoadAssetsFromCache(file);
            return null;
        }

        public Object LoadAssetFromBundle(AssetBundle ab,Type type = null,string assetName = null)
        {
            Object obj = null;
            if(ab!= null)
            {
                if(!string.IsNullOrEmpty(assetName))
                {
                    //ab 包里面所有资源的信息
                    string[] names = ab.GetAllAssetNames();
                    for (int i = 0; i < names.Length; i++)
                    {
                        //名称相同
                        if(names[i].IndexOf(assetName.ToLower()) != -1)
                        {
                            if (type != null)
                                obj = ab.LoadAsset(names[i], type);
                            else
                                obj = ab.LoadAsset(names[i]);
                            break;
                        }
                    }   
                }
                else
                {
                    //名称传空 默认给获取ab包内对应类型的第一个资源， 因为有的ab包只有一个资源
                    //或者不同的单个种类资源
                    Object[] objs;
                    if (type != null)
                        objs = ab.LoadAllAssets(type);
                    else
                        objs = ab.LoadAllAssets();
                    if (objs.Length > 0)
                        obj = objs[0];
                }
            }

            return obj;
        }

        /// <summary>
        /// 加载bundle包
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public AssetBundle LoadBundleFromFile(string file)
        {
            file = file.ToLower();
            //如果缓存中有 直接返回ab
            if (mCacheAssets.TryGetValue(file, out var node))
                return node.ab;

            //根据不同的平台获取对应的资源全路径
            string path = PlatformInterface.Inst.GetBundlePath(string.Format("{0}{1}", file, ABExtension), out ulong offset);

            if(mDependencies.TryGetValue(file,out var deps))
            {
                //依赖资源的ab包也需要加载 不然会丢失资源
                foreach (var dep in deps)
                {
                    LoadBundleFromFile(dep);
                }
            }

            AssetBundle ab;
            //判断是否存在该路径文件
            if(File.Exists(path))
            {
                //从第几个字节开始读取
                if (offset > 0)
                    ab = AssetBundle.LoadFromFile(path, 0, offset);
                else
                    ab = AssetBundle.LoadFromFile(path);
                CacheAssetBundle(file,ab);
                return ab;
            }
            //如果没有该路径 那么将当前路径的一些缓存信息给移除掉
            UnLoadAssetsFromCache(file);
            return null;
        }

        /// <summary>
        /// 缓存ab包
        /// </summary>
        /// <param name="file"></param>
        /// <param name="ab"></param>
        public void CacheAssetBundle(string file,AssetBundle ab)
        {
            //引用计数  +1
            if (mCacheAssets.TryGetValue(file, out AssetNode node))
                node.count += 1;
            else
                mCacheAssets.Add(file, new AssetNode(ab, 1));
        }

        /// <summary>
        /// 从缓存中移除资源
        /// </summary>
        /// <param name="abFile"></param>
        /// <param name="clean">是否强制移除所有已经加载的obj</param>
        public void UnLoadAssetsFromCache(string abFile,bool clean = false)
        {
            abFile = abFile.ToLower();

            if(mDependencies.TryGetValue(abFile,out var deps))
            {
                //获取依赖项 移除依赖项的所有依赖 递归
                foreach (var dep in deps)
                {
                    UnLoadAssetsFromCache(dep,clean);
                }
            }

            //移除资源缓存
            if(mCacheAssets.TryGetValue(abFile,out var node))
            {
                node.count -= 1;
                //计数小于0
                if (node.count <= 0)
                {
                    node.ab.Unload(clean);
                    mCacheAssets.Remove(abFile);
                }
            }
        }

       
    }
}
