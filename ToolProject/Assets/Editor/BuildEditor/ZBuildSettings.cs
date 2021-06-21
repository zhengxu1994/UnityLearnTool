using UnityEditor;
using UnityEngine;
namespace ZFramework
{
    [CreateAssetMenu]
    public class ZBuildSettings : ScriptableObject
    {
        public bool clearFolder = false;
        public bool isBuildExe = false;
        public bool isContainAB = false;
        public BuildType buildType = BuildType.Release;
        public BuildAssetBundleOptions buildAssetBundleOptions = BuildAssetBundleOptions.None;
    }
}

