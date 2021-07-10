using System;
using UnityEngine;

namespace ZFramework
{
    public class PlatformAndroid : PlatformInterface
    {
#if UNITY_ANDROID

        private string writeablePath = null;

        private AndroidJavaObject ajo = null;

        //初始化一袭诶sdk常量，避免调用插件，提高效率
        private bool platformIniting = false;

        private bool platformInited = false;

        private bool logining = false;
        private bool logined = false;

        private int platformId = 0;
        private string platformName;
        private string subPackageTag;

        private bool isPad = false;

        protected override void Init()
        {
            writeablePath = Application.persistentDataPath;//持久化路径
            //如果持久化路径不存在,那么读取其他的持久化路径
            if (string.IsNullOrEmpty(writeablePath))
                writeablePath = PlatformUtil.persistentDataPath;
            InitPlugin();
        }

        private void InitPlugin()
        {

        }

        public override void Release()
        {
        }

        public override string GetRelatedPath(string fullPath)
        {
            fullPath = StandardlizePath(fullPath);
            string[] sArray = fullPath.Split(new string[] { "/" }, StringSplitOptions.None);
            if (sArray.Length > 0)
            {
                fullPath = sArray[sArray.Length - 1];
            }
            return fullPath;
        }

        /// <summary>
        /// 获取apk包内除了bundle以外的文件
        /// </summary>
        /// <param name="relativePath"></param>
        /// <returns></returns>
        public override string GetFilePath(string relativePath)
        {
            
        }

        public override string GetBundlePath(string relativePath, out ulong offset)
        {
            offset = 0;
            return string.Empty;
        }
               
#endif
    }

}
