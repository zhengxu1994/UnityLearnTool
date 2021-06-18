using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace ZFramework
{
    /// <summary>
    /// 红点manager
    /// </summary>
    internal class RedDotMgr
    {
        public static RedDotMgr Inst { get; private set; } = new RedDotMgr();

        public HashBox<string> NeedCheckBlockStr { get; private set; } = new HashBox<string>();

        private RedDotMgr()
        {
            //检车是否需要封闭的模块
            //TODO
            NeedCheckBlockStr.Add(RedDotConst.MainMenu);
        }

        private Hashtable objTable = new Hashtable();
        private RedDotNode root = new RedDotNode("", "");

        public void InitTree()
        {
            FieldInfo[] fields = typeof(RedDotConst).GetFields(BindingFlags.Public | BindingFlags.Public);
            RedDotConst consts = new RedDotConst();
            for (int i = 0; i < fields.Length; i++)
                if (fields[i].GetValue(consts) is string dotstr)
                    BuildTree(dotstr);
            string[] activities = RedDotConst.GetActivitiesDotStr();
            for (int i = 0; i < activities.Length; i++)
                BuildTree(activities[i]);

            //load excel data
            //InitTree
            //TODO
        }

        /// <summary>
        /// 树结构，已root为原始节点，一节一节的往下初始化节点信息
        /// </summary>
        /// <param name="dotStr"></param>
        private void BuildTree(string dotStr)
        {
            string[] arr = dotStr.Split(',');
            var node = root;
            for (int i = 0; i < arr.Length; i++)
            {
                if (!node.Contains(arr[i]))
                {
                    // 根据类型创建对应类型的红点类
                    var subNode = RedDotNodeFactory.ConstructNode(arr, i);
                    node.AddSubNode(subNode);
                    //if(NeedCheckBlockStr.Contains(subNode.DotStr))
                    //    subNode.SetBlock()
                }
            }
        }
    }

    internal class RedDotNodeFactory
    {
        public static RedDotNode ConstructNode(string[] arr,int i)
        {
            //TODO:
            return new RedDotNode("","");
        }
    }
}
            