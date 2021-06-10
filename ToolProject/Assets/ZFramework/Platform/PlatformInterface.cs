using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZFramework.Platform
{
    public class PlatformInterface : Singleton<PlatformInterface>
    {
        public virtual string GetBundlePath(string relativePath,out ulong offset)
        {
            offset = 0;
            return string.Empty;
        }

        protected string StandardlizePath(string path)
        {
            string pathReplace = path.Replace(@"\", @"/");
            return pathReplace.ToLower();
        }
    }

    public class PlatformAndroid : PlatformInterface
    {
        public override string GetBundlePath(string relativePath, out ulong offset)
        {
            offset = 0;
            return string.Empty;
        }
    }

    public class PlatformEditor : PlatformInterface
    {
        private string bundlePath = "dist/pc";

        public override string GetBundlePath(string relativePath, out ulong offset)
        {
            offset = 0;
            return string.Format("{0}/../../{1}{2}", Application.dataPath, bundlePath,
                StandardlizePath(relativePath));
        }
    }
}
