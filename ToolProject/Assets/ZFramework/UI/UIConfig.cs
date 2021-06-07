using System;
namespace ZFramework.UI
{
    public partial class UIManager
    {
        private DictBox<string, UIData> uiDatas = new DictBox<string, UIData>();

        private void InitUIData()
        {

        }

        public UIData GetUIData(string name)
        {
            if (uiDatas.ContainKey(name))
                return uiDatas[name];
            return null;
        }

        //private UIData AddUI(string package,string name,string title = null)
        //{

        //}
    }

    public class UIData
    {
        public UIData(string name,string package)
        {
            this.name = name;
            this.package = package;
            resource = name;
        }

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

        public UIData SetFullScreen(bool value) { isFullScreen = value;return this; }

        public UIData SetModal(bool value) { hideBelow = !value;isModal = value;
            layer = LayerEnum.Cover;return this;
        }

        public UIData SetLayer(LayerEnum value) { layer = value;return this; }

        public UIData SetResource(string value) { resource = value;return this; }

        public UIData SetHideBelow(bool value) { hideBelow = value;return this; }

        public UIData SetRoot(bool value)
        {
            isRoot = value;
            if (value)
                isFullScreen = true;isModal = false;
            return this;
        }

        public UIData AddSound()
        {

            return this;
        }
    }
}