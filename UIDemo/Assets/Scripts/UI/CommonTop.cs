using System;
namespace ZFramework.UI
{
    public class CommonTop : ExtensionBase
    {
        public enum CtrStateId
        {
            main = 0,
            normal = 1,
            shop = 2,
            battle= 3
        }

        public void SetPanelInfo(TopInfo topInfo,bool showAni)
        {
            string name = topInfo.panelName;
            string tilte = topInfo.title;
            bool isRoot = false;
            UIData config = UIManager.Inst.GetUIData(name);

            if (config != null)
                isRoot = config.isRoot;
            //设置commomTop信息
        }

        public void SetTitle(string title)
        {

        }

        public override void OnCreate()
        {
             
        }
    }
}