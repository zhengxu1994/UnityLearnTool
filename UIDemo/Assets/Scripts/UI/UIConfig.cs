using System;
namespace ZFramework.UI
{
    public partial class UIManager
    {
        private DictBox<string, UIData> uiDatas = new DictBox<string, UIData>();

        private void InitUIData()
        {
            AddUI("Login", "UILogin").SetRoot(true);
            AddUI("Main", "MainUI", "", CommonTop.CtrStateId.main).SetRoot(true);
        }

        public UIData GetUIData(string name)
        {
            if (uiDatas.ContainKey(name))
                return uiDatas[name];
            return null;
        }

        private UIData AddUI(string package, string name, string title = null, CommonTop.CtrStateId ctrState = CommonTop.CtrStateId.normal)
        {
            UIData data = new UIData(name, package);
            if (title != null)
                data.topInfo = new TopInfo(name, title, ctrState);
            uiDatas[name] = data;
            return data;
        }
    }

    public class UIData
    {
        public UIData(string name, string package)
        {
            this.name = name;
            this.package = package;
            resource = name;
        }

        public TopInfo topInfo;

        public bool isRoot { private set; get; } = false;

        public bool isModal { private set; get; } = false;

        public bool isFullScreen { get; private set; } = false;

        public bool hideBelow { get; private set; } = true;

        public LayerEnum layer { get; private set; } = LayerEnum.UI;

        public string name { get; private set; } = "";

        public string package { get; private set; } = "";

        public string resource { get; private set; } = "";

        public string openSound { get; private set; }

        public string closeSound { get; private set; }

        public UIData SetFullScreen(bool value) { isFullScreen = value; return this; }

        public UIData SetModal(bool value) { hideBelow = !value; isModal = value;
            layer = LayerEnum.Cover; return this;
        }

        public UIData SetLayer(LayerEnum value) { layer = value; return this; }

        public UIData SetResource(string value) { resource = value; return this; }

        public UIData SetHideBelow(bool value) { hideBelow = value; return this; }

        public UIData SetRoot(bool value)
        {
            isRoot = value;
            if (value)
                isFullScreen = true; isModal = false;
            return this;
        }

        public UIData AddSound()
        {

            return this;
        }
    }

    public class TopInfo
    {
        public string panelName;
        private string titleKey;

        public string title { get => titleKey; }

        public ListBox<Resource> resources = new ListBox<Resource>();
        public CommonTop.CtrStateId ctr_state = CommonTop.CtrStateId.normal;

        public TopInfo(string panel,string title,CommonTop.CtrStateId page)
        {
            panelName = panel;
            titleKey = title;
            ctr_state = page;

            resources.Add(new Resource(ResourceType.gem));
            resources.Add(new Resource(ResourceType.coin));
            resources.Add(new Resource(ResourceType.food));
        }
    }

    public enum ResourceType
    {
        gem,
        coin,
        food,
    }

    public class Resource
    {
        public ResourceType type;
        public int id;

        public Resource(ResourceType type,int id = 0)
        {
            this.type = type;
            this.id = id;
        }
    }
}