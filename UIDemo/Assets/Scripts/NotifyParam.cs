using System;
using System.Collections.Generic;
using ZFramework.Pool;

namespace ZFramework
{
    public class NotifyParam
    {
        public Dictionary<string, int> intDatas = new Dictionary<string, int>();

        public Dictionary<string, string> strDatas = new Dictionary<string, string>();

        public Dictionary<string, bool> boolDatas = new Dictionary<string, bool>();

        public void Int(string key, int value)
        {
            if (!intDatas.ContainsKey(key))
                intDatas.Add(key, value);
            intDatas[key] = value;
        }

        public int Int(string key)
        {
            if (intDatas.ContainsKey(key))
                return intDatas[key];
            return -1;
        }

        public void Str(string key, string value)
        {
            if (!strDatas.ContainsKey(key))
                strDatas.Add(key, value);
            strDatas[key] = value;
        }

        public string Str(string key)
        {
            if (strDatas.ContainsKey(key))
                return strDatas[key];
            return "";
        }

        public void Bool(string key, bool value)
        {
            if (!boolDatas.ContainsKey(key))
                boolDatas.Add(key, value);
            boolDatas[key] = value;
        }

        public bool Bool(string key)
        {
            if (boolDatas.ContainsKey(key))
                return boolDatas[key];
            return false;
        }

        private static TObjectPool<NotifyParam> pool = new TObjectPool<NotifyParam>(PoolAlloc,PoolFree,PoolDestroy);

        public string type;
        public static NotifyParam Create(string type ="")
        {
            NotifyParam evt = pool.Alloc();
            evt.type = type;
            return evt;
        }

        private static NotifyParam PoolAlloc()
        {
            NotifyParam evt = new NotifyParam();
            return evt;
        }

        private static void PoolFree(NotifyParam evt)
        {
            evt.intDatas?.Clear();
            evt.strDatas?.Clear();
            evt.boolDatas?.Clear();
        }

        private static void PoolDestroy(NotifyParam evt)
        {
            evt.intDatas = null;
            evt.strDatas = null;
            evt.boolDatas = null;
        }

        public NotifyParam Clear()
        {
            PoolFree(this);
            return this;
        }

        public void Destory()
        {
            pool.Free(this);
        }

        public void Dispose()
        {
            Destory();
        }


    }
}