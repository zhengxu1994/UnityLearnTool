using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZFramework
{
    public enum NetworkMode
    {
        Offline,
        WiFi,
        Mobile
    }

    public class PlatformInterface
    {
        public static PlatformInterface Inst { get; private set; } = null;

        public static readonly ulong BundleOffset = 35;

        public static bool IsMobile()
        {
            if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
                return true;
            return false;
        }

        public static bool IsAndroid()
        {
            if (Application.platform == RuntimePlatform.Android)
                return true;
            return false;
        }

        public static bool IsIos()
        {
            if (Application.platform == RuntimePlatform.IPhonePlayer)
                return true;
            return false;
        }

        public static bool IsEditor()
        {
            if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
                return true;
            return false;
        }

        public static bool IsPlayer()
        {
            if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.OSXPlayer)
                return true;
            return false;
        }

        protected string StandardlizePath(string path)
        {
            string pathReplace = path.Replace(@"\", @"/");
            return pathReplace.ToLower();
        }

        public static void Create()
        {
            switch (Application.platform)
            {
                case RuntimePlatform.Android:
                    Inst = new PlatformAndroid();
                    break;
                case RuntimePlatform.IPhonePlayer:
                    Inst = new PlatformIphone();
                    break;
                case RuntimePlatform.WindowsPlayer:
                case RuntimePlatform.OSXPlayer:
                    Inst = new PlatformPlayer();
                    break;
                case RuntimePlatform.WindowsEditor:
                case RuntimePlatform.OSXEditor:
                    Inst = new PlatformEditor();
                    break;
                default:
                    Inst = new PlatformEditor();
                    break;
            }
            Inst.Init();
        }

        protected virtual void Init()
        {
        }

        public virtual void Release()
        {
        }

        public virtual string GetFilePath(string relativePath)
        {
            return string.Empty;
        }

        public virtual string GetExternalStorageDirectory()
        {
            return string.Empty;
        }

        public virtual string GetBundlePath(string relativePath, out ulong offset)
        {
            offset = 0;
            return string.Empty;
        }

        public virtual string GetWritePath(string relativePath)
        {
            return string.Empty;
        }

        string versionPath = "newdata";
        public virtual string GetVersionPath()
        {
            return GetWritePath(versionPath);
        }

        public virtual int GetTotalMemory()
        {
            return 0;
        }

        public virtual int GetAvailableMemory()
        {
            return 1000;
        }

        public virtual string Install(string file)
        {
            return string.Empty;
        }

        public virtual int GetSDKPlatformId()
        {
            return 0;
        }

        public virtual string GetSDKPlatformName()
        {
            return "";
        }

        public virtual string GetSubPackageTag()
        {
            return "";
        }

        public virtual string GetStoreId()
        {
            return "";
        }

        public virtual NetworkMode GetNetWorkMode()
        {
            return NetworkMode.WiFi;
        }

        public virtual int GetTestStatus()
        {
            return 0;
        }

        public virtual void InitSDK()
        {

        }

        public virtual bool ExitGame()
        {
            return false;
        }

        public virtual void Login()
        {

        }

        public virtual bool IsSDKFinished()
        {
            return true;
        }

        public virtual void Logout()
        {

        }

        public virtual void SubmitUserInfo(string type, string roleid, string rolename, string level
            , int zoneid, string zonename, string createtime)
        {

        }

        public virtual void Play(string roleid, string rolename, string levle, string vip, string orderId
            , int serverid, string servername, int cash, string pid, string desc)
        { }

        public virtual string GetVersion()
        {
            return "";
        }
        /// <summary>
        /// 相对路径
        /// </summary>
        /// <param name="fullPath"></param>
        /// <returns></returns>
        public virtual string GetRelatedPath(string fullPath)
        {
            return "";
        }

        public virtual int GetLoginStatus()
        {
            return 1;
        }

        public virtual long GetUserId()
        {
            return 0;
        }

        public virtual string GetUserName()
        {
            //真机不能用这个值，会出现重复，可以考虑多个值拼接md5
            return UnityEngine.SystemInfo.deviceUniqueIdentifier;
        }

        public virtual string GetToken()
        {
            return "";
        }

        public virtual void CheckGuestAccount()
        {

        }

        public virtual void ChangeAccount()
        {

        }

        public virtual void StartAccountHome()
        {

        }

        public virtual void StartForum()
        {

        }

        public virtual void ShowToolBar()
        {

        }

        public virtual void HideToolBar()
        {

        }

        //是否为平板设备，用来判断显示pad-ui或者mini-ui
        //在ios上检测准确可靠。android不够准确，默认设置为手机版
        public virtual bool IsPad()
        {
            return true;
        }

        public virtual bool IsSpecialScreen()
        {
            return false;
        }

        public virtual bool IsHdVersion() { return false; }

        public virtual void StartWebView(string strURL)
        {

        }

        public virtual void OpenUrl(string url)
        {

        }

        public virtual void SendSMS(string strNumber, string strMsg)
        {

        }

        public virtual void SendWeibo(string content)
        {

        }

        public virtual bool SendWeChat(string content)
        {
            return false;
        }

        /// <summary>
        /// 是否处于自动更新状态
        /// </summary>
        /// <returns></returns>
        public virtual bool IsUpdateState()
        {
            return false;
        }

        //自动更新
        public virtual bool CheckVersion()
        {
            return true;
        }

        //获取进度条进度
        public virtual int GetProgress()
        {
            return 0;
        }

        public virtual int GetCurrentState()
        {
            return 0;
        }

        public virtual long GetMemInfo() { return 0; }

        public virtual string GetUDID()
        {
            return "";
        }
    }

    public class PlatformIphone: PlatformInterface
    {

    }

    public class PlatformPlayer: PlatformInterface
    {

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
