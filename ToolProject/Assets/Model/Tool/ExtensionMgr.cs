using System;
using FairyGUI;
using ZFramework.UI;

namespace ZFramework
{
    internal static class ExtUtil
    {
        public static T Cast<T>(GObject obj) where T : ExtensionBase
        {
            T ret = null;
            if (obj.data != null)
                ret = obj.data as T;
            return ret;
        }

        public static T Cast<T>(EventContext obj) where T : GObject
        {
            T ret = null;
            if (obj.data != null)
                ret = obj.data as T;
            return ret;
        }
    }
}