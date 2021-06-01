using System;
using System.Collections.Generic;
namespace ZFramework
{
    public class NotifyParam
    {
        public Dictionary<string, int> intDatas = new Dictionary<string, int>();

        public Dictionary<string, string> strDatas = new Dictionary<string, string>();

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
    }
}