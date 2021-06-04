using System;
using System.Collections.Generic;
namespace ZFramework
{
    //本地数据存储
    public class LocalStore
    {
        private static StoreData data;
        public static StoreData Data
        {
            get {
                if (data == null)
                    data = new StoreData();
                return data;
            }
        }
    }

    [Serializable]
    public class StoreData
    {
        private Dictionary<string, int> nums;
        private Dictionary<string, float> floats;
        private Dictionary<string, string> strs;
        private Dictionary<string, List<int>> lnums;
        private Dictionary<string, List<string>> lstrs;
        private Dictionary<string, Dictionary<int, int>> mmnums;
        private Dictionary<string, Dictionary<int, string>> mmstrs;
        private Dictionary<string, Dictionary<string, int>> msnums;
        private Dictionary<string, Dictionary<string, string>> msstrs;

        public void Init()
        {
            if (nums == null) nums = new Dictionary<string, int>();
            if (floats == null) floats = new Dictionary<string, float>();
        }
    }
}
